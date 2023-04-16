using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiddleAPI.Entity
{
    [Table("JobCategory", Schema = "SyncMobile")]
    public class JobCategory : BaseEntity
    {
        [Column("ID")]
        public new Guid Id { get; set; }
        public string StringId { get; set; }
        public string? Description { get; set; }
        public bool Dirty { get; set; }
    }
}
