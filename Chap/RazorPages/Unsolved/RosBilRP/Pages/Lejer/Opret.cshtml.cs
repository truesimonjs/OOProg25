using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RosBilRP.Models;
using RosBilRP.Services;
using RosBilRP.SJS;

namespace RosBilRP.Pages.Lejer;

public class OpretModel : OpretPageModelBase<Leje,ILejeRepository>
{
	


	public SelectList KundeList { get; set; }
	public SelectList BilList { get; set; }

	public OpretModel(
		ILejeRepository repo,
		IKundeRepository kundeRepo,
		IBilRepository bilRepo) : base(repo)
	{
		

		KundeList = new SelectList(kundeRepo.All, nameof(Kunde.Id), nameof(Kunde.Navn));
		BilList = new SelectList(bilRepo.All, nameof(Bil.Id), nameof(Bil.NummerpladeOgModel));

		Element.Dato = DateOnly.FromDateTime(DateTime.Now);
	}

	
}

