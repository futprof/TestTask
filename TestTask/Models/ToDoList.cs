using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestTask.Models
{
    [JsonObject]
    public class ToDoList
    {
        public int TasksAmount { get; set; }
    }
}
