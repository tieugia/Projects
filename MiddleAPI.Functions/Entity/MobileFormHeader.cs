using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiddleAPI.Entity
{
    [Table("MobileFormHeader", Schema = "SyncMobile")]
	public class MobileFormHeader : BaseEntity  
	{
        [Column("ID")]
        public new Guid Id { get; set; }  
		public int AutoId { get; set; }  
		public string? PdaGuid { get; set; }  
		public string? FormType { get; set; }  
		public DateTime? FormDate { get; set; }  
		public int? JobEngID { get; set; }  
		public string? AzureBlobReference { get; set; }  
		public string? EngineerID { get; set; }  
		public int JobAutoId { get; set; }  
		public int? PlantAutoInc { get; set; }  
		public bool Dirty { get; set; }  
		public string? EngineerName { get; set; }  
	}
}