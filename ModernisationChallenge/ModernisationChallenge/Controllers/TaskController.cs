using Microsoft.AspNetCore.Mvc;
using ModernisationChallenge.DAL.Services;

namespace ModernisationChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        // GET: api/Task
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DAL.Entity.Task>>> Get()
        {
            var tasks = await _taskService.GetAllTasksAsync();
            return Ok(tasks);
        }
        // GET: api/Task/Complete/5
        [HttpGet("Complete/{id}")]
        public async Task<ActionResult<IEnumerable<DAL.Entity.Task>>> CompleteAsync(int id)
        {
            var tasks = await _taskService.CompleteTaskAsync(id);
            return Ok(tasks);
        }

        // GET: api/Task/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Task>> GetTaskByIdAsync(int id)
        {
            var task = await _taskService.GetTaskByIdAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        // PUT: api/Task/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTaskAsync(int id, DAL.Entity.Task task)
        {
            if (id != task.Id)
            {
                return BadRequest();
            }

            await _taskService.UpdateTaskAsync(id, task);

            return NoContent();
        }

        // POST: api/Task
        [HttpPost]
        public async Task<ActionResult<Task>> AddTaskAsync(DAL.Entity.Task task)
        {
            await _taskService.AddTaskAsync(task);

            return Ok();
        }

        // DELETE: api/Task/5
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> DeleteTaskAsync(int id)
        {
            var task = await _taskService.GetTaskByIdAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            await _taskService.DeleteTaskAsync(id);

            return NoContent();
        }
    }
}
