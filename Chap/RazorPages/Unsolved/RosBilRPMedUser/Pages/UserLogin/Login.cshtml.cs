using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RosBilRP.Models;
using RosBilRP.Services;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace RosBilRP.Pages.UserLogin
{
    public class LoginModel : PageModel
    {
        private IUserRepository userRepository;
        public static User? CurrentUser { get; set; }
        [BindProperty]
        public string UserName { get; set; }
        
        [BindProperty, DataType(DataType.Password)]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        public LoginModel(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<IActionResult> OnPost()
        {
            CurrentUser = userRepository.VerifyUser(UserName, Password);

            if (CurrentUser == null)
            {
                ErrorMessage = "Kunne ikke logge ind";
                return Page();
            }

            // Log ind
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                BuildClaimsPrincipal(CurrentUser));

            return RedirectToPage("/Index");
        }


        private ClaimsPrincipal BuildClaimsPrincipal(User user)
        {
            // Opbyg Claims-liste
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.Navn));
            claims.Add(new Claim(ClaimTypes.Role, user.Rolle));

            // Opret ClaimsIdentity (claims plus Authentication-strategi)
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            // Opret endeligt ClaimsPrincipal-objekt
            return new ClaimsPrincipal(claimsIdentity);
        }

    }
}
