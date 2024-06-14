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
    using System.Linq;
    using TFlex.DOCs.Model.Parameters;
    using TFlex.DOCs.References.ApplicabiltyMaterials;
    using TFlex.DOCs.Model.References.Nomenclature;
    using TFlex.DOCs.References.GroupFinanceNomenclature;
    using MDMEPZ.Exception;

    public partial class NomenclatureERPReference : SpecialReference<NomenclatureERPReferenceObject>
    {

        private CategoryProductReference categoryProductReference;
        private GroupListReference groupListReference;
        private TypeReproductionERPReference typeReproductionERPReference;
        private TypeNomenclatureERPReference typeNomenclatureERPReference;
        private UnitOfMeasurementReference unitOfMeasurementReference;
        private GroupFinanceNomenclatureReference groupFinanceNomenclatureReference;

        public partial class Factory
        {
        }

        private void loadSupportReference()
        {
            categoryProductReference = this.Connection.ReferenceCatalog.Find(CategoryProductReference.ReferenceId).CreateReference() as CategoryProductReference;
            groupListReference = this.Connection.ReferenceCatalog.Find(GroupListReference.ReferenceId).CreateReference() as GroupListReference;
            typeReproductionERPReference = this.Connection.ReferenceCatalog.Find(TypeReproductionERPReference.ReferenceId).CreateReference() as TypeReproductionERPReference;
            typeNomenclatureERPReference = this.Connection.ReferenceCatalog.Find(TypeNomenclatureERPReference.ReferenceId).CreateReference() as TypeNomenclatureERPReference;
            unitOfMeasurementReference = this.Connection.ReferenceCatalog.Find(UnitOfMeasurementReference.ReferenceId).CreateReference() as UnitOfMeasurementReference;
            groupFinanceNomenclatureReference = this.Connection.ReferenceCatalog.Find(GroupFinanceNomenclatureReference.ReferenceId).CreateReference() as GroupFinanceNomenclatureReference;
        }

        public ReferenceObject CreateReferenceObject(NomenclatureObject nom)
        {
            var filter = Filter.Parse($"[GUID(T-FLEX)] = '{nom.Guid}'", ParameterGroup);
            if (Find(filter).Any())
            {
                throw new ExceptionMDM("Объект с таким guid уже существует");
            }
            var erpObject = CreateReferenceObject() as NomenclatureERPReferenceObject;

            erpObject.StartUpdate();
            erpObject.Denotation.Value = nom.Denotation;
            erpObject.Name.Value = nom.Name;
            erpObject.GUIDTFLEX.Value = nom.SystemFields.Guid;
            erpObject.Weight.Value = nom.Mass;
            erpObject.EndUpdate("");

            erpObject.StartUpdate();
            erpObject.Nomenclature = nom;
            erpObject.EndUpdate("");

            return erpObject;
        }

        public ReferenceObject CreateReferenceObject(Nomenclature product)
        {

            var o = CreateReferenceObject() as NomenclatureERPReferenceObject;
            o.StartUpdate();
            o.Name.Value = product.name;
            o.GUID1C.Value = new Guid(product.guid1C);
            o.IsTypical.Value = product.isTypical;
            o.CodeElamed.Value = product.codeElamed;
            
            
            if (product.denotation != null)
            {
                o.Denotation.Value = product.denotation;
            }
            o.Weight.Value = product.weight;

            var productCategory = getProductCategoryByGuid1C(product);
            if(productCategory!= null)
            {
                o.ProductCategory = productCategory;
            }
            //o.ProductCategory = getProductCategoryByGuid1C(new Guid(product.category.guid1C));
            var groupList = getGroupListByGuid1C(product);
            if (groupList != null)
            {
                o.GroupList = groupList;
            }
            //o.GroupList = getGroupListByGuid1C(new Guid(product.groupOfList.guid1C));
            var typeReproduction = getTypeReproductionByGuid1C(product);
            if (typeReproduction != null)
            {
                o.TypeReproduction = typeReproduction;
            }
            //o.TypeReproduction = getTypeReproductionByGuid1C(new Guid(product.typeOfReproduction.guid1C));
            var typeNomenclature = getTypeNomenclatureByGuid1C(product);
            if(typeNomenclature != null)
            {
                o.TypeNomenclature = typeNomenclature;
            }
            //o.TypeNomenclature = getTypeNomenclatureByGuid1C(new Guid(product.typeNomenclature.guid1C));
            var unitsOfMeasurement = getUnitsOfMeasurementByGuid1C(product.unitOfMeasurement);
            if(unitsOfMeasurement != null)
            {
                o.UnitsOfMeasurement = unitsOfMeasurement;
            }

            var unitOfMeasurementWeight = getUnitsOfMeasurementByGuid1C(product.weightUnitOfMeasurement);
            if (unitOfMeasurementWeight != null)
            {
                o.UnitOfMeasurementWeight = unitOfMeasurementWeight;
            }

            var groupFinance = getGroupFinancialNomenclature(product);
            if (groupFinance != null)
            {
                o.GroupFinanceNomenclature = groupFinance;
            }

            //o.UnitsOfMeasurement = getUnitsOfMeasurementByGuid1C(new Guid(product.unitOfMeasurement.guid1C));
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

        public ReferenceObject findObjectByGuid1C(String guidStr)
        {
            Guid guid = new Guid(guidStr);
            return Find(Filter.Parse($"[GUID(1C)] = '{guid}'", ParameterGroup)).FirstOrDefault();
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

        private ReferenceObject getProductCategoryByGuid1C(Nomenclature product)
        {
            if(product.category is null)
            {
                return null;
            }
            if(product.category.guid1C is null)
            {
                return null;
            }

            //var categoryProductReference = this.Connection.ReferenceCatalog.Find(CategoryProductReference.ReferenceId).CreateReference() as CategoryProductReference;
            return categoryProductReference.FindByGuid1C(new Guid(product.category.guid1C));
        }

        private ReferenceObject getGroupListByGuid1C(Nomenclature product)
        {
            if (product.groupOfList is null)
            {
                return null;
            }
            if (product.groupOfList.guid1C is null)
            {
                return null;
            }

            //var groupListReference = this.Connection.ReferenceCatalog.Find(GroupListReference.ReferenceId).CreateReference() as GroupListReference;
            return groupListReference.FindByGuid1C(new Guid(product.groupOfList.guid1C));
        }

        private ReferenceObject getTypeReproductionByGuid1C(Nomenclature product)
        {
            if (product.typeOfReproduction is null)
            {
                return null;
            }
            if (product.typeOfReproduction.guid1C is null)
            {
                return null;
            }
            //var typeOfReproductionReference = this.Connection.ReferenceCatalog.Find(TypeReproductionERPReference.ReferenceId).CreateReference() as TypeReproductionERPReference;
            return typeReproductionERPReference.FindByGuid1C(new Guid(product.typeOfReproduction.guid1C));

        }

        private ReferenceObject getTypeNomenclatureByGuid1C(Nomenclature product)
        {
            if (product.typeNomenclature is null)
            {
                return null;
            }
            if (product.typeNomenclature.guid1C is null)
            {
                return null;
            }
            //var typeNomenclatureReference = this.Connection.ReferenceCatalog.Find(TypeNomenclatureERPReference.ReferenceId).CreateReference() as TypeNomenclatureERPReference;
            return typeNomenclatureERPReference.FindByGuid1C(new Guid(product.typeNomenclature.guid1C));
        }

        private ReferenceObject getUnitsOfMeasurementByGuid1C(UnitOfMeasurementFull unit)
        {
            if (unit is null)
            {
                return null;
            }
            if (unit.guid1C is null)
            {
                return null;
            }
            //var unitOfMeasurementReference = this.Connection.ReferenceCatalog.Find(UnitOfMeasurementReference.ReferenceId).CreateReference() as UnitOfMeasurementReference;
            return unitOfMeasurementReference.FindByGuid1C(new Guid(unit.guid1C));
        }

        private ReferenceObject getGroupFinancialNomenclature(Nomenclature nomenclature)
        {
            if(nomenclature is null)
            {
                return null;
            }
            if(nomenclature.financialGroup is null)
            {
                return null;
            }
            if(nomenclature.financialGroup.guid1C is null)
            {
                return null;
            }
            return groupFinanceNomenclatureReference.FindByGuid1C(new Guid(nomenclature.financialGroup.guid1C));
        }

        /// <summary>
        /// Находит запись в таблице номенклатуры по номенлктуре в PDM
        /// </summary>
        /// <param name="nom">номенклатура в PDM</param>
        /// <returns></returns>
        public NomenclatureERPReferenceObject FindByPdmObject(NomenclatureObject nom)
        {
            return Find(Filter.Parse($"[Номенклатура] = '{nom}'" , this.ParameterGroup)).FirstOrDefault() as NomenclatureERPReferenceObject;
        }
    }}