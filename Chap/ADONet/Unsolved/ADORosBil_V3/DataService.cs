
using ADORosBil.Models;
using ADORosBil.Repositories;
using Microsoft.Data.SqlClient;

/// <summary>
/// Denne klasse giver en samlet adgang til alle repositories, 
/// og dermed til alle data i databasen.
/// </summary>
public class DataService
{
	public IRepository<Kunde> Kunder { get; }
	public IRepository<Bil> Biler { get; }
	public IRepository<Leje> Udlejninger { get; }
	public IRepository<Medarbejder> MedarbejderRepo { get; }

	public DataService(string dataSource, string initialCatalog)
	{
		// Setup DB
		SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
		builder.DataSource = dataSource;
		builder.InitialCatalog = initialCatalog;

		// Map repository-interfaces til konkrete implementationer
		Kunder = new KundeRepository(builder.ConnectionString);
		Biler = new BilRepository(builder.ConnectionString);
		Udlejninger = new LejeRepository(builder.ConnectionString);
		MedarbejderRepo = new MedarbejderRepository(builder.ConnectionString);
	}
}
