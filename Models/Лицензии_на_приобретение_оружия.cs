using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Weapons.Models
{
    public class Лицензии_на_приобретение_оружия
    {
        [Key]
        public int Номер_лицензии_на_приобретение_оружия { get; set; }
        public int ID_гражданина { get; set; }
        public string Наименование_организации { get; set; }
        [DisplayFormat(DataFormatString =
        "{0:yyyy.MM.dd}", ApplyFormatInEditMode =
        true)]
        public DateTime Дата_выдачи { get; set; }
        [DisplayFormat(DataFormatString =
       "{0:yyyy.MM.dd}", ApplyFormatInEditMode =
        true)]
        public DateTime Дата_истечения { get; set; }
        [DisplayFormat(DataFormatString =
       "{0:yyyy.MM.dd}", ApplyFormatInEditMode =
        true)]
        public DateTime Дата_приобретения { get; set; }
    }
}
