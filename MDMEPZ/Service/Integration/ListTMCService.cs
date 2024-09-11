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
                    var roots = new HashSet<NomenclatureObject>();

                    var connections = action.GetChangeConnection();
                    var addedConnections = connections.Find(c => c.IsAdded);
                    var deletedConnections = connections.Find(c => c.IsDeleted);

                    var rootAdded = addedConnections.ParentObject as NomenclatureObject;
                    if (rootAdded != null)
                    {
                        roots.Add(rootAdded);
                    }
                    var rootDeleted = deletedConnections.ParentObject as NomenclatureObject;
                    if (rootDeleted != null)
                    {
                        roots.Add(rootDeleted);
                    }

                    var root = roots.First();

                    itemTMC.product = Nomenclature.CreateInstance(mdmReference.FindByPdmObject(root));
                    var addedNomenclature = addedConnections.ChildObject as NomenclatureObject;
                    if (addedNomenclature != null)
                    {
                        itemTMC.newNomenclature = Nomenclature.CreateInstance(mdmReference.FindByPdmObject(addedNomenclature));
                    }
                    var deletedNomenclature = deletedConnections.ChildObject as NomenclatureObject;
                    if (deletedNomenclature != null)
                    {
                        itemTMC.excluded = Nomenclature.CreateInstance(mdmReference.FindByPdmObject(deletedNomenclature));
                    }
                    listTMC.Add(itemTMC);
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
