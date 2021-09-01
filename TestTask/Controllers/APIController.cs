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


    }
}
