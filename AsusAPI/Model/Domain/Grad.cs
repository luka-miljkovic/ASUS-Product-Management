using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    [Table("Grad")]
    public class Grad
    {
        //public Grad()
        //{
        //    Kupci = new List<Kupac>();
        //}
        [Column("PostanskiBroj")]
        public int GradId { get; set; }
        public int DrzavaId { get; set; }
        public Drzava Drzava { get; set; }
        public string NazivGrada { get; set; }

        //public List<Kupac> Kupci { get; set; }
    }
}
