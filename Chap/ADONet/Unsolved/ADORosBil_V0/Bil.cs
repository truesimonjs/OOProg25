using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADORosBil
{
    internal class Bil
    {
        public int Id { get; }
        public string Nummerplade { get; set; }
        public string Model { get; set; }
        public int PrisPrDag { get; set; }

        public Bil(int id, string nummerplade, string model, int prisPrDag)
        {
            this.Id = id;
            this.Nummerplade = nummerplade;
            this.Model = model;
            this.PrisPrDag = prisPrDag;
        }
        public override string ToString()
        {
            return $"[Bil {Id}] {Model} (Nummerplade: {Nummerplade}), koster {PrisPrDag} kr per dag ";
        }
    }
}
