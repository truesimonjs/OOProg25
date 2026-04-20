using RosBilRP.Models;

namespace RosBilRP.Services;

/// <summary>
/// Et "teknologi-neutralt" interface for et repository med 
/// Create/Read/Delete-funktionalitet for objekter af typen T
/// </summary>
public interface IRepository<T> where T : IHarId
{
	/// <summary>
	/// Returnerer alle objekter i repository.
	/// </summary>
	List<T> All { get; }

	/// <summary>
	/// Gemmer det givne objekt i repository, og tildeler det et nyt Id.
	/// </summary>
	/// <returns>Det valgte Id for objektet</returns>
	int Create(T t);

	/// <summary>
	/// Læser det objekt der matcher det givne Id.
	/// </summary>
	/// <returns>Objekt der matcher Id, null hvis ingen objekter matcher.</returns>
	T? Read(int id);

	/// <summary>
	/// Sletter det objekt der matcher det givne Id.
	/// </summary>
	/// <returns>true if et objekt blev slettet, ellers falsefalse</returns>
	bool Delete(int id);
}


// Repository-metoder/properties som er specifikke for en domæne-klasse
// kan tilføjes til disse interfaces.

public interface IKundeRepository : IRepository<Kunde>
{
	List<Kunde> AllVIP { get; }
}

public interface IBilRepository : IRepository<Bil>
{
}

public interface ILejeRepository : IRepository<Leje>
{
}
public interface IAnsatRepository : IRepository<Ansat> 
{ 
}
public interface IOpgaveRepository : IRepository<Opgave>
{

}