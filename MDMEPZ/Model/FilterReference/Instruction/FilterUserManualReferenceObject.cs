namespace TFlex.DOCs.References.FilterUserManual{	using System;	using TFlex.DOCs.Model.References;	using TFlex.DOCs.Model.Structure;	using TFlex.DOCs.Model.References.Links;	using TFlex.DOCs.Model.Classes;
    using TFlex.DOCs.Model.Parameters;
    using MDMEPZ.Model.FilterReference;

    public partial class FilterUserManualReferenceObject : SpecialReferenceObject<FilterUserManualReference>, IFilterNSI
    {
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