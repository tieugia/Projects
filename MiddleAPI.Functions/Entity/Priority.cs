using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiddleAPI.Entity
{
    [Table("Priority", Schema = "SyncMobile")]
    public class Priority : BaseEntity
    {
        [Column("ID")]
        public new Guid Id { get; set; }
        public string StringId { get; set; }
        public string? Description { get; set; }
        public int? ResponseBreachTime { get; set; }
        public string? JeopardyTime1Colour { get; set; }
        public string? JeopardyTime2Colour { get; set; }
        public string? ResponseColour { get; set; }
        public int? JeopardyTime1 { get; set; }
        public int? JeopardyTime2 { get; set; }
        public bool ConsiderCompanyHours { get; set; }
        public bool Dirty { get; set; }
    }
}
