using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Weapons.Models
{
    public class Адреса_регистрации
    {
        [Key]
        public int Код_адреса { get; set; }
        public string Адрес { get; set; }
        public int ID_гражданина { get; set; }
    }
}
