using System;
using System.ComponentModel.DataAnnotations;

namespace MiddleAPI.Entity
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public Guid TenantId { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public bool Deleted { get; set; }
        [Timestamp]
        public byte[] Version { get; set; }
    }
}
