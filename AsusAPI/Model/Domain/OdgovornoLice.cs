using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    [Table("OdgovornoLice")]
    public class OdgovornoLice
    {
        [Key]
        public int SifraRadnika { get; set; }
        public string ImePrezime { get; set; }
        public string Email { get; set; }
        
        public Trziste Trziste { get; set; }
        public int SifraTrzista { get; set; }
    }
}
