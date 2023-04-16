using MiddleAPI.Extensions;
using MiddleAPI.Helpers;
using Sync.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddleAPI.Services
{
    public interface IAttachmentService
    {
        Task<bool> RequestAsync(string userId, int visitId, string token);
    }
    public class AttachmentService : BaseService, IAttachmentService
    {
        public AttachmentService(IMobileDbContext jlMobileDbContext) : base(jlMobileDbContext) { }

        public async Task<bool> RequestAsync(string userId, int visitId, string token)
        {
            var attachment = await Helper.GetObjectByUserIdAndVisitIdAsync<AttachmentDetailResponse>(userId, visitId, token, AppSettingUtil.Get("GetAttachmentEndpoint"));

            var attachmentResults = attachment.Results;
            if (attachment != null && attachmentResults.Any())
            {
                var tennantId = attachment.TenantId;
                await InsertOrUpdateFileLinksForAttachmentAsync(attachmentResults, tennantId);

                return await _jlMobileDbContext.SaveChangesAsync();
            }

            return true;
        }

        private Task InsertOrUpdateFileLinksForAttachmentAsync(IEnumerable<AttachmentDetail> attachmentDetails, Guid tenantId)
        {
            var fileLinks = attachmentDetails.Map(tenantId);
            var ids = fileLinks.Select(f => f.Id);
            return InsertOrUpdateListAsync(x => x.TenantId == tenantId && ids.Contains(x.Id), fileLinks);
        }
    }
}
