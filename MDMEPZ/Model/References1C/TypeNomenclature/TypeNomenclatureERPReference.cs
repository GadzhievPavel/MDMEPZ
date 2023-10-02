namespace TFlex.DOCs.References.TypeNomenclatureERP{	using System;	using TFlex.DOCs.Model.References;	using TFlex.DOCs.Model.Structure;	using TFlex.DOCs.Model.Classes;
    using TFlex.DOCs.Model;
    using MDMEPZ.Dto;
    using MDMEPZ.Util;
    using MDMEPZ.Dto.TypeNomenclature;

    public partial class TypeNomenclatureERPReference : SpecialReference<TypeNomenclatureERPReferenceObject>
    {
        public partial class Factory
        {
        }

        public ReferenceObject CreateReferenceObject(TypeOfNomenclature typeOfNomenclature)
        {
            var o = CreateReferenceObject() as TypeNomenclatureERPReferenceObject;
            o.StartUpdate();
            o.Name.Value = typeOfNomenclature.name;
            o.GUID_1C.Value = new Guid(typeOfNomenclature.guid1C);
            return o;
        }
    }}