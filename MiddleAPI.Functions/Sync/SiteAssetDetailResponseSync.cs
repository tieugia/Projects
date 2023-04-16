using System;
using System.Runtime.Serialization;

namespace Sync.Entity
{
    [DataContract]
    public class SiteAssetDetailResponseSync : PagedResponse<AssetDetailSync> 
    {
        [DataMember]
        public Guid TenantId { get; set; }
    }

}
