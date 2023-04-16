using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiddleAPI.Entity
{
    [Table("Plant", Schema = "SyncMobile")]
    public class Plant : BaseEntity
    {
        [Column("ID")]
        public new Guid Id { get; set; }
        public string StringId { get; set; }
        public int AutoInc { get; set; }
        public int SiteAutoId { get; set; }
        public string Description { get; set; }
        public string? AssetNo { get; set; }
        public string? Location { get; set; }
        public string? SerialNumber { get; set; }
        public string? EquipmentID { get; set; }
        public DateTime? DateOfInstallation { get; set; }
        public DateTime? PlantWarrantyExDate { get; set; }
        public string? Notes { get; set; }
        public int Quantity { get; set; }
        public string? SpecID { get; set; }
        public int? StockItemID { get; set; }
        public string? SystemId { get; set; }
        public string? EquipmentClassID { get; set; }
        public string? QRCode { get; set; }
        public bool? RefrigerantTypeEnabled { get; set; }
        public double? RefrigerantCharge { get; set; }
        public Guid? RefrigerantTypeId { get; set; }
        public string? Make { get; set; }
        public string? Model { get; set; }
        public string ContractID { get; set; }
        public Guid? MasterId { get; set; }
        public string? CustomReference { get; set; }
        public int? AssetConditionId { get; set; }
        public bool? IsSuspended { get; set; }
        public DateTime? SuspendedOn { get; set; }
        public bool Dirty { get; set; }
        public Guid? LibraryAssetConditionId { get; set; }
        public string? EquipmentClassDescription { get; set; }
        public DateTime? LastServiceDate { get; set; }
        public Guid? EquipmentClassUniqueId { get; set; }
    }
}