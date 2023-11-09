namespace TFlex.DOCs.References.EtalonProductOther{
    using System;
    using TFlex.DOCs.Model.References;
    using TFlex.DOCs.Model.Structure;
    using TFlex.DOCs.Model.Classes;
    using TFlex.DOCs.Model;
    using TFlex.DOCs.References.NomenclatureERP;
    using MDMEPZ.Util;

    public partial class EtalonProductOtherReference : SpecialReference<EtalonProductOtherReferenceObject>
    {

        public partial class Factory
        {
        }

        ReferenceObject CreateReferenceObject(NomenclatureERPReferenceObject nomenclature)
        {
            var etalon = CreateReferenceObject() as EtalonProductOtherReferenceObject;
            etalon.StartUpdate();
            etalon.Nomenclature = nomenclature;
            etalon.Name.Value = nomenclature.Name;
            return etalon;
        }
    }}