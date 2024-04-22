using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDMEPZ.Dto.AnotherDto.Division
{
    /// <summary>
    /// Класс отдельной загрузки Подразделений
    /// </summary>
    public class AnotherDivision
    {
        public ReferenceAnotherDevision Ссылка { get; set; }
        public string Наименование { get; set; }
        public string Код { get; set; }
        public string НомерЦеха { get; set; }
    }
}
