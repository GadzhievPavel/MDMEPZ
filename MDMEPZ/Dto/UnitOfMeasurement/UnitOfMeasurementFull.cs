using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFlex.DOCs.References.UnitOfMeasurement;

namespace MDMEPZ.Dto
{
    public class UnitOfMeasurementFull
    {
        public static UnitOfMeasurementFull CreateInstance(UnitOfMeasurementReferenceObject unitRefObj)
        {
            if (unitRefObj == null) return null;

            var unit = new UnitOfMeasurementFull();
            unit.name = unitRefObj.Name;
            unit.guid1C = unitRefObj.GUID_1C.GetString();
            unit.guidTFlex = unitRefObj.Guid.ToString();
            return unit;
        }
        public string name { get; set; }
        public string guid1C { get; set; }
        public string guidTFlex { get; set;}
    }
}
