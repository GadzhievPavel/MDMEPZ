using MDMEPZ.Dto;
using MDMEPZ.Dto.Notification;
using NotificationsEPZ;
using NotificationsEPZ.Changes.ListObjects;
using NotificationsEPZ.Changes.ListObjects.Actions;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFlex.DOCs.Model;
using TFlex.DOCs.Model.References.Catalogs;
using TFlex.DOCs.Model.References.Nomenclature;
using TFlex.DOCs.Model.References.Nomenclature.ModificationNotices;
using TFlex.DOCs.References.NomenclatureERP;
using TFlex.DOCs.References.StructureTypes;

namespace MDMEPZ.Service.Integration
{
    public class ListTMCService
    {
        private ServerConnection connection;
        private NomenclatureMDMReference mdmReference;
        private List<ItemTMC> listTMC;
        private StructureTypesReference structureTypesReference;
        private StructureTypesReferenceObject productionTechnologicalStructure;

        public ListTMCService(ServerConnection connection)
        {
            this.connection = connection;
            mdmReference = new NomenclatureMDMReference(connection);
            structureTypesReference = connection.ReferenceCatalog.Find(StructureTypesReference.ReferenceId).CreateReference() as StructureTypesReference;
            productionTechnologicalStructure = structureTypesReference.Find("Производственно-технологическая") as StructureTypesReferenceObject;
            listTMC = new List<ItemTMC>();
        }
        /// <summary>
        /// Веруть список тмц
        /// </summary>
        /// <param name="changes">список изменений</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public List<ItemTMC> GetListTMC(List<Change> changes)
        {
            foreach (var change in changes)
            {
                ///Обработка действий
                var actions = change.Actions;
                foreach (var action in actions)
                {
                    if (action.TypeGuid.Equals(TypeActionsChange.ChangeObject))
                    {
                        continue;
                    }

                    var itemTMC = new ItemTMC();

                    var connections = action.GetChangeConnection();
                    NomenclatureObject root;
                    if (connections.All(con => con.ParentObject.Equals(connections.First().ParentObject)))
                    {
                        root = connections.First().ParentObject as NomenclatureObject;
                    }
                    else
                    {
                        throw new System.Exception("родители у подключений отличаются");
                    }

                    itemTMC.product = Nomenclature.CreateInstance(root.
                        GetObject(NomenclatureMDMReferenceObject.RelationKeys.Nomenclature) as NomenclatureMDMReferenceObject);

                    if (action.TypeGuid.Equals(TypeActionsChange.SWAP) || action.TypeGuid.Equals(TypeActionsChange.ADD))
                    {
                        var addedConnections = connections.Find(c => !c.SystemFields.DeletedInDesignContext);
                        var addedNomenclature = addedConnections.ChildObject as NomenclatureObject;
                        if (addedNomenclature != null)
                        {
                            itemTMC.newNomenclature = Nomenclature.CreateInstance(addedNomenclature.
                                GetObject(NomenclatureMDMReferenceObject.RelationKeys.Nomenclature) as NomenclatureMDMReferenceObject);
                        }
                    }

                    if (action.TypeGuid.Equals(TypeActionsChange.DELETED) || action.TypeGuid.Equals(TypeActionsChange.SWAP))
                    {
                        var deletedConnections = connections.Find(c => c.SystemFields.DeletedInDesignContext);
                        var deletedNomenclature = deletedConnections.ChildObject as NomenclatureObject;
                        if (deletedNomenclature != null)
                        {
                            itemTMC.excluded = Nomenclature.CreateInstance(deletedNomenclature.
                                GetObject(NomenclatureMDMReferenceObject.RelationKeys.Nomenclature) as NomenclatureMDMReferenceObject);
                        }
                    }

                    if (action.TypeGuid.Equals(TypeActionsChange.CHANGE))
                    {
                        if (connections.Count > 1)
                        {
                            throw new System.Exception("Действие типа Изменение имеет более 1 подключения");
                        }

                        var connection = connections.First();
                        var deletedNomenclature = connection.ChildObject as NomenclatureObject;
                        var addedNomenclature = connection.ChildObject as NomenclatureObject;

                        itemTMC.newNomenclature = Nomenclature.CreateInstance(addedNomenclature.GetObject(
                            NomenclatureMDMReferenceObject.RelationKeys.Nomenclature) as NomenclatureMDMReferenceObject);
                        itemTMC.excluded = Nomenclature.CreateInstance(deletedNomenclature.GetObject(
                            NomenclatureMDMReferenceObject.RelationKeys.Nomenclature) as NomenclatureMDMReferenceObject);
                    }

                    listTMC.Add(itemTMC);
                }
                ///Область применения
                var usingAreas = change.UsingAreas;
                foreach (var area in usingAreas)
                {
                    var matchConnections = area.GetMatchConnections();
                    foreach (var matchConnection in matchConnections)
                    {
                        NomenclatureObject root;
                        var itemTMC = new ItemTMC();
                        var addedConnection = matchConnection.AddedConnection;
                        var deletedConnection = matchConnection.DeletedConnection;

                        if (addedConnection != null)
                        {
                            var addedNomenclature = addedConnection.ChildObject as NomenclatureObject;
                            if (addedNomenclature != null)
                            {
                                itemTMC.newNomenclature = Nomenclature.CreateInstance(addedNomenclature.
                                    GetObject(NomenclatureMDMReferenceObject.RelationKeys.Nomenclature) as NomenclatureMDMReferenceObject);
                            }
                        }

                        if (deletedConnection != null)
                        {
                            var deletedNomenclature = deletedConnection.ChildObject as NomenclatureObject;
                            if (deletedNomenclature != null)
                            {
                                itemTMC.excluded = Nomenclature.CreateInstance(deletedNomenclature.
                                    GetObject(NomenclatureMDMReferenceObject.RelationKeys.Nomenclature) as NomenclatureMDMReferenceObject);
                            }
                        }

                        HashSet<NomenclatureObject> roots = new HashSet<NomenclatureObject>();
                        if (addedConnection != null)
                        {
                            roots.Add(addedConnection.ParentObject as NomenclatureObject);
                        }
                        if (deletedConnection != null)
                        {
                            roots.Add(deletedConnection.ParentObject as NomenclatureObject);
                        }

                        if (roots.Count > 1)
                        {
                            throw new System.Exception("Более одного родительского объекта");
                        }
                        itemTMC.product = Nomenclature.CreateInstance(roots.First().
                            GetObject(NomenclatureMDMReferenceObject.RelationKeys.Nomenclature) as NomenclatureMDMReferenceObject);

                        listTMC.Add(itemTMC);

                    }
                }
            }
            return listTMC;
        }

        public List<ListInputs> GetListInputs(List<Change> changes)
        {
            var listInputs = new List<ListInputs>();
            foreach (var change in changes)
            {
                var actions = change.Actions;
                foreach (var action in actions)
                {
                    if (action.TypeGuid.Equals(TypeActionsChange.ChangeObject))
                    {
                        continue;
                    }

                    var input = new ListInputs();
                    var connections = action.GetChangeConnection();
                    NomenclatureObject root;

                    if (connections.All(con => con.ParentObject.Equals(connections.First().ParentObject)))
                    {
                        root = connections.First().ParentObject as NomenclatureObject;
                    }
                    else
                    {
                        throw new System.Exception("родители у подключений отличаются");
                    }
                    ///to do
                    ///connections.All(c => c.StructureTypes.Where(type =>type.Equals(productionTechnologicalStructure)).FirstOrDefault().Equals())
                    ///var inProductionTechnologicalStructure = 

                    input.usingZadel = action.UsingZadel;
                    if (action.TypeGuid.Equals(TypeActionsChange.SWAP))
                    {
                        var addedConnection = connections.Where(c => !c.SystemFields.DeletedInDesignContext).First();
                        var deletedConnection = connections.Where(c => c.SystemFields.DeletedInDesignContext).First();

                        var deletedNomenclature = deletedConnection.ChildObject as NomenclatureObject;
                        var addedNomenclature = addedConnection.ChildObject as NomenclatureObject;

                        input.nomenclatureSrc = Nomenclature.CreateInstance(deletedNomenclature.GetObject(
                                NomenclatureMDMReferenceObject.RelationKeys.Nomenclature) as NomenclatureMDMReferenceObject);
                        input.nomenclatureNew = NomenclatureWithRoute.CreateInstance(connection, addedNomenclature.GetObject(
                            NomenclatureMDMReferenceObject.RelationKeys.Nomenclature) as NomenclatureMDMReferenceObject);

                        input.countBefore = deletedConnection.Amount;
                        input.countZamen = addedConnection.Amount;
                        input.countAfter = 0;
                    }
                    else if (action.TypeGuid.Equals(TypeActionsChange.ADD))
                    {
                        var addedConnection = connections.Where(c => !c.SystemFields.DeletedInDesignContext).First();
                        var addedNomenclature = addedConnection.ChildObject as NomenclatureObject;

                        input.nomenclatureNew = NomenclatureWithRoute.CreateInstance(connection, addedNomenclature.GetObject(
                            NomenclatureMDMReferenceObject.RelationKeys.Nomenclature) as NomenclatureMDMReferenceObject);
                        input.countAfter = addedConnection.Amount;
                    }
                    else if (action.TypeGuid.Equals(TypeActionsChange.DELETED))
                    {
                        var deletedConnection = connections.Where(c => c.SystemFields.DeletedInDesignContext).First();
                        var deletedNomenclature = deletedConnection.ChildObject as NomenclatureObject;

                        input.nomenclatureSrc = Nomenclature.CreateInstance(deletedNomenclature.GetObject(
                            NomenclatureMDMReferenceObject.RelationKeys.Nomenclature) as NomenclatureMDMReferenceObject);

                        input.countAfter = 0;
                        input.countBefore = deletedConnection.Amount;
                    }

                    if (action.TypeGuid.Equals(TypeActionsChange.CHANGE))
                    {

                        var changeConnection = connections.Where(c => !c.SystemFields.DeletedInDesignContext).First();
                        var changeNomenclature = changeConnection.ChildObject as NomenclatureObject;
                        input.nomenclatureNew = NomenclatureWithRoute.CreateInstance(connection, changeNomenclature.GetObject(
                            NomenclatureMDMReferenceObject.RelationKeys.Nomenclature) as NomenclatureMDMReferenceObject);
                        input.nomenclatureSrc = Nomenclature.CreateInstance(changeNomenclature.GetObject(
                            NomenclatureMDMReferenceObject.RelationKeys.Nomenclature) as NomenclatureMDMReferenceObject);
                        input.countAfter = changeConnection.Amount;
                    }
                    listInputs.Add(input);
                }
                var areasUsing = change.UsingAreas;
                foreach (var area in areasUsing)
                {
                    var matchConnections = area.GetMatchConnections();
                    foreach (var connection in matchConnections)
                    {
                        var addedConnection = connection.AddedConnection as NomenclatureHierarchyLink;
                        var deletedConnection = connection.DeletedConnection as NomenclatureHierarchyLink;

                        var input = new ListInputs();

                        if (addedConnection != null)
                        {
                            var addedNomenclature = addedConnection.ChildObject as NomenclatureObject;
                            input.nomenclatureNew = NomenclatureWithRoute.CreateInstance(this.connection,
                                addedNomenclature.GetObject(NomenclatureMDMReferenceObject.RelationKeys.Nomenclature) as NomenclatureMDMReferenceObject);
                            input.countAfter = addedConnection.Amount;
                        }

                        if (deletedConnection != null)
                        {
                            var deletedNomenclature = deletedConnection.ChildObject as NomenclatureObject;
                            input.nomenclatureSrc = Nomenclature.CreateInstance(deletedNomenclature.GetObject(
                                NomenclatureMDMReferenceObject.RelationKeys.Nomenclature) as NomenclatureMDMReferenceObject);
                            input.countBefore = deletedConnection.Amount;
                        }

                        input.usingZadel = change.UsingZadel;
                        listInputs.Add(input);
                    }
                }
            }
            return listInputs;
        }
    }
}
