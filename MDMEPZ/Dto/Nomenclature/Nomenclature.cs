using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFlex.DOCs.References.NomenclatureERP;

namespace MDMEPZ.Dto
{
    public class Nomenclature
    {
        public static Nomenclature CreateInstance(NomenclatureERPReferenceObject nomenclatureERP)
        {
            var nom = new Nomenclature();
            nom.name = nomenclatureERP.Name;
            nom.denotation = nomenclatureERP.Denotation;
            nom.guid1C = nomenclatureERP.GUID1C.GetString();
            nom.guidTFlex = nomenclatureERP.GUIDTFLEX.GetString();

            nom.applicationMaterials = nomenclatureERP.MaterialUsed;

            
        }
        public string name { get; set; }
        public string denotation { get; set; }
        public string guid1C { get; set; }
        public string guidTFlex { get; set; }

        public ApplicationMaterials applicationMaterials { get; set; }
        public UnitOfMeasurementFull unitOfMeasurement { get; set; }
        public TypeOfNomenclature typeNomenclature { get; set; }
        public GroupOfList groupOfList { get; set; }
        public TypeOfReproduction typeOfReproduction { get; set; }
        public ProductCategory category { get; set; }
        public double weight { get; set; }
        public bool isTypical { get; set; }
        public string codeElamed { get; set; }
        public UnitOfMeasurementFull weightUnitOfMeasurement {  get; set; }

        public override string ToString()
        {
            return name+" "+denotation+" "+ guid1C;
        }
    }
}
