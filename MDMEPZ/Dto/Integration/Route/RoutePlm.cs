using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFlex.Model.Technology.References.TechnologyElements;

namespace MDMEPZ.Dto.Integration.Route
{
    public class RoutePlm
    {
        public string Name { get; set; }
        public string CodeDepartament { get; set; }
        public int TypeRoute { get; set; }
        public int AmountNorm { get; set; }
        public List<RoutePointPlm> RoutePoints { get; set; }

        public static RoutePlm CreateInstance(TechRoute route)
        {
            var routePlm = new RoutePlm();
            routePlm.Name = route.Name;
            ///Параметр маршрут
            routePlm.CodeDepartament = route[new Guid("da5c50c3-4add-4aea-9e4a-ef2ba4cb3573")].GetString();
            ///Тип воспроизодства
            routePlm.TypeRoute = route[new Guid("c9ed4fca-2cc1-45ef-a1b1-98acd3ef71bd")].GetInt32();

            routePlm.AmountNorm = 1;

            var routePoints = route.Children.ToList();
            routePlm.RoutePoints = new List<RoutePointPlm>();
            foreach (var routePoint in routePoints)
            {
                routePlm.RoutePoints.Add();
            }
            
        }
    }
}
