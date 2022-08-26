using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class OdgovornoLice : IdentityUser<int>
    {
        //[Key]
        public int OdgovornoLiceId { get; set; }
        public string ImePrezime { get; set; }
        public string Email { get; set; }
        
        //public Trziste Trziste { get; set; }
        //public int SifraTrzista { get; set; }
    }
}
