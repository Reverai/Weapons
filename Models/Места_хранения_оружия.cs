using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Weapons.Models
{
    public class Места_хранения_оружия
    {
        [Key]
        public int ID_места_хранения { get; set; }
        public string Район { get; set; }
        public string Дом { get; set; }
        public string Улица { get; set; }
        public string Квартира { get; set; }
        public int Код_города { get; set; }
    }
}
