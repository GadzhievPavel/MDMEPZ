//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TFlex.DOCs.References.FilterMaterial
{
	using System;
	using TFlex.DOCs.Model.References;
	using TFlex.DOCs.Model.Structure;
	using TFlex.DOCs.Model.References.Links;
	using TFlex.DOCs.Model.Classes;
	using TFlex.DOCs.Model.Parameters;
	
	
	/// <summary>
	/// Представляет объект справочника "Материалы НСИ"
	/// </summary>
	public partial class FilterMaterialReferenceObject
	{
		
		internal FilterMaterialReferenceObject(FilterMaterialReference reference) : 
				base(reference)
		{
		}
		
		/// <summary>
		/// Возвращает описание типа объекта
		/// </summary>
		public new FilterMaterialType Class
		{
			get
			{
				return ((FilterMaterialType)(base.Class));
			}
		}
		
		/// <summary>
		/// Возвращает параметр "Наименование"
		/// </summary>
		//public StringParameter Name
		//{
		//	get
		//	{
		//		return ((StringParameter)(this[FieldKeys.Name]));
		//	}
		//}
		
		/// <summary>
		/// Возвращает параметр "Классификация"
		/// </summary>
		public StringParameter Classification
		{
			get
			{
				return ((StringParameter)(this[FieldKeys.Classification]));
			}
		}
		
		/// <summary>
		/// Возвращает или задаёт связанный объект справочника "Номенклатура ERP" по связи "Входящая номенклатура"
		/// </summary>
		public ReferenceObject InputNomenclature
		{
			get
			{
				return GetObject(RelationKeys.InputNomenclature);
			}
			set
			{
				SetLinkedObject(RelationKeys.InputNomenclature, value);
			}
		}
		
		/// <summary>
		/// Уникальные идентификаторы (GUID) параметров справочника "Материалы НСИ"
		/// </summary>
		public class FieldKeys
		{
			
			/// <summary>
			/// Представляет уникальный идентификатор (GUID) параметра "Наименование"
			/// </summary>
		   //public static readonly Guid Name = new Guid("4bc7a674-7f9b-40b0-a269-05bb3394de8a");

			/// <summary>
			/// Представляет уникальный идентификатор (GUID) параметра "Классификация"
			/// </summary>
		   public static readonly Guid Classification = new Guid("45058b58-8472-4ad3-a53c-89d1d8b17a6a");

		}
		
		/// <summary>
		/// Уникальные идентификаторы (GUID) связей и списков объектов справочника "Материалы НСИ"
		/// </summary>
		public class RelationKeys
		{
			
			/// <summary>
			/// Представляет уникальный идентификатор (GUID) связи "Входящая номенклатура"
			/// </summary>
		   public static readonly Guid InputNomenclature = new Guid("0832726f-a2e7-4045-b35b-fb2c938520c1");

		}
	}
}
