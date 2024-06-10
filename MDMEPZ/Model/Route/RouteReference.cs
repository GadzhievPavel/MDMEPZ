namespace TFlex.DOCs.References.Route
{
	using System;
	using TFlex.DOCs.Model.References;
	using TFlex.DOCs.Model.Structure;
	using TFlex.DOCs.Model.Classes;
	using TFlex.DOCs.Model;
    using MDMEPZ.Util;
    using System.Collections.Generic;
    using MDMEPZ.Dto;

    public partial class RouteReference : SpecialReference<RouteReferenceObject>
	{
		
		public partial class Factory
		{
		}
		/// <summary>
		/// Создаёт маршрут
		/// </summary>
		/// <param name="route"></param>
		/// <returns></returns>
		public ReferenceObject CreateReferenceObject(Route route)
		{
			List<ReferenceObject> saveList = new List<ReferenceObject>();
			RouteReferenceObject routeReferenceObject = CreateReferenceObject(Classes.RouteType) as RouteReferenceObject;
			routeReferenceObject.StartUpdate();
			routeReferenceObject.Name.Value = route.Наименование;
			routeReferenceObject.UID.Value = route.Ссылка.UID;
			routeReferenceObject.Kod.Value = route.Код;
			routeReferenceObject.Vladelets.Value = route.Владелец.UID;
            //routeReferenceObject.EndChanges(); ????

			
			return routeReferenceObject;
		}
		/// <summary>
		/// Создаёт точку маршрута(заход)
		/// </summary>
		/// <param name="point"></param>
		/// <param name="parentRoute"></param>
		/// <returns></returns>
		public ReferenceObject CreateReferenceObjectRoutePoint(RoutePointRows point, ReferenceObject parentRoute)
		{

				var routePoint = CreateReferenceObject((ReferenceObject)parentRoute, Classes.RoutePointType) as RouteReferenceObject;
				routePoint.StartUpdate();
				routePoint.NomerStroki.Value = point.НомерСтроки;
				routePoint.UID.Value = point.Заход.UID;
				
			
			return routePoint;
		}
	}
}
