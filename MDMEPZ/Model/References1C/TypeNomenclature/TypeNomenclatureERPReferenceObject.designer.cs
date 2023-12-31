//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TFlex.DOCs.References.TypeNomenclatureERP
{
	using System;
	using TFlex.DOCs.Model.References;
	using TFlex.DOCs.Model.Structure;
	using TFlex.DOCs.Model.References.Links;
	using TFlex.DOCs.Model.Classes;
	using TFlex.DOCs.Model.Parameters;
	
	
	/// <summary>
	/// Представляет объект справочника "Типы номенклатуры"
	/// </summary>
	public partial class TypeNomenclatureERPReferenceObject
	{
		
		internal TypeNomenclatureERPReferenceObject(TypeNomenclatureERPReference reference) : 
				base(reference)
		{
		}
		
		/// <summary>
		/// Возвращает описание типа объекта
		/// </summary>
		public new TypeNomenclatureERPType Class
		{
			get
			{
				return ((TypeNomenclatureERPType)(base.Class));
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
		/// Возвращает параметр "GUID(1C)"
		/// </summary>
		public GuidParameter GUID_1C
		{
			get
			{
				return ((GuidParameter)(this[FieldKeys.GUID_1C]));
			}
		}
		
		/// <summary>
		/// Уникальные идентификаторы (GUID) параметров справочника "Типы номенклатуры"
		/// </summary>
		public class FieldKeys
		{
			
			/// <summary>
			/// Представляет уникальный идентификатор (GUID) параметра "Наименование"
			/// </summary>
		   public static readonly Guid Name = new Guid("1f562b15-21d1-4d8e-add9-0681607f3a83");

			/// <summary>
			/// Представляет уникальный идентификатор (GUID) параметра "GUID(1C)"
			/// </summary>
		   public static readonly Guid GUID_1C = new Guid("f2259197-f6a0-46e3-acdf-dfe4396b744b");

		}
	}
}
