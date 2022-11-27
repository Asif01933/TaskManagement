namespace TaskManagement.DTO
{
    public class TaskDto
    {
        public string Id { get; set; }
        public string TaskName { get; set; }
        public string TaskFrom { get; set; }
        public string TaskTo { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Status { get; set; }
    }
}
