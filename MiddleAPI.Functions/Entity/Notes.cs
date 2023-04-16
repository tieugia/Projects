using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiddleAPI.Entity
{
    [Table("Notes", Schema = "SyncMobile")]
	public class Notes : BaseEntity  
	{
        [Column("ID")]
        public new Guid Id { get; set; }  
		public int AutoId { get; set; }  
		public string? Note { get; set; }  
		public DateTime DateCreated { get; set; }  
		public bool IsPrivate { get; set; }  
		public bool IsActive { get; set; }  
		public int EntityType { get; set; }  
		public int UserID { get; set; }  
		public int? KeyIntId { get; set; }  
		public bool Dirty { get; set; }  
		public bool? IsFakeNote { get; set; }  
		public string? UserFullName { get; set; }  
		public string? EngineerName { get; set; }  
	}
}