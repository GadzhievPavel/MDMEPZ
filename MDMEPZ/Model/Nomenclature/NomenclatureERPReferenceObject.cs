namespace TFlex.DOCs.References.NomenclatureMDM
{
    using System;
    using TFlex.DOCs.Model.References;
    using TFlex.DOCs.Model.Structure;
    using TFlex.DOCs.Model.References.Links;
    using TFlex.DOCs.Model.Classes;
    using TFlex.DOCs.Model.Parameters;
    using TFlex.DOCs.References.NomenclatureERP;
    using MDMEPZ.Dto;
    using TFlex.DOCs.References.GroupFinanceNomenclature;
    using TFlex.DOCs.References.GroupList;
    using TFlex.DOCs.References.CategoryProduct;
    using TFlex.DOCs.References.TypeNomenclatureERP;
    using TFlex.DOCs.References.TypeReproductionERP;
    using TFlex.DOCs.References.UnitOfMeasurement;

    public partial class NomenclatureERPReferenceObject : NomenclatureMDMReferenceObject
    {
        public void Update(Nomenclature nomenclature)
        {
            this.Name.Value = nomenclature.name;
            this.Denotation.Value = nomenclature.denotation;
            this.Weight.Value = nomenclature.weight;
            this.IsTypical.Value = nomenclature.isTypical;
            this.CodeElamed.Value = nomenclature.codeElamed;

            var connection = Reference.Connection;

            var groupFinanceNomenclatureReference = new GroupFinanceNomenclatureReference(connection);
            if(nomenclature.financialGroup is null)
            {
                this.GroupFinanceNomenclature = null;
            }
            else
            {
                this.GroupFinanceNomenclature = groupFinanceNomenclatureReference.FindByGuid1C(new Guid(nomenclature.financialGroup.guid1C));
            }


            var groupListReference = new GroupListReference(connection);
            if (nomenclature.groupOfList is null)
            {
                this.GroupList = null;
            }
            else
            {
                this.GroupList = groupListReference.FindByGuid1C(new Guid(nomenclature.groupOfList.guid1C));
            }



            var categoryProductReference = new CategoryProductReference(connection);
            if(nomenclature.category is null)
            {
                this.ProductCategory = null;
            }
            else
            {
                this.ProductCategory = categoryProductReference.FindByGuid1C(new Guid(nomenclature.category.guid1C));
            }


            var typeNomenclatureReference = new TypeNomenclatureERPReference(connection);
            if(nomenclature.typeNomenclature is null)
            {
                this.TypeNomenclature = null;
            }
            else
            {
                this.TypeNomenclature = typeNomenclatureReference.FindByGuid1C(new Guid(nomenclature.typeNomenclature.guid1C));
            }


            var typeReproduction = new TypeReproductionERPReference(connection);
            if(nomenclature.typeOfReproduction is null)
            {
                this.TypeReproduction = null;
            }
            else
            {
                this.TypeReproduction = typeReproduction.FindByGuid1C(new Guid(nomenclature.typeOfReproduction.guid1C));
            }


            var unitOfMeasurementReference = new UnitOfMeasurementReference(connection);
            if(nomenclature.weightUnitOfMeasurement is null)
            {
                this.UnitOfMeasurementWeight = null;
            }
            else
            {
                this.UnitOfMeasurementWeight = unitOfMeasurementReference.FindByGuid1C(new Guid(nomenclature.weightUnitOfMeasurement.guid1C));
            }

            if(nomenclature.unitOfMeasurement is null)
            {
                this.UnitsOfMeasurement = null;
            }
            else
            {
                this.UnitsOfMeasurement = unitOfMeasurementReference.FindByGuid1C(new Guid(nomenclature.unitOfMeasurement.guid1C));
            }


        }
    }
}
