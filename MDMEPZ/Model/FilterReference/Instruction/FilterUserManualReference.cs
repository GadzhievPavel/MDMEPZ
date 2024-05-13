namespace TFlex.DOCs.References.FilterUserManual{	using System;	using TFlex.DOCs.Model.References;	using TFlex.DOCs.Model.Structure;	using TFlex.DOCs.Model.Classes;
    using TFlex.DOCs.Model;
    using MDMEPZ.Model.FilterReference;
    using TFlex.DOCs.Model.Search;
    using System.Linq;

    public partial class FilterUserManualReference : SpecialReference<FilterUserManualReferenceObject>, IFinderNsiReference
    {
        public ReferenceObject findObjectByNomenclatureERP(ReferenceObject obj)
        {
            return this.Find(Filter.Parse($"[Номенклатура ERP] = '{obj}'", ParameterGroup)).FirstOrDefault();
        }

        public partial class Factory		{		}	}}