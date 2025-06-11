using System.ComponentModel.DataAnnotations;

namespace DevTrack.Models;

public class Project
{
    public Guid Id { get; set; }
    
    [Required]
    [StringLength(100)]
    public string Title { get; set; } = string.Empty;
    
    [StringLength(500)]
    public string? Description { get; set; }
    
    public DateTime? DueDate { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    
    // Navigation property
    public List<DevTask> Tasks { get; set; } = new();
    
    // User who owns this project
    public string UserId { get; set; } = string.Empty;
} 