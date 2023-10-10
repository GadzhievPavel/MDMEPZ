namespace TFlex.DOCs.References.EtalonProduct{	using System;	using TFlex.DOCs.Model.References;	using TFlex.DOCs.Model.Structure;	using TFlex.DOCs.Model.Classes;	using TFlex.DOCs.Model;
    using TFlex.DOCs.References.NomenclatureERP;

    public partial class EtalonProductReference : SpecialReference<EtalonProductReferenceObject>	{				public partial class Factory		{		}		public ReferenceObject CreateReferenceObject(NomenclatureERPReferenceObject nomenclature)
		{
			var etalon = CreateReferenceObject() as EtalonProductReferenceObject;
			etalon.Name.Value = nomenclature.Name.Value;
			etalon.Nomenclature = nomenclature;
			etalon.Denotation.Value = nomenclature.Denotation.Value;
			return etalon;
		}	}}