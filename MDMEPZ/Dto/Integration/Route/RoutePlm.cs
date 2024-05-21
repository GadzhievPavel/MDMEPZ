using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFlex.DOCs.Model;
using TFlex.Model.Technology.References.TechnologyElements;

namespace MDMEPZ.Dto.Integration.Route
{
    /// <summary>
    /// Класс DTO технологического маршрута
    /// </summary>
    public class RoutePlm
    {
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Номер отдела
        /// </summary>
        public string CodeDepartament { get; set; }
        /// <summary>
        /// тип маршрута
        /// </summary>
        public int TypeRoute { get; set; }
        /// <summary>
        /// Единица нормирования
        /// </summary>
        public int AmountNorm { get; set; }
        /// <summary>
        /// Цехопереходы (точки маршрута)
        /// </summary>
        public List<RoutePointPlm> RoutePoints { get; set; }

        public static RoutePlm CreateInstance(ServerConnection connection, TechRoute route)
        {
            var routePlm = new RoutePlm();
            routePlm.Name = route.Name;
            ///Параметр маршрут
            routePlm.CodeDepartament = route[new Guid("da5c50c3-4add-4aea-9e4a-ef2ba4cb3573")].GetString();
            ///Тип воспроизодства
            routePlm.TypeRoute = route[new Guid("c9ed4fca-2cc1-45ef-a1b1-98acd3ef71bd")].GetInt32();

            ///todo
            ///чем заполнять?
            routePlm.AmountNorm = 1;

            var routePoints = route.Children.ToList();
            routePlm.RoutePoints = new List<RoutePointPlm>();
            foreach (var routePoint in routePoints)
            {
                routePlm.RoutePoints.Add(RoutePointPlm.CreateInstance(connection, routePoint));
            }
            
            return routePlm;
        }
    }
}
