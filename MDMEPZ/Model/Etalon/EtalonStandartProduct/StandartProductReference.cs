namespace TFlex.DOCs.References.StandartProduct{	using System;	using TFlex.DOCs.Model.References;	using TFlex.DOCs.Model.Structure;	using TFlex.DOCs.Model.Classes;	using TFlex.DOCs.Model;
    using TFlex.DOCs.References.NomenclatureERP;
    using MDMEPZ.Util;

    public partial class StandartProductReference : SpecialReference<StandartProductReferenceObject>	{				public partial class Factory		{		}		public ReferenceObject CreateReferenceObject(NomenclatureERPReferenceObject nomenclature)
		{
			var etalon = CreateReferenceObject() as StandartProductReferenceObject;
			etalon.StartUpdate();
			etalon.Name.Value = nomenclature.Name.Value;
			etalon.Nomenclature = nomenclature;
			return etalon;
		}	}}