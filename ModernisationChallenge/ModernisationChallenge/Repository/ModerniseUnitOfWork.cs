namespace ModernisationChallenge.Repository
{
    public interface IModerniseUnitOfWork : IDisposable
    {
        ITaskRepository TaskRepository { get; }
        Task<bool> SaveChangesAsync();
    }

    public class ModerniseUnitOfWork : IModerniseUnitOfWork
    {
        private readonly ModerniseDbContext _context;

        public ModerniseUnitOfWork(ModerniseDbContext context)
        {
            _context = context;
        }

        private TaskRepository _taskRepository;
        public ITaskRepository TaskRepository 
            => _taskRepository ??= new TaskRepository(_context);

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
