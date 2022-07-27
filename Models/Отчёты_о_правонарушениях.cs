using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Weapons.Models
{
    public class Отчёты_о_правонарушениях
    {
        [Key]
        public int Номер_отчёта { get; set; }
        public string Вид_правонарушения { get; set; }
        [DisplayFormat(DataFormatString =
        "{0:yyyy.MM.dd}", ApplyFormatInEditMode =
        true)]
        public DateTime Дата_правонарушения { get; set; }
    }
}
