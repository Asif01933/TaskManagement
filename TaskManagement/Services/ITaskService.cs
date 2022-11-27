using TaskManagement.DTO;
using System.Collections.Generic;
using Microsoft.AspNetCore.JsonPatch;

namespace TaskManagement.Services
{
    public interface ITaskService
    {
        TaskDto CreateTask(CreateTaskDto taskRequest);
        
        IEnumerable<TaskDto> GetTasks();

        TaskDto GetByTaskId(string id);
        IEnumerable<TaskDto> GetName(string taskfrom);
        IEnumerable<TaskDto> GetMyTask(string taskto);
        IEnumerable<TaskDto> GetCompletedTask(string taskto);
        IEnumerable<TaskDto> GetByWord(string taskname);
        void DeleteTask(string userId);
        string UpdateTask(UpdateTaskDto taskRequest);
        void UpdatePatch(string id,JsonPatchDocument taskRequest);
        string UpdatePendingTask(UpdatePendingTaskDto taskRequest);
    }
}
