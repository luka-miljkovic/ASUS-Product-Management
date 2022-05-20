using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DataTransferObject
{
    public class TrzisteDTO
    {
        [Key]
        public int TrzisteId { get; set; }
        public string NazivTrzista { get; set; }
    }
}
