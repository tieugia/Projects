using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiddleAPI.Entity
{
    [Table("CompanyForm", Schema = "SyncMobile")]
    public class CompanyForm : BaseEntity
    {
        public int FormId { get; set; }
        public bool IsRequired { get; set; }
        public bool IsRemoved { get; set; }
        public string ShowOnJsonData { get; set; }
        public Guid EntityId { get; set; }
        public int EntityType { get; set; }
        public bool Dirty { get; set; }
    }
}
