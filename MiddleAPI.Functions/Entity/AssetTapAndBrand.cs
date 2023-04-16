using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiddleAPI.Entity
{
    [Table("AssetTapAndBrand", Schema = "SyncMobile")]
	public class AssetTapAndBrand : BaseEntity  
	{
        [Column("ID")]
        public new Guid Id { get; set; }  
		public Guid? AssetId { get; set; }  
		public Guid? BrandId { get; set; }  
		public int? TapNumber { get; set; }  
	}
}