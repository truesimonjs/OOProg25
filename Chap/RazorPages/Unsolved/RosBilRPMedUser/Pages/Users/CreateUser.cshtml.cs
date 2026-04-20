using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RosBilRP.Services;
using RosBilRP.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace RosBilRP.Pages.Users
{
    [Authorize(Roles = "admin")]
    public class CreateUserModel : PageModel
    {
        private IUserRepository repo;
        [BindProperty]
        public User Element {  get; set; } = new User();
        public SelectList Roles { get; set; }
        public CreateUserModel(IUserRepository repo)
        {
            this.repo= repo;
            Roles = new(repo.Roles);
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();
            repo.Create(Element);
            return RedirectToPage("/Index");
        }
        public void OnGet()
        {
        }
    }
}
