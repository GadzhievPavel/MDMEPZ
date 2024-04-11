namespace TFlex.DOCs.References.EtalonUserManual{	using System;	using TFlex.DOCs.Model.References;	using TFlex.DOCs.Model.Structure;	using TFlex.DOCs.Model.Classes;	using TFlex.DOCs.Model;
    using MDMEPZ.Model.FilterReference;
    using TFlex.DOCs.Model.Search;
    using System.Linq;
    using TFlex.DOCs.References.NomenclatureERP;
    using TFlex.DOCs.References.EtalonDetailAndAssebly;
    using MDMEPZ.Util;

    public partial class EtalonUserManualReference : SpecialReference<EtalonUserManualReferenceObject>, IFinderEtalonReference	{
        public ReferenceObject findObjectEtalonByNomenclatureERP(ReferenceObject nomErp)
        {
            return this.Find(Filter.Parse($"[Номенклатура ERP] = '{nomErp}'", ParameterGroup)).FirstOrDefault();
        }

        public ReferenceObject CreateReferenceObject(NomenclatureERPReferenceObject erpNomenclature)
        {
            var etalon = CreateReferenceObject() as EtalonUserManualReferenceObject;
            etalon.StartUpdate();
            etalon.Nomenclature = erpNomenclature;
            etalon.Denotation.Value = erpNomenclature.Denotation.Value;
            etalon.Name.Value = erpNomenclature.Name.Value;
            return etalon;
        }
        public partial class Factory		{		}	}}