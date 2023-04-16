using MiddleAPI.Entity;
using MiddleAPI.Extensions;
using MiddleAPI.Helpers;
using Sync.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddleAPI.Services
{
    public interface IVisitService
    {
        Task<bool> RequestAsync(string userId, int visitId, string token);
    }
    public class VisitService : BaseService, IVisitService
    {
        public VisitService(IMobileDbContext jlMobileDbContext)
            : base(jlMobileDbContext) { }

        public async Task<bool> RequestAsync(string userId, int visitId, string token)
        {
            var visit = await Helper.GetObjectByUserIdAndVisitIdAsync<VisitSync>(userId, visitId, token, AppSettingUtil.Get("GetVisitEndpoint"));

            if (visit is null)
            {
                return true;
            }

            var visitDetail = visit.VisitDetail;

            var tenantId = visit.TenantId;

            await InsertOrUpdateJobEngForVisitAsync(visitDetail, tenantId);

            var otherVisits = visitDetail?.OtherVisits;

            if (otherVisits != null && otherVisits.Any())
            {
                await InsertOrUpdateJobEngForOtherVisitAsync(otherVisits, tenantId);
            }

            var teamMembers = visitDetail?.TeamMembers;

            if (teamMembers != null && teamMembers.Any())
            {
                await InsertOrUpdateTeamMembersForVisitAsync(tenantId, visitDetail, teamMembers);
            }

            var jobDetail = visit.JobDetail;

            var formRules = visitDetail?.FormRule?.FormRules;

            if (jobDetail != null)
            {
                if (formRules != null && formRules.Any())
                {
                    await InsertOrUpdateFormRulesForVisitAsync(tenantId, jobDetail, formRules);
                }

                await InsertOrUpdateJobForVisitAsync(jobDetail, tenantId, visitDetail.IsSuspended);

                if (!string.IsNullOrWhiteSpace(jobDetail.PriorityId))
                {
                    await InsertOrUpdatePriorityForVisitAsync(jobDetail, tenantId);
                }

                if (!string.IsNullOrWhiteSpace(jobDetail.JobCategoryId))
                {
                    await InsertOrUpdateJobCategoryForVisitAsync(jobDetail, tenantId);
                }

                if (jobDetail.JobTypeUniqueId != Guid.Empty)
                {
                    await InsertOrUpdateJobCtlForVisitAsync(jobDetail, tenantId);
                }
            }

            var siteDetail = visit.SiteDetail;

            if (siteDetail != null)
            {
                await InsertOrUpdateContractForVisitAsync(siteDetail, tenantId);
            }

            var customerDetail = visit.CustomerDetail;

            if (customerDetail != null)
            {
                await InsertOrUpdateCustomerForVisitAsync(customerDetail, tenantId);
            }

            var quoteDetail = visit.QuoteDetail;

            if (quoteDetail != null)
            {
                await InsertOrUpdateQuoteForVisitAsync(quoteDetail, tenantId);

                var quoteLines = quoteDetail.QuoteLines;

                if (quoteLines != null && quoteLines.Any())
                {
                    await InsertOrUpdateQuoteLinesForVisitAsync(quoteLines, quoteDetail.AutoId, tenantId);
                }
            }

            var quoteHistories = siteDetail.QuoteHistory;

            if (siteDetail != null && siteDetail.QuoteHistory.Any())
            {
                await InsertOrUpdateQuoteHistoryForVisitAsync(quoteHistories, tenantId);
            }

            var notes = new List<Notes>();

            var visitDetailNotes = visitDetail?.Notes;

            if (visitDetailNotes != null && visitDetailNotes.Any())
            {
                notes.AddRange(visitDetailNotes.Map(tenantId, 4, visitDetail.Id));
            }

            var jobDetailNotes = jobDetail?.Notes;

            if (jobDetailNotes != null && jobDetailNotes.Any())
            {
                notes.AddRange(jobDetailNotes.Map(tenantId, 3, jobDetail.Id));
            }

            var siteDetailNotes = siteDetail?.Notes;

            if (siteDetailNotes != null && siteDetailNotes.Any())
            {
                notes.AddRange(siteDetailNotes.Map(tenantId, 2, siteDetail.Id));
            }

            var quoteDetailNotes = quoteDetail?.Notes;

            if (quoteDetailNotes != null && quoteDetailNotes.Any())
            {
                notes.AddRange(quoteDetailNotes.Map(tenantId, 24, quoteDetail.AutoId));
            }

            if (notes.Any())
            {
                await InsertOrUpdateNotesForVisitAsync(notes.ToArray(), tenantId);
            }

            var visitDetailTasks = visitDetail?.Tasks;

            if (visitDetailTasks != null && visitDetailTasks.Any())
            {
                await InsertOrUpdateJobTasksForVisitAsync(visitDetailTasks, jobDetail.Id, tenantId);
            }

            var fileLinks = new List<FileLink>();

            var jobDetailFileLinks = jobDetail?.Attachments;

            if (jobDetailFileLinks != null && jobDetailFileLinks.Any())
            {
                fileLinks.AddRange(jobDetailFileLinks.Map(tenantId));
            }

            var siteDetailFileLinks = siteDetail?.Attachments;

            if (siteDetailFileLinks != null && siteDetailFileLinks.Any())
            {
                fileLinks.AddRange(siteDetailFileLinks.Map(tenantId));
            }

            var quoteDetailFileLinks = quoteDetail?.Attachments;

            if (quoteDetailFileLinks != null && quoteDetailFileLinks.Any())
            {
                fileLinks.AddRange(quoteDetailFileLinks.Map(tenantId));
            }

            if (fileLinks.Any())
            {
                await InsertOrUpdateFileLinksForVisitAsync(fileLinks.ToArray(), tenantId);
            }

            var mobileFormHeaders = new List<MobileFormHeader>();

            var jobDetailFormsLogbooks = jobDetail?.FormsLogbook;

            if (jobDetailFormsLogbooks != null && jobDetailFormsLogbooks.Any())
            {
                mobileFormHeaders.AddRange(jobDetailFormsLogbooks.Map(tenantId));
            }

            var siteDetailFormsLogbooks = siteDetail?.FormsLogbook;

            if (siteDetailFormsLogbooks != null && siteDetailFormsLogbooks.Any())
            {
                mobileFormHeaders.AddRange(siteDetailFormsLogbooks.Map(tenantId));
            }

            if (mobileFormHeaders.Any())
            {
                var formHeadersDistinct = mobileFormHeaders.DistinctBy(m => m.Id).ToArray();
                await InsertOrUpdateMobileFormHeadersForVisitAsync(formHeadersDistinct, tenantId);
            }

            return await _jlMobileDbContext.SaveChangesAsync();
        }

        #region JobEng(s)
        private Task InsertOrUpdateJobEngForVisitAsync(VisitDetailSync visitDetail, Guid tenantId)
        {
            var jobEng = visitDetail.Map(tenantId);
            return InsertOrUpdateAsync(x => x.TenantId == tenantId && x.JobEngID == jobEng.JobEngID, jobEng);
        }

        private Task InsertOrUpdateJobEngForOtherVisitAsync(IEnumerable<OtherVisitSync> otherVisits, Guid tenantId)
        {
            var jobEngs = otherVisits.Map(tenantId);
            var jobEngIds = jobEngs.Select(j => j.JobEngID);

            return InsertOrUpdateListAsync(x => x.TenantId == tenantId && jobEngIds.Contains(x.JobEngID), jobEngs);
        }
        #endregion

        #region TeamMembers
        private Task InsertOrUpdateTeamMembersForVisitAsync(Guid tenantId, VisitDetailSync visitDetail, IEnumerable<TeamMemberDetail> teamMemberDetails)
        {
            var teamMembers = teamMemberDetails.Map(tenantId, visitDetail.Id);
            var visitIds = teamMembers.Select(m => m.VisitId);
            var engineerIds = teamMembers.Select(m => m.EngineerId);

            return InsertOrUpdateListAsync(x => x.TenantId == tenantId && visitIds.Contains(x.VisitId) && engineerIds.Contains(x.EngineerId), teamMembers, new string[] { "TenantId", "VisitId", "EngineerId" });
        }
        #endregion

        #region CompanyForms
        private Task InsertOrUpdateFormRulesForVisitAsync(Guid tenantId, JobDetailSync jobDetail, IEnumerable<FormRule> formRules)
        {
            var companyForms = formRules.Map(tenantId, jobDetail.JobUniqueId);
            var ids = companyForms.Select(c => c.Id);

            return InsertOrUpdateListAsync(x => x.TenantId == tenantId && ids.Contains(x.Id), companyForms);
        }
        #endregion

        #region Job
        private Task InsertOrUpdateJobForVisitAsync(JobDetailSync jobDetail, Guid tenantId, bool isSuspended)
        {
            var job = jobDetail.Map(tenantId, isSuspended);

            return InsertOrUpdateAsync(x => x.TenantId == tenantId && x.Id == job.Id, job);
        }
        #endregion

        #region Priority
        private Task InsertOrUpdatePriorityForVisitAsync(JobDetailSync jobDetail, Guid tenantId)
        {
            var priority = jobDetail.Map(tenantId);

            return InsertOrUpdateAsync(x => x.TenantId == tenantId && x.Id == priority.Id, priority);
        }
        #endregion

        #region JobCategory
        private Task InsertOrUpdateJobCategoryForVisitAsync(JobDetailSync jobDetail, Guid tenantId)
        {
            var jobCategory = jobDetail.Map2JobCategory(tenantId);

            return InsertOrUpdateAsync(x => x.TenantId == tenantId && x.Id == jobCategory.Id, jobCategory);
        }
        #endregion

        #region JobCtl
        private Task InsertOrUpdateJobCtlForVisitAsync(JobDetailSync jobDetail, Guid tenantId)
        {
            var jobCtl = jobDetail.Map2JobCtl(tenantId);
            return InsertOrUpdateAsync(x => x.TenantId == tenantId && x.Id == jobCtl.Id, jobCtl);
        }
        #endregion

        #region Contract
        private Task InsertOrUpdateContractForVisitAsync(SiteDetailSync siteDetail, Guid tenantId)
        {
            var contract = siteDetail.Map(tenantId);

            return InsertOrUpdateAsync(x => x.TenantId == tenantId && x.Id == contract.Id, contract);
        }
        #endregion

        #region Customer
        private Task InsertOrUpdateCustomerForVisitAsync(CustomerDetailSync customerDetail, Guid tenantId)
        {
            var customer = customerDetail.Map(tenantId);

            return InsertOrUpdateAsync(x => x.TenantId == tenantId && x.Id == customer.Id, customer);
        }
        #endregion

        #region Quote(s)
        private Task InsertOrUpdateQuoteForVisitAsync(QuoteDetailSync quoteDetail, Guid tenantId)
        {
            var quote = quoteDetail.Map(tenantId);

            return InsertOrUpdateAsync(x => x.TenantId == tenantId && x.Id == quote.Id, quote);
        }

        private Task InsertOrUpdateQuoteHistoryForVisitAsync(IEnumerable<QuoteHistoryListItemSync> quoteHistories, Guid tenantId)
        {
            var quotes = quoteHistories.Map(tenantId);
            var autoIds = quotes.Select(n => n.AutoId);
            return InsertOrUpdateListAsync(x => x.TenantId == tenantId && autoIds.Contains(x.AutoId), quotes);
        }
        #endregion

        #region QuoteLines
        private Task InsertOrUpdateQuoteLinesForVisitAsync(IEnumerable<QuoteLine> quoteLineItems, int quoteDetailAutoId, Guid tenantId)
        {
            var quoteLines = quoteLineItems.Map(tenantId, quoteDetailAutoId);
            var autoIds = quoteLines.Select(n => n.AutoId);
            return InsertOrUpdateListAsync(x => x.TenantId == tenantId && autoIds.Contains(x.AutoId), quoteLines, new string[] { "TenantId", "AutoId" });
        }
        #endregion

        #region Notes
        private Task InsertOrUpdateNotesForVisitAsync(Notes[] notes, Guid tenantId)
        {
            var autoIds = notes.Select(n => n.AutoId);
            return InsertOrUpdateListAsync(x => x.TenantId == tenantId && autoIds.Contains(x.AutoId), notes, new string[] { "TenantId", "AutoId" });
        }
        #endregion

        #region JobTasks
        private Task InsertOrUpdateJobTasksForVisitAsync(IEnumerable<TaskDetail> taskDetails, int jobDetailId, Guid tenantId)
        {
            var jobTasks = taskDetails.Map(tenantId, jobDetailId);
            var ids = jobTasks.Select(m => m.Id);

            return InsertOrUpdateListAsync(x => x.TenantId == tenantId && ids.Contains(x.Id), jobTasks);
        }
        #endregion

        #region FileLinks
        private Task InsertOrUpdateFileLinksForVisitAsync(IEnumerable<FileLink> fileLinks, Guid tenantId)
        {
            var ids = fileLinks.Select(f => f.Id);
            return InsertOrUpdateListAsync(x => x.TenantId == tenantId && ids.Contains(x.Id), fileLinks);
        }
        #endregion

        #region MobileFormHeaders
        private Task InsertOrUpdateMobileFormHeadersForVisitAsync(IEnumerable<MobileFormHeader> mobileFormHeaders, Guid tenantId)
        {
            var ids = mobileFormHeaders.Select(m => m.Id);
            return InsertOrUpdateListAsync(x => x.TenantId == tenantId && ids.Contains(x.Id), mobileFormHeaders);
        }
        #endregion
    }
}
