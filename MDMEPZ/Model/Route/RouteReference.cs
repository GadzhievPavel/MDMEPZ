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
		/// ������ �������
		/// </summary>
		/// <param name="route"></param>
		/// <returns></returns>
		public ReferenceObject CreateReferenceObject(Route route)
		{
			List<ReferenceObject> saveList = new List<ReferenceObject>();
			RouteReferenceObject routeReferenceObject = CreateReferenceObject(Classes.RouteType) as RouteReferenceObject;
			routeReferenceObject.StartUpdate();
			routeReferenceObject.Name.Value = route.������������;
			routeReferenceObject.UID.Value = route.������.UID;
			routeReferenceObject.Kod.Value = route.���;
			routeReferenceObject.Vladelets.Value = route.��������.UID;
            //routeReferenceObject.EndChanges(); ????

			
			return routeReferenceObject;
		}
		/// <summary>
		/// ������ ����� ��������(�����)
		/// </summary>
		/// <param name="point"></param>
		/// <param name="parentRoute"></param>
		/// <returns></returns>
		public ReferenceObject CreateReferenceObjectRoutePoint(RoutePointRows point, ReferenceObject parentRoute)
		{

				var routePoint = CreateReferenceObject((ReferenceObject)parentRoute, Classes.RoutePointType) as RouteReferenceObject;
				routePoint.StartUpdate();
				routePoint.NomerStroki.Value = point.�����������;
				routePoint.UID.Value = point.�����.UID;
				
			
			return routePoint;
		}
	}
}
