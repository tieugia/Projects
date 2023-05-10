using ModernisationChallenge.Repository;

namespace ModernisationChallenge.Services
{
    public interface ITaskService
    {
        Task<Entity.Task> GetTaskByIdAsync(int id);

        Task<dynamic> GetAllTasksAsync();

        Task<bool> AddTaskAsync(Entity.Task task);

        Task<bool> UpdateTaskAsync(Entity.Task task);

        Task DeleteTaskAsync(int id);

    }

    public class TaskService : ITaskService
    {
        private readonly IModerniseUnitOfWork _unitOfWork;

        public TaskService(IModerniseUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<Entity.Task> GetTaskByIdAsync(int id)
        {
            return _unitOfWork.TaskRepository.GetByIdAsync(id);
        }

        public Task<dynamic> GetAllTasksAsync()
        {
            return _unitOfWork.TaskRepository.GetAllAsync();
        }

        public async Task<bool> AddTaskAsync(Entity.Task task)
        {
            await _unitOfWork.TaskRepository.AddAsync(task);
            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateTaskAsync(Entity.Task task)
        {
            await _unitOfWork.TaskRepository.UpdateAsync(task);
            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteTaskAsync(int id)
        {
            await _unitOfWork.TaskRepository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
