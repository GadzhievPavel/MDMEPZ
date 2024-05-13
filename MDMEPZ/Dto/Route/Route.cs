using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDMEPZ.Dto
{
    /// <summary>
    /// Маршрут
    /// </summary>
    public class Route
    {
        public bool OBJECT { get; set; }
        public string NEW { get; set; }
        public bool SAVE { get; set; }
        public bool Предопределенный { get; set; }
        public ReferenceRoute Ссылка { get; set; }
        public bool ПометкаУдаления { get; set; }
        public Owner Владелец { get; set; }
        public Parent Родитель { get; set; }
        public string Наименование { get; set; }
        public string Код { get; set; }
        public int КоличествоНормирования { get; set; }
        public bool Поточный { get; set; }
        public RoutePoint ТочкиМаршрута { get; set; }
    }
}
