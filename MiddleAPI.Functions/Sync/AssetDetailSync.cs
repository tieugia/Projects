using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Sync.Entity
{
    [DataContract]
    public class AssetDetailSync
    {
        [DataMember]
        public string ContractId { get; set; }
        [DataMember]
        public int PartAutoId { get; set; }
        [DataMember]
        public int AssetId { get; set; }
        [DataMember]
        public string PlantId { get; set; }
        [DataMember]
        public int? JobPlantId { get; set; }
        [DataMember]
        public int? JobPlantVisitId { get; set; }
        [DataMember]
        public string AssetDescription { get; set; }
        
        [DataMember]
        public string AssetNumber { get; set; }
        [DataMember]
        public string SystemId { get; set; }
        [DataMember]
        public string QRCode { get; set; }
        [DataMember]
        public string Location { get; set; }
        [DataMember]
        public string SerialNumber { get; set; }
        [DataMember]
        public string EquipmentId { get; set; }
        [DataMember]
        public string EquipmentClassId { get; set; }
        [DataMember]
        public DateTime? DateOfInstallation { get; set; }
        [DataMember]
        public DateTime? WarrantyExpiryDate { get; set; }
        [DataMember]
        public DateTime? LastServiceDate { get; set; }
        [DataMember]
        public string JobPlantNotes { get; set; }
        [DataMember]
        public string PlantNotes { get; set; }
        [DataMember]
        public string ActionRequiredNotes { get; set; }
        [DataMember]
        public string EquipmentClassDescription { get; set; }
        [DataMember]
        public Guid EquipmentClassUniqueId { get; set; }
        [DataMember]
        public int Quantity { get; set; }
        [DataMember]
        public bool Completed { get; set; }
        //public string Status { get { return Completed ? "Complete" : "Not Complete"; } }
        [DataMember]
        public DateTime? DateCompleted { get; set; }
        [DataMember]
        public string Freq { get; set; }
        [DataMember]
        public string SpecID { get; set; }
        [DataMember]
        public string ServiceSpecCode { get; set; }
        [DataMember]
        public string ServiceType { get; set; }
        [DataMember]
        public string ServiceDuration { get; set; }
        [DataMember]
        public string ServiceSpec { get; set; }
        [DataMember]
        public string ServiceNotes { get; set; }
        [DataMember]
        public int ForecastTime { get; set; }
        [DataMember]
        public bool RefrigerantTypeEnabled { get; set; }
        [DataMember]
        public Guid? RefrigerantTypeId { get; set; }
        [DataMember]
        public double RefrigerantCharge { get; set; }
        [DataMember]
        public IEnumerable<AttachmentDetailSync> Attachments { get; set; }
        [DataMember]
        public string JobAssetNotesHistory { get; set; }
        [DataMember]
        public string Make { get; set; }
        [DataMember]
        public string Model { get; set; }
        [DataMember]
        public Guid? PPMServiceTypeId { get; set; }
        [DataMember]
        public IEnumerable<AssetTaskItem> ServiceTypeTaskList { get; set; }
        [DataMember]
        public IEnumerable<PlantTapsAndBrands> AssetTapsAndBrandsList { get; set; }
        [DataMember]
        public string SiteAssetGuidId { get; set; }
        [DataMember]
        public Guid? MasterId { get; set; }
        [DataMember]
        public Guid? LibraryAssetConditionUniqueId { get; set; }
        [DataMember]
        public int? LibraryAssetConditionId { get; set; }
        [DataMember]
        public string ReferenceNumber { get; set; }
        [DataMember]
        public int? ServiceOrder { get; set; }
        [DataMember]
        public Guid UniqueId { get; set; }
        [DataMember]
        public int SiteAutoID { get; set; }
        [DataMember]
        public int AssetConditionId { get; set; }
        [DataMember]
        public Guid Job2plntUniqueId { get; set; }
        [DataMember]
        public Guid Job2plntSiteAssetUniqueId { get; set; }
        [DataMember]
        public int JobAutoID { get; set; }
        [DataMember]
        public DateTime? SuspendedOn { get; set; }
    }
}
