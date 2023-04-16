using System.ComponentModel.DataAnnotations.Schema;

namespace MiddleAPI.Entity
{
    [Table("Contract", Schema = "SyncMobile")]
    public class Contract : BaseEntity
    {
        public string StringId { get; set; }
        public int AutoId { get; set; }
        public string? Site { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? Address3 { get; set; }
        public string? Address4 { get; set; }
        public string? PostCode { get; set; }
        public string? Contact { get; set; }
        public string? EmailAddress { get; set; }
        public string? Mobile { get; set; }
        public string? Telephone { get; set; }
        public bool Warning1Used { get; set; }
        public string? Warning1Comments { get; set; }
        public bool Warning2Used { get; set; }
        public string? Warning2Comments { get; set; }
        public bool Warning3Used { get; set; }
        public string? Warning3Comments { get; set; }
        public string? AreaID { get; set; }
        public bool Dirty { get; set; }
        public string? SecondaryTelephone { get; set; }
        public int? AccountManagerId { get; set; }
        public string? AccountManagerName { get; set; }
    }
}
