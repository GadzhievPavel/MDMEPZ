namespace TFlex.DOCs.References.ReplacementERP{
    using System;
    using TFlex.DOCs.Model.References;
    using TFlex.DOCs.Model.Structure;
    using TFlex.DOCs.Model.Classes;
    using TFlex.DOCs.Model;
    using MDMEPZ.Dto.ReplacementErp;
    using TFlex.DOCs.References.NomenclatureERP;
    using MDMEPZ.Util;

    public partial class ReplacementERPReference : SpecialReference<ReplacementERPReferenceObject>
    {
        private NomenclatureMDMReference nomenclatureERPRef;
        public partial class Factory
        {
        }

        public ReferenceObject CreateReferenceObject(Replacement replacement)
        {
            var obj = CreateReferenceObject() as ReplacementERPReferenceObject;
            obj.StartUpdate();
            obj.NomenclatureGuid.Value = new Guid(replacement.baseNomenclature);
            obj.ReplacementNomenclatureGuid.Value = new Guid(replacement.replacement);
            obj.ApplicabilityNomanclatureGuid.Value = new Guid(replacement.applicability);

            var baseNomenclature = this.nomenclatureERPRef.findObjectByGuid1C(replacement.baseNomenclature);
            var replacementNomenclature = this.nomenclatureERPRef.findObjectByGuid1C(replacement.replacement);
            var applicabilityNomenclature = this.nomenclatureERPRef.findObjectByGuid1C(replacement.applicability);

            if (baseNomenclature != null)
            {
                obj.NomenclatureERP = baseNomenclature;
            }
            if(replacementNomenclature != null)
            {
                obj.ReplacementNomenclatureERP = replacementNomenclature;
            }
            if(applicabilityNomenclature != null)
            {
                obj.ApplicabilityNomenclatureERP = applicabilityNomenclature;
            }
            return obj;
        }

        private void loadSupportReference()
        {
            this.nomenclatureERPRef = Connection.ReferenceCatalog.Find(NomenclatureMDMReference.ReferenceId).CreateReference() as NomenclatureMDMReference;        }
    }}