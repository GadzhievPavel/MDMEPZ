namespace TFlex.DOCs.References.EtalonDetailAndAssebly
{
	using System;
	using TFlex.DOCs.Model.References;
	using TFlex.DOCs.Model.Structure;
	using TFlex.DOCs.Model.References.Links;
	using TFlex.DOCs.Model.Classes;
	using TFlex.DOCs.Model.Parameters;
	using TFlex.DOCs.Model.Macros.ObjectModel;
    using TFlex.DOCs.References.NomenclatureERP;
    using MDMEPZ.Util;
	using TFlex.DOCs.Model.References.Nomenclature;
	using TFlex.DOCs.Model.References.Documents;
    using DeveloperUtilsLibrary;

    public partial class EtalonDetailAndAsseblingReferenceObject : SpecialReferenceObject<EtalonDetailAndAsseblingReference>
	{
		private Reference refDocument;
		private NomenclatureReference refNomenclature;
		public ReferenceObject CreateInPDM()
		{
            if (this.refDocument != null)
            {
                var nomenclatureERP = this.Nomenclature as NomenclatureMDMReferenceObject;
                var document = refDocument.CreateReferenceObject();
                var objEsi = refNomenclature.CreateNomenclatureObject(document, null, null, null, false);
                nomenclatureERP.StartUpdate();
                nomenclatureERP.Nomenclature = objEsi;
                nomenclatureERP.EndUpdate("");
            }
            return null;
        }
	}
}
