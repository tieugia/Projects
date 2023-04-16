using System.ComponentModel.DataAnnotations.Schema;

namespace MiddleAPI.Entity
{
    [Table("TeamMember", Schema = "SyncMobile")]
    public class TeamMember : BaseEntity
    {
        public int VisitId { get; set; }
        public int EngineerId { get; set; }
        public string? EngineerName { get; set; }
        public bool IsLeader { get; set; }
    }
}
