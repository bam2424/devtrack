using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using DevTrack.Data;
using DevTrack.Models;
using DevTrack.Services;

namespace DevTrack.Controllers
{
    public class AuthController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly GoogleLoginService _googleLoginService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthController(
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager,
            GoogleLoginService googleLoginService,
            IHttpContextAccessor httpContextAccessor)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _googleLoginService = googleLoginService;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost]
        public IActionResult ExternalLogin(string provider, string returnUrl = "/")
        {
            var redirectUrl = Url.Action(nameof(ExternalLoginCallback), "Auth", new { returnUrl });
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return Challenge(properties, provider);
        }

        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = "/", string? remoteError = null)
        {
            if (remoteError != null)
            {
                TempData["Error"] = $"Error from external provider: {remoteError}";
                return Redirect("/");
            }

            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                TempData["Error"] = "Error loading external login information.";
                return Redirect("/");
            }

            // Always log the Google login attempt (regardless of success)
            await LogGoogleLogin(info);

            // Sign in the user with this external login provider if the user already has a login
            var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);
            
            if (result.Succeeded)
            {
                return LocalRedirect(returnUrl);
            }

            // If the user does not have an account, create one
            var email = info.Principal.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value;
            var name = info.Principal.FindFirst(System.Security.Claims.ClaimTypes.Name)?.Value;

            if (!string.IsNullOrEmpty(email))
            {
                var user = await _userManager.FindByEmailAsync(email);
                if (user == null)
                {
                    user = new IdentityUser
                    {
                        UserName = email,
                        Email = email,
                        EmailConfirmed = true
                    };

                    var createResult = await _userManager.CreateAsync(user);
                    if (createResult.Succeeded)
                    {
                        await _userManager.AddLoginAsync(user, info);
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                else
                {
                    await _userManager.AddLoginAsync(user, info);
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
            }

            TempData["Error"] = "Unable to load user information from Google.";
            return Redirect("/");
        }

        private async Task LogGoogleLogin(ExternalLoginInfo info)
        {
            try
            {
                var email = info.Principal.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value;
                
                if (!string.IsNullOrEmpty(email))
                {
                    // Find existing user or use a temporary ID for logging
                    var user = await _userManager.FindByEmailAsync(email);
                    var userId = user?.Id ?? "unknown-user"; // Log even if user doesn't exist yet
                    
                    await _googleLoginService.LogGoogleLoginAsync(userId, info.Principal);
                }
            }
            catch (Exception ex)
            {
                // Log error but don't fail the login process
                // In production, use proper logging framework
            }
        }
    }
} 