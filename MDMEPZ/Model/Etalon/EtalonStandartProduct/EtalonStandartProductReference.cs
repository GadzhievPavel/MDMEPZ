namespace TFlex.DOCs.References.StandartProduct
{
	using System;
	using TFlex.DOCs.Model.References;
	using TFlex.DOCs.Model.Structure;
	using TFlex.DOCs.Model.Classes;
	using TFlex.DOCs.Model;
    using TFlex.DOCs.References.NomenclatureERP;
    using MDMEPZ.Util;

    public partial class EtalonStandartProductReference : SpecialReference<EtalonStandartProductReferenceObject>
	{
		
		public partial class Factory
		{
		}

		public ReferenceObject CreateReferenceObject(NomenclatureERPReferenceObject nomenclature)
		{
			var etalon = CreateReferenceObject() as EtalonStandartProductReferenceObject;
			etalon.StartUpdate();
			etalon.Name.Value = nomenclature.Name.Value;
			etalon.Nomenclature = nomenclature;
			return etalon;
		}
	}
}
