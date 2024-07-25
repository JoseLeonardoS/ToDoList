using ToDoList.Dto;
using ToDoList.Models;

namespace ToDoList.Services
{
    public interface ITaskInterface
    {
        Task<ResponseModel<List<TaskItem>>> GetAllTasks();
        Task<ResponseModel<TaskItem>> GetTaskById(int id);
        Task<ResponseModel<TaskItem>> GetTaskByTitle(string title);
        Task<ResponseModel<List<TaskItem>>> CreateTask(CreateTaskDto task);
        Task<ResponseModel<List<TaskItem>>> UpdateTask(UpdateTaskDto task);
        Task<ResponseModel<List<TaskItem>>> DeleteTask(int id);
    }
}
