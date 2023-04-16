using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Sync.Entity
{
    [DataContract]
    public class OtherVisitSync
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public Guid UniqueId { get; set; }
        [DataMember]
        public string VisitNumber { get; set; }

        [DataMember]
        public int JobId { get; set; }
        [DataMember]
        public Guid JobUniqueId { get; set; }
        [DataMember]
        public string JobNumber { get; set; }
        [DataMember]
        public string EngineerName { get; set; }
        [DataMember]
        public int StatusId { get; set; }
        [DataMember]
        public string StatusDescription { get; set; }
        [DataMember]
        public DateTime StatusDate { get; set; }
        [DataMember]
        public DateTime? VisitStartDate { get; set; }
        [DataMember]
        public DateTime? VisitEndDate { get; set; }
        [DataMember]
        public string RevisitReason { get; set; }
        [DataMember]
        public int EngineerAutoID { get; set; }
        [DataMember]
        public IEnumerable<NoteDetail> Notes { get; set; }
    }
}
