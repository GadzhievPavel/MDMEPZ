namespace TFlex.DOCs.References.NomenclatureERP
{
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
    using TFlex.DOCs.References.NomenclatureMDM;
    using MDMEPZ.Dto.ITRP;
    using TFlex.DOCs.References.TypeTMC;
    using MDMEPZ.Service;
    using DeveloperUtilsLibrary;

    public partial class NomenclatureMDMReference : SpecialReference<NomenclatureMDMReferenceObject>
    {

        protected CategoryProductReference categoryProductReference;
        protected GroupListReference groupListReference;
        protected TypeReproductionERPReference typeReproductionERPReference;
        protected TypeNomenclatureERPReference typeNomenclatureERPReference;
        protected UnitOfMeasurementReference unitOfMeasurementReference;
        protected GroupFinanceNomenclatureReference groupFinanceNomenclatureReference;
        private NomenclaturePDMHandler nomenclaturePDMHandler;

        private ClassObject erpClass;
        private ClassObject itrpClass;

        public partial class Factory
        {
        }

        private void loadSupportReference()
        {
            erpClass = this.Classes.AllClasses.Where(cl => cl.Guid.Equals(NomenclatureMDMTypes.Keys.NomenclatureERP)).FirstOrDefault();
            itrpClass = this.Classes.AllClasses.Where((cl) => cl.Guid.Equals(NomenclatureMDMTypes.Keys.NomenclatureITRP)).FirstOrDefault();

            categoryProductReference = this.Connection.ReferenceCatalog.Find(CategoryProductReference.ReferenceId).CreateReference() as CategoryProductReference;
            groupListReference = this.Connection.ReferenceCatalog.Find(GroupListReference.ReferenceId).CreateReference() as GroupListReference;
            typeReproductionERPReference = this.Connection.ReferenceCatalog.Find(TypeReproductionERPReference.ReferenceId).CreateReference() as TypeReproductionERPReference;
            typeNomenclatureERPReference = this.Connection.ReferenceCatalog.Find(TypeNomenclatureERPReference.ReferenceId).CreateReference() as TypeNomenclatureERPReference;
            unitOfMeasurementReference = this.Connection.ReferenceCatalog.Find(UnitOfMeasurementReference.ReferenceId).CreateReference() as UnitOfMeasurementReference;
            groupFinanceNomenclatureReference = this.Connection.ReferenceCatalog.Find(GroupFinanceNomenclatureReference.ReferenceId).CreateReference() as GroupFinanceNomenclatureReference;

            nomenclaturePDMHandler = new NomenclaturePDMHandler(this.Connection);
        }
        /// <summary>
        /// Создаем объект объект в MDM на основе объекта PDM
        /// </summary>
        /// <param name="nom">Объект PDM</param>
        /// <returns></returns>
        /// <exception cref="ExceptionMDM">проверка на уникальность</exception>
        public ReferenceObject CreateReferenceObject(NomenclatureObject nom)
        {
            var filter = Filter.Parse($"[GUID(T-FLEX)] = '{nom.Guid}'", ParameterGroup);
            if (Find(filter).Any())
            {
                throw new ExceptionMDM("Объект с таким guid уже существует");
            }

            //NomenclatureMDMTypes nomenclatureMDMTypes = new NomenclatureMDMTypes(this.ParameterGroup);
            var erpObject = CreateReferenceObject(erpClass) as NomenclatureERPReferenceObject;

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
        /// Создание объекта в MDM из DTO
        /// </summary>
        /// <param name="product"> DTO номенклатуры</param>
        /// <returns></returns>
        public ReferenceObject CreateReferenceObject(Nomenclature product)
        {
            //NomenclatureMDMTypes nomenclatureMDMTypes = new NomenclatureMDMTypes(this.ParameterGroup);
            var o = CreateReferenceObject(erpClass) as NomenclatureERPReferenceObject;
            o.StartUpdate();
            o.Name.Value = product.name;
            o.GUID1C.Value = new Guid(product.guid1C);
            o.IsTypical.Value = product.isTypical;
            o.CodeElamed.Value = product.codeElamed;
            o.Artikul_ERP.Value = product.article;
            o.Kod_BP_ERP.Value = product.codeBP;

            if (product.denotation != null)
            {
                o.Denotation.Value = product.denotation;
            }
            o.Weight.Value = product.weight;

            var productCategory = categoryProductReference.FindByGuid1C(product);
            if (productCategory != null)
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
            if (unitsOfMeasurement != null)
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
        /// Создает номенклатуру ИТРП на основе данных из ИТРП
        /// </summary>
        /// <param name="nomenclatureItrpMain"></param>
        /// <returns></returns>
        public NomenclatureITRPReferenceObject CreateReferenceObject(NomenclatureItrpMain nomenclatureItrpMain)
        {
            //NomenclatureMDMTypes nomenclatureMDMTypes = new NomenclatureMDMTypes(this.ParameterGroup);
            var o = CreateReferenceObject(itrpClass) as NomenclatureITRPReferenceObject;
            o.StartUpdate();
            o.Name.Value = nomenclatureItrpMain.Наименование;
            o.NameForInput.Value = nomenclatureItrpMain.НаименованиеДляВвода;
            o.NameFull.Value = nomenclatureItrpMain.НаименованиеПолное;
            o.Denotation.Value = nomenclatureItrpMain.Обозначение;
            o.GUID1C.Value = new Guid(nomenclatureItrpMain.UID);
            o.ID53.Value = nomenclatureItrpMain.ID53;
            o.Articul.Value = nomenclatureItrpMain.Артикул;
            o.Code.Value = nomenclatureItrpMain.Код;
            var baseUnitMeasurement = nomenclatureItrpMain.БазоваяЕдиницаИзмерения;
            if (baseUnitMeasurement != null)
            {
                var baseUnitReferenceObject = o.CreateUnitsOfMeasurement(NomenclatureITRPReferenceObject.TypesOfListUnitsOfMeasurement.BaseUnitOfMeasurementClass);
                baseUnitReferenceObject.UID = baseUnitMeasurement.UID;
                baseUnitReferenceObject.Name = baseUnitMeasurement.Наименование;
                baseUnitReferenceObject.EndUpdate("создана единица измерения");
            }
            var unitStorageRemains = nomenclatureItrpMain.ЕдиницаХраненияОстатков;
            if (unitStorageRemains != null)
            {
                var unitStorageRemainsReferenceObject = o.CreateUnitsOfMeasurement(NomenclatureITRPReferenceObject.TypesOfListUnitsOfMeasurement.UnitOfMeasurementStorageRemainsClass);
                unitStorageRemainsReferenceObject.UID = unitStorageRemains.UID;
                unitStorageRemainsReferenceObject.Name = unitStorageRemains.Наименование;
                unitStorageRemainsReferenceObject.EndUpdate("создана единица измерения");
            }
            var unitAccountInProduction = nomenclatureItrpMain.ЕдиницаУчетаВПроизводстве;
            if (unitAccountInProduction != null)
            {
                var unitAccountInProductionReferenceObject = o.CreateUnitsOfMeasurement(NomenclatureITRPReferenceObject.TypesOfListUnitsOfMeasurement.UnitOfMeasurementAccountInProduction);
                unitAccountInProductionReferenceObject.UID = unitAccountInProduction.UID;
                unitAccountInProductionReferenceObject.Name = unitAccountInProduction.Наименование;
                unitAccountInProductionReferenceObject.EndUpdate("создана единица измерения");
            }
            var units = nomenclatureItrpMain.Единицы;
            if (units != null)
            {
                foreach (var unit in units)
                {
                    if (unit != null)
                    {
                        var unitReferenceObject = o.CreateUnit();
                        unitReferenceObject.Koeff = unit.ЕдиницыИзмеренияКоэффициент;
                        unitReferenceObject.Code = unit.ЕдиницыИзмеренияКод;
                        unitReferenceObject.UID = unit.UID;
                        unitReferenceObject.Name = unit.ЕдиницыИзмеренияНаименование;
                        unitReferenceObject.EndUpdate("создание единицы");
                    }
                }
            }
            var typeTMCReference = new TypeTMCReference(this.Connection);
            if (nomenclatureItrpMain.ВидУчетаТМЦ != null)
            {
                var typeTMCReferenceObject = typeTMCReference.FindByGuid1C(new Guid(nomenclatureItrpMain.ВидУчетаТМЦ.UID));
                o.TypeTMC = typeTMCReferenceObject;
            }

            o.TypeReproduction = nomenclatureItrpMain.ВидВоспроизводства;
            o.EndUpdate("");
            return o;
        }
        /// <summary>
        /// Создание ревизии в справочнике MDM
        /// </summary>
        /// <param name="newNomenclatureRevision"></param>
        /// <returns></returns>
        public NomenclatureMDMReferenceObject CreateRevision(NomenclatureObject newNomenclatureRevision)
        {
            var allRevisionsNomenclature = newNomenclatureRevision.GetAllRevision();
            var sourceRevisionNomenclature = allRevisionsNomenclature.Find(nom =>
                nom.SystemFields.RevisionName.Equals(newNomenclatureRevision.SystemFields.SourceRevisionName));
            var sourceRevisonNomenclatureMdm = sourceRevisionNomenclature.GetObject(NomenclatureMDMReferenceObject.RelationKeys.Nomenclature);

            var newRevisionMdmObject = sourceRevisonNomenclatureMdm.CreateRevision() as NomenclatureMDMReferenceObject;
            newRevisionMdmObject.StartUpdate();
            newRevisionMdmObject.GUIDTFLEX.Value = newNomenclatureRevision.Guid;
            newRevisionMdmObject.Nomenclature = newNomenclatureRevision;
            return newRevisionMdmObject;
        }
        /// <summary>
        /// Поиск по обозначению
        /// </summary>
        /// <param name="denotation"></param>
        /// <returns></returns>
        public List<ReferenceObject> findObjectsByDenotation(String denotation)
        {
            return Find(getFilterNomenclatureByDenotation(denotation));
        }
        /// <summary>
        /// Поиск по названию
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<ReferenceObject> findObjectsByName(String name)
        {
            return Find(getFilterNomenclatureByName(name));
        }
        /// <summary>
        /// Поиск по guid 1C
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

        ///// <summary>
        ///// Находит запись в таблице номенклатуры по номенлктуре в PDM
        ///// </summary>
        ///// <param name="nom">номенклатура в PDM</param>
        ///// <returns></returns>
        //public NomenclatureMDMReferenceObject FindByPdmObject(NomenclatureObject nom)
        //{
        //    return Find(Filter.Parse($"[Номенклатура] = '{nom}'", this.ParameterGroup)).FirstOrDefault() as NomenclatureMDMReferenceObject;
        //}

        /// <summary>
        /// Находит номенклатуру в MDM по объекту из справочника "Материалы ТП"
        /// </summary>
        /// <param name="materialTP"></param>
        /// <returns></returns>
        public NomenclatureMDMReferenceObject FindByTechnologicalMaterial(TechProcessMaterialsReferenceObject materialTP)
        {
            var material = materialTP.GetObject(TechProcessMaterialsReferenceObject.RelationKeys.MaterialsTP_MaterialsRel);
            var materialPdm = material.GetLinkedNomenclatureObject();
            return materialPdm.GetObject(NomenclatureMDMReferenceObject.RelationKeys.Nomenclature) as NomenclatureMDMReferenceObject;
            //return FindByPdmObject(materialPdm);
        }
    }
}
