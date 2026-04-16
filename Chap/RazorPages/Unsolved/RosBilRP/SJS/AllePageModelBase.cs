using Microsoft.AspNetCore.Mvc.RazorPages;
using RosBilRP.Models;
using RosBilRP.Services;

namespace RosBilRP.SJS
{
    public abstract class AllePageModelBase<T,RepositoryT> : PageModel
        where T : IHarId
        where RepositoryT : IRepository<T>
    {
        protected RepositoryT repo;
        public List<T> Data { get; private set; }
        public AllePageModelBase(RepositoryT repo)
        {
            this.repo = repo;
        }
        public virtual void OnGet()
        {
            Data = repo.All;
        }

        public virtual bool CanDelete(int id)
        {
            return true;
        }
    }
}
