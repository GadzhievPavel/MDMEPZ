//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TFlex.DOCs.References.FilterOtherProduct
{
	using System;
	using TFlex.DOCs.Model.References;
	using TFlex.DOCs.Model.Structure;
	using TFlex.DOCs.Model.References.Links;
	using TFlex.DOCs.Model.Classes;
	using TFlex.DOCs.Model.Parameters;
	
	
	/// <summary>
	/// Представляет объект справочника "Прочие изделия НСИ"
	/// </summary>
	public partial class FilterOtherProductReferenceObject
	{
		
		internal FilterOtherProductReferenceObject(FilterOtherProductReference reference) : 
				base(reference)
		{
		}
		
		/// <summary>
		/// Возвращает описание типа объекта
		/// </summary>
		public new FilterOtherProductType Class
		{
			get
			{
				return ((FilterOtherProductType)(base.Class));
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
		/// Уникальные идентификаторы (GUID) параметров справочника "Прочие изделия НСИ"
		/// </summary>
		public class FieldKeys
		{
			
			/// <summary>
			/// Представляет уникальный идентификатор (GUID) параметра "Наименование"
			/// </summary>
		   //public static readonly Guid Name = new Guid("52b6c6c2-5b15-4aa4-9983-9a7206c1a6e1");

			/// <summary>
			/// Представляет уникальный идентификатор (GUID) параметра "Классификация"
			/// </summary>
		   public static readonly Guid Classification = new Guid("691980a7-83f6-41ec-b465-02741a6527c3");

		}
		
		/// <summary>
		/// Уникальные идентификаторы (GUID) связей и списков объектов справочника "Прочие изделия НСИ"
		/// </summary>
		public class RelationKeys
		{
			
			/// <summary>
			/// Представляет уникальный идентификатор (GUID) связи "Входящая номенклатура"
			/// </summary>
		   public static readonly Guid InputNomenclature = new Guid("7c4b9d7a-787d-4d73-b1b2-f51c072eb662");

		}
	}
}
