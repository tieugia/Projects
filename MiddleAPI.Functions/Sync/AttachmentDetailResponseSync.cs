using System;
using System.Runtime.Serialization;

namespace Sync.Entity
{
    [DataContract]
    public class AttachmentDetailResponseSync : PagedResponse<AttachmentDetailSync>
    {
        [DataMember]
        public DateTime? FromDate { get; set; }
        [DataMember]
        public DateTime? ToDate { get; set; }
    }
}
