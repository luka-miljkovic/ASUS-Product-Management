using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DataTransferObject
{
    public class GradDTO
    {
        [Key]
        public int PostanskiBroj { get; set; }
        [Key]
        public int IDDrzave { get; set; }
        public DrzavaDTO Drzava { get; set; }
        public string NazivGrada { get; set; }

        public List<KupacDTO> Kupci = new List<KupacDTO>();
    }
}
