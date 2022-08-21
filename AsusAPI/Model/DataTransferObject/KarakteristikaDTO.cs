using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DataTransferObject
{
    public class KarakteristikaDTO
    {
        //[Key]
        public int IDKarakteristike { get; set; }
        //[Key]
        public int SifraProizvoda { get; set; }
        public ProizvodDTO Proizvod { get; set; }
        public double Vrednost { get; set; }
        public string NazivKarakteristike { get; set; }
    }
}
