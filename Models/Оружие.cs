using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Weapons.Models
{
    public class Оружие
    {
        [Key]
        public int Номер_лицензии_на_приобретение_оружия { get; set; }
        public string Серийный_номер { get; set; }
        public int Код_модели { get; set; }
        public string Серия { get; set; }
        [DisplayFormat(DataFormatString =
        "{0:yyyy.MM.dd}", ApplyFormatInEditMode =
        true)]
        public DateTime Год_выпуска { get; set; }
        public int Код_производителя { get; set; }
    }
}
