using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Sync.Entity
{
    [DataContract]    
    public class VisitDetailSync
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public Guid VisitUniqueId { get; set; }

        [DataMember]
        public int JobId { get; set; }
        [DataMember]
        public Guid JobUniqueId { get; set; }

        [DataMember]
        public string JobNumber { get; set; }
        [DataMember]
        public string VisitNumber { get; set; }
        [DataMember]
        public int StatusId { get; set; }
        [DataMember]
        public double? Mileage { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public DateTime StatusDate { get; set; }
        [DataMember]
        public DateTime StartDate { get; set; }
        [DataMember]
        public DateTime EndDate { get; set; }
        [DataMember]
        public IEnumerable<NoteDetailSync> Notes { get; set; }
        [DataMember]
        public IEnumerable<AssetDetail> Assets { get; set; }
        [DataMember]
        public IEnumerable<OtherVisitSync> OtherVisits { get; set; }
        [DataMember]
        public IEnumerable<TaskDetail> Tasks { get; set; }
        [DataMember]
        [Obsolete("This key FormRules will return empty data, it is used for supporting old mobile users having app versions below Android v1.0.127 & iOS v1.0.99.")]
        public FormDetail FormRules { get; set; }
        [DataMember]
        public FormDetail FormRule { get; set; }
        [DataMember]
        public bool IsPPMJob { get; set; }
        [DataMember]
        public bool SignatureRequired { get; set; }
        [DataMember]
        public bool IsSuspended { get; set; }
        [DataMember]
        public int? TeamId { get; set; }
        [DataMember]
        public bool IsTeamVisit { get; set; }
        [DataMember]
        public int EngineerAutoId { get; set; }
        [DataMember]
        public IEnumerable<TeamMemberDetail> TeamMembers { get; set; }
        [DataMember]
        public string RevisitReason { get; set; }
        [DataMember]
        public string EngineerName { get; set; }
    }
}
