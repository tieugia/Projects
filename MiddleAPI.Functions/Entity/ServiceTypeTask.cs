using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiddleAPI.Entity
{
    [Table("ServiceTypeTask", Schema = "SyncMobile")]
	public class ServiceTypeTask : BaseEntity  
	{
        [Column("ID")]
        public new Guid Id { get; set; }  
		public int VisitAutoId { get; set; }  
		public int AssetAutoId { get; set; }  
		public string? Description { get; set; }  
		public int? Duration { get; set; }  
		public int? Frequency { get; set; }  
		public int? FrequencyPeriod { get; set; }  
		public bool? IsCompleted { get; set; }  
		public DateTime? DateCompleted { get; set; }  
		public int? ServiceOrder { get; set; }  
		public bool? IsMandatory { get; set; }  
		public Guid? ReasonId { get; set; }  
		public bool Dirty { get; set; }  
	}
}