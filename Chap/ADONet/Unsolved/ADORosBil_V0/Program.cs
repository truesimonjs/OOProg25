
// 1) DB opsætning
using ADORosBil;
using Microsoft.Data.SqlClient;
using System.Reflection;

internal class Program
{
    private static void Main(string[] args)
    {
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
        builder.DataSource = "(localdb)\\MSSQLLocalDB";
        builder.InitialCatalog = "RosBilDB";



        ReadKunde(builder);
        ReadBil(builder);
        ReadLeje(builder);
    }
    private static void ReadLeje(SqlConnectionStringBuilder builder)
    {
        List<Leje> lejeAftaler = new();
        try
        {
            using SqlConnection connection = new SqlConnection(builder.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand("select * from Leje", connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(reader.GetOrdinal("Id"));
                int bilId = reader.GetInt32(reader.GetOrdinal("BilId"));
                int kundeId = reader.GetInt32(reader.GetOrdinal("KundeId"));
                DateTime date = reader.GetDateTime(reader.GetOrdinal("Dato"));
                int antalDage = reader.GetInt32(reader.GetOrdinal("AntalDage"));
                lejeAftaler.Add(new(id, bilId, kundeId, date, antalDage));
            }

        }
        catch (Exception)
        {

            throw;
        }
        // 3) Udskriv alle lejeaftaler 
        Console.WriteLine($"Alle lejeaftaler ({lejeAftaler.Count} ialt)");
        Console.WriteLine("----------------------------------");
        foreach (Leje leje in lejeAftaler)
        {
            Console.WriteLine(leje);
        }
        Console.WriteLine();


    }
    private static void ReadBil(SqlConnectionStringBuilder builder)
    {
        List<Bil> biler = new List<Bil>();
        try
        {
            using SqlConnection connection = new SqlConnection(builder.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand("select * from Bil", connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(reader.GetOrdinal("Id"));
                string nummerplade = reader.GetString(reader.GetOrdinal("Nummerplade"));
                string model = reader.GetString(reader.GetOrdinal("Model"));
                int prisPrDag = reader.GetInt32(reader.GetOrdinal("PrisPrDag"));
                biler.Add(new Bil(id, nummerplade, model, prisPrDag));
            }
        }
        catch (Exception)
        {

            throw;
        }
        // 3) Udskriv alle biler 
        Console.WriteLine($"Alle biler ({biler.Count} ialt)");
        Console.WriteLine("----------------------------------");
        foreach (Bil bil in biler)
        {
            Console.WriteLine(bil);
        }
        Console.WriteLine();
    }
    private static void ReadKunde(SqlConnectionStringBuilder builder)
    {
        // 2) Læs alle Kunder fra DB
        List<Kunde> kunder = new List<Kunde>();
        try
        {
            // 2a) Etablér DB-forbindelse (med brug af using-syntaksen)
            using SqlConnection connection = new SqlConnection(builder.ConnectionString);
            connection.Open();

            // 2b) Definér og udfør SQL-statement
            SqlCommand cmd = new SqlCommand("SELECT * FROM Kunde", connection);
            SqlDataReader reader = cmd.ExecuteReader();

            // 2c) Processér de læste data
            while (reader.Read())
            {
                int id = reader.GetInt32(reader.GetOrdinal("Id"));
                string navn = reader.GetString(reader.GetOrdinal("Navn"));
                int telefon = reader.GetInt32(reader.GetOrdinal("Telefon"));
                bool vip = reader.GetBoolean(reader.GetOrdinal("VIP"));

                kunder.Add(new Kunde(id, navn, telefon, vip));
            }
        }
        catch (SqlException sqlEx)
        {
            Console.WriteLine($"SqlException under læsning fra DB : {sqlEx.Message}");
        }

        // 3) Udskriv alle Kunder (5 kunder bør blive udskrevet)
        Console.WriteLine($"Alle Kunder ({kunder.Count} ialt)");
        Console.WriteLine("----------------------------------");
        foreach (Kunde kunde in kunder)
        {
            Console.WriteLine(kunde);
        }
        Console.WriteLine();
    }
}
