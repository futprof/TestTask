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
				for (int i = 1; i < 21; i++)
				{
					tasks.Add(new Task() {
						Id = Guid.NewGuid().ToString(),
						Name = "Task#" + i,
						DueDate = new DateTime(2021, 10, i),
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
