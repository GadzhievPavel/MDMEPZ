namespace TFlex.DOCs.References.CategoryProduct{	using System;	using TFlex.DOCs.Model.References;	using TFlex.DOCs.Model.Structure;	using TFlex.DOCs.Model.References.Links;	using TFlex.DOCs.Model.Classes;	using TFlex.DOCs.Model.Parameters;
    using TFlex.DOCs.Model.Plugins;
    using System.Collections.Generic;
    using TFlex.DOCs.Model.Desktop;
    using TFlex.DOCs.Model.References.Units;
    using TFlex.DOCs.References.UnitOfMeasurement;
    using MDMEPZ.Dto;

    public partial class CategoryProductReferenceObject : SpecialReferenceObject<CategoryProductReference>	{		public String CreateCategoryProductReferenceObject(ProductCategory[] categoryProducts)
		{
            CategoryProductReference categoryProductReference;
			List<ReferenceObject> saveList = new List<ReferenceObject>();
            var c = categoryProductReference.CreateReferenceObject();
			c.EndChanges();
            foreach (ProductCategory category in categoryProducts)
            {
                var obj = categoryProductReference.CreateReferenceObject(category);
                obj.EndChanges();
                saveList.Add(obj);
            }
            Desktop.CheckIn(saveList, "", false);
            return "correctly";
        }	}}