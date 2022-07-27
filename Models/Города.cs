using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Weapons.Models
{
    public class Города
    {
        [Key]
        public int Код_города { get; set; }
        public string Город { get; set; }
        public string Область { get; set; }
    }
}
