namespace TFlex.DOCs.References.FilterUserManual
    using TFlex.DOCs.Model;
    using MDMEPZ.Model.FilterReference;
    using TFlex.DOCs.Model.Search;
    using System.Linq;

    public partial class FilterUserManualReference : SpecialReference<FilterUserManualReferenceObject>, IFinderNsiReference
    {
        public ReferenceObject findObjectByNomenclatureERP(ReferenceObject obj)
        {
            return this.Find(Filter.Parse($"[������������ ERP] = '{obj}'", ParameterGroup)).FirstOrDefault();
        }

        public partial class Factory