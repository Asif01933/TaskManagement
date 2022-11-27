using TaskManagement.DTO;
using TaskManagement.Models;
using TaskManagement.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using TaskManagement.Repositories;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskManagement.Controllers
{
   
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;


        public TaskController(ITaskService taskService)
            => _taskService = taskService;

        [HttpPost]
        [Route("api/new-task")]
        public IActionResult Create(CreateTaskDto taskRequest)
        {
            return Ok(_taskService.CreateTask(taskRequest));
        }

       
       

        [HttpGet]
        [Route("api/tasks")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_taskService.GetTasks());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/ordered-tasks")]
        public IActionResult GetName(string taskfrom)
        {
            try
            {
                var posts = _taskService.GetName(taskfrom);
                return Ok(posts);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/due-tasks")]
        public IActionResult GetTaskTo(string taskto)
        {
            try
            {
                var posts = _taskService.GetMyTask(taskto);
                return Ok(posts);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/task-lists")]
        public IActionResult GetByWord(string taskname)
        {
            try
            {
                var posts = _taskService.GetByWord(taskname);
                return Ok(posts);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("api/completed-tasks")]
        public IActionResult GetCompletedTask(string taskto)
        {
            try
            {
                var posts = _taskService.GetCompletedTask(taskto);
                return Ok(posts);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpPut]
        [Route("api/tasks")]
        public IActionResult Update(UpdateTaskDto taskRequest)
        {
            try
            {
                return Ok(_taskService.UpdateTask(taskRequest));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("api/checkcout-tasks")]
        public IActionResult UpdatePendingTask(UpdatePendingTaskDto taskRequest)
        {
            try
            {
                return Ok(_taskService.UpdatePendingTask(taskRequest));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("api/tasks/{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                _taskService.DeleteTask(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("api/tasks/{id}")]
        public IActionResult GetByTaskId(string id)
        {
            try
            {
                return Ok(_taskService.GetByTaskId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
