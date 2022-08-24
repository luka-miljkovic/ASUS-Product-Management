using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Model.Domain
{
    [Table("Grad")]
    public class Grad
    {
        public int PostanskiBroj { get; set; }
        public int IDDrzave { get; set; }
        [JsonIgnore]
        public Drzava Drzava { get; set; }
        public string NazivGrada { get; set; }

        //public List<Kupac> Kupci = new List<Kupac>();
    }
}
