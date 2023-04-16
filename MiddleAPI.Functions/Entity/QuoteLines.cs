using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiddleAPI.Entity
{
    [Table("QuoteLines", Schema = "SyncMobile")]
    public class QuoteLines : BaseEntity
    {
        [Column("ID")]
        public new Guid Id { get; set; }
        public int AutoId { get; set; }
        public int QuoteAutoId { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
        public double? Quantity { get; set; }
        public double? VatRate { get; set; }
        public double? Total { get; set; }
        public bool Dirty { get; set; }
    }
}
