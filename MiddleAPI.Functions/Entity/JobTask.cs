using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiddleAPI.Entity
{
    [Table("JobTask", Schema = "SyncMobile")]
	public class JobTask : BaseEntity  
	{
        [Column("ID")]
        public new Guid Id { get; set; }  
		public string JobId { get; set; }  
		public string Task { get; set; }  
		public string Summary { get; set; }  
		public string? SubTask { get; set; }  
		public bool Complete { get; set; }  
		public DateTime? DateCompleted { get; set; }  
		public int JobAutoId { get; set; }  
		public bool Dirty { get; set; }  
		public bool? IsMandatory { get; set; }  
		public Guid? ReasonId { get; set; }  
	}
}