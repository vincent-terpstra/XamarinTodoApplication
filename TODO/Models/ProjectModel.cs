using SQLite;

namespace TODO.Models;

public class ProjectModel
{
    [PrimaryKey, AutoIncrement]
    public long ID { get; set; }
    
    public string Title { get; set; }
    public string Description { get; set; }
}