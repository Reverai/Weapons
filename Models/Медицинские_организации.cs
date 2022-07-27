using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Weapons.Models
{
    public class Медицинские_организации
    {
        [Key]
        public int ID_организации { get; set; }
        public string Наименование_организации { get; set; }
    }
}
