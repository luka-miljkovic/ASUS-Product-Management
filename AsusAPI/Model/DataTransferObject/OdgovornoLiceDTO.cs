using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DataTransferObject
{
    public class OdgovornoLiceDTO
    {
        //[Key]
        public int OdgovornoLiceId { get; set; }
        public string ImePrezime { get; set; }
        public string Email { get; set; }
        //public TrzisteDTO Trziste { get; set; }
        //public int SifraTrzista { get; set; }
    }
}
