using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RosBilRP.Models;
using RosBilRP.Services;
using RosBilRP.SJS;

namespace RosBilRP.Pages.Ansatte
{
    public class OpretAnsatteModel : OpretPageModelBase<Ansat,IAnsatRepository>
    {
        public override string ReturnPage => "AlleAnsatte";
        public OpretAnsatteModel(IAnsatRepository repo) : base(repo)
        {
        }

        public void OnGet()
        {
        }
    }
}
