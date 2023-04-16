using System;
using System.Runtime.Serialization;

namespace Sync.Entity
{
    [DataContract]
    public class AttachmentDetailSync
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string FileName { get; set; }
        [DataMember]
        public DateTime DateAdded { get; set; }
        [DataMember]
        public int AssetAutoIncId { get; set; }
        [DataMember]
        public Guid? BatchId { get; set; }
        [DataMember]
        public Guid UniqueId { get; set; }
        [DataMember]
        public Guid NoteId { get; set; }
        [DataMember]
        public string AzureBlobReference { get; set; }
        [DataMember]
        public int NoteAutoId { get; set; }
        [DataMember]
        public int KeyIntId { get; set; }
        [DataMember]
        public int EntityType { get; set; }
        [DataMember]
        public Guid KeyGuidId { get; set; }
    }
}
