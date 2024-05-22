using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFlex.DOCs.References.ApplicabiltyMaterials;
using TFlex.DOCs.References.CategoryProduct;
using TFlex.DOCs.References.GroupFinanceNomenclature;
using TFlex.DOCs.References.GroupList;
using TFlex.DOCs.References.NomenclatureERP;
using TFlex.DOCs.References.TypeNomenclatureERP;
using TFlex.DOCs.References.TypeReproductionERP;
using TFlex.DOCs.References.UnitOfMeasurement;

namespace MDMEPZ.Dto
{
    /// <summary>
    /// DTO номенклатуры ERP
    /// </summary>
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

            //nom.applicationMaterials = ApplicationMaterials.CreateInstance(nomenclatureERP.MaterialUsed as ApplicabiltyMaterialsReferenceObject);
            nom.unitOfMeasurement = UnitOfMeasurementFull.CreateInstance(nomenclatureERP.UnitsOfMeasurement as UnitOfMeasurementReferenceObject);
            nom.typeNomenclature = TypeOfNomenclature.CreateInstance(nomenclatureERP.TypeNomenclature as TypeNomenclatureERPReferenceObject);
            nom.groupOfList = GroupOfList.CreateInstance(nomenclatureERP.GroupList as GroupListReferenceObject);
            nom.typeOfReproduction = TypeOfReproduction.CreateInstance(nomenclatureERP.TypeReproduction as TypeReproductionERPReferenceObject);
            nom.category = ProductCategory.CreateInstance(nomenclatureERP.ProductCategory as CategoryProductReferenceObject);
            nom.financialGroup = GroupFinanceNomenclature.CreateInstance(nomenclatureERP.GroupFinanceNomenclature as GroupFinanceNomenclatureReferenceObject);

            nom.weight = nomenclatureERP.Weight;
            nom.isTypical = nomenclatureERP.IsTypical;
            nom.codeElamed = nomenclatureERP.CodeElamed;
            nom.weightUnitOfMeasurement = UnitOfMeasurementFull.CreateInstance(nomenclatureERP.UnitOfMeasurementWeight as UnitOfMeasurementReferenceObject);

            return nom;
        }
        /// <summary>
        /// Наименование
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// Обозначение
        /// </summary>
        public string denotation { get; set; }
        /// <summary>
        /// Guid 1C
        /// </summary>
        public string guid1C { get; set; }
        /// <summary>
        /// Guid T-FLEX
        /// </summary>
        public string guidTFlex { get; set; }

        //public ApplicationMaterials applicationMaterials { get; set; }
        /// <summary>
        /// Единица измерения
        /// </summary>
        public UnitOfMeasurementFull unitOfMeasurement { get; set; }
        /// <summary>
        /// Тип номенклатуры
        /// </summary>
        public TypeOfNomenclature typeNomenclature { get; set; }
        /// <summary>
        /// Группа списка
        /// </summary>
        public GroupOfList groupOfList { get; set; }
        /// <summary>
        /// Тип воспроизводства
        /// </summary>
        public TypeOfReproduction typeOfReproduction { get; set; }
        /// <summary>
        /// Товарная категория
        /// </summary>
        public ProductCategory category { get; set; }
        /// <summary>
        /// Вес
        /// </summary>
        public double weight { get; set; }
        /// <summary>
        /// Типовое
        /// </summary>
        public bool isTypical { get; set; }
        /// <summary>
        /// Код Еламед
        /// </summary>
        public string codeElamed { get; set; }
        /// <summary>
        /// Единица измерения массы
        /// </summary>
        public UnitOfMeasurementFull weightUnitOfMeasurement { get; set; }
        /// <summary>
        /// Группа финансового учета
        /// </summary>
        public GroupFinanceNomenclature financialGroup { get; set; }

        /// <summary>
        /// Ввозможность выгрузки в 1C
        /// </summary>
        /// <returns></returns>
        public bool EnableSync()
        {
            Guid guidTFlex = new Guid(this.guidTFlex);

            if(guidTFlex != null && unitOfMeasurement != null &&
                typeNomenclature != null && groupOfList != null && 
                typeOfReproduction != null && financialGroup != null)
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
