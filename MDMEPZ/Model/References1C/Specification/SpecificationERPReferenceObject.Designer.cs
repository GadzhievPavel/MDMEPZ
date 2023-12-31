//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TFlex.DOCs.References.SpecificationERP
{
	using System;
	using TFlex.DOCs.Model.References;
	using TFlex.DOCs.Model.Structure;
	using TFlex.DOCs.Model.References.Links;
	using TFlex.DOCs.Model.Classes;
	using TFlex.DOCs.Model.Parameters;
	
	
	/// <summary>
	/// Представляет объект справочника "Спецификации"
	/// </summary>
	public partial class SpecificationERPReferenceObject
	{
		
		internal SpecificationERPReferenceObject(SpecificationERPReference reference) : 
				base(reference)
		{
		}
		
		/// <summary>
		/// Возвращает описание типа объекта
		/// </summary>
		public new SpecificationERPType Class
		{
			get
			{
				return ((SpecificationERPType)(base.Class));
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
		/// Возвращает связанные объекты справочника "Номенклатура ERP" по связи "Набор подключений"
		/// </summary>
		public ReferenceObjectCollection Connections
		{
			get
			{
				return Links.ToMany[RelationKeys.Connections].Objects;
			}
		}
		
		/// <summary>
		/// Подключает объект справочника "Номенклатура ERP" по связи "Набор подключений"
		/// </summary>
		/// <param name="newLinkedObject">
		/// Подключаемый объект
		/// </param>
		/// <returns>
		/// Подключённый объект
		/// </returns>
		public ReferenceObject AddConnection(ReferenceObject newLinkedObject)
		{
			return AddLinkedObject(RelationKeys.Connections, newLinkedObject);
		}
		
		/// <summary>
		/// Отключает объект справочника "Номенклатура ERP" по связи "Набор подключений"
		/// </summary>
		/// <param name="linkedObject">
		/// Связанный объект
		/// </param>
		/// <returns>
		/// true, если объект был отключен
		/// </returns>
		public Boolean RemoveConnection(ReferenceObject linkedObject)
		{
			return RemoveLinkedObject(RelationKeys.Connections, linkedObject);
		}
		
		/// <summary>
		/// Уникальные идентификаторы (GUID) параметров справочника "Спецификации"
		/// </summary>
		public class FieldKeys
		{
			
			/// <summary>
			/// Представляет уникальный идентификатор (GUID) параметра "Наименование"
			/// </summary>
		   public static readonly Guid Name = new Guid("7cf66939-0073-4727-bd32-97b4cf130bfc");

		}
		
		/// <summary>
		/// Уникальные идентификаторы (GUID) связей и списков объектов справочника "Спецификации"
		/// </summary>
		public class RelationKeys
		{
			
			/// <summary>
			/// Представляет уникальный идентификатор (GUID) связи "Набор подключений"
			/// </summary>
		   public static readonly Guid Connections = new Guid("04d3917e-0441-47cc-967b-4319f176fd31");

		}
	}
}
