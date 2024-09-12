namespace TFlex.DOCs.References.EtalonMaterial
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

    public partial class EtalonMaterialReference : SpecialReference<EtalonMaterialReferenceObject>, IFinderEtalonReference
	{
        public ReferenceObject findObjectEtalonByNomenclatureERP(ReferenceObject nomErp)
        {
            return this.Find(Filter.Parse($"[Номенклатура ERP М] = '{nomErp}'", ParameterGroup)).FirstOrDefault();
        }

        public partial class Factory
		{
		}

		ReferenceObject CreateReferenceObject(NomenclatureMDMReferenceObject nomenclature)
		{
			var etalon = CreateReferenceObject(nomenclature) as EtalonMaterialReferenceObject;
			etalon.StartUpdate();
			etalon.Nomenclature = nomenclature;
			etalon.Name.Value = nomenclature.Name.Value;
			return etalon;
		}

	}
}
