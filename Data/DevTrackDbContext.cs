using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DevTrack.Models;

namespace DevTrack.Data;

public class DevTrackDbContext : IdentityDbContext
{
    public DevTrackDbContext(DbContextOptions<DevTrackDbContext> options) : base(options)
    {
    }
    
    public DbSet<Project> Projects { get; set; }
    public DbSet<DevTask> Tasks { get; set; }
    public DbSet<TimeLog> TimeLogs { get; set; }
    public DbSet<GoogleLoginLog> GoogleLoginLogs { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // Configure Project entity
        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Title).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.UserId).IsRequired();
            
            // One project has many tasks
            entity.HasMany(e => e.Tasks)
                .WithOne(e => e.Project)
                .HasForeignKey(e => e.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
        });
        
        // Configure DevTask entity
        modelBuilder.Entity<DevTask>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.Tags).HasMaxLength(500);
            
            // One task has many time logs
            entity.HasMany(e => e.TimeLogs)
                .WithOne(e => e.Task)
                .HasForeignKey(e => e.TaskId)
                .OnDelete(DeleteBehavior.Cascade);
        });
        
        // Configure TimeLog entity
        modelBuilder.Entity<TimeLog>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Notes).HasMaxLength(500);
            entity.Property(e => e.UserId).IsRequired();
        });
        
        // Configure GoogleLoginLog entity
        modelBuilder.Entity<GoogleLoginLog>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.UserId).IsRequired();
            entity.Property(e => e.GoogleId).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Email).IsRequired().HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.ProfilePictureUrl).HasMaxLength(500);
            entity.Property(e => e.IpAddress).HasMaxLength(45); // IPv6 max length
            entity.Property(e => e.UserAgent).HasMaxLength(1000);
            
            // Index for faster queries
            entity.HasIndex(e => e.GoogleId);
            entity.HasIndex(e => e.Email);
            entity.HasIndex(e => e.LoginTime);
        });
    }
} 