using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Sync.Entity
{
    [DataContract]
    public class Visit
    {
        [DataMember]
        public VisitDetail VisitDetail { get; set; }
        [DataMember]
        public JobDetail JobDetail { get; set; }
        [DataMember]
        public SiteDetail SiteDetail { get; set; }
        [DataMember]
        public CustomerDetail CustomerDetail { get; set; }
        [DataMember]
        public QuoteDetail QuoteDetail { get; set; }
    }

    [DataContract]
    public class VisitDetail
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int JobId { get; set; }
        [DataMember]
        public Guid JobUniqueId { get; set; }

        [DataMember]
        public string JobNumber { get; set; }
        [DataMember]
        public string VisitNumber { get; set; }
        [DataMember]
        public int StatusId { get; set; }
        [DataMember]
        public double? Mileage { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public DateTime StatusDate { get; set; }
        [DataMember]
        public DateTime StartDate { get; set; }
        [DataMember]
        public DateTime EndDate { get; set; }
        [DataMember]
        public IEnumerable<NoteDetail> Notes { get; set; }
        [DataMember]
        public IEnumerable<AssetDetail> Assets { get; set; }
        [DataMember]
        public IEnumerable<OtherVisit> OtherVisits { get; set; }
        [DataMember]
        public IEnumerable<TaskDetail> Tasks { get; set; }
        [DataMember]
        [Obsolete("This key FormRules will return empty data, it is used for supporting old mobile users having app versions below Android v1.0.127 & iOS v1.0.99.")]
        public FormDetail FormRules { get; set; }
        [DataMember]
        public FormDetail FormRule { get; set; }
        [DataMember]
        public bool IsPPMJob { get; set; }
        [DataMember]
        public bool SignatureRequired { get; set; }
        [DataMember]
        public bool IsSuspended { get; set; }
        [DataMember]
        public int? TeamId { get; set; }
        [DataMember]
        public bool IsTeamVisit { get; set; }
        public int EngineerAutoId { get; set; }
        [DataMember]
        public IEnumerable<TeamMemberDetail> TeamMembers { get; set; }
    }

    [DataContract]
    public class TeamMemberDetail
    {
        [DataMember]
        public string EngineerName { get; set; }
        [DataMember]
        public int EngineerId { get; set; }
        [DataMember]
        public bool IsLeader { get; set; }
    }

    [DataContract]
    public class JobDetail
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string JobId { get; set; }

        [DataMember]
        public string TvsJobId { get; set; }


        [DataMember]
        public int SiteId { get; set; }

        [DataMember]
        public int CustomerId { get; set; }
        [DataMember]
        public string JobOwner { get; set; }
        [DataMember]
        public string JobOwnerContact { get; set; }
        [DataMember]
        public string JobOwnerTelephone { get; set; }
        [DataMember]
        public string JobOwnerMobile { get; set; }
        [DataMember]
        public string JobDescription { get; set; }
        [DataMember]
        public string JobType { get; set; }
        [DataMember]
        public string JobDepositType { get; set; }
        [DataMember]
        public string TaskType { get; set; }
        [DataMember]
        public string Priority { get; set; }
        [DataMember]
        public string ResponseTime { get; set; }
        [DataMember]
        public string JeopardyTime1 { get; set; }
        [DataMember]
        public string JeopardyTime2 { get; set; }
        [DataMember]
        public string ResponseColour { get; set; }
        [DataMember]
        public string JeopardyTime1Colour { get; set; }
        [DataMember]
        public string JeopardyTime2Colour { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public string OrderNumber { get; set; }
        [DataMember]
        public string Telephone { get; set; }
        [DataMember]
        public string Contact { get; set; }
        [DataMember]
        public string AreaId { get; set; }
        [DataMember]
        public IEnumerable<NoteDetail> Notes { get; set; }
        [DataMember]
        public IEnumerable<JobVisit> Visits { get; set; }
        [DataMember]
        public IEnumerable<AttachmentDetail> Attachments { get; set; }
        [DataMember]
        public IEnumerable<formsLogbook> FormsLogbook { get; set; }

        [DataMember]
        public IEnumerable<JobFault> JobFaults { get; set; }
        [DataMember]
        public string AdditionalInformation { get; set; }
        [DataMember]
        public DateTime DateLogged { get; set; }
        [DataMember]
        public DateTime? DateComplete { get; set; }
        [DataMember]
        public DateTime? EstimatedAppointmentDate { get; set; }
        [DataMember]
        public string Supervisor { get; set; }

        [DataMember]
        public bool ConsiderCompanyHours { get; set; }

        [DataMember]
        public bool JobAlreadyAttended { get; set; }

        [DataMember]
        public string CustomReference { get; set; }
        [DataMember]
        public string SecondaryTelephone { get; set; }
        [DataMember]
        public int? PortalUserId { get; set; }
    }

    [DataContract]
    public class QuoteHistoryListItem
    {
        [DataMember]
        public int AutoId { get; set; }
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public int ParentJobAutoId { get; set; }
        [DataMember]
        public string Customer { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Owner { get; set; }
        [DataMember]
        public string OrderNumber { get; set; }
        [DataMember]
        public decimal Total { get; set; }
    }

    [DataContract]
    public class QuoteDetail
    {
        [DataMember]
        public int AutoId { get; set; }
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public int ParentJobAutoId { get; set; }
        [DataMember]
        public string ParentJobId { get; set; }
        [DataMember]
        public string Customer { get; set; }
        [DataMember]
        public string Site { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Owner { get; set; }
        [DataMember]
        public string OrderNumber { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public QuoteStatus Status { get; set; }
        [DataMember]
        public decimal Value { get; set; }
        [DataMember]
        public decimal VAT { get; set; }
        [DataMember]
        public decimal Total { get; set; }
        [DataMember]
        public IEnumerable<NoteDetail> Notes { get; set; }
        [DataMember]
        public IEnumerable<AttachmentDetail> Attachments { get; set; }
        [DataMember]
        public IEnumerable<QuoteLine> QuoteLines { get; set; }

    }

    [DataContract]
    public class QuoteLine
    {
        [DataMember]
        public int AutoId { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public double Quantity { get; set; }
        [DataMember]
        public decimal Price { get; set; }
        //[DataMember]
        //public string PriceString { get { return Price.ToString("C"); } }
        [DataMember]
        public decimal Total { get; set; }
        //[DataMember]
        //public string TotalString { get { return Total.ToString("C"); } }
        [DataMember]
        public double VatRate { get; set; }
        //[DataMember]
        //public string VatRateString { get { return String.Format("{0:P}", VatRate / 100); } }
    }

    [DataContract]
    public class OtherVisit
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string JobNumber { get; set; }
        [DataMember]
        public string EngineerName { get; set; }
        [DataMember]
        public int StatusId { get; set; }
        [DataMember]
        public string StatusDescription { get; set; }
        [DataMember]
        public DateTime? VisitStartDate { get; set; }
        [DataMember]
        public DateTime? VisitEndDate { get; set; }
        [DataMember]
        public string Notes { get; set; }
        [DataMember]
        public string RevisitReason { get; set; }
        [DataMember]
        public int EngineerAutoID { get; set; }
    }

    [DataContract]
    public class SiteDetail
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string SiteId { get; set; }
        [DataMember]
        public string Site { get; set; }
        [DataMember]
        public string Address1 { get; set; }
        [DataMember]
        public string Address2 { get; set; }
        [DataMember]
        public string Address3 { get; set; }
        [DataMember]
        public string Address4 { get; set; }
        [DataMember]
        public string PostCode { get; set; }
        [DataMember]
        public string Contact { get; set; }
        [DataMember]
        public string EmailAddress { get; set; }
        [DataMember]
        public string Mobile { get; set; }
        [DataMember]
        public string Telephone { get; set; }
        [DataMember]
        public bool Warning1Used { get; set; }
        [DataMember]
        public string Warning1Comments { get; set; }
        [DataMember]
        public bool Warning2Used { get; set; }
        [DataMember]
        public string Warning2Comments { get; set; }
        [DataMember]
        public bool Warning3Used { get; set; }
        [DataMember]
        public string Warning3Comments { get; set; }
        [DataMember]
        public IEnumerable<NoteDetail> Notes { get; set; }
        [DataMember]
        public IEnumerable<SiteHistory> History { get; set; }
        [DataMember]
        public IEnumerable<QuoteHistoryListItem> QuoteHistory { get; set; }
        [DataMember]
        public IEnumerable<SiteAsset> Assets { get; set; }
        [DataMember]
        public IEnumerable<AttachmentDetail> Attachments { get; set; }
        [DataMember]
        public IEnumerable<formsLogbook> FormsLogbook { get; set; }
        [DataMember]
        public string SecondaryTelephone { get; set; }
        [DataMember]
        public int? AccountManagerId { get; set; }
        [DataMember]
        public string AccountManagerName { get; set; }
    }

    [DataContract]
    public class JobFault
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string JobID { get; set; }
        [DataMember]
        public string FaultId { get; set; }
        [DataMember]
        public int FaultAutoId { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Notes { get; set; }
        [DataMember]
        public bool Status { get; set; }
        [DataMember]
        public string EngID { get; set; }
        [DataMember]
        public string EngName { get; set; }
        [DataMember]
        public DateTime ReportedOn { get; set; }
    }

    [DataContract]
    public class AttachmentDetail
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string FileName { get; set; }
        //public string URL { get { return Id.ToString(); } }
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
        public int NoteAutoId { get; set; }
        [DataMember]
        public Guid KeyGuidId { get; set; }
        [DataMember]
        public string AzureBlobReference { get; set; }
        [DataMember]
        public int EntityType { get; set; }
        [DataMember]
        public int KeyIntId { get; set; }
    }

    [DataContract]
    public class EngineerDocumentDetail
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
        public DateTime? ExpiryDate { get; set; }
        [DataMember]
        public Guid UniqueId { get; set; }
        [DataMember]
        public Guid DocumentId { get; set; }
        [DataMember]
        public string DocumentTypeDescription { get; set; }
    }

    [DataContract]
    public class formsLogbook
    {
        [DataMember]
        public string Uniquekey { get; set; }
        [DataMember]
        public string FormType { get; set; }
        [DataMember]
        public string EngineerName { get; set; }
        [DataMember]
        public string AssetNo { get; set; }
        [DataMember]
        public DateTime FormCompletionDate { get; set; }
        [DataMember]
        public string FileExtension { get; set; }
        [DataMember]
        public Guid UniqueId { get; set; }
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int JobEngID { get; set; }
        [DataMember]
        public string AzureBlobReference { get; set; }
        [DataMember]
        public string EngineerId { get; set; }
        [DataMember]
        public int JobAutoId { get; set; }
        [DataMember]
        public int PlantAutoInc { get; set; }
    }


    [DataContract]
    public class CustomerDetail
    {
        [DataMember]
        public int AutoId { get; set; }
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string CustomerId { get; set; }
        [DataMember]
        public string Customer { get; set; }
        [DataMember]
        public string Address1 { get; set; }
        [DataMember]
        public string Address2 { get; set; }
        [DataMember]
        public string Address3 { get; set; }
        [DataMember]
        public string Address4 { get; set; }
        [DataMember]
        public string PostCode { get; set; }
        [DataMember]
        public string Contact { get; set; }
        [DataMember]
        public string EmailAddress { get; set; }
        [DataMember]
        public string Mobile { get; set; }
        [DataMember]
        public string Telephone { get; set; }
        [DataMember]
        public string Notes { get; set; }
        [DataMember]
        public bool Warning1Used { get; set; }
        [DataMember]
        public string Warning1Comments { get; set; }
        [DataMember]
        public bool Warning2Used { get; set; }
        [DataMember]
        public string Warning2Comments { get; set; }
        [DataMember]
        public bool Warning3Used { get; set; }
        [DataMember]
        public string Warning3Comments { get; set; }
        [DataMember]
        public string SecondaryTelephone { get; set; }
        [DataMember]
        public int? AccountManagerId { get; set; }
        [DataMember]
        public string AccountManagerName { get; set; }
        [DataMember]
        public bool JobOrderNumberMandatory { get; set; }
    }

    [DataContract]
    public class NoteDetail
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Note { get; set; }
        [DataMember]
        public DateTime DateCreated { get; set; }
        [DataMember]
        public bool IsPrivate { get; set; }
        [DataMember]
        public string User { get; set; }
        public int UserID { get; set; }
        [DataMember]
        public bool IsFakeNote { get; set; }
        [DataMember]
        public Guid UniqueId { get; set; }
        [DataMember]
        public int KeyIntId { get; set; }
        [DataMember]
        public bool IsPrivateAndShowOnMobile { get; set; }
    }

    [DataContract]
    public class SiteHistory
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string JobNumber { get; set; }
        [DataMember]
        public string JobDescription { get; set; }
        [DataMember]
        public string JobTypeDescription { get; set; }
        [DataMember]
        public string TaskTypeDescription { get; set; }
        [DataMember]
        public string StatusDescription { get; set; }
        [DataMember]
        public DateTime? DateComplete { get; set; }
    }

    [DataContract]
    public class JobVisit
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string JobNumber { get; set; }
        [DataMember]
        public string RevisitReason { get; set; }
        [DataMember]
        public string EngineerName { get; set; }
        [DataMember]
        public int StatusId { get; set; }
        [DataMember]
        public string StatusDescription { get; set; }
        [DataMember]
        public DateTime? VisitStartDate { get; set; }
        [DataMember]
        public DateTime? VisitEndDate { get; set; }
        [DataMember]
        public string Notes { get; set; }
    }

    [DataContract]
    public class SiteAsset
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string PlantId { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Location { get; set; }
        [DataMember]
        public int Quantity { get; set; }
        [DataMember]
        public string SerialNumber { get; set; }
        [DataMember]
        public string EquipmentClass { get; set; }
        [DataMember]
        public string EquipmentClassId { get; set; }
        [DataMember]
        public DateTime? DateOfInstallation { get; set; }
        [DataMember]
        public bool IsSuspended { get; set; }
        //public string StatusDescription { get { return IsSuspended ? "Suspended" : "Active"; } }
        [DataMember]
        public DateTime? SuspendedOn { get; set; }
        [DataMember]
        public string AssetNo { get; set; }
        [DataMember]
        public string SystemId { get; set; }
        [DataMember]
        public string QRCode { get; set; }
        [DataMember]
        public bool RefrigerantTypeEnabled { get; set; }
        [DataMember]
        public Guid? RefrigerantTypeId { get; set; }
        [DataMember]
        public double RefrigerantCharge { get; set; }
        [DataMember]
        public IEnumerable<AttachmentDetail> Attachments { get; set; }
        [DataMember]
        public string Make { get; set; }
        [DataMember]
        public string Model { get; set; }
        [DataMember]
        public string SiteAssetGuidId { get; set; }
        [DataMember]
        public Guid? MasterId { get; set; }
        [DataMember]
        public Guid? LibraryAssetConditionId { get; set; }
    }

    [DataContract]
    public class Attachment
    {

        [DataMember]
        public byte[] fileContent { get; set; }
        [DataMember]
        public string fileName { get; set; }
        [DataMember]
        public string fileExtension { get; set; }
        [DataMember]
        public string azureBlobReference { get; set; }
    }

    [DataContract]
    public class ServiceTypeLines
    {
        [DataMember]
        public Guid ServiceTypeLineId { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public int Duration { get; set; }
        [DataMember]
        public int Frequency { get; set; }
        [DataMember]
        public int FrequencyPeriod { get; set; }
    }

    [DataContract]
    public class PlantTapsAndBrands
    {
        [DataMember]
        public Guid AssetId { get; set; }
        [DataMember]
        public Guid BrandId { get; set; }
        [DataMember]
        public Guid UniqueId { get; set; }
        [DataMember]
        public int TapNumber { get; set; }
    }

    [DataContract]
    public class AssetTask
    {
        [DataMember]
        public int JobAssetId { get; set; }
        [DataMember]
        public IEnumerable<AssetTaskItem> JobAssetTasks { get; set; }
    }

    [DataContract]
    public class AssetTaskItem
    {
        [DataMember]
        public Guid JobAssetTaskId { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public int ServiceOrder { get; set; }
        [DataMember]
        public bool? Completed { get; set; }
        [DataMember]
        public DateTime? DateCompleted { get; set; }
        [DataMember]
        public string CompletedBy { get; set; }
        [DataMember]
        public int Duration { get; set; }
        [DataMember]
        public string Frequency { get; set; }
        [DataMember]
        public int FrequencyPeriod { get; set; }
        [DataMember]
        public bool IsMandatory { get; set; }
        [DataMember]
        public Guid? ReasonId { get; set; }
    }


    [DataContract]
    public class AssetDetail
    {
        public AssetDetail()
        {
            ServiceTypeTaskList = new List<AssetTaskItem>();
        }
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
        public IEnumerable<AttachmentDetail> Attachments { get; set; }
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
        public Guid? LibraryAssetConditionId { get; set; }
        [DataMember]
        public string ReferenceNumber { get; set; }
        [DataMember]
        public int? ServiceOrder { get; set; }
    }

    [DataContract]
    public class TaskDetail
    {
        [DataMember]
        public Guid UniqueId { get; set; }
        [DataMember]
        public string JobId { get; set; }
        [DataMember]
        public string Task { get; set; }
        [DataMember]
        public string Summary { get; set; }
        [DataMember]
        public string SubTask { get; set; }
        [DataMember]
        public bool Complete { get; set; }
        [DataMember]
        public DateTime? DateCompleted { get; set; }
        [DataMember]
        public DateTime? DateAdded { get; set; }
        [DataMember]
        public bool IsMandatory { get; set; }
        [DataMember]
        public Guid? ReasonId { get; set; }
    }

    [DataContract]
    public class FormDetail
    {
        [DataMember]
        public bool Success { get; set; }
        [DataMember]
        public string Errors { get; set; }
        [DataMember]
        public List<FormRule> FormRules { get; set; }
    }

    [DataContract]
    public class FormRule
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public int FormId { get; set; }
        [DataMember]
        public bool IsRequired { get; set; }
        [DataMember]
        public bool IsRemoved { get; set; }
        [DataMember]
        public ShowOnRuleItem ShowOnRules { get; set; }
    }

    [DataContract]
    public class ShowOnRuleItem
    {
        [DataMember]
        public bool ShowOnAccept { get; set; }
        [DataMember]
        public bool ShowOnTravel { get; set; }
        [DataMember]
        public bool ShowOnArrival { get; set; }
        [DataMember]
        public bool ShowOnComplete { get; set; }
        [DataMember]
        public bool ShowOnAbandonTravel { get; set; }
        [DataMember]
        public bool ShowOnLeaveSite { get; set; }
        [DataMember]
        public bool ShowOnReject { get; set; }
        [DataMember]
        public bool ShowOnAbort { get; set; }
    }

    [DataContract]
    public class SiteAssetDetailResponse : PagedResponse<AssetDetail> { }

    [DataContract]
    public class AttachmentDetailResponse : PagedResponse<AttachmentDetail>
    {
        [DataMember]
        public DateTime? FromDate { get; set; }
        [DataMember]
        public DateTime? ToDate { get; set; }
        [DataMember]
        public Guid TenantId { get; set; }
    }

    [DataContract]
    public class EngineerDetail
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string StringId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public String EmailAddress { get; set; }

        [DataMember]
        public String QRCode { get; set; }

    }

    [DataContract]
    public enum QuoteStatus
    {
        A, //Awaiting Survey
        F, //Follow Up
        N, //New Quote
        O, //Ordered
        P, //Priced
        Q, //Quote Sent
        R, //Rejected
        S  //Survey Completed
    }
}
