namespace TFlex.DOCs.References.TypeReproductionERP{	using System;	using TFlex.DOCs.Model.References;	using TFlex.DOCs.Model.Structure;	using TFlex.DOCs.Model.Classes;
    using TFlex.DOCs.Model;
    using MDMEPZ.Dto;
    using MDMEPZ.Util;
    using MDMEPZ.Model;
    using TFlex.DOCs.Model.Search;
    using System.Linq;

    public partial class TypeReproductionERPReference : SpecialReference<TypeReproductionERPReferenceObject>, IFindService
    {
        public partial class Factory
        {
        }

        public ReferenceObject CreateReferenceObject(TypeOfReproduction typeOfReproduction)        {            var o = CreateReferenceObject() as TypeReproductionERPReferenceObject;            o.StartUpdate();            o.Name.Value = typeOfReproduction.name;            o.GUID_1C.Value = new Guid(typeOfReproduction.guid1C);            return o;        }

        public ReferenceObject FindByGuid1C(Guid guid)
        {
            return Find(Filter.Parse($"[GUID(1C)] = '{guid}'", this.ParameterGroup)).First();
        }
    }}