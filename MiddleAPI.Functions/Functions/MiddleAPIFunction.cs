using AzureFunctions.Extensions.Middleware;
using AzureFunctions.Extensions.Middleware.Abstractions;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using MiddleAPI.Helpers;
using MiddleAPI.Models;
using MiddleAPI.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MiddleAPI.Functions
{
    public class MiddleAPIFunction
    {
        const string CONNECTION = "ServiceBusNamespace";
        const string MiddleAPIQueueName = "mobile-test";

        readonly IVisitService _visitService;
        readonly IAssetService _assetService;
        readonly IAttachmentService _attachmentService;
        readonly INonHttpMiddlewareBuilder _middlewareBuilder;

        public MiddleAPIFunction(
            IVisitService visitService,
            IAssetService assetService,
            IAttachmentService attachmentService,
            INonHttpMiddlewareBuilder middlewareBuilder)
        {
            _visitService = visitService;
            _assetService = assetService;
            _attachmentService = attachmentService;
            _middlewareBuilder = middlewareBuilder;
        }

        [FunctionName(nameof(Run))]
        public async Task Run([ServiceBusTrigger(MiddleAPIQueueName, Connection = CONNECTION)] RequestModel model, ILogger logger, ExecutionContext context)
        {
            var token = await GetBearerToken();
            var startTime = DateTime.Now;

            await _middlewareBuilder.ExecuteAsync(new NonHttpMiddleware(async () =>
            {
                await _visitService.RequestAsync(model.UserId, model.VisitId, token);
                await _assetService.RequestAsync(model.UserId, model.VisitId, token);
                await _attachmentService.RequestAsync(model.UserId, model.VisitId, token);

            }, context, (model.UserId, model.VisitId, token)));

            var timer = DateTime.Now - startTime;
            logger.LogInformation($"Function completed in {timer.Minutes} minutes and {timer.Seconds} seconds");
        }

        private async Task<string> GetBearerToken()
        {
            using var _httpClient = new HttpClient();

            var url = AppSettingUtil.IdentityServerEndpoint;

            var dict = new Dictionary<string, string>();
            dict.Add("client_id", AppSettingUtil.ClientId);
            dict.Add("client_secret", AppSettingUtil.ClientSecret);
            dict.Add("grant_type", AppSettingUtil.GrantType);
            dict.Add("scope", AppSettingUtil.Scope);

            var request = new HttpRequestMessage(HttpMethod.Post, url) { Content = new FormUrlEncodedContent(dict) };

            var response = await _httpClient.SendAsync(request);

            var model = JsonConvert.DeserializeObject<IdentityServerResponse>(await response.Content.ReadAsStringAsync());
            return model.AccessToken;
        }
    }
}
