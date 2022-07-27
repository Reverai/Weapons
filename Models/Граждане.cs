using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Weapons.Models
{
    public class Граждане
    {
        [Key]
        public int ID_гражданина { get; set; }
        public string Фамилия { get; set; }
        public string Имя { get; set; }
        public string Отчество { get; set; }
        public string Адрес_фактического_проживания { get; set; }
        [DisplayFormat(DataFormatString =
        "{0:yyyy.MM.dd}", ApplyFormatInEditMode =
        true)]
        public DateTime Дата_рождения { get; set; }
        public int Серия_паспорта { get; set; }
        public int Номер_паспорта { get; set; }
        [DisplayFormat(DataFormatString =
        "{0:yyyy.MM.dd}", ApplyFormatInEditMode =
        true)]
        public DateTime Дата_выдачи_паспорта { get; set; }
        public string Кем_выдан_паспорт { get; set; }
        public string Номер_телефона { get; set; }
        public string Номер_СНИЛС { get; set; }
        public string Email { get; set; }

    }
}
