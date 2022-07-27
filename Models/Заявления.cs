using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Weapons.Models
{
    public class Заявления
    {
        [Key]
        public int Номер_заявления { get; set; }
        public string Цель_приобретения_оружия { get; set; }
        public int ID_гражданина { get; set; }
        public string Фото { get; set; }

    }
}
