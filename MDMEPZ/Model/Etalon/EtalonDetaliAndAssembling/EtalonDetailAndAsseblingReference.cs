namespace TFlex.DOCs.References.EtalonDetailAndAssebly
{
	using System;
	using TFlex.DOCs.Model.References;
	using TFlex.DOCs.Model.Structure;
	using TFlex.DOCs.Model.Classes;
	using TFlex.DOCs.Model;
    using TFlex.DOCs.References.NomenclatureERP;
    using MDMEPZ.Util;
    using MDMEPZ.Model.FilterReference;
    using TFlex.DOCs.Model.Search;
    using System.Linq;

    public partial class EtalonDetailAndAsseblingReference : SpecialReference<EtalonDetailAndAsseblingReferenceObject>, IFinderEtalonReference
	{

        public ReferenceObject findObjectEtalonByNomenclatureERP(ReferenceObject nomErp)
        {
            return this.Find(Filter.Parse($"[Номенклатура ERP ДиС] = '{nomErp}'", ParameterGroup)).FirstOrDefault();
        }

        public partial class Factory
		{
		}

		ReferenceObject CreateReferenceObject(NomenclatureMDMReferenceObject erpNomenclature)
		{
			var etalon = CreateReferenceObject() as EtalonDetailAndAsseblingReferenceObject;
			etalon.StartUpdate();
			etalon.Nomenclature = erpNomenclature;
			etalon.Denotation.Value = erpNomenclature.Denotation.Value;
			etalon.Name.Value = erpNomenclature.Name.Value;
			return etalon;
		}
	}
}
