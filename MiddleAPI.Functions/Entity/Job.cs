using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiddleAPI.Entity
{
    [Table("Job", Schema = "SyncMobile")]
    public class Job : BaseEntity
    {
        public int? AssignedUserId { get; set; }
        public int CustomerAutoId { get; set; }
        public int SiteAutoId { get; set; }
        public int AutoId { get; set; }
        public string? PriorityID { get; set; }
        public string Description { get; set; }
        public string? OrderNumber { get; set; }
        public string? Telephone { get; set; }
        public string? Status { get; set; }
        public string? Contact { get; set; }
        public string? ExternalId { get; set; }
        public string? TaskTypeID { get; set; }
        public DateTime DateLogged { get; set; }
        public DateTime? DateComplete { get; set; }
        public DateTime? EstAppDateTime { get; set; }
        public string? JobDepositType { get; set; }
        public string? CustomReference { get; set; }
        public string JobTypeID { get; set; }
        public string ContractID { get; set; }
        public int? QuoteAutoId { get; set; }
        public bool IsSuspended { get; set; }
        public int TypeOfJobId { get; set; }
        public bool Dirty { get; set; }

        [Column("stringId")]
        public string StringId { get; set; }
        public string? SecondaryTelephone { get; set; }
        public bool? JobAlreadyAttended { get; set; }
        public string? JobCategoryDescription { get; set; }
        public string? Priority { get; set; }
        public int? ResponseBreachTime { get; set; }
        public string? JeopardyTime1Colour { get; set; }
        public string? JeopardyTime2Colour { get; set; }
        public string? ResponseColour { get; set; }
        public int? JeopardyTime1 { get; set; }
        public int? JeopardyTime2 { get; set; }
        public bool? ConsiderCompanyHours { get; set; }
        public string? JobOwner { get; set; }
        public string? JobOwnerContact { get; set; }
    }
}
