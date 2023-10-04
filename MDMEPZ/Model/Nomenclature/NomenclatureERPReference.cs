namespace TFlex.DOCs.References.NomenclatureERP{
    using System;
    using TFlex.DOCs.Model.References;
    using TFlex.DOCs.Model.Structure;
    using TFlex.DOCs.Model.Classes;
    using TFlex.DOCs.Model;
    using System.Collections.Generic;
    using TFlex.DOCs.Model.Search;
    using MDMEPZ.Dto;
    using TFlex.DOCs.References.GroupList;
    using MDMEPZ.Util;
    using TFlex.DOCs.References.CategoryProduct;
    using TFlex.DOCs.References.TypeReproductionERP;
    using TFlex.DOCs.References.TypeNomenclatureERP;
    using TFlex.DOCs.References.UnitOfMeasurement;

    public partial class NomenclatureERPReference : SpecialReference<NomenclatureERPReferenceObject>
    {

        public partial class Factory
        {
        }

        public ReferenceObject CreateReferenceObject(Product product)
        {
            var o = CreateReferenceObject() as NomenclatureERPReferenceObject;
            o.StartUpdate();
            o.Name.Value = product.name;
            o.GUID1C.Value = new Guid(product.guid1C);
            o.Denotation.Value = product.denotation;
            o.Weight.Value = product.weight;

            o.ProductCategory = getProductCategoryByGuid1C(new Guid(product.category.guid1C));
            o.GroupList = getGroupListByGuid1C(new Guid(product.groupOfList.guid1C));
            o.TypeReproduction = getTypeReproductionByGuid1C(new Guid(product.typeOfReproduction.guid1C));
            o.TypeNomenclature = getTypeNomenclatureByGuid1C(new Guid(product.typeNomenclature.guid1C));
            o.UnitsOfMeasurement = getUnitsOfMeasurementByGuid1C(new Guid(product.unitOfMeasurement.guid1C));
            return o;
        }

        public List<ReferenceObject> findObjectsByDenotation(String denotation)
        {
            return Find(getFilterNomenclatureByDenotation(denotation));
        }

        public List<ReferenceObject> findObjectsByName(String name)
        {
            return Find(getFilterNomenclatureByName(name));
        }
        private Filter getFilterNomenclatureByDenotation(String denotation)
        {
            Filter filter = new Filter(ParameterGroup);
            ReferenceObjectTerm term = new ReferenceObjectTerm(filter.Terms);
            term.Path.AddParameter(ParameterGroup.Parameters.Find(NomenclatureERPReferenceObject.FieldKeys.Denotation));
            term.Operator = ComparisonOperator.Equal;
            term.Value = denotation;
            filter.Validate();
            return filter;
        }

        private Filter getFilterNomenclatureByName(String name)
        {
            Filter filter = new Filter(ParameterGroup);
            ReferenceObjectTerm term = new ReferenceObjectTerm(filter.Terms);
            term.Path.AddParameter(ParameterGroup.Parameters.Find(NomenclatureERPReferenceObject.FieldKeys.Name));
            term.Operator = ComparisonOperator.Equal;
            term.Value = name;
            filter.Validate();
            return filter;
        }

        private ReferenceObject getProductCategoryByGuid1C(Guid guid)
        {
            var categoryProductReference = this.Connection.ReferenceCatalog.Find(CategoryProductReference.ReferenceId).CreateReference() as CategoryProductReference;
            return categoryProductReference.FindByGuid1C(guid);
        }

        private ReferenceObject getGroupListByGuid1C(Guid guid)
        {
            var groupListReference = this.Connection.ReferenceCatalog.Find(GroupListReference.ReferenceId).CreateReference() as GroupListReference;
            return groupListReference.FindByGuid1C(guid);
        }

        private ReferenceObject getTypeReproductionByGuid1C(Guid guid)
        {
            var typeOfReproductionReference = this.Connection.ReferenceCatalog.Find(TypeReproductionERPReference.ReferenceId).CreateReference() as TypeReproductionERPReference;
            return typeOfReproductionReference.FindByGuid1C(guid);

        }

        private ReferenceObject getTypeNomenclatureByGuid1C(Guid guid)
        {
            var typeNomenclatureReference = this.Connection.ReferenceCatalog.Find(TypeNomenclatureERPReference.ReferenceId).CreateReference() as TypeNomenclatureERPReference;
            return typeNomenclatureReference.FindByGuid1C(guid);
        }

        private ReferenceObject getUnitsOfMeasurementByGuid1C(Guid guid)
        {
            var unitOfMeasurementReference = this.Connection.ReferenceCatalog.Find(UnitOfMeasurementReference.ReferenceId).CreateReference() as UnitOfMeasurementReference;
            return unitOfMeasurementReference.FindByGuid1C(guid);
        }

        
    }}