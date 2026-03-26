
/// <summary>
/// Klasse som simulerer en UI for en app, hvor alle data fra databasen kan vises.
/// </summary>
public class UI
{
	private DataService _dataService;

	public UI(DataService dataService)
	{
		_dataService = dataService;
	}

	public void VisAlleKunder()
	{
		VisAlle(_dataService.Kunder);
	}

	public void VisAlleBiler()
	{
		VisAlle(_dataService.Biler);
	}

	public void VisAlleUdlejninger()
	{
		VisAlle(_dataService.Udlejninger);
	}
	public void VisAlleMedarbejder()
	{
		VisAlle(_dataService.MedarbejderRepo);
	}

	private void VisAlle<T>(IRepository<T> repo) where T : IHarId
	{
		PageModel<T> pageModel = new PageModel<T>(repo);
		Page<T> page = new Page<T>(pageModel);
		string pageStr = page.Render();

		Vis(pageStr);
	}

	private void Vis(string pageStr)
	{
		Console.WriteLine(pageStr);
	}
}
