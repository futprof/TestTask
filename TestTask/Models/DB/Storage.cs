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
                Name = task.Name,
                DueDate = task.DueDate,
                Status = Status.Active
            };
            _ctx.Add(newTask);
            _ctx.SaveChanges();
            return newTask.Id;
        }

        public List<Task> GetTasks(int page, int results)
        {
            try
            {
                int skipRecords;
                if (page <= 1) skipRecords = 0;                
                else skipRecords = page * results- results  ;
                return _ctx.Task.OrderBy(x => x.DueDate)
                                .Skip(skipRecords)
                                .Take(results)
                                .ToList();
            }
            catch (Exception)
            {
                throw;
            }            
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

        internal ToDoList GetTasksAmount()
        {
            var toDoList = new ToDoList();
            toDoList.TasksAmount = _ctx.Task.Count();
            return toDoList;
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

        public List<Task> SearchTask(string name)
        { 
            var tasks= _ctx.Task.Where(n => EF.Functions.Like(n.Name, $"%{name}%")).ToList();
            return tasks;
        }

        public List<Task> SearchTask(bool status)
        {
            var tasks = _ctx.Task.Where(s => s.Status.Equals(status==true?Status.Active:Status.Done)).ToList();
            return tasks;
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
