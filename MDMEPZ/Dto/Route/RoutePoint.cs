using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    /// <summary>
    /// Точка маршрута
    /// </summary>
    public class RoutePoint
    {
        public string TYPE { get; set; }
        public RoutePointColumns COLUMNS { get; set; }
        public List<RoutePointRows> ROWS { get; set; } 

    }
}
