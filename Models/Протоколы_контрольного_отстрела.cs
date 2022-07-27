using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Weapons.Models
{
    public class Протоколы_контрольного_отстрела
    {
        [Key]
        public int Номер_протокола_контрольного_отстрела { get; set; }
        public int Номер_лицензии_на_приобретение_оружия { get; set; }
        public string Номер_воинской_части_или_наименование_организации { get; set; }
        [DisplayFormat(DataFormatString =
        "{0:yyyy.MM.dd}", ApplyFormatInEditMode =
        true)]
        public DateTime Дата_и_время_отстрела { get; set; }
    }
}
