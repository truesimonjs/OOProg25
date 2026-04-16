using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RosBilRP.Models;
using RosBilRP.Services;
using RosBilRP.SJS;

namespace RosBilRP.Pages.Kunder;

public class AlleModel : AllePageModelBase<Kunde,IKundeRepository>
{
    public AlleModel(IKundeRepository repo) : base(repo)
    {
    }

    /*
private IKundeRepository _repo;

public List<Kunde> Data { get; private set; }

public AlleModel(IKundeRepository repo)
{
    _repo = repo;
}

public void OnGet()
{
    Data = _repo.All;
}

/// <summary>
/// Denne metode afgør, om Kunde-objektet med det givne id må slettes.
/// Det må det kun, hvis der ikke er nogle Leje-objekter, der refererer
/// til det. Det kan vi afgøre ud fra Lejes-property, idet den KUN vil
/// være tom, hvis ingen Leje-objekter refererer til dette Kunde-objekt.
/// </summary>

 */
    public override bool CanDelete(int id)
	{
		Kunde? kunde = Data.Find(k => k.Id == id);

		return (kunde != null && kunde.Lejes.Count == 0);
	}
}
