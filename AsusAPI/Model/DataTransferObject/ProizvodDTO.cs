using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DataTransferObject
{
    public class ProizvodDTO
    {
        [Key]
        public int SifraProizvoda { get; set; }
        public string NazivModela { get; set; }
        public List<KarakteristikaDTO> Karakteristike { get; set; }
    }
}
