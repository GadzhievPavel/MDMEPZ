namespace TFlex.DOCs.References.TypeNomenclatureERP
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
    using MDMEPZ.Exception;

    public partial class TypeNomenclatureERPReference : SpecialReference<TypeNomenclatureERPReferenceObject>, IFindService
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

        public ReferenceObject FindByGuid1C(Guid guid)
        {
            try
            {
                return Find(Filter.Parse($"[GUID(1C)] = '{guid}'", this.ParameterGroup)).First();
            }
            catch
            {
                throw new ExceptionFinder($"тип номенклатуры не найден с guid {guid}");
            }
        }

        public ReferenceObject FindByGuid1C(Nomenclature product)
        {
            if (product.typeNomenclature is null)
            {
                return null;
            }
            if (product.typeNomenclature.guid1C is null)
            {
                return null;
            }
            //var typeNomenclatureReference = this.Connection.ReferenceCatalog.Find(TypeNomenclatureERPReference.ReferenceId).CreateReference() as TypeNomenclatureERPReference;
            return FindByGuid1C(new Guid(product.typeNomenclature.guid1C));
        }
    }
}
