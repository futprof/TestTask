using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestTask.Models.DB
{
    public class DBInitializer
    {
        public static void InitializeDB(AppContext ctx)
        {
			try
			{				
				ctx.Database.EnsureCreated();
				if (ctx.Task.Any()) return;

				//create some default tasks
				var tasks = new List<Task>();
				var dueDate = DateTime.Now;
				for (int i = 1; i < 350; i++)
				{

					tasks.Add(new Task() {
						Id = Guid.NewGuid().ToString(),
						Name = "Task#" + i,
						DueDate = dueDate.AddDays(i),
						Status = Status.Active
					});
				}
				ctx.Task.AddRange(tasks);
				ctx.SaveChanges();
			}
			catch (Exception)
			{
				throw;
			}
        }
    }
}
