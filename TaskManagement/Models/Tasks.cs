namespace TaskManagement.Models
{
    public class Tasks
    {
        public string Id { get; set; }
        public string TaskName { get; set; }
        public string TaskFrom { get; set; }
        public string TaskTo { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Status { get; set; }
    }
}
