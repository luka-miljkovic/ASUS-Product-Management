using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    [Table("Kupac")]
    public class Kupac
    {
        [Key]
        public int PIB { get; set; }
        public string NazivKupca { get; set; }
        public string UlicaIBroj { get; set; }

        public int DrzavaId { get; set; }
        public int GradId { get; set; }
        
        //public Grad? Grad { get; set; }
        

    }
}
