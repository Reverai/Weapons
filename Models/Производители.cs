using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Weapons.Models
{
    public class Производители
    {
        [Key]
        public int Код_производителя { get; set; }
        public string Наименование_производителя { get; set; }
    }
}
