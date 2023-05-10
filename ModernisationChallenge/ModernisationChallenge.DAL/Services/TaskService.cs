using ModernisationChallenge.DAL.Repository;

namespace ModernisationChallenge.DAL.Services
{
    public interface ITaskService
    {
        Task<Entity.Task> GetTaskByIdAsync(int id);

        Task<dynamic> GetAllTasksAsync();

        Task<bool> AddTaskAsync(Entity.Task task);

        Task<bool> UpdateTaskAsync(int id, Entity.Task task);

        Task<bool> CompleteTaskAsync(int id);

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
            task.DateCreated = DateTime.Now;
            task.DateModified = DateTime.Now;
            await _unitOfWork.TaskRepository.AddAsync(task);
            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateTaskAsync(int id, Entity.Task task)
        {
            var existingTask = await _unitOfWork.TaskRepository.GetByIdAsync(id);
            existingTask.Details = task.Details;
            await _unitOfWork.TaskRepository.UpdateAsync(existingTask);
            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> CompleteTaskAsync(int id)
        {
            var task = await _unitOfWork.TaskRepository.GetByIdAsync(id);
            task.Completed = !task.Completed;
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
