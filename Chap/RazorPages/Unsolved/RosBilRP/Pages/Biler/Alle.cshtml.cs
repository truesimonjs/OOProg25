using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RosBilRP.Models;
using RosBilRP.Services;
using RosBilRP.SJS;

namespace RosBilRP.Pages.Biler;

public class AlleModel : AllePageModelBase<Bil,IBilRepository>
{
    public AlleModel(IBilRepository repo) : base(repo)
    {
    }


    /// <summary>
    /// Denne metode afgør, om Bil-objektet med det givne id må slettes.
    /// Det må det kun, hvis der ikke er nogle Leje-objekter, der refererer
    /// til det. Det kan vi afgøre ud fra Lejes-property, idet den KUN vil
    /// være tom, hvis ingen Leje-objekter refererer til dette Bil-objekt.
    /// </summary>
    public override bool CanDelete(int id)
	{
		Bil? bil = Data.Find(b => b.Id == id);

		return (bil != null && bil.Lejes.Count == 0);
	}
}
