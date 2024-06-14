using MDMEPZ.Dto.AnotherDto.Division;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDMEPZ.Dto
{
    public class Visit
    {
        public bool OBJECT { get; set; }
        public string NEW { get; set; }
        public bool SAVE { get; set; }
        public bool Предопределенный { get; set; }
        public LinkVisit Ссылка { get; set; }
        public bool ПометкаУдаления { get; set; }
        public OwnerVisit Владелец { get; set; }
        public string Наименование { get; set; }
        public string Код { get; set; }
        public string НаименованиеКраткое { get; set; }
        public ReferenceAnotherDevision Подразделение { get; set; }
        public Region Участок { get; set; }
    }
}
