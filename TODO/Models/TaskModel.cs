using System;
using SQLite;

namespace TODO.Models
{
    public class TaskModel
    {
        [PrimaryKey, AutoIncrement]
        public long ID { get; set; }
        public string Description { get; set; }
        public DateTime CreateTime { get; set; } = DateTime.Now;
    }
}