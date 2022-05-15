using System;
using System.Collections.Generic;

#nullable disable

namespace ConsoleApp1.Models
{
    public partial class Kupac
    {
        public int Pib { get; set; }
        public string NazivKupca { get; set; }
        public string UlicaIbroj { get; set; }
        public int DrzavaId { get; set; }
        public int GradId { get; set; }

        public virtual Grad Grad { get; set; }
    }
}
