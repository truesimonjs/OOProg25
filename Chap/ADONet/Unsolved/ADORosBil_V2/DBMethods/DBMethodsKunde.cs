
using Microsoft.Data.SqlClient;

/// <summary>
/// Klasse til at arbejde med Kunde-tabellen.
/// </summary>
public class DBMethodsKunde : DBMethodsBase<Kunde>
{
	public DBMethodsKunde(string connectionString)
		: base(connectionString, "Kunde", $"(@Id , @Navn, @Telefon, @VIP)")
	{
	}

	protected override Kunde GetRow(SqlDataReader reader)
	{
		int id = reader.GetInt32(reader.GetOrdinal("Id"));
		string navn = reader.GetString(reader.GetOrdinal("Navn"));
		int telefon = reader.GetInt32(reader.GetOrdinal("Telefon"));
		bool vip = reader.GetBoolean(reader.GetOrdinal("VIP"));

		return new Kunde(id, navn, telefon, vip);
	}

	protected override void AddParameterValues(SqlCommand cmd, Kunde kunde)
	{
		cmd.Parameters.AddWithValue("@Id", kunde.Id);
		cmd.Parameters.AddWithValue("@Navn", kunde.Navn);
		cmd.Parameters.AddWithValue("@Telefon", kunde.Telefon);
		cmd.Parameters.AddWithValue("@VIP", kunde.VIP);
	}
	public List<Kunde> GetVipKunde()
	{
		List<Kunde> kunder = ReadAllFromDB();
		kunder.RemoveAll(item => !item.VIP);
		return kunder;
		
	}
}


