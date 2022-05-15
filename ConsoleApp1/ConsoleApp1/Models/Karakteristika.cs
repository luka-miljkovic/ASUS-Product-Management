using System;
using System.Collections.Generic;

#nullable disable

namespace ConsoleApp1.Models
{
    public partial class Karakteristika
    {
        public int KarakteristikaId { get; set; }
        public int ProizvodId { get; set; }
        public double Vrednost { get; set; }
        public string NazivKarakteristike { get; set; }

        public virtual Proizvod Proizvod { get; set; }
    }
}
