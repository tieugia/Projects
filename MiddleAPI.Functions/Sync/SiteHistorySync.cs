using System;
using System.Runtime.Serialization;

namespace Sync.Entity
{
    [DataContract]
    public class SiteHistorySync
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string JobNumber { get; set; }
        [DataMember]
        public string JobDescription { get; set; }
        [DataMember]
        public string JobTypeDescription { get; set; }
        [DataMember]
        public string TaskTypeDescription { get; set; }
        [DataMember]
        public string StatusDescription { get; set; }
        [DataMember]
        public DateTime? DateComplete { get; set; }

        [DataMember]
        public int JobCategoryId { get; set; }

        [DataMember]
        public Guid JobCategoryUniqueId { get; set; }
        [DataMember]
        public string JobCategoryStringId { get; set; }

        [DataMember]
        public Guid JobUniqueId { get; set; }
        [DataMember]
        public string JobTypeStringId { get; set; }
        [DataMember]
        public int JobTypeAutoID { get; set; }
        [DataMember]
        public Guid JobTypeUniqueID { get; set; }
    }
}
