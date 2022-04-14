using System;

namespace TODO.Models
{
    public class TaskModel
    {

        public string description { get; set; }
        public string guid { get; set; } = Guid.NewGuid().ToString();
        
        public DateTime createTime { get; set; } = DateTime.Now;
    }
}