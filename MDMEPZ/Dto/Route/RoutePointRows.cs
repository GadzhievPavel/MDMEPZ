﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDMEPZ.Dto
{
    /// <summary>
    /// Строка точки маршрута
    /// </summary>
    public class RoutePointRows
    {
        public int НомерСтроки { get; set;}
        public EnterRoute Заход { get; set; }
    }
}
