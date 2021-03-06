using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestTask.Models
{
    [JsonObject]
    public class Task
    {
        [Key]        
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime DueDate { get; set; }
        public Status Status { get; set; }

    }
}
