

// 1) Opret et context-objekt

using Microsoft.EntityFrameworkCore;

using RosBilDBContext context = new RosBilDBContext();



Console.WriteLine();


// Læs alle Kunder fra databasen, og udskriv dem (bør udskrive 5 kunder)
foreach (var obj in context.Set<Kunde>())
{
	Console.WriteLine(obj);
}

Console.WriteLine();
foreach (var obj in context.Set<Bil>())
{
    Console.WriteLine(obj);
}

Console.WriteLine();
foreach (var obj in context.Set<Leje>().Include(I=>I.Kunde).Include(I=>I.Bil))
{
    Console.WriteLine(obj);
}

Console.WriteLine();

