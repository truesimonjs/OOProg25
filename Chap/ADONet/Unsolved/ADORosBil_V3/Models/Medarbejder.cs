using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADORosBil.Models
{
    public class Medarbejder :IHarId
    {
        public int Id { get; set; }
        public string Navn { get; set; } = "Default name";

        public Medarbejder(int id, string navn)
        {
            Id = id; 
            Navn = navn;
        }
        public override string ToString()
        {
            return Navn;
        }

    }
}
