namespace TFlex.DOCs.References.CategoryProduct
{
	using System;
	using TFlex.DOCs.Model.References;
	using TFlex.DOCs.Model.Structure;
	using TFlex.DOCs.Model.Classes;
	using TFlex.DOCs.Model;
    using System.Runtime.Remoting.Contexts;
    using System.Collections.Generic;
    using MDMEPZ.Dto;
    using TFlex.DOCs.References.GroupList;
    using MDMEPZ.Util;
    using TFlex.DOCs.Model.Search;
    using System.Linq;
    using MDMEPZ.Model;
    using DeveloperUtilsLibrary;

    public partial class CategoryProductReference : SpecialReference<CategoryProductReferenceObject>, IFindService
	{
		
		public partial class Factory
		{
		}

        public ReferenceObject CreateReferenceObject(ProductCategory productCategory)
        {
            var o = CreateReferenceObject() as CategoryProductReferenceObject;
            o.StartUpdate();
            o.Name.Value = productCategory.name;
            o.GUID_1C.Value = new Guid(productCategory.guid1C);
            return o;
        }

        public ReferenceObject FindByGuid1C(Guid guid)
        {
            return Find(Filter.Parse($"[GUID(1C)] = '{guid}'",this.ParameterGroup)).FirstOrDefault();
        }

        public ReferenceObject FindByGuid1C(Nomenclature product)
        {
            if (product.category is null)
            {
                return null;
            }
            if (product.category.guid1C is null)
            {
                return null;
            }

            //var categoryProductReference = this.Connection.ReferenceCatalog.Find(CategoryProductReference.ReferenceId).CreateReference() as CategoryProductReference;
            return FindByGuid1C(new Guid(product.category.guid1C));
        }
    }
}
