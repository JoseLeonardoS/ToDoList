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

        [HttpGet("GetAllTasks")]
        public async Task<ActionResult<ResponseModel<List<TaskItem>>>> GetAllTasks()
        {
            var tasks = await _taskInterface.GetAllTasks();
            return Ok(tasks);
        }

        [HttpGet("GetTaskById/{id}")]
        public async Task<ActionResult<ResponseModel<TaskItem>>> GetTaskById(int id)
        {
            var task = await _taskInterface.GetTaskById(id);
            return Ok(task);
        }

        [HttpGet("GetTaskByTitle/{title}")]
        public async Task<ActionResult<ResponseModel<TaskItem>>> GetTaskByTitle(string title)
        {
            var task = await _taskInterface.GetTaskByTitle(title);
            return Ok(task);
        }

        [HttpPost("CreateTask")]
        public async Task<ActionResult<ResponseModel<List<TaskItem>>>> CreateTask(CreateTaskDto task)
        {
            var tasks = await _taskInterface.CreateTask(task);
            return Ok(tasks);
        }

        [HttpPut("UpdateTask")]
        public async Task<ActionResult<ResponseModel<List<TaskItem>>>> UpdateTask(UpdateTaskDto task)
        {
            var tasks = await _taskInterface.UpdateTask(task);
            return Ok(tasks);
        }

        [HttpDelete("DeleteTask")]
        public async Task<ActionResult<ResponseModel<List<TaskItem>>>> DeleteTask(int id)
        {
            var tasks = await _taskInterface.DeleteTask(id);
            return Ok(tasks);
        }
    }
}
