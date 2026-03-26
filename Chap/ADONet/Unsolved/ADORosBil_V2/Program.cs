
using Microsoft.Data.SqlClient;

// 1) DB opsætning
SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
builder.DataSource = "(localdb)\\MSSQLLocalDB";
builder.InitialCatalog = "RosBilDB";


// 2) Læs og udskriv alle data fra databasen.
DBMethodsKunde dbMethodsKunde = new DBMethodsKunde(builder.ConnectionString);
List<Kunde> kunder = dbMethodsKunde.ReadAllFromDB();
Helpers.PrintList(kunder);

DBMethodsBil dbMethodsBil = new DBMethodsBil(builder.ConnectionString);
List<Bil> biler = dbMethodsBil.ReadAllFromDB();
Helpers.PrintList(biler);

DBMethodsLeje dbMethodsLeje = new DBMethodsLeje(builder.ConnectionString, dbMethodsBil, dbMethodsKunde);
//DBMethodsLejeJoin dbMethodsLeje = new DBMethodsLejeJoin(builder.ConnectionString);
List<Leje> lejer = dbMethodsLeje.ReadAllFromDB();
Helpers.PrintList(lejer);


// 3) Opret to nye Kunder, og tilføj dem til DB
Kunde k1 = new Kunde(0, "Finn", 19283746, false);
Kunde k2 = new Kunde(0, "Gina", 90705030, true);

int k1Id = dbMethodsKunde.WriteToDB(k1);
int k2Id = dbMethodsKunde.WriteToDB(k2);


// 4) Læs alle Kunder fra DB og udskriv dem (bør udskrive 7 Kunder)
kunder = dbMethodsKunde.ReadAllFromDB();
Helpers.PrintList(kunder);


// 5) Slet de Kunder som lige er blevet oprettet
dbMethodsKunde.DeleteFromDB(k1Id);
dbMethodsKunde.DeleteFromDB(k2Id);


// 6) Læs alle Kunder fra DB og udskriv dem (bør udskrive 5 Kunder)
kunder = dbMethodsKunde.ReadAllFromDB();
Helpers.PrintList(kunder);


// 7) Opret to nye Leje-objekter, og tilføj dem til DB
Leje l1 = Helpers.CreateLeje(0, 2, 3, new DateOnly(2025, 3, 22), 5, dbMethodsKunde, dbMethodsBil);
Leje l2 = Helpers.CreateLeje(0, 4, 2, new DateOnly(2025, 3, 23), 4, dbMethodsKunde, dbMethodsBil);

int l1Id = dbMethodsLeje.WriteToDB(l1);
int l2Id = dbMethodsLeje.WriteToDB(l2);


// 8) Læs alle Leje-objekter fra DB og udskriv dem (bør udskrive 10 Leje-objekter)
lejer = dbMethodsLeje.ReadAllFromDB();
Helpers.PrintList(lejer);


// 9) Slet de Leje-objekter som lige er blevet oprettet
dbMethodsLeje.DeleteFromDB(l1Id);
dbMethodsLeje.DeleteFromDB(l2Id);


// 10) Læs alle Leje-objekter fra DB og udskriv dem (bør udskrive 8 Leje-objekter)
lejer = dbMethodsLeje.ReadAllFromDB();
Helpers.PrintList(lejer);
Helpers.PrintList(dbMethodsKunde.GetVipKunde());
