namespace TFlex.DOCs.References.EtalonOriginalMaket{	using System;	using TFlex.DOCs.Model.References;	using TFlex.DOCs.Model.Structure;	using TFlex.DOCs.Model.Classes;	using TFlex.DOCs.Model;
    using TFlex.DOCs.References.NomenclatureERP;
    using MDMEPZ.Util;

    public partial class EtalonOriginalMaketReference : SpecialReference<EtalonOriginalMaketReferenceObject>	{				public partial class Factory		{		}		public ReferenceObject CreateReferenceObject(NomenclatureERPReferenceObject nomenclature)
		{
			var etalon = CreateReferenceObject() as NomenclatureERPReferenceObject;
			etalon.StartUpdate();
			etalon.Nomenclature = nomenclature;
			etalon.Name.Value = nomenclature.Name.Value;
			etalon.Denotation.Value = nomenclature.Denotation.Value;
			return etalon;
		}	}}