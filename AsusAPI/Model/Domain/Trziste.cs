using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    [Table("Trziste")]
    public class Trziste
    {
        [Key]
        public int SifraTrzista { get; set; }
        public string NazivTrzista { get; set; }
    }
}
