using System.ComponentModel.DataAnnotations;

namespace DevTrack.Models;

public class DevTask
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(200)]
    public string Title { get; set; } = string.Empty;
    
    [StringLength(1000)]
    public string? Description { get; set; }
    
    public TaskStatus Status { get; set; } = TaskStatus.ToDo;
    public TaskPriority Priority { get; set; } = TaskPriority.Medium;
    
    public DateTime? DueDate { get; set; }
    
    // Simple comma-separated tags for MVP
    public string Tags { get; set; } = string.Empty;
    
    public bool IsCompleted { get; set; } = false;
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    
    // Foreign key
    public Guid ProjectId { get; set; }
    public Project Project { get; set; } = null!;
    
    // Navigation property for time tracking
    public List<TimeLog> TimeLogs { get; set; } = new();
}

public enum TaskStatus
{
    ToDo = 0,
    InProgress = 1,
    Done = 2
}

public enum TaskPriority
{
    Low = 0,
    Medium = 1,
    High = 2
} 