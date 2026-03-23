
using Microsoft.Data.SqlClient;

internal class Program
{
    private static void Main(string[] args)
    {
        // 1) DB opsætning - NB: Behøves kun een gang,
        //    ligemeget hvor mange tabeller vi arbejder med.
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
        builder.DataSource = "(localdb)\\MSSQLLocalDB";
        builder.InitialCatalog = "RosBilDB";


        // 2) - 6) Benyt Kunde-tabel

        // 2) Læs alle Kunder fra DB og udskriv dem (bør udskrive 5 Kunder)
        DBMethodsKunde dbMethodsKunde = new DBMethodsKunde(builder.ConnectionString);
        List<Kunde> kunder = dbMethodsKunde.ReadAllFromDB();
        Helpers.PrintList("Kunde", kunder);


        // 3) Opret to nye Kunder, og tilføj dem til DB
        int maxId = Helpers.FindMaxId(kunder);

        Kunde k1 = new Kunde(maxId + 1, "Finn", 19283746, false);
        Kunde k2 = new Kunde(maxId + 2, "Gina", 90705030, true);

        dbMethodsKunde.WriteToDB(k1);
        dbMethodsKunde.WriteToDB(k2);


        // 4) Læs alle Kunder fra DB og udskriv dem (bør udskrive 7 Kunder)
        kunder = dbMethodsKunde.ReadAllFromDB();
        Helpers.PrintList("Kunde", kunder);


        // 5) Slet de Kunder som lige er blevet oprettet
        dbMethodsKunde.DeleteFromDB(k1.Id);
        dbMethodsKunde.DeleteFromDB(k2.Id);


        // 6) Læs alle Kunder fra DB og udskriv dem (bør udskrive 5 Kunder)
        kunder = dbMethodsKunde.ReadAllFromDB();
        Helpers.PrintList("Kunde", kunder);
    }
}