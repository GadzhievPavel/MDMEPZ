using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDMEPZ.Dto.ITRP
{
    public class FullUnitOfMeasurementItrp
    {
        public string UID { get; set; }
        public string ЕдиницыИзмеренияКод {  get; set; }
        public string ЕдиницыИзмеренияНаименование {  get; set; }
        public double ЕдиницыИзмеренияКоэффициент { get; set; }
    }
}
