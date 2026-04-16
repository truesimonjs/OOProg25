using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RosBilRP.Models;
using RosBilRP.Services;
using RosBilRP.SJS;

namespace RosBilRP.Pages.Biler;

public class OpretModel : OpretPageModelBase<Bil, IBilRepository>
{
    public OpretModel(IBilRepository repo) : base(repo)
    {
    }
}
