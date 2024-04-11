using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDMEPZ.Dto
{
    /// <summary>
    /// Главный класс операции
    /// </summary>
    public class Operation
    {
        public bool OBJECT { get; set; }
        public string NEW { get; set; }
        public bool SAVE { get; set; }
        public bool Предопределенный { get; set; }
        public ReferenceOperation Ссылка { get; set; }
        public bool ПометкаУдаления { get; set; }
        public Route Владелец { get; set; }
        public string Наименование { get; set; }
        public string Код { get; set; }
        public EnterRoute Заход { get; set; }
        public string НомерОперации { get; set; }
        public TypeOperation ВидТехнологическойОперации { get; set; }
        public bool ОтходВПроцентах { get; set; }
        public string ПорядковыйНомер { get; set; }
        public Division Подразделение { get; set; }
        public Region Участок { get; set; }
        public Expenses СтатьяЗатрат { get; set; }
        public bool НеУчитывать { get; set; }
        public MainInputs ОсновныеВходы { get; set; }
        public Executors Исполнители { get; set; }


    }
}
