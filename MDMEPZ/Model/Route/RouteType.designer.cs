//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TFlex.DOCs.References.Route
{
	using System;
	using TFlex.DOCs.Model.References;
	using TFlex.DOCs.Model.Classes;
	
	
	/// <summary>
	/// Представляет описание типа объекта справочника "Маршруты ERP"
	/// </summary>
	public partial class RouteType
	{
		
		internal RouteType(RouteTypes owner) : 
				base(owner)
		{
		}
		
		/// <summary>
		/// Возвращает типы объектов справочника "Маршруты ERP"
		/// </summary>
		public new RouteTypes Classes
		{
			get
			{
				return ((RouteTypes)(base.Classes));
			}
		}
		
		/// <summary>
		/// Возвращает true, если текущий экземпляр описывает тип "Маршруты ERP" или порождён от него
		/// </summary>
		public bool IsMainTypeRoute
		{
			get
			{
				return IsInherit(RouteTypes.Keys.MainTypeRoute);
			}
		}
		
		/// <summary>
		/// Возвращает true, если текущий экземпляр описывает тип "Маршрут" или порождён от него
		/// </summary>
		public bool IsRouteType
		{
			get
			{
				return IsInherit(RouteTypes.Keys.RouteType);
			}
		}
		
		/// <summary>
		/// Возвращает true, если текущий экземпляр описывает тип "Цехопереход" или порождён от него
		/// </summary>
		public bool IsRoutePointType
		{
			get
			{
				return IsInherit(RouteTypes.Keys.RoutePointType);
			}
		}
	}
}
