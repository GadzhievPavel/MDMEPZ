namespace TFlex.DOCs.References.FilterOtherProduct{	using System;	using TFlex.DOCs.Model.References;	using TFlex.DOCs.Model.Structure;	using TFlex.DOCs.Model.Classes;	using TFlex.DOCs.Model;
    using MDMEPZ.Model.FilterReference;
    using TFlex.DOCs.Model.Search;

    public partial class FilterOtherProductReference : SpecialReference<FilterOtherProductReferenceObject>, IFinderNsiReference	{
        public ReferenceObject findObjectByNomenclatureERP(ReferenceObject obj)
        {
            //this.Find(Filter.Parse(""),)
        }

        public partial class Factory		{		}	}}