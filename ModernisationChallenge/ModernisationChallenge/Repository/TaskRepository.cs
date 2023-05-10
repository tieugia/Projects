using Microsoft.EntityFrameworkCore;

namespace ModernisationChallenge.Repository
{
    public interface ITaskRepository
    {
        Task<dynamic> GetAllAsync();
        Task<Entity.Task> GetByIdAsync(int id);
        Task AddAsync(Entity.Task task);
        Task UpdateAsync(Entity.Task task);
        Task DeleteAsync(int id);
    }

    public class TaskRepository : ITaskRepository
    {
        private readonly ModerniseDbContext _context;

        public TaskRepository(ModerniseDbContext context)
        {
            _context = context;
        }

        public async Task<dynamic> GetAllAsync()
        {
            var taskQuery =

            from task in _context.Tasks

            where task.DateDeleted == null

            orderby task.Id

            select new 
            {
                task.Id,
                task.Completed,
                task.Details
            };

            return taskQuery.AsEnumerable();
        }

        public async Task<Entity.Task> GetByIdAsync(int id)
        {
            return await _context.Tasks.FindAsync(id);
        }

        public async Task AddAsync(Entity.Task task)
        {
            await _context.Tasks.AddAsync(task);
        }

        public async Task UpdateAsync(Entity.Task task)
        {
            _context.Entry(task).State = EntityState.Modified;
        }

        public async Task DeleteAsync(int id)
        {
            var task = await GetByIdAsync(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
            }
        }
    }
}
