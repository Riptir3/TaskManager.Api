namespace TaskManager.Api.Models.Entities
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime DueDate { get; set; } = DateTime.Now;
        public bool IsCompleted { get; set; } = false;


        public Guid UserId { get; set; }
        public User? User { get; set; } 
    }
}
