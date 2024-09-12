namespace TFlex.DOCs.References.TypeReproductionERP
{
	using System;
	using TFlex.DOCs.Model.References;
	using TFlex.DOCs.Model.Structure;
	using TFlex.DOCs.Model.Classes;
    using TFlex.DOCs.Model;
    using MDMEPZ.Dto;
    using MDMEPZ.Util;
    using MDMEPZ.Model;
    using TFlex.DOCs.Model.Search;
    using System.Linq;
    using DeveloperUtilsLibrary;

    public partial class TypeReproductionERPReference : SpecialReference<TypeReproductionERPReferenceObject>, IFindService
    {
        public partial class Factory
        {
        }

        public ReferenceObject CreateReferenceObject(TypeOfReproduction typeOfReproduction)
        {
            var o = CreateReferenceObject() as TypeReproductionERPReferenceObject;
            o.StartUpdate();
            o.Name.Value = typeOfReproduction.name;
            o.GUID_1C.Value = new Guid(typeOfReproduction.guid1C);
            return o;
        }

        public ReferenceObject FindByGuid1C(Guid guid)
        {
            return Find(Filter.Parse($"[GUID(1C)] = '{guid}'", this.ParameterGroup)).FirstOrDefault();
        }

        public ReferenceObject FindByGuid1C(Nomenclature product)
        {
            if (product.typeOfReproduction is null)
            {
                return null;
            }
            if (product.typeOfReproduction.guid1C is null)
            {
                return null;
            }
            //var typeOfReproductionReference = this.Connection.ReferenceCatalog.Find(TypeReproductionERPReference.ReferenceId).CreateReference() as TypeReproductionERPReference;
            return FindByGuid1C(new Guid(product.typeOfReproduction.guid1C));

        }
    }
}
