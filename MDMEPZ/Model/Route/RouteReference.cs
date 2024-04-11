namespace TFlex.DOCs.References.Route{
    using System;
    using System.Linq;
    using MDMEPZ.Dto;
    using MDMEPZ.Model;
    using MDMEPZ.Util;
    using TFlex.DOCs.Model;
    using TFlex.DOCs.Model.Classes;
    using TFlex.DOCs.Model.References;
    using TFlex.DOCs.Model.Search;
    using TFlex.DOCs.Model.Structure;


    public partial class RouteReference : SpecialReference<RouteReferenceObject>	{				public partial class Factory		{		}		public ReferenceObject CreateReferenceObject(MDMEPZ.Dto.Route route)
		{			RouteReferenceObject routeReferenceObject = CreateReferenceObject() as RouteReferenceObject;
            routeReferenceObject.StartUpdate();            routeReferenceObject.Name_Route.Value = route.Наименование;            routeReferenceObject.Kod_Route.Value = route.Код;            routeReferenceObject.Kolichestvo_normirovaniya_Route.Value = route.КоличествоНормирования;            return routeReferenceObject;		}	}}