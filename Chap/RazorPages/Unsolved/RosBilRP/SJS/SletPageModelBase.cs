using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RosBilRP.Models;
using RosBilRP.Services;

namespace RosBilRP.SJS
{
    public abstract class SletPageModelBase<T, RepositoryT> : PageModel
        where T : IHarId
        where RepositoryT : IRepository<T>
    {

        private RepositoryT repo;
        public virtual string ReturnPage => "Alle";
        [BindProperty]
        public T Element { get; set; }

        public SletPageModelBase(RepositoryT repo)
        {
            this.repo = repo;
        }

        public virtual IActionResult OnGet(int id)
        {
            T? element = repo.Read(id);

            if (element == null)
                return RedirectToPage("Error");

            Element = element;
            return Page();
        }

        public virtual IActionResult OnPost()
        {
            repo.Delete(Element.Id);

            return RedirectToPage(ReturnPage);
        }
    }
}
