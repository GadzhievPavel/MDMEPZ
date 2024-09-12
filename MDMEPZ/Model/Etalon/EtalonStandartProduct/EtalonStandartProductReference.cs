namespace TFlex.DOCs.References.StandartProduct
{
	using System;
	using TFlex.DOCs.Model.References;
	using TFlex.DOCs.Model.Structure;
	using TFlex.DOCs.Model.Classes;
	using TFlex.DOCs.Model;
    using TFlex.DOCs.References.NomenclatureERP;
    using MDMEPZ.Util;
    using TFlex.DOCs.Model.Search;
    using MDMEPZ.Model.FilterReference;
    using System.Linq;
    using DeveloperUtilsLibrary;

    public partial class EtalonStandartProductReference : SpecialReference<EtalonStandartProductReferenceObject>, IFinderEtalonReference
	{
        public ReferenceObject findObjectEtalonByNomenclatureERP(ReferenceObject nomErp)
        {
            return this.Find(Filter.Parse($"[Номенклатура ERP СИ] = '{nomErp}'", ParameterGroup)).FirstOrDefault();
        }

        public partial class Factory
		{
		}

		public ReferenceObject CreateReferenceObject(NomenclatureMDMReferenceObject nomenclature)
		{
			var etalon = CreateReferenceObject() as EtalonStandartProductReferenceObject;
			etalon.StartUpdate();
			etalon.Name.Value = nomenclature.Name.Value;
			etalon.Nomenclature = nomenclature;
			return etalon;
		}
	}
}
