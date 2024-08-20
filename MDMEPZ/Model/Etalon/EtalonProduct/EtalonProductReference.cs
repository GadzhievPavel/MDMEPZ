namespace TFlex.DOCs.References.EtalonProduct{	using System;	using TFlex.DOCs.Model.References;	using TFlex.DOCs.Model.Structure;	using TFlex.DOCs.Model.Classes;	using TFlex.DOCs.Model;
    using TFlex.DOCs.References.NomenclatureERP;
    using TFlex.DOCs.Model.Search;
    using MDMEPZ.Model.FilterReference;
    using System.Linq;

    public partial class EtalonProductReference : SpecialReference<EtalonProductReferenceObject>, IFinderEtalonReference	{

        public ReferenceObject findObjectEtalonByNomenclatureERP(ReferenceObject nomErp)
        {
            return this.Find(Filter.Parse($"[������������ ERP �] = '{nomErp}'", ParameterGroup)).FirstOrDefault();
        }

        public partial class Factory		{		}		public ReferenceObject CreateReferenceObject(NomenclatureMDMReferenceObject nomenclature)
		{
			var etalon = CreateReferenceObject() as EtalonProductReferenceObject;
			etalon.Name.Value = nomenclature.Name.Value;
			etalon.Nomenclature = nomenclature;
			etalon.Denotation.Value = nomenclature.Denotation.Value;
			return etalon;
		}	}}