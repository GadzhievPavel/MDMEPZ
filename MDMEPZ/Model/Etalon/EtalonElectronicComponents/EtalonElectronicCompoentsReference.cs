namespace TFlex.DOCs.References.EtalonElectronicCompoents{	using System;	using TFlex.DOCs.Model.References;	using TFlex.DOCs.Model.Structure;	using TFlex.DOCs.Model.Classes;	using TFlex.DOCs.Model;
    using TFlex.DOCs.References.NomenclatureERP;
    using MDMEPZ.Util;

    public partial class EtalonElectronicCompoentsReference : SpecialReference<EtalonElectronicCompoentsReferenceObject>	{				public partial class Factory		{		}		ReferenceObject CreateReferenceObject(NomenclatureERPReferenceObject nomenclatureERPReferenceObject)
		{
			var etalon = CreateReferenceObject() as EtalonElectronicCompoentsReferenceObject;
			etalon.StartUpdate();
			etalon.Nomenclature = nomenclatureERPReferenceObject;
			etalon.Name.Value = nomenclatureERPReferenceObject.Name.Value;
			return etalon;
		}	}}