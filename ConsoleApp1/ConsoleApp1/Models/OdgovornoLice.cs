using System;
using System.Collections.Generic;

#nullable disable

namespace ConsoleApp1.Models
{
    public partial class OdgovornoLice
    {
        public int SifraRadnika { get; set; }
        public string ImePrezime { get; set; }
        public string Email { get; set; }
        public int SifraTrzista { get; set; }

        public virtual Trziste SifraTrzistaNavigation { get; set; }
    }
}
