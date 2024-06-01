using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RecycloSmart.Models
{
    public class Radnik
    {
        public int Id {  get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
    }
}
