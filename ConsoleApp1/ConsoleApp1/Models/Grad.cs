using System;
using System.Collections.Generic;

#nullable disable

namespace ConsoleApp1.Models
{
    public partial class Grad
    {
        public Grad()
        {
            Kupacs = new HashSet<Kupac>();
        }

        public int PostanskiBroj { get; set; }
        public int DrzavaId { get; set; }
        public string NazivGrada { get; set; }

        public virtual Drzava Drzava { get; set; }
        public virtual ICollection<Kupac> Kupacs { get; set; }
    }
}
