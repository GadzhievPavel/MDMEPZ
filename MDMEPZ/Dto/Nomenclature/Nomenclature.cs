using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFlex.DOCs.References.ApplicabiltyMaterials;
using TFlex.DOCs.References.CategoryProduct;
using TFlex.DOCs.References.GroupList;
using TFlex.DOCs.References.NomenclatureERP;
using TFlex.DOCs.References.TypeNomenclatureERP;
using TFlex.DOCs.References.TypeReproductionERP;
using TFlex.DOCs.References.UnitOfMeasurement;

namespace MDMEPZ.Dto
{
    public class Nomenclature
    {
        public static Nomenclature CreateInstance(NomenclatureERPReferenceObject nomenclatureERP)
        {
            if (nomenclatureERP == null)
            {
                return null;
            }

            var nom = new Nomenclature();
            nom.name = nomenclatureERP.Name;
            nom.denotation = nomenclatureERP.Denotation;
            nom.guid1C = nomenclatureERP.GUID1C.GetString();
            nom.guidTFlex = nomenclatureERP.GUIDTFLEX.GetString();

            List<ApplicationMaterials> listMaterials = new List<ApplicationMaterials>();
            nomenclatureERP.MaterialsUsed.ToList().ForEach(mat => { listMaterials.Add(ApplicationMaterials.CreateInstance(mat as ApplicabiltyMaterialsReferenceObject)); });
            nom.applicationMaterials = listMaterials.ToArray();
            nom.unitOfMeasurement = UnitOfMeasurementFull.CreateInstance(nomenclatureERP.UnitsOfMeasurement as UnitOfMeasurementReferenceObject);
            nom.typeNomenclature = TypeOfNomenclature.CreateInstance(nomenclatureERP.TypeNomenclature as TypeNomenclatureERPReferenceObject);
            nom.groupOfList = GroupOfList.CreateInstance(nomenclatureERP.GroupList as GroupListReferenceObject);
            nom.typeOfReproduction = TypeOfReproduction.CreateInstance(nomenclatureERP.TypeReproduction as TypeReproductionERPReferenceObject);
            nom.category = ProductCategory.CreateInstance(nomenclatureERP.ProductCategory as CategoryProductReferenceObject);

            nom.weight = nomenclatureERP.Weight;
            nom.isTypical = nomenclatureERP.IsTypical;
            nom.codeElamed = nomenclatureERP.CodeElamed;
            nom.weightUnitOfMeasurement = UnitOfMeasurementFull.CreateInstance(nomenclatureERP.UnitOfMeasurementWeight as UnitOfMeasurementReferenceObject);

            return nom;
        }
        public string name { get; set; }
        public string denotation { get; set; }
        public string guid1C { get; set; }
        public string guidTFlex { get; set; }

        //public ApplicationMaterials applicationMaterials { get; set; }
        public ApplicationMaterials[] applicationMaterials {  get; set; }
        public UnitOfMeasurementFull unitOfMeasurement { get; set; }
        public TypeOfNomenclature typeNomenclature { get; set; }
        public GroupOfList groupOfList { get; set; }
        public TypeOfReproduction typeOfReproduction { get; set; }
        public ProductCategory category { get; set; }
        public double weight { get; set; }
        public bool isTypical { get; set; }
        public string codeElamed { get; set; }
        public UnitOfMeasurementFull weightUnitOfMeasurement { get; set; }

        public bool EnableSync()
        {
            Guid guidTFlex = new Guid(this.guidTFlex);

            if(guidTFlex != null && unitOfMeasurement != null && typeNomenclature != null && groupOfList != null && typeOfReproduction != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return name + " " + denotation + " " + guid1C;
        }
    }
}
