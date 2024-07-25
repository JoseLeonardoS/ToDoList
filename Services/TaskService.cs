using Microsoft.EntityFrameworkCore;
using ToDoList.Data;
using ToDoList.Dto;
using ToDoList.Models;

namespace ToDoList.Services
{
    public class TaskService : ITaskInterface
    {
        private readonly AppDbContext _context;

        public TaskService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<TaskItem>>> CreateTask(CreateTaskDto task)
        {
            ResponseModel<List<TaskItem>> response = new ResponseModel<List<TaskItem>>();

            try
            {
                var tsk = new TaskItem{
                    Title = task.Title,
                    Description = task.Description,
                    CreateDate = DateTime.Now
                };

                _context.Add(tsk);
                await _context.SaveChangesAsync();

                response.Message = "A new task has been created";
                response.Data = await _context.Tasks.ToListAsync();
                
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<TaskItem>>> DeleteTask(int id)
        {
            ResponseModel<List<TaskItem>> response = new ResponseModel<List<TaskItem>>();
            try
            {
                var tsk = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == id);

                if (tsk != null)
                {
                    _context.Remove(tsk);
                    await _context.SaveChangesAsync();

                    response.Message = "Task has been deleted";
                    response.Data = await _context.Tasks.ToListAsync();
                    return response;
                }

                response.Message = "Unable to delete task";
                response.Data = await _context.Tasks.ToListAsync();
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<TaskItem>>> GetAllTasks()
        {
            ResponseModel<List<TaskItem>> response = new ResponseModel<List<TaskItem>>();
            try
            {
                var tasks = await _context.Tasks.ToListAsync();

                if(tasks != null)
                {
                    response.Message = "Data found";
                    response.Data = tasks;

                    return response;
                }

                response.Message = "Data not found";
                response.Data = tasks;
                return response;
            }
            catch(Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<TaskItem>> GetTaskById(int id)
        {
            ResponseModel<TaskItem> response = new ResponseModel<TaskItem>();
            try
            {
                var task = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == id);

                if(task != null)
                {
                    response.Message = "Task found";
                    response.Data = task;
                    return response;
                }

                response.Message = "Task not found";
                response.Data = task;
                return response;
            }
            catch( Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<TaskItem>> GetTaskByTitle(string title)
        {
            ResponseModel<TaskItem> response = new ResponseModel<TaskItem>();
            try
            {
                var task = await _context.Tasks.FirstOrDefaultAsync(x => x.Title == title);

                if (task != null)
                {
                    response.Message = "Task found";
                    response.Data = task;
                    return response;
                }

                response.Message = "Task not found";
                response.Data = task;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<TaskItem>>> UpdateTask(UpdateTaskDto task)
        {
            ResponseModel<List<TaskItem>> response = new ResponseModel<List<TaskItem>>();
            try
            {
                var tsk = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == task.Id);

                if(tsk != null)
                {
                    tsk.Title = task.Title;
                    tsk.Description = task.Description;
                    tsk.TaskDone = task.TaskDone;

                    _context.Update(tsk);
                    await _context.SaveChangesAsync();

                    response.Message = "Task has been updated";
                    response.Data = await _context.Tasks.ToListAsync();
                    return response;
                }

                response.Message = "Unable to update task";
                response.Data = await _context.Tasks.ToListAsync();
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }
    }
}
