using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Dto;
using ToDoList.Models;
using ToDoList.Services;

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskInterface _taskInterface;

        public TasksController(ITaskInterface taskInterface)
        {
            _taskInterface = taskInterface;
        }

        [HttpPost("CreateTask")]
        public async Task<ActionResult<ResponseModel<List<TaskItem>>>> CreateTask(CreateTaskDto task)
        {
            var tasks = await _taskInterface.CreateTask(task);
            return Ok(tasks);
        }
    }
}
