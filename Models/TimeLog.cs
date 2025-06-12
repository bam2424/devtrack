using System.ComponentModel.DataAnnotations;

namespace DevTrack.Models;

public class TimeLog
{
    public int Id { get; set; }
    
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    
    // Duration in minutes (calculated when timer stops)
    public int DurationMinutes { get; set; } = 0;
    
    [StringLength(500)]
    public string? Notes { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    // Foreign key
    public int TaskId { get; set; }
    public DevTask Task { get; set; } = null!;
    
    // User who logged this time
    public string UserId { get; set; } = string.Empty;
    
    // Helper property to check if timer is running
    public bool IsRunning => EndTime == null;
    
    // Helper properties for backward compatibility
    public DateTime Date => StartTime.Date;
    public double Hours => DurationMinutes / 60.0;
    public string Description => Notes ?? "";
} 