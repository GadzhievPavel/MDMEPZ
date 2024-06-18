namespace TFlex.DOCs.References.Route
{
    using MDMEPZ.Dto;
    using MDMEPZ.Util;
    using System.Collections.Generic;
    using TFlex.DOCs.Model.References;

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
