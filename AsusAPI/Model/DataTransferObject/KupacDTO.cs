using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DataTransferObject
{
    public class KupacDTO
    {
        [Key]
        public int PIB { get; set; }
        public string NazivKupca { get; set; }
        public string UlicaBroj { get; set; }
        public int IDDrzave { get; set; }
        public int PostanskiBroj { get; set; }
        public GradDTO Grad { get; set; }
        public DrzavaDTO Drzava { get; set; }
    }
}
