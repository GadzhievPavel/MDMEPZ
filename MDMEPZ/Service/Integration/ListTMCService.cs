using MDMEPZ.Dto;
using MDMEPZ.Dto.Notification;
using NotificationsEPZ;
using NotificationsEPZ.Changes.ListObjects;
using NotificationsEPZ.Changes.ListObjects.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFlex.DOCs.Model;
using TFlex.DOCs.Model.References.Nomenclature;
using TFlex.DOCs.Model.References.Nomenclature.ModificationNotices;
using TFlex.DOCs.References.NomenclatureERP;

namespace MDMEPZ.Service.Integration
{
    public class ListTMCService
    {
        private ServerConnection connection;
        private NomenclatureMDMReference mdmReference;
        private List<ItemTMC> listTMC;

        public ListTMCService(ServerConnection connection)
        {
            this.connection = connection;
            mdmReference = new NomenclatureMDMReference(connection);
            listTMC = new List<ItemTMC>();
        }

        public List<ItemTMC> GetListTMC(List<Change> changes)
        {
            foreach (var change in changes)
            {
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

                    if (action.TypeGuid.Equals(TypeActionsChange.SWAP) || action.TypeGuid.Equals(TypeActionsChange.ADD) ||
                        action.TypeGuid.Equals(TypeActionsChange.CHANGE))
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
                    listTMC.Add(itemTMC);
                }
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

                        if (addedConnection == null)
                        {
                            var addedNomenclature = addedConnection.ChildObject as NomenclatureObject;
                            if (addedNomenclature != null)
                            {
                                itemTMC.newNomenclature = Nomenclature.CreateInstance(addedNomenclature.
                                    GetObject(NomenclatureMDMReferenceObject.RelationKeys.Nomenclature) as NomenclatureMDMReferenceObject);
                            }
                        }

                        if (deletedConnection == null)
                        {
                            var deletedNomenclature = deletedConnection.ChildObject as NomenclatureObject;
                            if (deletedNomenclature != null)
                            {
                                itemTMC.excluded = Nomenclature.CreateInstance(deletedNomenclature.
                                    GetObject(NomenclatureMDMReferenceObject.RelationKeys.Nomenclature) as NomenclatureMDMReferenceObject);
                            }
                        }

                        HashSet<NomenclatureObject> roots = new HashSet<NomenclatureObject>();
                        if (addedConnection == null)
                        {
                            roots.Add(addedConnection.ParentObject as NomenclatureObject);
                        }
                        if (deletedConnection == null)
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
        //public List<ItemTMC> getListTMC(List<MatchConnection> matches, NotificationsEPZ.Changes.ListObjects.Action action)
        //{
        //    var listTMC = new List<ItemTMC>();
        //    var products = new List<NomenclatureObject>();
        //    foreach (var match in matches)
        //    {
        //        HashSet<NomenclatureObject> nomenclatures = new HashSet<NomenclatureObject>();
        //        var sourceParent = match.SourceConnection?.ParentObject as NomenclatureObject;
        //        if (sourceParent == null)
        //        {
        //            nomenclatures.Add(sourceParent);
        //        }
        //        var deletedParent = match.DeletedConnection?.ParentObject as NomenclatureObject;
        //        if (deletedParent == null)
        //        {
        //            nomenclatures.Add(deletedParent);
        //        }
        //        var addedParent = match.AddedConnection?.ParentObject as NomenclatureObject;
        //        if (addedParent == null)
        //        {
        //            nomenclatures.Add(addedParent);
        //        }

        //        if (nomenclatures.Count() > 1)
        //        {
        //            throw new System.Exception("подключения имеют разных размеров");
        //        }
        //        products.AddRange(nomenclatures);
        //    }

        //    foreach (var product in products)
        //    {
        //        var itemTMC = new ItemTMC();
        //        itemTMC.product = Nomenclature.CreateInstance(mdmReference.FindByPdmObject(product));
        //        var connections = action.GetChangeConnection();
        //        if (connections != null)
        //        {
        //            if (connections.Any())
        //            {
        //                foreach (var connection in connections)
        //                {
        //                    if (connection.IsAdded)
        //                    {
        //                        itemTMC.newNomenclature = Nomenclature.CreateInstance(mdmReference.FindByPdmObject(connection.ChildObject as NomenclatureObject));
        //                    }
        //                    else if (connection.IsDeleted)
        //                    {
        //                        itemTMC.excluded = Nomenclature.CreateInstance(mdmReference.FindByPdmObject(connection.ChildObject as NomenclatureObject));
        //                    }
        //                }
        //            }
        //        }
        //        listTMC.Add(itemTMC);
        //    }
        //    return listTMC;
        //}
    }
}
