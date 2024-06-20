using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFlex.Model.Technology.References.TechnologyElements;

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
        public Owner Владелец { get; set; } //номенклатура 
        public Parent Родитель { get; set; }
        public string Наименование { get; set; }
        public string Код { get; set; }
        public int КоличествоНормирования { get; set; }
        public bool Поточный { get; set; }
        public RoutePoint ТочкиМаршрута { get; set; }

        public static Route CreateInstance(TechRoute routePdm)
        {
            var routeDto = new Route();

            routeDto.Ссылка = new ReferenceRoute();
            routeDto.Ссылка.TYPE = "СправочникСсылка.Маршруты";


            routeDto.Ссылка.UID = null;

            return routeDto;
        }
    }
}
