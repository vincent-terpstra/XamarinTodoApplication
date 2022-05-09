using System;
using SQLite;

namespace TODO.Models
{
    public class TaskModel
    {
        [PrimaryKey, AutoIncrement]
        public long Id { get; set; }

        public long ProjectId { get; set; }
        public string Description { get; set; }
        public DateTime CreateTime { get; set; } = DateTime.Now;

        public bool IsCompleted { get; set; } = false;

    }
}