using MiddleAPI.Extensions;
using MiddleAPI.Helpers;
using Sync.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddleAPI.Services
{
    public interface IAssetService
    {
        Task<bool> RequestAsync(string userId, int visitId, string token);
    }
    public class AssetService : BaseService, IAssetService
    {
        public AssetService(IMobileDbContext jlMobileDbContext)
            : base(jlMobileDbContext) { }

        public async Task<bool> RequestAsync(string userId, int visitId, string token)
        {
            var asset = await Helper.GetObjectByUserIdAndVisitIdAsync<SiteAssetDetailResponseSync>(userId, visitId, token, AppSettingUtil.Get("GetAssetEndpoint"));

            var assetResults = asset?.Results;

            var tenantId = asset.TenantId;

            if (assetResults != null && assetResults.Any())
            {
                await InsertOrUpdatePlantsForAssetAsync(assetResults, tenantId);

                foreach (var assetResult in assetResults)
                {
                    var assetTapsAndBrandsList = assetResult.AssetTapsAndBrandsList;
                    if (assetTapsAndBrandsList.Any())
                        await InsertOrUpdateAssetTapAndBrandsForAssetAsync(assetTapsAndBrandsList, tenantId);
                    var serviceTypeTaskList = assetResult.ServiceTypeTaskList;
                    if (serviceTypeTaskList.Any())
                        await InsertOrUpdateServiceTypeTasksForAssetAsync(serviceTypeTaskList, visitId, assetResult.AssetId, tenantId);
                }

                await InsertOrUpdateJob2plntsForAssetAsync(assetResults, tenantId);

                return await _jlMobileDbContext.SaveChangesAsync();
            }

            return true;
        }

        #region Job2plnts
        private Task InsertOrUpdateJob2plntsForAssetAsync(IEnumerable<AssetDetailSync> assetDetails, Guid tenantId)
        {
            var job2plnts = assetDetails.Map2Job2plnt(tenantId);
            var autoIds = job2plnts.Select(m => m.AutoId);
            return InsertOrUpdateListAsync(x => x.TenantId == tenantId && autoIds.Contains(x.AutoId), job2plnts, new string[] { "TenantId", "AutoId" });
        }
        #endregion

        #region Plants
        private Task InsertOrUpdatePlantsForAssetAsync(IEnumerable<AssetDetailSync> assetDetails, Guid tenantId)
        {
            var plants = assetDetails.Map(tenantId);
            var ids = plants.Select(m => m.Id);

            return InsertOrUpdateListAsync(x => x.TenantId == tenantId && ids.Contains(x.Id), plants);
        }
        #endregion

        #region AssetTapAndBrands
        private Task InsertOrUpdateAssetTapAndBrandsForAssetAsync(IEnumerable<PlantTapsAndBrands> plantTapsAndBrands, Guid tenantId)
        {
            var assetTapAndBrands = plantTapsAndBrands.Map(tenantId);
            var ids = assetTapAndBrands.Select(m => m.Id);

            return InsertOrUpdateListAsync(x => x.TenantId == tenantId && ids.Contains(x.Id), assetTapAndBrands);
        }
        #endregion

        #region ServiceTypeTasks
        private Task InsertOrUpdateServiceTypeTasksForAssetAsync(IEnumerable<AssetTaskItem> assetTaskItems, int visitId, int assetId, Guid tenantId)
        {
            var serviceTypeTasks = assetTaskItems.Map(visitId, assetId, tenantId);
            var ids = serviceTypeTasks.Select(m => m.Id);

            return InsertOrUpdateListAsync(x => x.TenantId == tenantId && ids.Contains(x.Id), serviceTypeTasks);
        }
        #endregion
    }
}
