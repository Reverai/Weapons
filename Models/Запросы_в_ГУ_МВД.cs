using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Weapons.Models
{
    public class Запросы_в_ГУ_МВД
    {
        [Key]
        public int Номер_запроса_в_ГУ_МВД { get; set; }
        [DisplayFormat(DataFormatString =
        "{0:yyyy.MM.dd}", ApplyFormatInEditMode =
        true)]
        public DateTime Дата_запроса { get; set; }
        public int Номер_отчёта { get; set; }
        public int ID_гражданина { get; set; }
    }
}
