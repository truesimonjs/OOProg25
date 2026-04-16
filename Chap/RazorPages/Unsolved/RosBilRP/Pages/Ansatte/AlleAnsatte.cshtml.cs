using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RosBilRP.Services;
using RosBilRP.SJS;
using RosBilRP.Models;

namespace RosBilRP.Pages.Ansatte
{
    public class AlleAnsatteModel : AllePageModelBase<Ansat,IAnsatRepository>
    {
        public AlleAnsatteModel(IAnsatRepository repo) : base(repo)
        {
        }

      
    }
}
