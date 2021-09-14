using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestTask.Models
{
    [JsonObject]
    public class ErrorMessage
    {
        public DateTimeOffset DateOffset { get; set; }
        public string Method { get; set; }
        public string Message { get; set; }
    }
}
