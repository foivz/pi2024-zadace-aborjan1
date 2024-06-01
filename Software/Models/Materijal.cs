using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecycloSmart.Models
{
    public abstract class Materijal
    {
        public string Naziv {  get; set; }
        public int Kolicina { get; set; }
        public string Vrsta { get; set; }
        public int Datum { get; set; }


    }
}
