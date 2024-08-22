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
    public class UnitITRPReferenceObject : BaseObjectTFlex
    {
        public UnitITRPReferenceObject(ReferenceObject obj) : base(obj)
        {

        }

        public string UID
        {
            get
            {
                return this.obj[NomenclatureITRPReferenceObject.FieldKeysUnits.UID].GetString();
            }
            set
            {
                this.obj[NomenclatureITRPReferenceObject.FieldKeysUnits.UID].Value = value;
            }
        }

        public string Name
        {
            get
            {
                return this.obj[NomenclatureITRPReferenceObject.FieldKeysUnits.Name].GetString();
            }
            set
            {
                this.obj[NomenclatureITRPReferenceObject.FieldKeysUnits.Name].Value = value;
            }
        }

        public double Koeff
        {
            get
            {
                return this.obj[NomenclatureITRPReferenceObject.FieldKeysUnits.UnitOfMeasurementKoeff].GetDouble();
            }
            set
            {
                this.obj[NomenclatureITRPReferenceObject.FieldKeysUnits.UnitOfMeasurementKoeff].Value = value;
            }
        }

        public string Code
        {
            get
            {
                return this.obj[NomenclatureITRPReferenceObject.FieldKeysUnits.UnitOfMeasurementCode].GetString();
            }
            set
            {
                this.obj[NomenclatureITRPReferenceObject.FieldKeysUnits.UnitOfMeasurementCode].Value = value;
            }
        }
    }
}
