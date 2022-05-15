using System;
using System.Collections.Generic;

#nullable disable

namespace ConsoleApp1.Models
{
    public partial class Drzava
    {
        public Drzava()
        {
            Grads = new HashSet<Grad>();
        }

        public int DrzavaId { get; set; }
        public string NazivDrzave { get; set; }

        public virtual ICollection<Grad> Grads { get; set; }
    }
}
