using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Weapons.Models
{
    public class Лицензии_на_хранение_оружия
    {
        [Key]
        public int Номер_лицензии { get; set; }
        public int Номер_лицензии_на_приобретение_оружия { get; set; }
        [DisplayFormat(DataFormatString =
        "{0:yyyy.MM.dd}", ApplyFormatInEditMode =
        true)]
        public DateTime Дата_выдачи { get; set; }
        [DisplayFormat(DataFormatString =
       "{0:yyyy.MM.dd}", ApplyFormatInEditMode =
        true)]
        public DateTime Дата_окончания { get; set; }
        public string Где_выдано { get; set; }
        public string Кем_выдано { get; set; }
        public int ID_места_хранения { get; set; }
    }
}
