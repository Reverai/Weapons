using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Weapons.Models
{
    public class Модели
    {
        [Key]
        public int Код_модели { get; set; }
        public string Модель { get; set; }
        public string Калибр { get; set; }
        public string Тип { get; set; }
    }
}
