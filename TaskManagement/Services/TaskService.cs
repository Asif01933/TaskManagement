
using System;
using TaskManagement.DTO;
using TaskManagement.Models;
using TaskManagement.Repositories;
using TaskManagement.Services;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using System.Diagnostics.Eventing.Reader;

namespace TaskManagement.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository<Tasks> _repository;
        private readonly IPersonRepository<Person> _personRepository;
        public TaskService(ITaskRepository<Tasks> repository,IPersonRepository<Person> personRepository)
        {
            _repository = repository;
            _personRepository = personRepository;
           
            
        }

        public TaskDto CreateTask(CreateTaskDto taskRequest)
        {
            
            var existingPerson1 = _personRepository.GetAll.FirstOrDefault(x => x.Name == taskRequest.TaskFrom);
            var existingPerson2 = _personRepository.GetAll.FirstOrDefault(x => x.Name == taskRequest.TaskTo);
            if (existingPerson1.Name.ToLower()!= taskRequest.TaskFrom.ToLower() || existingPerson2.Name.ToLower() != taskRequest.TaskTo.ToLower())
            {
                throw new Exception($"User doesn't exist");
            }
            var newTask = new Tasks()
            {
                Id = Guid.NewGuid().ToString(),
                TaskName = taskRequest.TaskName,
                TaskFrom = taskRequest.TaskFrom,
                TaskTo = taskRequest.TaskTo,
                CreatedAt = DateTime.UtcNow,
                Status = taskRequest.Status
            };

            _repository.Add(newTask);

            return new TaskDto()
            {
                TaskName = newTask.TaskName,
                TaskTo = newTask.TaskTo,
                TaskFrom = newTask.TaskFrom,
                CreatedAt = newTask.CreatedAt,
                Id = newTask.Id,
                Status = newTask.Status
            };
        }

        public IEnumerable<TaskDto>GetName(string taskfrom)
        {
            

            return _repository.GetAll.Where(x => x.TaskFrom.ToLower() == taskfrom.ToLower()).Select(x=>new TaskDto()
            {
                Id = x.Id,
                TaskName = x.TaskName,
                TaskFrom = x.TaskFrom,
                TaskTo = x.TaskTo,
                CreatedAt = x.CreatedAt,
                Status = x.Status
            });
        }
        public IEnumerable<TaskDto> GetMyTask(string taskto)
        {


            return _repository.GetAll.Where(x => x.TaskTo.ToLower() == taskto.ToLower()).Where(x=>x.Status==true).Select(x => new TaskDto()
            {
                Id = x.Id,
                TaskName = x.TaskName,
                TaskFrom = x.TaskFrom,
                TaskTo = x.TaskTo,
                CreatedAt = x.CreatedAt,
                Status = x.Status
            });
        }
        public IEnumerable<TaskDto> GetCompletedTask(string taskto)
        {


            return _repository.GetAll.Where(x => x.TaskTo.ToLower() == taskto.ToLower()).Where(x => x.Status == false).Select(x => new TaskDto()
            {
                Id = x.Id,
                TaskName = x.TaskName,
                TaskFrom = x.TaskFrom,
                TaskTo = x.TaskTo,
                CreatedAt = x.CreatedAt,
                Status = x.Status
            });
        }
        public IEnumerable<TaskDto> GetByWord(string taskname)
        {
            var value = taskname.ToLower();

            return _repository.GetAll.Where(x => x.TaskName.ToLower().Contains(value)).Select(x => new TaskDto()
            {
                Id = x.Id,
                TaskName = x.TaskName,
                TaskFrom = x.TaskFrom,
                TaskTo = x.TaskTo,
                CreatedAt = x.CreatedAt,
                Status = x.Status
            });
        }
        public IEnumerable<TaskDto> GetTasks()
        {
           
            return _repository.GetAll.Where(x => x.Status == true).Select(x => new TaskDto()
            {
                Id = x.Id,
                TaskName = x.TaskName,
                TaskFrom = x.TaskFrom,
                TaskTo = x.TaskTo,
                CreatedAt = x.CreatedAt,
                Status = x.Status
            });
        }
        public TaskDto GetByTaskId(string id)
        {
            var userModel = _repository.FindById(id);
            return new TaskDto()
            {
                Id = userModel.Id,
                TaskName = userModel.TaskName,
                TaskFrom = userModel.TaskFrom,
                TaskTo = userModel.TaskTo,
                CreatedAt = userModel.CreatedAt,
                Status = userModel.Status
            };
        }
        public string UpdateTask(UpdateTaskDto taskRequest)
        {
            var existingTask = _repository.FindById(taskRequest.Id);

            _ = existingTask ?? throw new Exception($"Task with {taskRequest.Id} doesn't exist");

            
            existingTask.TaskName = taskRequest.TaskName;
            

            _repository.Update(existingTask);

            return existingTask.Id;
        }
        public void UpdatePatch(string id,JsonPatchDocument taskRequest)
        {
            var existingTask = _repository.FindById(id);
            _ = existingTask ?? throw new Exception($"Task with {id} doesn't exist");
            taskRequest.ApplyTo(existingTask);
            _repository.check();


        }
        public string UpdatePendingTask(UpdatePendingTaskDto taskRequest)
        {
            var existingTask = _repository.FindById(taskRequest.Id);

            _ = existingTask ?? throw new Exception($"Task with {taskRequest.Id} doesn't exist");


            existingTask.Status = taskRequest.Status;


            _repository.Update(existingTask);

            return existingTask.Id;
        }
        public void DeleteTask(string userId)
        {
            var existingUser = _repository.FindById(userId);

            _ = existingUser ?? throw new Exception($"User with {userId} doesn't exist");

            _repository.Delete(existingUser);
        }


    }
}
