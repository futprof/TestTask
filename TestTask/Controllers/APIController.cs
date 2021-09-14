using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Models;
using TestTask.Models.DB;

namespace TestTask.Controllers
{
    public class APIController : ControllerBase
    {
        private readonly Storage _storage;
        private ErrorMessage _errorMessage;
        public APIController(DbContextOptions<Models.DB.AppContext> options)
        {
            _storage = new Storage(options);
        }

        [HttpPost]
        [Route("api/get-all-tasks")]
        public string GetAll(int page, int results)
        {
            try
            {
                var tasks = _storage.GetTasks(page, results);
                var json = JsonConvert.SerializeObject(tasks, Formatting.Indented);
                return json;
            }
            catch (Exception)
            {
                _errorMessage = new ErrorMessage {
                    DateOffset = DateTimeOffset.UtcNow,
                    Message = "Bad reqest.",
                    Method = ControllerContext.ActionDescriptor.ActionName }; 
                return JsonConvert.SerializeObject(_errorMessage, Formatting.Indented);
                throw;
            }
           
        }

        [HttpDelete]
        [Route("api/del-task/{id}")]
        public bool RemoveTask(string id)
        {
            try
            {
                return _storage.RemoveTask(id);
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        [HttpPost]
        [Route("api/change-status")]
        public bool ChangeTaskStatus(string id, bool status)
        {
            try
            {
                return _storage.ChengeTaskStatus(id, status);
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpGet]
        [Route("api/get-task/{id}")]
        public string GetTask(string id)
        {
            try
            {
                var task = _storage.GetTask(id);
                var json = JsonConvert.SerializeObject(task, Formatting.Indented);
                return json;
            }
            catch (Exception)
            {
                _errorMessage = new ErrorMessage
                {
                    DateOffset = DateTimeOffset.UtcNow,
                    Message = "Bad reqest.",
                    Method = ControllerContext.ActionDescriptor.ActionName
                };
                return JsonConvert.SerializeObject(_errorMessage, Formatting.Indented);                
            }           
        }

        [HttpPost]
        [Route("api/update-task")]
        public string UpdateTask(Models.Task task)
        {
            try
            {
                return _storage.UpdateTask(task);
            }
            catch (Exception)
            {
                _errorMessage = new ErrorMessage
                {
                    DateOffset = DateTimeOffset.UtcNow,
                    Message = "Bad reqest.",
                    Method = ControllerContext.ActionDescriptor.ActionName
                };
                return JsonConvert.SerializeObject(_errorMessage, Formatting.Indented);
            }
           
        }

        [HttpPost]
        [Route("api/add-task")]
        public JsonResult AddTask(Models.Task task)
        {            
            try
            {
                if (!ModelState.IsValid)
                {
                    return new JsonResult("Task is not valid!");
                }
                _storage.AddTask(task);
                return new JsonResult("Sucess!");
            }
            catch (Exception)
            {
                _errorMessage = new ErrorMessage
                {
                    DateOffset = DateTimeOffset.UtcNow,
                    Message = "Bad reqest.",
                    Method = ControllerContext.ActionDescriptor.ActionName
                };
                return new JsonResult(JsonConvert.SerializeObject(_errorMessage, Formatting.Indented));                
            }
        }

        [HttpGet]
        [Route("api/tasks-amount")]
        public string GetTasksAmount()
        {           
            try
            {
                var json = JsonConvert.SerializeObject(_storage.GetTasksAmount());
                return json;
            }
            catch (Exception)
            {
                _errorMessage = new ErrorMessage
                {
                    DateOffset = DateTimeOffset.UtcNow,
                    Message = "Bad reqest.",
                    Method = ControllerContext.ActionDescriptor.ActionName
                };
                return JsonConvert.SerializeObject(_errorMessage, Formatting.Indented);
                throw;
            }
        }

        [HttpGet]
        [Route("api/search-by-name/{name}")]
        public string SearchTask(string name)
        {
            try
            {
                var tasks = _storage.SearchTask(name);
                var json = JsonConvert.SerializeObject(tasks, Formatting.Indented);
                return json;
            }
            catch (Exception)
            {
                _errorMessage = new ErrorMessage
                {
                    DateOffset = DateTimeOffset.UtcNow,
                    Message = "Bad reqest.",
                    Method = ControllerContext.ActionDescriptor.ActionName
                };
                return JsonConvert.SerializeObject(_errorMessage, Formatting.Indented);
            }
           
        }

        [HttpGet]
        [Route("api/search-by-status/{status}")]
        public string SearchTask(bool status)
        {
            try
            {
                var tasks = _storage.SearchTask(status);
                var json = JsonConvert.SerializeObject(tasks, Formatting.Indented);
                return json;
            }
            catch (Exception)
            {
                _errorMessage = new ErrorMessage
                {
                    DateOffset = DateTimeOffset.UtcNow,
                    Message = "Bad reqest.",
                    Method = ControllerContext.ActionDescriptor.ActionName
                };
                return JsonConvert.SerializeObject(_errorMessage, Formatting.Indented);
            }           
        }
    }
}
