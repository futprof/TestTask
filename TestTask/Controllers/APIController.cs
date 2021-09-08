﻿using Microsoft.AspNetCore.Mvc;
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

        [HttpDelete]
        [Route("api/del-task/{id}")]
        public bool RemoveTask(string id )
        {
            return _storage.RemoveTask(id);            
        }

        [HttpPost]
        [Route("api/change-status")]
        public bool ChangeTaskStatus(string id, bool status)
        {            
            return _storage.ChengeTaskStatus(id, status);
        }

        [HttpGet]
        [Route("api/get-task/{id}")]
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
            return _storage.UpdateTask(task);
        }

        [HttpPost]
        [Route("api/add-task")]
        public JsonResult AddTask(Models.Task task)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult("Task is not valid!");
            }
            _storage.AddTask(task);
            return new JsonResult("Sucess!");
        }

    }
}
