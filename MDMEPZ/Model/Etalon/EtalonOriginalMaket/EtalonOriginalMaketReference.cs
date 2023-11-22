namespace TFlex.DOCs.References.EtalonOriginalMaket{	using System;	using TFlex.DOCs.Model.References;	using TFlex.DOCs.Model.Structure;	using TFlex.DOCs.Model.Classes;	using TFlex.DOCs.Model;
    using TFlex.DOCs.References.NomenclatureERP;
    using MDMEPZ.Util;
    using MDMEPZ.Model.FilterReference;
    using TFlex.DOCs.Model.Search;
    using System.Linq;

    public partial class EtalonOriginalMaketReference : SpecialReference<EtalonOriginalMaketReferenceObject>, IFinderEtalonReference	{
        public ReferenceObject findObjectEtalonByNomenclatureERP(ReferenceObject nomErp)
        {
            return this.Find(Filter.Parse($"[Номенклатура ERP ОМ] = '{nomErp}'", ParameterGroup)).FirstOrDefault();
        }

        public partial class Factory		{		}		public ReferenceObject CreateReferenceObject(NomenclatureERPReferenceObject nomenclature)
		{
			var etalon = CreateReferenceObject() as NomenclatureERPReferenceObject;
			etalon.StartUpdate();
			etalon.Nomenclature = nomenclature;
			etalon.Name.Value = nomenclature.Name.Value;
			etalon.Denotation.Value = nomenclature.Denotation.Value;
			return etalon;
		}	}}