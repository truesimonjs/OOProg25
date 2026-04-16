using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RosBilRP.Models;
using RosBilRP.Services;
using RosBilRP.SJS;

namespace RosBilRP.Pages.Kunder;

public class SletModel : SletPageModelBase<Kunde, IKundeRepository>
{
    public SletModel(IKundeRepository repo) : base(repo)
    {
    }
}
