using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ADORosBil
{
    internal class Leje
    {
        public int Id { get; }
        public string KundeNavn { get; set; }
        
        public string BilModel { get; set; }

        public DateTime Date { get; set; } //not sure about datatype

        public int AntalDage { get; set; }

        public Leje(int id,string kundeNavn, string bilModel, DateTime date,int antalDage)
        {
            this.Id = id;
            this.KundeNavn = kundeNavn;
            this.BilModel = bilModel;
            this.Date = date;
            this.AntalDage = antalDage;
        }

        public override string ToString()
        {
            return $"[LejeAftale {Id}] {KundeNavn} har lejet {BilModel} i {AntalDage} dage";
        }
    }
}
