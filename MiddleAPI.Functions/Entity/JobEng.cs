using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiddleAPI.Entity
{
    [Table("Jobeng", Schema = "SyncMobile")]
    public class JobEng : BaseEntity
    {
        public int JobAutoId { get; set; }
        public int EngineerAutoId { get; set; }
        public int JobEngID { get; set; }
        public int? StatusID { get; set; }
        public DateTime? VisitDateTime { get; set; }
        public DateTime? VisitEndDateTime { get; set; }
        public DateTime? StatusDate { get; set; }
        public bool? SignatureRequired { get; set; }
        public string? JobID { get; set; }
        public string? RevisitReason { get; set; }
        public bool Dirty { get; set; }
        public string? EngineerName { get; set; }
        public string? TeamId { get; set; }
        public bool? IsTeamVisit { get; set; }
        public double? Mileage { get; set; }
        public string? Notes { get; set; }
    }
}
