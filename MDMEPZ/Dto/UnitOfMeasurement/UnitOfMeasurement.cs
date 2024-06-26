using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFlex.DOCs.References.UnitOfMeasurement;

namespace MDMEPZ.Dto
{
    public class UnitOfMeasurement
    {
        public string name { get; set; }
        public string guid1C { get; set; }

        public static UnitOfMeasurement CreateInstance(UnitOfMeasurementReferenceObject unitMdm) 
        {
            var unitDto = new UnitOfMeasurement();
            unitDto.name = unitMdm.Name;
            unitDto.guid1C = unitDto.guid1C;
            return unitDto;
        }
    }
}
