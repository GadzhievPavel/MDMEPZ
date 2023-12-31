//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TFlex.DOCs.References.EtalonWorkpiece
{
	using System;
	using TFlex.DOCs.Model.References;
	using TFlex.DOCs.Model.Structure;
	using TFlex.DOCs.Model.References.Links;
	using TFlex.DOCs.Model.Classes;
	using TFlex.DOCs.Model.Parameters;
	
	
	/// <summary>
	/// Представляет объект справочника "Эталонные заготовки"
	/// </summary>
	public partial class EtalonWorkpieceReferenceObject
	{
		
		internal EtalonWorkpieceReferenceObject(EtalonWorkpieceReference reference) : 
				base(reference)
		{
		}
		
		/// <summary>
		/// Возвращает описание типа объекта
		/// </summary>
		public new EtalonWorkpieceType Class
		{
			get
			{
				return ((EtalonWorkpieceType)(base.Class));
			}
		}
		
		/// <summary>
		/// Возвращает параметр "Наименование"
		/// </summary>
		public StringParameter Name
		{
			get
			{
				return ((StringParameter)(this[FieldKeys.Name]));
			}
		}
		
		/// <summary>
		/// Возвращает параметр "Обозначение"
		/// </summary>
		public StringParameter Denotation
		{
			get
			{
				return ((StringParameter)(this[FieldKeys.Denotation]));
			}
		}
		
		/// <summary>
		/// Возвращает параметр "Покупное"
		/// </summary>
		public BooleanParameter IsBuying
		{
			get
			{
				return ((BooleanParameter)(this[FieldKeys.IsBuying]));
			}
		}
		
		/// <summary>
		/// Возвращает параметр "Конечное изделие"
		/// </summary>
		public BooleanParameter IsFinalProduct
		{
			get
			{
				return ((BooleanParameter)(this[FieldKeys.IsFinalProduct]));
			}
		}
		
		/// <summary>
		/// Возвращает параметр "Литера"
		/// </summary>
		public StringParameter Litera
		{
			get
			{
				return ((StringParameter)(this[FieldKeys.Litera]));
			}
		}
		
		/// <summary>
		/// Возвращает параметр "Формат"
		/// </summary>
		public StringParameter Format
		{
			get
			{
				return ((StringParameter)(this[FieldKeys.Format]));
			}
		}
		
		/// <summary>
		/// Возвращает или задаёт связанный объект справочника "Материалы" по связи "Материалы"
		/// </summary>
		public ReferenceObject Material
		{
			get
			{
				return GetObject(RelationKeys.Material);
			}
			set
			{
				SetLinkedObject(RelationKeys.Material, value);
			}
		}
		
		/// <summary>
		/// Возвращает или задаёт связанный объект справочника "Номенклатура ERP" по связи "Номенклатура ERP З"
		/// </summary>
		public ReferenceObject Nomenclature
		{
			get
			{
				return GetObject(RelationKeys.Nomenclature);
			}
			set
			{
				SetLinkedObject(RelationKeys.Nomenclature, value);
			}
		}
		
		/// <summary>
		/// Уникальные идентификаторы (GUID) параметров справочника "Эталонные заготовки"
		/// </summary>
		public class FieldKeys
		{
			
			/// <summary>
			/// Представляет уникальный идентификатор (GUID) параметра "Наименование"
			/// </summary>
		   public static readonly Guid Name = new Guid("f7de9f9a-fb94-414a-a87c-7d5797a1d986");

			/// <summary>
			/// Представляет уникальный идентификатор (GUID) параметра "Обозначение"
			/// </summary>
		   public static readonly Guid Denotation = new Guid("634e1a57-3c98-4894-ac37-c717471c1eb5");

			/// <summary>
			/// Представляет уникальный идентификатор (GUID) параметра "Покупное"
			/// </summary>
		   public static readonly Guid IsBuying = new Guid("7ef31679-bd26-4641-878d-f90ecf8dde11");

			/// <summary>
			/// Представляет уникальный идентификатор (GUID) параметра "Конечное изделие"
			/// </summary>
		   public static readonly Guid IsFinalProduct = new Guid("9d671dea-211b-4668-9ca6-1c80f0f2139e");

			/// <summary>
			/// Представляет уникальный идентификатор (GUID) параметра "Литера"
			/// </summary>
		   public static readonly Guid Litera = new Guid("cf53a185-a969-48a3-9b98-2f86d02bd1ae");

			/// <summary>
			/// Представляет уникальный идентификатор (GUID) параметра "Формат"
			/// </summary>
		   public static readonly Guid Format = new Guid("eaf2aaa9-eda3-4665-a8ac-066458382ecb");

		}
		
		/// <summary>
		/// Уникальные идентификаторы (GUID) связей и списков объектов справочника "Эталонные заготовки"
		/// </summary>
		public class RelationKeys
		{
			
			/// <summary>
			/// Представляет уникальный идентификатор (GUID) связи "Материалы"
			/// </summary>
		   public static readonly Guid Material = new Guid("dd01bb29-ea25-407a-8975-7f9f0db26ad0");

			/// <summary>
			/// Представляет уникальный идентификатор (GUID) связи "Номенклатура ERP З"
			/// </summary>
		   public static readonly Guid Nomenclature = new Guid("b83e8813-4bb8-4bab-b9e0-e22945c60bcf");

		}
	}
}
