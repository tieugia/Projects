using System;
using System.Runtime.Serialization;

namespace Sync.Entity
{
    public class QuoteHistoryListItemSync
    {
        [DataMember]
        public int AutoId { get; set; }
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public int? ParentJobAutoId { get; set; }
        [DataMember]
        public string Customer { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Owner { get; set; }
        [DataMember]
        public string OrderNumber { get; set; }
        [DataMember]
        public decimal Total { get; set; }
        [DataMember]
        public Guid CustomerUniqueId { get; set; }
        [DataMember]
        public int CustomerAutoID { get; set; }
        [DataMember]
        public Guid UniqueId { get; set; }
        [DataMember]
        public int AssignedUserId { get; set; }
        [DataMember]
        public double Value { get; set; }
        [DataMember]
        public double VAT { get; set; }
        [DataMember]
        public int SiteAutoId { get; set; }
        [DataMember]
        public DateTime DateLogged { get; set; }
        [DataMember]
        public string Status { get; set; }
    }
}
