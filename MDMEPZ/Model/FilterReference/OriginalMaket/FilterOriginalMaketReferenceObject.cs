namespace TFlex.DOCs.References.FilterOiginalMaket{	using System;	using TFlex.DOCs.Model.References;	using TFlex.DOCs.Model.Structure;	using TFlex.DOCs.Model.References.Links;	using TFlex.DOCs.Model.Classes;	using TFlex.DOCs.Model.Parameters;
	using MDMEPZ.Model.FilterReference;

	public partial class FilterOriginalMaketReferenceObject : SpecialReferenceObject<FilterOriginalMaketReference>, IFilterNSI	{
        public void setEmptyClassification()
        {
            Classification.Value = ValueNSI.empty;
        }

        public void setEquivalent()
        {
            Classification.Value = ValueNSI.equivalent;
        }

        public void setStandard()
        {
            Classification.Value = ValueNSI.standard;
        }
    }}