using MiddleAPI.Entity;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;

namespace MiddleAPI
{
    public interface IMobileDbContext
    {
        #region Methods
        Task<bool> SaveChangesAsync();
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        void Dispose();
        #endregion

        public DbSet<JobEng> JobEngs { get; }
        public DbSet<TeamMember> TeamMembers { get; }
        public DbSet<CompanyForm> CompanyForms { get; }
        public DbSet<Job> Jobs { get; }
        public DbSet<Priority> Priorities { get; }
        public DbSet<JobCategory> JobCategories { get; }
        public DbSet<JobCtl> JobCtls { get; }
        public DbSet<Contract> Contracts { get; }
        public DbSet<Customer> Customers { get; }
        public DbSet<Quote> Quotes { get; }
        public DbSet<QuoteLines> QuoteLines { get; }
        public DbSet<Notes> Notes { get; }
        public DbSet<JobTask> JobTasks { get; }
        public DbSet<FileLink> FileLinks { get; }
        public DbSet<MobileFormHeader> MobileFormHeaders { get; }
        public DbSet<AssetTapAndBrand> AssetTapAndBrands { get; }
        public DbSet<ServiceTypeTask> ServiceTypeTasks { get; }
        public DbSet<Plant> Plants { get; }
        public DbSet<Job2plnt> Job2plnts { get; }
    }

    public class MobileDbContext : DbContext, IMobileDbContext
    {
        public MobileDbContext(string connectionString) : base(connectionString) { }

        #region Methods
        public new DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public new async Task<bool> SaveChangesAsync()
        {
            return await base.SaveChangesAsync() > 0;
        }
        #endregion

        public DbSet<JobEng> JobEngs { get; set; }
        public DbSet<TeamMember> TeamMembers { get; }
        public DbSet<CompanyForm> CompanyForms { get; }
        public DbSet<Job> Jobs { get; }
        public DbSet<Priority> Priorities { get; }
        public DbSet<JobCategory> JobCategories { get; }
        public DbSet<JobCtl> JobCtls { get; }
        public DbSet<Contract> Contracts { get; }
        public DbSet<Customer> Customers { get; }
        public DbSet<Quote> Quotes { get; }
        public DbSet<QuoteLines> QuoteLines { get; }
        public DbSet<Notes> Notes { get; }
        public DbSet<JobTask> JobTasks { get; }
        public DbSet<FileLink> FileLinks { get; }
        public DbSet<MobileFormHeader> MobileFormHeaders { get; }
        public DbSet<AssetTapAndBrand> AssetTapAndBrands { get; }
        public DbSet<ServiceTypeTask> ServiceTypeTasks { get; }
        public DbSet<Plant> Plants { get; }
        public DbSet<Job2plnt> Job2plnts { get; }
    }
}