using System;
using System.Collections.Generic;

#nullable disable

namespace ConsoleApp1.Models
{
    public partial class Proizvod
    {
        public Proizvod()
        {
            Karakteristikas = new HashSet<Karakteristika>();
        }

        public int ProizvodId { get; set; }
        public string NazivModela { get; set; }

        public virtual ICollection<Karakteristika> Karakteristikas { get; set; }
    }
}
