using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RosBilRP.Models;
using RosBilRP.Services;

namespace RosBilRP.SJS
{
    public abstract class OpretPageModelBase<T, RepositoryT> : PageModel
        where T : IHarId, new()
        
        where RepositoryT : IRepository<T>
    {
        private RepositoryT repo;
        [BindProperty]
        public T Element { get; set; } = new T();
        public virtual string ReturnPage => "Alle";
        public OpretPageModelBase(RepositoryT repo)
        {
            this.repo = repo;
        }

        public IActionResult OnPost()
        {
            // Tjek om det indtastede data er validt
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Send data videre til repository
            repo.Create(Element);

            // Vend tilbage til oversigen
            return RedirectToPage(ReturnPage);
        }
    }
}
