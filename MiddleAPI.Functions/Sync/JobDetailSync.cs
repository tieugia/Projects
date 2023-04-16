using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Sync.Entity
{
    [DataContract]
    public class JobDetailSync
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public Guid JobUniqueId { get; set; }

        [DataMember]
        public string JobId { get; set; }

        [DataMember]
        public string TvsJobId { get; set; }

        [DataMember]
        public int SiteId { get; set; }
        [DataMember]
        public Guid SiteUniqueId { get; set; }

        [DataMember]
        public int CustomerId { get; set; }
        [DataMember]
        public string JobOwner { get; set; }
        [DataMember]
        public string JobOwnerContact { get; set; }
        [DataMember]
        public string JobOwnerTelephone { get; set; }
        [DataMember]
        public string JobOwnerMobile { get; set; }
        [DataMember]
        public string JobDescription { get; set; }
        [DataMember]
        public string JobType { get; set; }
        [DataMember]
        public string JobDepositType { get; set; }
        [DataMember]
        public string TaskType { get; set; }
        [DataMember]
        public string Priority { get; set; }
        [DataMember]
        public string ResponseTime { get; set; }
        [DataMember]
        public string JeopardyTime1 { get; set; }
        [DataMember]
        public string JeopardyTime2 { get; set; }
        [DataMember]
        public string ResponseColour { get; set; }
        [DataMember]
        public string JeopardyTime1Colour { get; set; }
        [DataMember]
        public string JeopardyTime2Colour { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public string OrderNumber { get; set; }
        [DataMember]
        public string Telephone { get; set; }
        [DataMember]
        public string Contact { get; set; }
        [DataMember]
        public string AreaId { get; set; }
        [DataMember]
        public IEnumerable<NoteDetailSync> Notes { get; set; }
        [DataMember]
        public IEnumerable<JobVisitSync> Visits { get; set; }
        [DataMember]
        public IEnumerable<AttachmentDetail> Attachments { get; set; }
        [DataMember]
        public IEnumerable<formsLogbook> FormsLogbook { get; set; }

        [DataMember]
        public IEnumerable<JobFault> JobFaults { get; set; }
        [DataMember]
        public string AdditionalInformation { get; set; }
        [DataMember]
        public DateTime DateLogged { get; set; }
        [DataMember]
        public DateTime? DateComplete { get; set; }
        [DataMember]
        public DateTime? EstimatedAppointmentDate { get; set; }
        [DataMember]
        public string Supervisor { get; set; }

        [DataMember]
        public bool ConsiderCompanyHours { get; set; }

        [DataMember]
        public bool JobAlreadyAttended { get; set; }

        [DataMember]
        public string CustomReference { get; set; }
        [DataMember]
        public string SecondaryTelephone { get; set; }
        [DataMember]
        public int? PortalUserId { get; set; }
        [DataMember]
        public string JobCategoryId { get; set; }

        [DataMember]
        public Guid JobCategoryUniqueId { get; set; }
        [DataMember]
        public Guid PriorityUniqueId { get; set; }
        [DataMember]
        public int TypeOfJobId { get; set; }
        [DataMember]
        public int QuoteAutoId { get; set; }
        [DataMember]
        public string ContractID { get; set; }
        [DataMember]
        public string PriorityId { get; set; }
        [DataMember]
        public string JobStatusID { get; set; }
        [DataMember]
        public string JobTypeID { get; set; }
        [DataMember]
        public int JobTypeAutoId { get; set; }
        [DataMember]
        public Guid JobTypeUniqueId { get; set; }
        [DataMember]
        public string ExternalId { get; set; }
        [DataMember]
        public int? AssignedUserId { get; set; }
        [DataMember]
        public string TaskTypeID { get; set; }
    }
}
