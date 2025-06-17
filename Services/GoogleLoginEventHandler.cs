using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using DevTrack.Services;
using System.Security.Claims;

namespace DevTrack.Services
{
    public class GoogleLoginEventHandler
    {
        private readonly GoogleLoginService _googleLoginService;
        private readonly UserManager<IdentityUser> _userManager;

        public GoogleLoginEventHandler(GoogleLoginService googleLoginService, UserManager<IdentityUser> userManager)
        {
            _googleLoginService = googleLoginService;
            _userManager = userManager;
        }

        public async Task HandleGoogleLoginAsync(ClaimsPrincipal principal, AuthenticationProperties properties)
        {
            // Get the user's email from Google claims
            var email = principal.FindFirst(ClaimTypes.Email)?.Value;
            if (string.IsNullOrEmpty(email))
                return;

            // Find or create the user
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                // Log the Google login
                await _googleLoginService.LogGoogleLoginAsync(user.Id, principal);
            }
        }
    }
} 