namespace TFlex.DOCs.References.VariantsMaterials{	using System;	using TFlex.DOCs.Model.References;	using TFlex.DOCs.Model.Structure;	using TFlex.DOCs.Model.Classes;	using TFlex.DOCs.Model;
    using TFlex.DOCs.Model.References.Materials;
    using TFlex.DOCs.Model.Search;
    using System.Linq;
    using MDMEPZ.Util;

    public partial class VariantsMaterialsReference : SpecialReference<VariantsMaterialsReferenceObject>	{				public partial class Factory		{		}		/// <summary>
		/// �������� ������� �� ������ ������������� ���������
		/// </summary>
		/// <param name="source"></param>
		/// <returns></returns>		//public ReferenceObject CreateReferenceObject(MaterialReferenceObject source)
		//{
		//	var obj = CreateReferenceObject() as VariantsMaterialsReferenceObject;
		//	obj.StartUpdate();
		//	obj.Name.Value = source.Name;
		//	obj.LinkedMaterial = source;
		//	return obj;
		//}		/// <summary>
		/// �������� ������� �� ������ ������������� ��������� � ����������� � ������������� �������
		/// </summary>
		/// <param name="source"></param>
		/// <param name="parent"></param>
		/// <returns></returns>		public ReferenceObject CreateReferenceObject(MaterialReferenceObject source, ReferenceObject parent)
		{
			var obj = CreateReferenceObject(parent) as VariantsMaterialsReferenceObject;
            obj.StartUpdate();
            obj.Name.Value = source.Name;
            obj.LinkedMaterial = source;
			return obj;
		}		public VariantsMaterialsReferenceObject FindByMaterial(ReferenceObject material)
		{
			return Find(Filter.Parse($"[��������� ��������] = '{material}'", this.ParameterGroup)).FirstOrDefault() as VariantsMaterialsReferenceObject;
		}	}}