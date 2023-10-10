namespace TFlex.DOCs.References.EtalonWorkpiece{
    using System;
    using TFlex.DOCs.Model.References;
    using TFlex.DOCs.Model.Structure;
    using TFlex.DOCs.Model.Classes;
    using TFlex.DOCs.Model;
    using TFlex.DOCs.References.NomenclatureERP;
    using MDMEPZ.Util;

    public partial class EtalonWorkpieceReference : SpecialReference<EtalonWorkpieceReferenceObject>
    {
        public partial class Factory
        {
        }

        public ReferenceObject CreateReferenceObject(NomenclatureERPReferenceObject nomenclature)
        {
            var etalon = CreateReferenceObject() as EtalonWorkpieceReferenceObject;
            etalon.StartUpdate();
            etalon.Nomenclature = nomenclature;
            etalon.Name.Value = nomenclature.Name.Value;
            etalon.Denotation.Value = nomenclature.Denotation.Value;
            return etalon;
        }
    }
}