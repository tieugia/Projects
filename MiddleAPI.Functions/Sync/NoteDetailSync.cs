using System;
using System.Runtime.Serialization;

namespace Sync.Entity
{
    [DataContract]
    public class NoteDetailSync
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public Guid UniqueId { get; set; }
        [DataMember]
        public string Note { get; set; }
        [DataMember]
        public DateTime DateCreated { get; set; }
        [DataMember]
        public bool IsPrivate { get; set; }
        [DataMember]
        public string User { get; set; }
        [DataMember]
        public int UserID { get; set; }
        [DataMember]
        public bool IsFakeNote { get; set; }
        [DataMember]
        public bool IsPrivateAndShowOnMobile { get; set; }
    }
}
