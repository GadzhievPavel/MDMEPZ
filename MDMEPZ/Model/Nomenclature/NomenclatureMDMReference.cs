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
    using TFlex.Model.Technology.References.Materials;

    public partial class NomenclatureMDMReference : SpecialReference<NomenclatureMDMReferenceObject>
    {

        protected CategoryProductReference categoryProductReference;
        protected GroupListReference groupListReference;
        protected TypeReproductionERPReference typeReproductionERPReference;
        protected TypeNomenclatureERPReference typeNomenclatureERPReference;
        protected UnitOfMeasurementReference unitOfMeasurementReference;
        protected GroupFinanceNomenclatureReference groupFinanceNomenclatureReference;

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
        /// <summary>
        /// ������� ������ ������ � MDM �� ������ ������� PDM
        /// </summary>
        /// <param name="nom">������ PDM</param>
        /// <returns></returns>
        /// <exception cref="ExceptionMDM">�������� �� ������������</exception>
        public ReferenceObject CreateReferenceObject(NomenclatureObject nom)
        {
            var filter = Filter.Parse($"[GUID(T-FLEX)] = '{nom.Guid}'", ParameterGroup);
            if (Find(filter).Any())
            {
                throw new ExceptionMDM("������ � ����� guid ��� ����������");
            }
            var erpObject = CreateReferenceObject() as NomenclatureMDMReferenceObject;

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

        /// <summary>
        /// �������� ������� � MDM �� DTO
        /// </summary>
        /// <param name="product"> DTO ������������</param>
        /// <returns></returns>
        public ReferenceObject CreateReferenceObject(Nomenclature product)
        {

            var o = CreateReferenceObject() as NomenclatureMDMReferenceObject;
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

            var productCategory = categoryProductReference.FindByGuid1C(product);
            if(productCategory!= null)
            {
                o.ProductCategory = productCategory;
            }
            var groupList = groupListReference.FindByGuid1C(product);
            if (groupList != null)
            {
                o.GroupList = groupList;
            }
            var typeReproduction = typeReproductionERPReference.FindByGuid1C(product);
            if (typeReproduction != null)
            {
                o.TypeReproduction = typeReproduction;
            }
            var typeNomenclature = typeNomenclatureERPReference.FindByGuid1C(product);
            if (typeNomenclature != null)
            {
                o.TypeNomenclature = typeNomenclature;
            }
            var unitsOfMeasurement = unitOfMeasurementReference.FindByGuid1C(product.unitOfMeasurement);
            if(unitsOfMeasurement != null)
            {
                o.UnitsOfMeasurement = unitsOfMeasurement;
            }

            var unitOfMeasurementWeight = unitOfMeasurementReference.FindByGuid1C(product.weightUnitOfMeasurement);
            if (unitOfMeasurementWeight != null)
            {
                o.UnitOfMeasurementWeight = unitOfMeasurementWeight;
            }

            var groupFinance = groupFinanceNomenclatureReference.FindByGuid1C(product);
            if (groupFinance != null)
            {
                o.GroupFinanceNomenclature = groupFinance;
            }

            return o;
        }

        /// <summary>
        /// ����� �� �����������
        /// </summary>
        /// <param name="denotation"></param>
        /// <returns></returns>
        public List<ReferenceObject> findObjectsByDenotation(String denotation)
        {
            return Find(getFilterNomenclatureByDenotation(denotation));
        }
        /// <summary>
        /// ����� �� ��������
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<ReferenceObject> findObjectsByName(String name)
        {
            return Find(getFilterNomenclatureByName(name));
        }
        /// <summary>
        /// ����� �� guid 1C
        /// </summary>
        /// <param name="guidStr"></param>
        /// <returns></returns>
        public ReferenceObject findObjectByGuid1C(String guidStr)
        {
            Guid guid = new Guid(guidStr);
            return Find(Filter.Parse($"[GUID(1C)] = '{guid}'", ParameterGroup)).FirstOrDefault();
        }
        private Filter getFilterNomenclatureByDenotation(String denotation)
        {
            Filter filter = new Filter(ParameterGroup);
            ReferenceObjectTerm term = new ReferenceObjectTerm(filter.Terms);
            term.Path.AddParameter(ParameterGroup.Parameters.Find(NomenclatureMDMReferenceObject.FieldKeys.Denotation));
            term.Operator = ComparisonOperator.Equal;
            term.Value = denotation;
            filter.Validate();
            return filter;
        }

        private Filter getFilterNomenclatureByName(String name)
        {
            Filter filter = new Filter(ParameterGroup);
            ReferenceObjectTerm term = new ReferenceObjectTerm(filter.Terms);
            term.Path.AddParameter(ParameterGroup.Parameters.Find(NomenclatureMDMReferenceObject.FieldKeys.Name));
            term.Operator = ComparisonOperator.Equal;
            term.Value = name;
            filter.Validate();
            return filter;
        }

        /// <summary>
        /// ������� ������ � ������� ������������ �� ����������� � PDM
        /// </summary>
        /// <param name="nom">������������ � PDM</param>
        /// <returns></returns>
        public NomenclatureMDMReferenceObject FindByPdmObject(NomenclatureObject nom)
        {
            return Find(Filter.Parse($"[������������] = '{nom}'" , this.ParameterGroup)).FirstOrDefault() as NomenclatureMDMReferenceObject;
        }

        /// <summary>
        /// ������� ������������ � MDM �� ������� �� ����������� "��������� ��"
        /// </summary>
        /// <param name="materialTP"></param>
        /// <returns></returns>
        public NomenclatureMDMReferenceObject FindByTechnologicalMaterial(TechProcessMaterialsReferenceObject materialTP)
        {
            var material = materialTP.GetObject(TechProcessMaterialsReferenceObject.RelationKeys.MaterialsTP_MaterialsRel);
            var materialPdm = material.GetLinkedNomenclatureObject();
            return FindByPdmObject(materialPdm);
        }
    }}