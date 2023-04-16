using System.ComponentModel.DataAnnotations.Schema;

namespace MiddleAPI.Entity
{
    [Table("Jobctl", Schema = "SyncMobile")]
    public class JobCtl : BaseEntity
    {
        public string StringId { get; set; }
        public int AutoId { get; set; }
        public string? Description { get; set; }
        public bool Dirty { get; set; }
    }
}
