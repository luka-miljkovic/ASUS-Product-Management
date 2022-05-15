using System;
using System.Collections.Generic;

#nullable disable

namespace ConsoleApp1.Models
{
    public partial class Trziste
    {
        public Trziste()
        {
            OdgovornoLices = new HashSet<OdgovornoLice>();
        }

        public int SifraTrzista { get; set; }
        public string NazivTrzista { get; set; }

        public virtual ICollection<OdgovornoLice> OdgovornoLices { get; set; }
    }
}
