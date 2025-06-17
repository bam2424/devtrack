using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace DevTrack.Models
{
    public class GoogleLoginLog
    {
        public Guid Id { get; set; }
        
        [Required]
        public string UserId { get; set; } = string.Empty;
        
        [Required]
        public string GoogleId { get; set; } = string.Empty;
        
        [Required]
        public string Email { get; set; } = string.Empty;
        
        public string? Name { get; set; }
        
        public string? ProfilePictureUrl { get; set; }
        
        public DateTime LoginTime { get; set; } = DateTime.UtcNow;
        
        public string? IpAddress { get; set; }
        
        public string? UserAgent { get; set; }
        
        // Navigation property
        public IdentityUser? User { get; set; }
    }
} 