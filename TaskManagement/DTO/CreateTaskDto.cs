namespace TaskManagement.DTO
{
    public class CreateTaskDto
    {
        public string TaskName { get; set; }
        public string TaskFrom { get; set; }
        public string TaskTo { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Status { get; set; }
    }
}
