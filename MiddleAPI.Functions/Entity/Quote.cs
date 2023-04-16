using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiddleAPI.Entity
{
    [Table("Quote", Schema = "SyncMobile")]
    public class Quote : BaseEntity
    {
        [Column("ID")]
        public new Guid Id { get; set; }
        public string StringId { get; set; }
        public int AutoId { get; set; }
        public string? ParentJobID { get; set; }
        public string Description { get; set; }
        public string? OrderNumber { get; set; }
        public int? AssignedUserId { get; set; }
        public int CustomerAutoId { get; set; }
        public int SiteAutoId { get; set; }
        public string? Site { get; set; }
        public DateTime? DateLogged { get; set; }
        public string Status { get; set; }
        public double? Value { get; set; }
        public double? VAT { get; set; }
        public bool Dirty { get; set; }
        public string? Owner { get; set; }
    }

}
