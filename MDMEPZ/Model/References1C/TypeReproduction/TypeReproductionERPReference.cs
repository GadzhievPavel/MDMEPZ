namespace TFlex.DOCs.References.TypeReproductionERP{	using System;	using TFlex.DOCs.Model.References;	using TFlex.DOCs.Model.Structure;	using TFlex.DOCs.Model.Classes;
    using TFlex.DOCs.Model;
    using MDMEPZ.Dto;
    using MDMEPZ.Util;

    public partial class TypeReproductionERPReference : SpecialReference<TypeReproductionERPReferenceObject>
    {
        public partial class Factory
        {
        }

        //public ReferenceObject CreateReferenceObject(TypeOfReproduction typeOfReproduction)        //{        //    var o = CreateReferenceObject() as TypeReproductionERPReferenceObject;        //    o.StartUpdate();        //    o.Name.Value = typeOfReproduction.Name;        //    o.GUID_1C.Value = new Guid(typeOfReproduction.Guid1C);        //    o.EndChanges();        //    return o;        //}
    }}