namespace TFlex.DOCs.References.EtalonDetailAndAssebly{	using System;	using TFlex.DOCs.Model.References;	using TFlex.DOCs.Model.Structure;	using TFlex.DOCs.Model.References.Links;	using TFlex.DOCs.Model.Classes;	using TFlex.DOCs.Model.Parameters;
	using TFlex.DOCs.Model.Macros.ObjectModel;
    using TFlex.DOCs.References.NomenclatureERP;
    using MDMEPZ.Util;
	using TFlex.DOCs.Model.References.Nomenclature;
	using TFlex.DOCs.Model.References.Documents;

	public partial class EtalonDetailAndAsseblingReferenceObject : SpecialReferenceObject<EtalonDetailAndAsseblingReference>	{		private Reference refDocument;		private NomenclatureReference refNomenclature;		public ReferenceObject CreateInPDM()
		{
			
			var document = refDocument.CreateReferenceObject();




            //to do
        }	}}