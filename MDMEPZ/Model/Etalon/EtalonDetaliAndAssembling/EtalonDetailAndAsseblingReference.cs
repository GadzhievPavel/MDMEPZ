namespace TFlex.DOCs.References.EtalonDetailAndAssebly
{
	using System;
	using TFlex.DOCs.Model.References;
	using TFlex.DOCs.Model.Structure;
	using TFlex.DOCs.Model.Classes;
	using TFlex.DOCs.Model;
    using TFlex.DOCs.References.NomenclatureERP;
    using MDMEPZ.Util;

    public partial class EtalonDetailAndAsseblingReference : SpecialReference<EtalonDetailAndAsseblingReferenceObject>
	{
		
		public partial class Factory
		{
		}

		ReferenceObject CreateReferenceObject(NomenclatureERPReferenceObject erpNomenclature)
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
