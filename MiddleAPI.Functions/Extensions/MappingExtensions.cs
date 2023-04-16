using MiddleAPI.Entity;
using Newtonsoft.Json;
using Sync.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MiddleAPI.Extensions
{
    public static class MappingExtensions
    {
        #region JobEng
        public static JobEng Map(this VisitDetailSync visitDetail, Guid tenantId)
        {
            return new JobEng
            {
                Id = visitDetail.JobUniqueId,
                TenantId = tenantId,
                Deleted = false,
                JobAutoId = visitDetail.JobId,
                EngineerAutoId = visitDetail.EngineerAutoId,
                JobEngID = visitDetail.Id,
                StatusID = visitDetail.StatusId,
                VisitDateTime = visitDetail.StartDate,
                VisitEndDateTime = visitDetail.EndDate,
                StatusDate = visitDetail.StatusDate,
                SignatureRequired = visitDetail.SignatureRequired,
                JobID = visitDetail.JobNumber,
                RevisitReason = visitDetail.RevisitReason,
                EngineerName = visitDetail.EngineerName,
                TeamId = visitDetail.TeamId.ToString(),
                IsTeamVisit = visitDetail.IsTeamVisit,
                Mileage = visitDetail.Mileage
            };
        }

        public static JobEng[] Map(this IEnumerable<OtherVisitSync> otherVisitItems, Guid tenantId)
        {
            return otherVisitItems.Select(x => new JobEng
            {
                Id = x.UniqueId,
                TenantId = tenantId,
                Deleted = false,
                JobAutoId = x.JobId,
                EngineerAutoId = x.EngineerAutoID,
                JobEngID = x.Id,
                StatusID = x.StatusId,
                VisitDateTime = x.VisitStartDate,
                VisitEndDateTime = x.VisitEndDate,
                StatusDate = x.StatusDate,
                //SignatureRequired = x.SignatureRequired,
                JobID = x.JobNumber,
                RevisitReason = x.RevisitReason,
                EngineerName = x.EngineerName,
                Notes = string.Join(',', x.Notes.Select(n => n.Note))
            }).ToArray();
        }
        #endregion

        #region TeamMember
        public static TeamMember[] Map(this IEnumerable<TeamMemberDetail> teamMembers, Guid tenantId, int visitId)
        {
            return teamMembers.Select(x => new TeamMember
            {
                Id = Guid.NewGuid(),
                TenantId = tenantId,
                Deleted = false,
                VisitId = visitId,
                EngineerId = x.EngineerId,
                EngineerName = x.EngineerName,
                IsLeader = x.IsLeader
            }).ToArray();
        }
        #endregion

        #region CompanyForm
        public static CompanyForm[] Map(this IEnumerable<FormRule> formRules, Guid tenantId, Guid jobId)
        {
            return formRules.Select(x => new CompanyForm
            {
                Id = x.Id,
                TenantId = tenantId,
                Deleted = false,
                FormId = x.FormId,
                IsRequired = x.IsRequired,
                IsRemoved = x.IsRemoved,
                ShowOnJsonData = JsonConvert.SerializeObject(x.ShowOnRules),
                EntityId = jobId,
                EntityType = 3
            }).ToArray();
        }
        #endregion

        #region Job
        public static Job Map(this JobDetailSync jobDetail, Guid tenantId, bool isSuspended)
        {
            return new Job
            {
                Id = jobDetail.JobUniqueId,
                StringId = jobDetail.JobId,
                TenantId = tenantId,
                Deleted = false,
                AssignedUserId = jobDetail.AssignedUserId,
                CustomerAutoId = jobDetail.CustomerId,
                SiteAutoId = jobDetail.SiteId,
                AutoId = jobDetail.Id,
                PriorityID = jobDetail.PriorityId,
                Description = jobDetail.JobDescription,
                OrderNumber = jobDetail.OrderNumber,
                Telephone = jobDetail.Telephone,
                Status = jobDetail.JobStatusID,
                Contact = jobDetail.Contact,
                ExternalId = jobDetail.TvsJobId,
                TaskTypeID = jobDetail.TaskTypeID,
                DateLogged = jobDetail.DateLogged,
                DateComplete = jobDetail.DateComplete,
                EstAppDateTime = jobDetail.EstimatedAppointmentDate,
                JobDepositType = jobDetail.JobDepositType,
                CustomReference = jobDetail.CustomReference,
                JobTypeID = jobDetail.JobTypeID,
                ContractID = jobDetail.ContractID,
                QuoteAutoId = jobDetail.QuoteAutoId,
                IsSuspended = isSuspended,
                TypeOfJobId = jobDetail.TypeOfJobId,
                SecondaryTelephone = jobDetail.SecondaryTelephone,
                JobAlreadyAttended = jobDetail.JobAlreadyAttended,
                JobCategoryDescription = jobDetail.TaskType,
                Priority = jobDetail.Priority,
                ResponseBreachTime = int.Parse(jobDetail.ResponseTime),
                JeopardyTime1Colour = jobDetail.JeopardyTime1Colour,
                JeopardyTime2Colour = jobDetail.JeopardyTime2Colour,
                ResponseColour = jobDetail.ResponseColour,
                JeopardyTime1 = int.Parse(jobDetail.JeopardyTime1),
                JeopardyTime2 = int.Parse(jobDetail.JeopardyTime2),
                ConsiderCompanyHours = jobDetail.ConsiderCompanyHours,
                JobOwner = jobDetail.JobOwner,
                JobOwnerContact = jobDetail.JobOwnerContact
            };
        }
        #endregion

        #region Priority
        public static Priority Map(this JobDetailSync jobDetail, Guid tenantId)
        {
            return new Priority
            {
                Id = jobDetail.PriorityUniqueId,
                StringId = jobDetail.PriorityId,
                TenantId = tenantId,
                Deleted = false,
                Description = jobDetail.Priority,
                ResponseBreachTime = int.Parse(jobDetail.ResponseTime),
                JeopardyTime1Colour = jobDetail.JeopardyTime1Colour,
                JeopardyTime2Colour = jobDetail.JeopardyTime2Colour,
                ResponseColour = jobDetail.ResponseColour,
                JeopardyTime1 = int.Parse(jobDetail.JeopardyTime1),
                JeopardyTime2 = int.Parse(jobDetail.JeopardyTime2),
                ConsiderCompanyHours = jobDetail.ConsiderCompanyHours
            };
        }
        #endregion

        #region JobCategory
        public static JobCategory Map2JobCategory(this JobDetailSync jobDetail, Guid tenantId)
        {
            return new JobCategory
            {
                Id = jobDetail.JobCategoryUniqueId,
                StringId = jobDetail.JobCategoryId,
                TenantId = tenantId,
                Deleted = false,
                Description = jobDetail.TaskType
            };
        }
        #endregion

        #region JobCtl
        public static JobCtl Map2JobCtl(this JobDetailSync jobDetail, Guid tenantId)
        {
            return new JobCtl
            {
                Id = jobDetail.JobTypeUniqueId,
                Deleted = false,
                TenantId = tenantId,
                Description = jobDetail.JobType,
                StringId = jobDetail.JobTypeID,
                AutoId = jobDetail.JobTypeAutoId
            };
        }
        #endregion

        #region Contract
        public static Contract Map(this SiteDetailSync siteDetail, Guid tenantId)
        {
            return new Contract
            {
                Id = siteDetail.SiteUniqueId,
                StringId = siteDetail.SiteId,
                Deleted = false,
                TenantId = tenantId,
                AutoId = siteDetail.Id,
                Site = siteDetail.Site,
                Address1 = siteDetail.Address1,
                Address2 = siteDetail.Address2,
                Address3 = siteDetail.Address3,
                Address4 = siteDetail.Address4,
                PostCode = siteDetail.PostCode,
                Contact = siteDetail.Contact,
                EmailAddress = siteDetail.EmailAddress,
                Mobile = siteDetail.Mobile,
                Telephone = siteDetail.Telephone,
                Warning1Used = siteDetail.Warning1Used,
                Warning1Comments = siteDetail.Warning1Comments,
                Warning2Used = siteDetail.Warning2Used,
                Warning2Comments = siteDetail.Warning2Comments,
                Warning3Used = siteDetail.Warning3Used,
                Warning3Comments = siteDetail.Warning3Comments,
                AreaID = siteDetail.AreaId,
                SecondaryTelephone = siteDetail.SecondaryTelephone,
                AccountManagerId = siteDetail.AccountManagerId,
                AccountManagerName = siteDetail.AccountManagerName
            };
        }
        #endregion

        #region Customer
        public static Customer Map(this CustomerDetailSync customerDetail, Guid tenantId)
        {
            return new Customer
            {
                Id = customerDetail.CustomerUniqueId,
                StringId = customerDetail.CustomerId,
                Deleted = false,
                TenantId = tenantId,
                AutoLastID = customerDetail.Id,
                Name = customerDetail.Customer,
                Address1 = customerDetail.Address1,
                Address2 = customerDetail.Address2,
                Address3 = customerDetail.Address3,
                Address4 = customerDetail.Address4,
                PostCode = customerDetail.PostCode,
                Contact = customerDetail.Contact,
                EmailAddress = customerDetail.EmailAddress,
                MobileNumber = customerDetail.Mobile,
                Telephone = customerDetail.Telephone,
                Warning1Used = customerDetail.Warning1Used,
                Warning1Comments = customerDetail.Warning1Comments,
                Warning2Used = customerDetail.Warning2Used,
                Warning2Comments = customerDetail.Warning2Comments,
                Warning3Used = customerDetail.Warning3Used,
                Warning3Comments = customerDetail.Warning3Comments,
                SecondaryTelephone = customerDetail.SecondaryTelephone,
                AccountManagerId = customerDetail.AccountManagerId,
                AccountManagerName = customerDetail.AccountManagerName
            };
        }
        #endregion

        #region Quote
        // Visit.QuoteDetail
        public static Quote Map(this QuoteDetailSync quoteDetail, Guid tenantId)
        {
            return new Quote
            {
                Id = quoteDetail.UniqueId,
                StringId = quoteDetail.Id,
                AutoId = quoteDetail.AutoId,
                ParentJobID = null,
                Description = quoteDetail.Description,
                OrderNumber = quoteDetail.OrderNumber,
                Deleted = false,
                TenantId = tenantId,
                AssignedUserId = quoteDetail.AssignedUserId,
                CustomerAutoId = quoteDetail.CustomerAutoID,
                SiteAutoId = quoteDetail.SiteAutoId,
                Value = (double?)quoteDetail.Value,
                VAT = (double?)quoteDetail.VAT,
                DateLogged = quoteDetail.DateLogged,
                Status = quoteDetail.Status,
                Owner = quoteDetail.Owner
            };
        }

        // Visit.SiteDetail.QuoteHistory
        public static Quote[] Map(this IEnumerable<QuoteHistoryListItemSync> quoteDetails, Guid tenantId)
        {
            return quoteDetails.Select(x => new Quote
            {
                Id = x.UniqueId,
                StringId = x.Id,
                AutoId = x.AutoId,
                ParentJobID = x.ParentJobAutoId.ToString(),
                Description = x.Description,
                OrderNumber = x.OrderNumber,
                Deleted = false,
                TenantId = tenantId,
                AssignedUserId = x.AssignedUserId,
                CustomerAutoId = x.CustomerAutoID,
                SiteAutoId = x.SiteAutoId,
                Value = x.Value,
                VAT = x.VAT,
                DateLogged = x.DateLogged,
                Status = x.Status,
                Owner = x.Owner
            }).ToArray();
        }
        #endregion

        #region QuoteLines
        public static IEnumerable<QuoteLines> Map(this IEnumerable<QuoteLine> quoteLines, Guid tenantId, int quoteDetailAutoId)
        {
            return quoteLines.Select(x => new QuoteLines
            {
                Id = Guid.NewGuid(),
                Deleted = false,
                TenantId = tenantId,
                AutoId = x.AutoId,
                QuoteAutoId = quoteDetailAutoId,
                Description = x.Description,
                Price = (double?)x.Price,
                Quantity = x.Quantity,
                VatRate = x.VatRate,
                Total = (double?)x.Total
            });
        }
        #endregion

        #region Notes
        public static List<Notes> Map(this IEnumerable<NoteDetail> noteDetails, Guid tenantId, int entityType, int? keyIntId = null)
        {
            return noteDetails.Select(x => new Notes
            {
                Id = x.UniqueId,
                AutoId = x.Id,
                Deleted = false,
                TenantId = tenantId,
                Note = x.Note,
                DateCreated = x.DateCreated,
                IsPrivate = x.IsPrivate,
                IsActive = true,
                EntityType = entityType,
                UserID = -1,
                KeyIntId = keyIntId ?? x.KeyIntId,
                IsFakeNote = x.IsFakeNote,
                UserFullName = x.User
            }).ToList();
        }

        public static List<Notes> Map(this IEnumerable<NoteDetailSync> noteDetails, Guid tenantId, int entityType, int keyIntId)
        {
            return noteDetails.Select(x => new Notes
            {
                Id = x.UniqueId,
                AutoId = x.Id,
                Deleted = false,
                TenantId = tenantId,
                Note = x.Note,
                DateCreated = x.DateCreated,
                IsPrivate = x.IsPrivate,
                IsActive = true,
                EntityType = entityType,
                UserID = -1,
                KeyIntId = keyIntId,
                IsFakeNote = x.IsFakeNote,
                UserFullName = x.User
            }).ToList();
        }
        #endregion

        #region JobTask
        public static IEnumerable<JobTask> Map(this IEnumerable<TaskDetail> taskDetails, Guid tenantId, int jobAutolId)
        {
            return taskDetails.Select(x => new JobTask
            {
                Id = x.UniqueId,
                Deleted = false,
                TenantId = tenantId,
                JobId = x.JobId,
                Task = x.Task,
                Summary = x.Summary,
                SubTask = x.SubTask,
                Complete = x.Complete,
                DateCompleted = x.DateCompleted,
                JobAutoId = jobAutolId,
                IsMandatory = x.IsMandatory,
                ReasonId = x.ReasonId
            });
        }
        #endregion

        #region FileLink
        public static List<FileLink> Map(this IEnumerable<AttachmentDetail> attachmentDetails, Guid tenantId)
        {
            return attachmentDetails.Select(x => new FileLink
            {
                Id = x.UniqueId,
                FileLinkID = x.Id,
                Deleted = false,
                TenantId = tenantId,
                Description = x.Description,
                FileName = x.FileName,
                DateAdded = x.DateAdded,
                BatchId = x.BatchId,
                NoteId = x.NoteAutoId,
                KeyGuidId = x.KeyGuidId,
                IsPrivate = false,
                Active = true,
                AzureBlobReference = x.AzureBlobReference,
                EntityType = x.EntityType,
                KeyIntId = x.KeyIntId
            }).ToList();
        }

        public static List<FileLink> Map(this IEnumerable<AttachmentDetailSync> attachmentDetails, Guid tenantId)
        {
            return attachmentDetails.Select(x => new FileLink
            {
                Id = x.UniqueId,
                FileLinkID = x.Id,
                Deleted = false,
                TenantId = tenantId,
                Description = x.Description,
                FileName = x.FileName,
                DateAdded = x.DateAdded,
                BatchId = x.BatchId,
                NoteId = x.NoteAutoId,
                KeyGuidId = x.KeyGuidId,
                IsPrivate = false,
                Active = true,
                AzureBlobReference = x.AzureBlobReference,
                EntityType = x.EntityType,
                KeyIntId = x.KeyIntId
            }).ToList();
        }
        #endregion

        #region MobileFormHeader
        public static List<MobileFormHeader> Map(this IEnumerable<formsLogbook> formsLogbooks, Guid tenantId)
        {
            return formsLogbooks.Select(x => new MobileFormHeader
            {
                Id = x.UniqueId,
                AutoId = x.ID,
                PdaGuid = x.Uniquekey,
                FormType = x.FormType,
                FormDate = x.FormCompletionDate,
                JobEngID = x.JobEngID,
                AzureBlobReference = x.AzureBlobReference,
                EngineerID = x.EngineerId,
                JobAutoId = x.JobAutoId,
                PlantAutoInc = x.PlantAutoInc,
                Deleted = false,
                TenantId = tenantId,
                EngineerName = x.EngineerName
            }).ToList();
        }
        #endregion

        #region Plant
        public static IEnumerable<Plant> Map(this IEnumerable<AssetDetailSync> assetDetails, Guid tenantId)
        {
            return assetDetails.Select(x => new Plant
            {
                Id = x.UniqueId,
                StringId = x.PlantId,
                Deleted = false,
                TenantId = tenantId,
                AutoInc = x.AssetId,
                SiteAutoId = x.SiteAutoID,
                Description = x.AssetDescription,
                AssetNo = x.AssetNumber,
                Location = x.Location,
                SerialNumber = x.SerialNumber,
                EquipmentID = x.EquipmentId,
                DateOfInstallation = x.DateOfInstallation,
                PlantWarrantyExDate = x.WarrantyExpiryDate,
                Notes = x.PlantNotes,
                Quantity = x.Quantity,
                SpecID = x.SpecID,
                StockItemID = x.PartAutoId,
                SystemId = x.SystemId,
                EquipmentClassID = x.EquipmentClassId,
                QRCode = x.QRCode,
                RefrigerantTypeEnabled = x.RefrigerantTypeEnabled,
                RefrigerantCharge = x.RefrigerantCharge,
                RefrigerantTypeId = x.RefrigerantTypeId,
                Make = x.Make,
                Model = x.Model,
                ContractID = x.ContractId,
                MasterId = x.MasterId,
                CustomReference = x.ReferenceNumber,
                AssetConditionId = x.AssetConditionId,
                IsSuspended = false,
                LibraryAssetConditionId = x.LibraryAssetConditionUniqueId,
                EquipmentClassDescription = x.EquipmentClassDescription,
                LastServiceDate = x.LastServiceDate,
                EquipmentClassUniqueId = x.EquipmentClassUniqueId
            });
        }
        #endregion

        #region AssetTapAndBrand
        public static IEnumerable<AssetTapAndBrand> Map(this IEnumerable<PlantTapsAndBrands> plantTapsAndBrands, Guid tenantId)
        {
            return plantTapsAndBrands.Select(x => new AssetTapAndBrand
            {
                Id = x.UniqueId,
                Deleted = false,
                TenantId = tenantId,
                AssetId = x.AssetId,
                BrandId = x.BrandId,
                TapNumber = x.TapNumber
            });
        }
        #endregion

        #region Job2plnt
        public static IEnumerable<Job2plnt> Map2Job2plnt(this IEnumerable<AssetDetailSync> assetDetails, Guid tenantId)
        {
            return assetDetails
                .Where(x => x != null && x.JobPlantId != null)
                .Select(x => new Job2plnt
                {
                    Id = Guid.NewGuid(),
                    AutoId = (int)x.JobPlantId,
                    Deleted = false,
                    TenantId = tenantId,
                    PlantNotes = x.JobPlantNotes,
                    ActionRequiredNotes = x.ActionRequiredNotes,
                    Completed = x.Completed,
                    DateCompleted = x.DateCompleted,
                    Frequency = int.Parse(x.Freq),
                    VisitId = x.JobPlantVisitId,
                    ForecastTime = x.ForecastTime,
                    PPMServiceDuration = int.Parse(x.ServiceDuration),
                    PPMServiceTypeId = x.PPMServiceTypeId,
                    SiteAssetUniqueId = x.Job2plntSiteAssetUniqueId,
                    JobAutoId = x.JobAutoID,
                    AssetConditionId = x.AssetConditionId,
                    JobAssetNotesHistory = x.JobAssetNotesHistory,
                    PPMServiceType = x.ServiceType,
                    PPMServiceSpec = x.ServiceSpec,
                    PPMServiceNotes = x.ServiceNotes,
                    PPMServiceOrder = x.ServiceOrder,
                    PPMServiceSpecCode = x.ServiceSpecCode
                });
        }
        #endregion

        #region ServiceTypeTask
        public static IEnumerable<ServiceTypeTask> Map(this IEnumerable<AssetTaskItem> assetTaskItems, int visitAutoId, int assetAutoId, Guid tenantId)
        {
            return assetTaskItems
                .Where(x => x != null && x.JobAssetTaskId != Guid.Empty)
                .Select(x => new ServiceTypeTask
                {
                    Id = x.JobAssetTaskId,
                    Deleted = false,
                    VisitAutoId = visitAutoId,
                    AssetAutoId = assetAutoId,
                    Description = x.Description,
                    Duration = x.Duration,
                    Frequency = int.Parse(x.Frequency),
                    FrequencyPeriod = x.FrequencyPeriod,
                    IsCompleted = x.Completed,
                    DateCompleted = x.DateCompleted,
                    ServiceOrder = x.ServiceOrder,
                    IsMandatory = x.IsMandatory,
                    ReasonId = x.ReasonId,
                    TenantId = tenantId
                });
        }
        #endregion
    }
}
