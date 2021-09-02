using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Models.DB;

namespace TestTask.Controllers
{
    public class APIController : ControllerBase
    {
        private readonly Storage _storage;
        public APIController(DbContextOptions<Models.DB.AppContext> options)
        {
            _storage = new Storage(options);
        }

        [HttpGet]
        [Route("api/get-all-tasks")]
        public string GetAll()
        {
            var tasks = _storage.GetTasks();
            var json = JsonConvert.SerializeObject(tasks, Formatting.Indented);
            return json;
        }

        [HttpPost]
        [Route("api/del-task")]
        public bool RemoveTask(string id )
        {
            return _storage.RemoveTask(id);            
        }

        [HttpPost]
        [Route("api/chandge-status")]
        public bool ChandgeTaskStatus(string id, bool status)
        {            
            return _storage.ChengeTaskStatus(id, status);
        }

        [HttpGet]
        [Route("api/get-task")]
        public string GetTask(string id)
        {
            var task = _storage.GetTask(id);
            var json = JsonConvert.SerializeObject(task, Formatting.Indented);
            return json;
        }

        [HttpPost]
        [Route("api/update-task")]
        public string UpdateTask(Models.Task task)
        {
            return JsonConvert.SerializeObject(_storage.UpdateTask(task));
        }

    }
}
