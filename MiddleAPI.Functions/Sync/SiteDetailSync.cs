using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Sync.Entity
{
    [DataContract]
    public class SiteDetailSync
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public Guid SiteUniqueId { get; set; }
        [DataMember]
        public string SiteId { get; set; }
        [DataMember]
        public string Site { get; set; }
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
        public IEnumerable<NoteDetailSync> Notes { get; set; }
        [DataMember]
        public IEnumerable<SiteHistorySync> History { get; set; }
        [DataMember]
        public IEnumerable<QuoteHistoryListItemSync> QuoteHistory { get; set; }
        [DataMember]
        public IEnumerable<SiteAsset> Assets { get; set; }
        [DataMember]
        public IEnumerable<AttachmentDetail> Attachments { get; set; }
        [DataMember]
        public IEnumerable<formsLogbook> FormsLogbook { get; set; }
        [DataMember]
        public string SecondaryTelephone { get; set; }
        [DataMember]
        public int? AccountManagerId { get; set; }
        [DataMember]
        public string AccountManagerName { get; set; }
        [DataMember]
        public string AreaId { get; set; }
    }
}
