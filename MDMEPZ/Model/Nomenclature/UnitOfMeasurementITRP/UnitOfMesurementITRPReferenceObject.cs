using MDMEPZ.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFlex.DOCs.Model.References;
using TFlex.DOCs.References.NomenclatureMDM;

namespace MDMEPZ.Model.Nomenclature.UnitOfMeasurementITRP
{
    public class UnitOfMesurementITRPReferenceObject:BaseObjectTFlex
    {
        public UnitOfMesurementITRPReferenceObject(ReferenceObject obj):base(obj)
        {
            
        }

        public string UID
        {
            get
            {
                return obj[NomenclatureITRPReferenceObject.FieldKeysOfListUnitsOfMeasurement.UID].GetString();
            }
            set
            {
                obj[NomenclatureITRPReferenceObject.FieldKeysOfListUnitsOfMeasurement.UID].Value = value;
            }
        }

        public string Name
        {
            get
            {
                return obj[NomenclatureITRPReferenceObject.FieldKeysOfListUnitsOfMeasurement.Name].GetString();
            }
            set
            {
                obj[NomenclatureITRPReferenceObject.FieldKeysOfListUnitsOfMeasurement.Name].Value = value;
            }
        }
    }
}
