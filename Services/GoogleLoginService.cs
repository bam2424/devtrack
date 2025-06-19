using DevTrack.Data;
using DevTrack.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace DevTrack.Services
{
    public class GoogleLoginService
    {
        private readonly DevTrackDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GoogleLoginService(DevTrackDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task LogGoogleLoginAsync(string userId, ClaimsPrincipal user)
        {
            try
            {
                var googleId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var email = user.FindFirst(ClaimTypes.Email)?.Value;
                var name = user.FindFirst(ClaimTypes.Name)?.Value;
                var picture = user.FindFirst("picture")?.Value;

                // Enhanced logging for debugging
                Console.WriteLine($"[GoogleLoginService] Logging Google login for email: {email}, UserId: {userId}");

                if (string.IsNullOrEmpty(googleId) || string.IsNullOrEmpty(email))
                {
                    Console.WriteLine($"[GoogleLoginService] Missing required data - GoogleId: {googleId}, Email: {email}");
                    return;
                }

                var httpContext = _httpContextAccessor.HttpContext;
                var ipAddress = httpContext?.Connection?.RemoteIpAddress?.ToString();
                var userAgent = httpContext?.Request?.Headers["User-Agent"].ToString();

                var loginLog = new GoogleLoginLog
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    GoogleId = googleId,
                    Email = email,
                    Name = name,
                    ProfilePictureUrl = picture,
                    LoginTime = DateTime.UtcNow,
                    IpAddress = ipAddress,
                    UserAgent = userAgent
                };

                _context.GoogleLoginLogs.Add(loginLog);
                await _context.SaveChangesAsync();
                
                Console.WriteLine($"[GoogleLoginService] Successfully logged Google login for {email}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[GoogleLoginService] Error logging Google login: {ex.Message}");
                Console.WriteLine($"[GoogleLoginService] Stack trace: {ex.StackTrace}");
            }
        }

        public async Task<List<GoogleLoginLog>> GetRecentLoginsAsync(int count = 50)
        {
            return await _context.GoogleLoginLogs
                .Include(g => g.User)
                .OrderByDescending(g => g.LoginTime)
                .Take(count)
                .ToListAsync();
        }

        public async Task<List<GoogleLoginLog>> GetLoginsByUserAsync(string userId)
        {
            return await _context.GoogleLoginLogs
                .Where(g => g.UserId == userId)
                .OrderByDescending(g => g.LoginTime)
                .ToListAsync();
        }

        public async Task<Dictionary<string, int>> GetLoginStatsAsync()
        {
            var totalLogins = await _context.GoogleLoginLogs.CountAsync();
            var uniqueUsers = await _context.GoogleLoginLogs
                .Select(g => g.GoogleId)
                .Distinct()
                .CountAsync();
            var todayLogins = await _context.GoogleLoginLogs
                .Where(g => g.LoginTime.Date == DateTime.UtcNow.Date)
                .CountAsync();
            var thisWeekLogins = await _context.GoogleLoginLogs
                .Where(g => g.LoginTime >= DateTime.UtcNow.AddDays(-7))
                .CountAsync();

            return new Dictionary<string, int>
            {
                ["TotalLogins"] = totalLogins,
                ["UniqueUsers"] = uniqueUsers,
                ["TodayLogins"] = todayLogins,
                ["ThisWeekLogins"] = thisWeekLogins
            };
        }
    }
} 