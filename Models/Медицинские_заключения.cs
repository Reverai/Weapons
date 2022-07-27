using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Weapons.Models
{
    public class Медицинские_заключения
    {
        [Key]
        public int Номер_медицинского_заключения { get; set; }
        public int ID_гражданина { get; set; }
        public int ID_организации { get; set; }
        public string Наличие_противопоказаний_к_владению_оружием { get; set; }
        public string Фамилия_врача { get; set; }
        public string Имя_врача { get; set; }
        public string Отчество_врача { get; set; }
        [DisplayFormat(DataFormatString =
        "{0:yyyy.MM.dd}", ApplyFormatInEditMode =
        true)]
        public DateTime Дата_заключения { get; set; }
        [DisplayFormat(DataFormatString =
        "{0:yyyy.MM.dd}", ApplyFormatInEditMode =
        true)]
        public DateTime Срок_истечения { get; set; }

    }
}
