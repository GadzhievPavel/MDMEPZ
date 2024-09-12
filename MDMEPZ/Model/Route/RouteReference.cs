namespace TFlex.DOCs.References.Route
{
    using DeveloperUtilsLibrary;
    using MDMEPZ.Dto;
    using MDMEPZ.Util;
    using System.Collections.Generic;
    using System.Linq;
    using TFlex.DOCs.Model.References;
    using TFlex.DOCs.Model.Search;
    using TFlex.Model.Technology.References.TechnologyElements;

    /// <summary>
    /// ���������� MDM
    /// </summary>
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
        /// �������� ������� � MDM �� ������ ������ �� PDM
        /// </summary>
        /// <param name="techRoute"></param>
        /// <returns></returns>
        public ReferenceObject CreateReferenceObject(TechRoute techRoute)
        {
            var findedRoute = Find(Filter.Parse($"[������� ��] = '{techRoute}'", ParameterGroup)).FirstOrDefault();
            if (findedRoute != null)
            {
                return findedRoute;
            }

            var routeMdm = CreateReferenceObject(Classes.RouteType) as RouteReferenceObject;
            routeMdm.StartUpdate();
            routeMdm.Name.Value = techRoute.Name.Value;
            routeMdm.RoutePdm = techRoute;
            return routeMdm;
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
            //routePoint.Vladelets.Value = vladelets;
            return routePoint;
        }
        /// <summary>
        /// ������� � json ������, ��� ��� ��������� ������ �� UID �
        /// </summary>
        /// <param name="visit"></param>
        /// <returns></returns>
        //public ReferenceObject CreateReferenceObjectRoutePoint(Visit visit)
        //      {
        //	var referenceRouteAndPoint = Connection.ReferenceCatalog.Find(RouteReference.ReferenceId).CreateReference();
        //	var oneVisit = referenceRouteAndPoint.Find(RouteTypes.Keys.RoutePointType, visit.������.UID).FirstOrDefault();
        //	if(oneVisit!=null)
        //          {
        //		var cexoperexod = oneVisit.GetObject(RouteReferenceObject.RelationKeys.Visit_Link);
        //		cexoperexod.SetLinkedObject(new Guid("30888ac1-d215-478f-aaf2-915be9aa9066"),);//��������� ���������� ������������ �������������
        //          }

        //      }
    }
}
