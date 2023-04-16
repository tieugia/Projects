using System;
using System.Runtime.Serialization;

namespace Sync.Entity
{
    [DataContract]
    public class CustomerDetailSync
    {
        [DataMember]
        public int AutoId { get; set; }
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string CustomerId { get; set; }
        [DataMember]
        public string Customer { get; set; }

        [DataMember]
        public Guid CustomerUniqueId { get; set; }

        [DataMember]
        public string Address1 { get; set; }
        [DataMember]
        public string Address2 { get; set; }
        [DataMember]
        public string Address3 { get; set; }
        [DataMember]
        public string Address4 { get; set; }
        [DataMember]
        public string PostCode { get; set; }
        [DataMember]
        public string Contact { get; set; }
        [DataMember]
        public string EmailAddress { get; set; }
        [DataMember]
        public string Mobile { get; set; }
        [DataMember]
        public string Telephone { get; set; }
        [DataMember]
        public string Notes { get; set; }
        [DataMember]
        public bool Warning1Used { get; set; }
        [DataMember]
        public string Warning1Comments { get; set; }
        [DataMember]
        public bool Warning2Used { get; set; }
        [DataMember]
        public string Warning2Comments { get; set; }
        [DataMember]
        public bool Warning3Used { get; set; }
        [DataMember]
        public string Warning3Comments { get; set; }
        [DataMember]
        public string SecondaryTelephone { get; set; }
        [DataMember]
        public int? AccountManagerId { get; set; }
        [DataMember]
        public string AccountManagerName { get; set; }
        [DataMember]
        public bool JobOrderNumberMandatory { get; set; }
    }
}
