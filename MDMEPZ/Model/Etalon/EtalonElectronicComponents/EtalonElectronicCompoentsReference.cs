namespace TFlex.DOCs.References.EtalonElectronicCompoents{	using System;	using TFlex.DOCs.Model.References;	using TFlex.DOCs.Model.Structure;	using TFlex.DOCs.Model.Classes;	using TFlex.DOCs.Model;
    using TFlex.DOCs.References.NomenclatureERP;
    using MDMEPZ.Util;
    using TFlex.DOCs.Model.Search;
    using MDMEPZ.Model.FilterReference;
    using System.Linq;

    public partial class EtalonElectronicCompoentsReference : SpecialReference<EtalonElectronicCompoentsReferenceObject>, IFinderEtalonReference	{
        public ReferenceObject findObjectEtalonByNomenclatureERP(ReferenceObject nomErp)
        {
            return this.Find(Filter.Parse($"[Номенклатура ERP] = '{nomErp}'", ParameterGroup)).FirstOrDefault();
        }

        public partial class Factory		{		}		ReferenceObject CreateReferenceObject(NomenclatureMDMReferenceObject nomenclatureERPReferenceObject)
		{
			var etalon = CreateReferenceObject() as EtalonElectronicCompoentsReferenceObject;
			etalon.StartUpdate();
			etalon.Nomenclature = nomenclatureERPReferenceObject;
			etalon.Name.Value = nomenclatureERPReferenceObject.Name.Value;
			return etalon;
		}	}}