using System;

namespace TODO.Models
{
    public class TaskModel
    {

        public string Description { get; set; }
        public string Guid { get; set; } = System.Guid.NewGuid().ToString();
        
        public DateTime CreateTime { get; set; } = DateTime.Now;
    }
}