using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RosBilRP.Models;
using RosBilRP.Services;
using RosBilRP.SJS;

namespace RosBilRP.Pages.Lejer;

public class AlleModel : AllePageModelBase<Leje, ILejeRepository>
{
    public AlleModel(ILejeRepository repo) : base(repo)
    {

    }
}

