using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    [Table("Drzava")]
    public class Drzava
    {
        [Key]
        public int IDDrzave { get; set; }
        public string NazivDrzave { get; set; }
        public List<Grad> Gradovi = new List<Grad>();
        public List<Kupac> Kupci = new List<Kupac>();
    }
}
