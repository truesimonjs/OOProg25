
// 1) DB opsætning
using Microsoft.Data.SqlClient;

internal class Program
{
    private static void Main(string[] args)
    {
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
        builder.DataSource = "(localdb)\\MSSQLLocalDB";
        builder.InitialCatalog = "RosBilDB";


        ReadKunde(builder);
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
