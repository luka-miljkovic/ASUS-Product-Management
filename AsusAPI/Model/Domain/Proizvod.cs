using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    [Table("Proizvod")]
    public class Proizvod
    {
        public int ProizvodId { get; set; }
        public string NazivModela { get; set; }
        public List<Karakteristika> Karakteristike { get; set; }
    }
}
