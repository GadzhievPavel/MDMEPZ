namespace TFlex.DOCs.References.CategoryProduct{	using System;	using TFlex.DOCs.Model.References;	using TFlex.DOCs.Model.Structure;	using TFlex.DOCs.Model.Classes;	using TFlex.DOCs.Model;
    using System.Runtime.Remoting.Contexts;
    using System.Collections.Generic;
    using MDMEPZ.Dto;
    using TFlex.DOCs.References.GroupList;
    using MDMEPZ.Util;

    public partial class CategoryProductReference : SpecialReference<CategoryProductReferenceObject>	{				public partial class Factory		{		}
        
        //public ReferenceObject CreateReferenceObject(ProductCategory productCategory)
        //{
        //    var o = CreateReferenceObject() as CategoryProductReferenceObject;
        //    o.StartUpdate();
        //    o.Name.Value = productCategory.Name;
        //    o.GUID_1C.Value = new Guid(productCategory.Guid1C);
        //    o.EndChanges();
        //    return o;
        //}
    }}