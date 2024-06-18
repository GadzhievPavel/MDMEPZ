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
            //routePoint.Vladelets.Value = vladelets;
            return routePoint;
        }
        /// <summary>
        /// Получаю в json заходы, ищу уже созданные заходы по UID и
        /// </summary>
        /// <param name="visit"></param>
        /// <returns></returns>
        //public ReferenceObject CreateReferenceObjectRoutePoint(Visit visit)
        //      {
        //	var referenceRouteAndPoint = Connection.ReferenceCatalog.Find(RouteReference.ReferenceId).CreateReference();
        //	var oneVisit = referenceRouteAndPoint.Find(RouteTypes.Keys.RoutePointType, visit.Ссылка.UID).FirstOrDefault();
        //	if(oneVisit!=null)
        //          {
        //		var cexoperexod = oneVisit.GetObject(RouteReferenceObject.RelationKeys.Visit_Link);
        //		cexoperexod.SetLinkedObject(new Guid("30888ac1-d215-478f-aaf2-915be9aa9066"),);//установка найденному цехопереходу подразделение
        //          }

        //      }
    }
}
