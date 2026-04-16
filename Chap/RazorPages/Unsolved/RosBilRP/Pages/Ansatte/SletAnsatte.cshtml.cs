using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RosBilRP.Services;
using RosBilRP.Models;
using RosBilRP.SJS;

namespace RosBilRP.Pages.Ansatte
{
    public class SletAnsatteModel : SletPageModelBase<Ansat, IAnsatRepository>
    {
        public override string ReturnPage => "AlleAnsatte";
        public SletAnsatteModel(IAnsatRepository repo) : base(repo)
        {
        }
    }
}
