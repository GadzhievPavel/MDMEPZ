namespace TFlex.DOCs.References.EtalonProductOther{
    using System;
    using TFlex.DOCs.Model.References;
    using TFlex.DOCs.Model.Structure;
    using TFlex.DOCs.Model.Classes;
    using TFlex.DOCs.Model;
    using TFlex.DOCs.References.NomenclatureERP;
    using MDMEPZ.Util;
    using TFlex.DOCs.Model.Search;
    using MDMEPZ.Model.FilterReference;
    using System.Linq;

    public partial class EtalonProductOtherReference : SpecialReference<EtalonProductOtherReferenceObject>, IFinderEtalonReference
    {

        public partial class Factory
        {
        }

        ReferenceObject CreateReferenceObject(NomenclatureMDMReferenceObject nomenclature)
        {
            var etalon = CreateReferenceObject() as EtalonProductOtherReferenceObject;
            etalon.StartUpdate();
            etalon.Nomenclature = nomenclature;
            etalon.Name.Value = nomenclature.Name;
            return etalon;
        }

        public ReferenceObject findObjectEtalonByNomenclatureERP(ReferenceObject nomErp)
        {
            return this.Find(Filter.Parse($"[Номенклатура ERP ПИ] = '{nomErp}'", ParameterGroup)).FirstOrDefault();
        }
    }}