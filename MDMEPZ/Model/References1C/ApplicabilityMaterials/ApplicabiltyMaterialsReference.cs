namespace TFlex.DOCs.References.ApplicabiltyMaterials{
    using System;
    using TFlex.DOCs.Model.References;
    using TFlex.DOCs.Model.Structure;
    using TFlex.DOCs.Model.Classes;
    using TFlex.DOCs.Model;
    using MDMEPZ.Dto;
    using TFlex.DOCs.References.NomenclatureERP;
    using TFlex.DOCs.References.UnitOfMeasurement;
    using MDMEPZ.Util;

    public partial class ApplicabiltyMaterialsReference : SpecialReference<ApplicabiltyMaterialsReferenceObject>
    {
        private NomenclatureERPReference nomErpReference;
        private UnitOfMeasurementReference unitOfMeasurementReference;
        public partial class Factory
        {
        }

        private void loadSupportReference()
        {
            nomErpReference = Connection.ReferenceCatalog.Find(NomenclatureERPReference.ReferenceId).CreateReference() as NomenclatureERPReference;
            unitOfMeasurementReference = Connection.ReferenceCatalog.Find(UnitOfMeasurementReference.ReferenceId).CreateReference() as UnitOfMeasurementReference;
        }
        public ReferenceObject CreateReferenceObject(ApplicationMaterials material)
        {
            var appMaterial = CreateReferenceObject() as ApplicabiltyMaterialsReferenceObject;
            appMaterial.Amount.Value = material.amount;
            appMaterial.Material = nomErpReference.findObjectByGuid1C(material.material);
            appMaterial.UnitsOfMeasurement = unitOfMeasurementReference.FindByName(material.unitOfMeasurement);
            appMaterial.EndUpdate("");
            return appMaterial;

        }
    }}