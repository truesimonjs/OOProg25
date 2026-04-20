using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RosBilRP.Models;
using RosBilRP.Services;
using System.ComponentModel.DataAnnotations;

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

        public void OnGet()
        {
        }
    }
}
