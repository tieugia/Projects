using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiddleAPI.Entity
{
    [Table("FileLink", Schema = "SyncMobile")]
    public class FileLink : BaseEntity
    {
        public int FileLinkID { get; set; }
        public string? Description { get; set; }
        public string? FileName { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? BatchId { get; set; }
        public int? NoteId { get; set; }
        public Guid? KeyGuidId { get; set; }
        public bool IsPrivate { get; set; }
        public bool Active { get; set; }
        public string? AzureBlobReference { get; set; }
        public int EntityType { get; set; }
        public int? KeyIntId { get; set; }
        public bool Dirty { get; set; }
    }
}