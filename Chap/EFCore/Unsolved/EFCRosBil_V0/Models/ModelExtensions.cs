using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


  public partial class Kunde
{
    public override string ToString()
    {
        return $"[Kunde {Id}] {Navn} (tlf: {Telefon}), er {(Vip ? "" : "ikke ")}VIP ";
    }
}
public partial class Bil
{
    public override string ToString()
    {
        return $"[Bil {Id}] {Model}";
    }


}
public partial class Leje
{
    public override string ToString()
    {
        return $"[LejeAftale {Id}] {Kunde.Navn} lejer en {Bil.Model}";
    }
}