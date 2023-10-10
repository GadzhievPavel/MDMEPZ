namespace TFlex.DOCs.References.EtalonMaterial{	using System;	using TFlex.DOCs.Model.References;	using TFlex.DOCs.Model.Structure;	using TFlex.DOCs.Model.Classes;	using TFlex.DOCs.Model;
    using TFlex.DOCs.References.NomenclatureERP;
    using MDMEPZ.Util;

    public partial class EtalonMaterialReference : SpecialReference<EtalonMaterialReferenceObject>	{				public partial class Factory		{		}		ReferenceObject CreateReferenceObject(NomenclatureERPReferenceObject nomenclature)
		{
			var etalon = CreateReferenceObject(nomenclature) as EtalonMaterialReferenceObject;
			etalon.StartUpdate();
			etalon.Nomenclature = nomenclature;
			etalon.Name.Value = nomenclature.Name.Value;
			return etalon;
		}	}}