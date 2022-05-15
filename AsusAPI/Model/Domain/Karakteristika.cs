using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    [Table("Karakteristika")]
    public class Karakteristika
    {
        //[Key]
        public int KarakteristikaId { get; set; }
        public int ProizvodId { get; set; }
        public Proizvod Proizvod { get; set; }
        public double Vrednost { get; set; }
        public string NazivKarakteristike { get; set; }
    }
}
