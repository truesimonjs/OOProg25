using Microsoft.AspNetCore.Mvc.RazorPages;
using RosBilRP.Models;
using RosBilRP.Services;

namespace RosBilRP.SJS
{
    public abstract class OpretPageModelBase<T, RepositoryT> : PageModel
        where T : IHarId
        where RepositoryT : IRepository<T>
    {
    }
}
