using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFlex.DOCs.References.CategoryProduct;

namespace MDMEPZ.Dto
{
    public class ProductCategory
    {
        public static ProductCategory CreateInstance(CategoryProductReferenceObject category)
        {
            if (category == null) return null;
            var categoryProduct = new ProductCategory();
            categoryProduct.guid1C = category.GUID_1C.GetString();
            categoryProduct.name = category.Name;
            return categoryProduct;
        }
        public string name { get; set; }
        public string guid1C { get; set; }
    }
}
