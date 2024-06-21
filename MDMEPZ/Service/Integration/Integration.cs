using MDMEPZ.Dto;
using MDMEPZ.Exception;
using MDMEPZ.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFlex.DOCs.Model;
using TFlex.DOCs.Model.References;
using TFlex.DOCs.Model.References.Nomenclature;
using TFlex.DOCs.Model.Search;
using TFlex.DOCs.References.NomenclatureERP;
using TFlex.DOCs.References.Route;
using TFlex.DOCs.References.StructureTypes;
using TFlex.Model.Technology.References.TechnologyElements;

namespace MDMEPZ.Service.Integration
{
    public class Integration
    {
        private NomenclatureObject rootProduct;
        private HashSet<NomenclatureObject> nomenclatures;
        private StructureTypesReference structureTypesReference;
        private StructureTypesReferenceObject structureType;
        private ServerConnection connection;
        private NomenclatureERPReference referenceERP;

        public Integration(ServerConnection serverConnection, NomenclatureObject rootProduct)
        {
            this.rootProduct = rootProduct;
            nomenclatures = new HashSet<NomenclatureObject>();
            this.connection = serverConnection;
            referenceERP = serverConnection.ReferenceCatalog.Find(NomenclatureERPReference.ReferenceId).CreateReference() as NomenclatureERPReference;

            if (referenceERP is null)
            {
                throw new ExceptionIntegration("Справочник Номенклатуры ERP не был найден");
            }
            structureTypesReference = serverConnection.ReferenceCatalog.Find(StructureTypesReference.ReferenceId).CreateReference() as StructureTypesReference;

            if (structureTypesReference is null)
            {
                throw new ExceptionIntegration("Справочник типов структур не был найден");
            }

            structureType = structureTypesReference.Find("Производственно-технологическая") as StructureTypesReferenceObject;

            if (structureType is null)
            {
                throw new ExceptionIntegration("Производственно-технологическая структура не была найдена");
            }

            FillNomenclature(this.rootProduct);
        }

        public Integration(NomenclatureERPReference nomenclatureERP, StructureTypesReference structureTypesReference, NomenclatureObject rootProduct)
        {
            this.rootProduct = rootProduct;
            nomenclatures = new HashSet<NomenclatureObject>();
            this.referenceERP = nomenclatureERP;
            if (referenceERP is null)
            {
                throw new ExceptionIntegration("Справочник Номенклатуры ERP не был найден");
            }
            this.structureTypesReference = structureTypesReference;
            if (structureTypesReference is null)
            {
                throw new ExceptionIntegration("Справочник типов структур не был найден");
            }
            structureType = structureTypesReference.Find("Производственно-технологическая") as StructureTypesReferenceObject;

            if (structureType is null)
            {
                throw new ExceptionIntegration("Производственно-технологическая структура не была найдена");
            }

            FillNomenclature(this.rootProduct);
        }

        /// <summary>
        /// Заполнение списка номенклатуры
        /// </summary>
        /// <param name="nom"></param>
        private void FillNomenclature(NomenclatureObject nom)
        {
            nomenclatures.Add(nom);
            var childrenLinks = nom.Children.GetHierarchyLinks().Cast<NomenclatureHierarchyLink>();
            var links = childrenLinks.Where(link => link.StructureTypes.Contains(structureType)).ToList();
            foreach (var link in links)
            {
                var child = link.ChildObject;
                if (child != null)
                {
                    nomenclatures.Add((NomenclatureObject)child);
                    FillNomenclature((NomenclatureObject)child);
                }
            }
        }

        /// <summary>
        /// Создание объекта в MDM
        /// </summary>
        public void CreateNomenclatureInMDM()
        {
            foreach (var nom in nomenclatures)
            {
                try
                {
                    var o = referenceERP.CreateReferenceObject(nom);
                    o.EndUpdate("Создан объек");
                }
                catch (ExceptionMDM ex)
                {
                    throw ex;
                }
                catch (ExceptionIntegration ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Формирование ресурсной спецификации
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string SendBom(string path)
        {
            var bomService = new BomService(connection ,rootProduct, nomenclatures);
            return bomService.GetBom(path);
        }
        /// <summary>
        /// Формирует набор Json строк в формате выгрузки из 1С
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public List<String> GetFilesOfBom(string root)
        {
            var bomService = new BomService(connection, rootProduct, nomenclatures);
            List<String> jsons = new List<String>();
            //jsons.Add(bomService.);
            return jsons;
        }

        /// <summary>
        /// Создает и возвращает все маршруты прикрепленные к коллекции номенклатуры
        /// </summary>
        /// <returns></returns>
        private List<RouteReferenceObject> preprocessingRoute()
        {
            RouteReference routeReference = new RouteReference(connection);
            List<RouteReferenceObject> listRoutes = new List<RouteReferenceObject>();
            foreach(var nom in nomenclatures)
            {
                var routesPdm = nom.GetObjects(NomenclatureObject.RelationKeys.LinkedTP).
                    Where(obj => obj.Class.Guid.Equals(new Guid("c02f6d42-1a50-48b2-ab35-fef5a165cde3"))).ToList();///поиск маршрута по guid
                foreach(var route in routesPdm)
                {
                    var routeMDM = routeReference.CreateReferenceObject(route) as RouteReferenceObject;
                    routeMDM.EndUpdate("Сохранение созданного объекта");
                    listRoutes.Add(routeMDM);
                }   
            }

            return listRoutes;
        }
    }
}
