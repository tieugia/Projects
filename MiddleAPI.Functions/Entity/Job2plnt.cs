using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiddleAPI.Entity
{
    [Table("Job2plnt", Schema = "SyncMobile")]
    public class Job2plnt : BaseEntity
    {
        public int AutoId { get; set; }
        public string? PlantNotes { get; set; }
        public string? ActionRequiredNotes { get; set; }
        public bool? Completed { get; set; }
        public DateTime? DateCompleted { get; set; }
        public int? Frequency { get; set; }
        public int? VisitId { get; set; }
        public int ForecastTime { get; set; }
        public int? PPMServiceDuration { get; set; }
        public Guid? PPMServiceTypeId { get; set; }
        public Guid SiteAssetUniqueId { get; set; }
        public int JobAutoId { get; set; }
        public int? AssetConditionId { get; set; }
        public bool Dirty { get; set; }
        public string? JobAssetNotesHistory { get; set; }
        public string? PPMServiceType { get; set; }
        public string? PPMServiceSpec { get; set; }
        public string? PPMServiceNotes { get; set; }
        public int? PPMServiceOrder { get; set; }
        public string? PPMServiceSpecCode { get; set; }
    }
}