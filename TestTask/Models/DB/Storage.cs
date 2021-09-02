using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestTask.Models.DB
{
    public class Storage
    {
        private readonly AppContext _ctx;


        public Storage(DbContextOptions<AppContext> options)
        {
            _ctx = new AppContext(options);
        }

        public string AddTask(Task task)
        {
            Task newTask = new Task
            {
                Id = Guid.NewGuid().ToString(),
                DueDate = task.DueDate,
                Status = Status.Active
            };
            _ctx.Add(newTask);
            _ctx.SaveChanges();
            return newTask.Id;
        }

        public List<Task> GetTasks()
        {
            return _ctx.Task.ToList();
        }

        public Task GetTask(string id)
        {
            try
            {
                var task = _ctx.Task.FirstOrDefault(i => i.Id.Equals(id));
                return task;
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public bool ChengeTaskStatus(string id, bool status)
        { 
                var task = GetTask(id);
                if (task != null)
                {
                    task.Status = status == true ? Status.Done : Status.Active;
                    _ctx.Task.Attach(task);
                    _ctx.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
        }

        public string UpdateTask(Task task)
        {
            try
            {
                var storedTask = _ctx.Task.FirstOrDefault(i => i.Id.Equals(task.Id));
                if (storedTask != null)
                {
                    storedTask.Name = task.Name;
                    storedTask.DueDate = task.DueDate;
                    _ctx.Task.Update(storedTask);
                    _ctx.SaveChanges();
                    return "Success!";
                }
                else return "No task to update.";
            }
            catch (Exception)
            {
                return "Somethisng were wrong...";
                throw;
            }            
        }

        public bool RemoveTask(string id)
        {
            try
            {
                var task = GetTask(id);
                if (task != null)
                {
                    _ctx.Task.Remove(task);
                    _ctx.SaveChanges();
                    return true;
                }
                else return false;
            }
            catch (Exception)
            {
                return false;
                throw;
                //TODO: rework exception handler
            }
        }
    }
}
