using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RosBilRP.Models;
using RosBilRP.Services;
using RosBilRP.SJS;

namespace RosBilRP.Pages.Lejer;

public class SletModel : SletPageModelBase<Leje, ILejeRepository>
{
    public SletModel(ILejeRepository repo) : base(repo)
    {
    }
}
