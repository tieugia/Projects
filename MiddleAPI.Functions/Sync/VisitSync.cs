using System;
using System.Runtime.Serialization;

namespace Sync.Entity
{
    [DataContract]
    public class VisitSync
    {
        [DataMember]
        public VisitDetailSync VisitDetail { get; set; }
        [DataMember]
        public JobDetailSync JobDetail { get; set; }
        [DataMember]
        public SiteDetailSync SiteDetail { get; set; }
        [DataMember]
        public CustomerDetailSync CustomerDetail { get; set; }
        [DataMember]
        public QuoteDetailSync QuoteDetail { get; set; }

        [DataMember]
        public Guid TenantId { get; set; }
    }
}
