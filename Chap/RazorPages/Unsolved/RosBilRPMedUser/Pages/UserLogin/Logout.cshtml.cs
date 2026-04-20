using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RosBilRP.Pages.UserLogin
{
    public class LogoutModel : PageModel
    {
        public async Task<IActionResult> OnGet()
        {
            LoginModel.CurrentUser = null;

            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToPage("/Index");
        }

    }
}
