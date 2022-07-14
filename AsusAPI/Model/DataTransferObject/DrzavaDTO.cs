using Model.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DataTransferObject
{
    public class DrzavaDTO
    {
        [Key]
        public int IDDrzave { get; set; }
        public string NazivDrzave { get; set; }
        public List<GradDTO> Gradovi { get; set; }
    }
}
