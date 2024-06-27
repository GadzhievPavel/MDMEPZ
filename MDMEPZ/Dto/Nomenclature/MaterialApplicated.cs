using MDMEPZ.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFlex.DOCs.Model;
using TFlex.DOCs.Model.References;
using TFlex.DOCs.Model.References.Materials;
using TFlex.DOCs.References.NomenclatureERP;
using TFlex.DOCs.References.UnitOfMeasurement;
using TFlex.Model.Technology.References.Materials;

namespace MDMEPZ.Dto
{
    /// <summary>
    /// Материал с указанием применяемости
    /// </summary>
    public class MaterialApplicated
    {
        public Nomenclature nomenclature { get; set; }
        public Double amount { get; set; }

        public int rationingUnit { get; set; }
        public UnitOfMeasurement unitOfMeasurement { get; set; }

        public static MaterialApplicated CreateInstance(ServerConnection connection, TechnologicalProcessMaterial materialTp)
        {
            var materialApplicated = new MaterialApplicated();

            var material = materialTp.GetMaterial();
            if (material == null)
            {
                throw new ExceptionIntegration($"материал ТП {materialTp} не связан с материалом в справочнике \"Материалы\"");
            }
            var materialNom = (material as MaterialReferenceObject).GetLinkedNomenclatureObject();
            var materialMdm = materialNom.GetObject(NomenclatureERPReferenceObject.RelationKeys.Nomenclature) as NomenclatureERPReferenceObject;
            if (materialMdm == null)
            {
                throw new ExceptionIntegration($"материал ТП {materialNom} не имеет представление в MDM");
            }
            materialApplicated.nomenclature = Nomenclature.CreateInstance(materialMdm);

            materialApplicated.rationingUnit = materialTp.RationingUnit.Value;

            var unit = materialTp.GetUnits();
            var unitOfMeasurement = new UnitOfMeasurementReference(connection);
            var unitMdm = unitOfMeasurement.FindByObjectTFlex(unit) as UnitOfMeasurementReferenceObject;

            materialApplicated.unitOfMeasurement = UnitOfMeasurement.CreateInstance(unitMdm);

            materialApplicated.amount = materialTp.DefaultRate.Value;
            return materialApplicated;
        }
    }
}
