//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TFlex.DOCs.References.GroupList
{
	using System;
	using TFlex.DOCs.Model.References;
	using TFlex.DOCs.Model.Structure;
	using TFlex.DOCs.Model.References.Links;
	using TFlex.DOCs.Model.Classes;
	using TFlex.DOCs.Model.Parameters;
	
	
	/// <summary>
	/// Представляет объект справочника "Группы списка"
	/// </summary>
	public partial class GroupListReferenceObject
	{
		
		internal GroupListReferenceObject(GroupListReference reference) : 
				base(reference)
		{
		}
		
		/// <summary>
		/// Возвращает описание типа объекта
		/// </summary>
		public new GroupListType Class
		{
			get
			{
				return ((GroupListType)(base.Class));
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
		/// Уникальные идентификаторы (GUID) параметров справочника "Группы списка"
		/// </summary>
		public class FieldKeys
		{
			
			/// <summary>
			/// Представляет уникальный идентификатор (GUID) параметра "Наименование"
			/// </summary>
		   public static readonly Guid Name = new Guid("e6952ba1-0dd3-41e6-88dd-87c7819f94d5");

			/// <summary>
			/// Представляет уникальный идентификатор (GUID) параметра "GUID(1C)"
			/// </summary>
		   public static readonly Guid GUID_1C = new Guid("967b0475-e6b7-414d-a1d9-ec06678be2a7");

		}
	}
}
