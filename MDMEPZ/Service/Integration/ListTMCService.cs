using MDMEPZ.Dto;
using MDMEPZ.Dto.Notification;
using NotificationsEPZ.Changes.ListObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFlex.DOCs.Model;
using TFlex.DOCs.Model.References.Nomenclature;
using TFlex.DOCs.References.NomenclatureERP;

namespace MDMEPZ.Service.Integration
{
    public class ListTMCService
    {
        private ServerConnection connection;
        private NomenclatureMDMReference mdmReference;
        public ListTMCService(ServerConnection connection)
        {
            this.connection = connection;
            mdmReference = new NomenclatureMDMReference(connection);
        }
        public List<ItemTMC> getListTMC(List<MatchConnection> matches, NotificationsEPZ.Changes.ListObjects.Action action)
        {
            var listTMC = new List<ItemTMC>();
            var products = new List<NomenclatureObject>();
            foreach (var match in matches)
            {
                HashSet<NomenclatureObject> nomenclatures = new HashSet<NomenclatureObject>();
                var sourceParent = match.SourceConnection.ParentObject as NomenclatureObject;
                if (sourceParent == null)
                {
                    nomenclatures.Add(sourceParent);
                }
                var deletedParent = match.DeletedConnection.ParentObject as NomenclatureObject;
                if (deletedParent == null)
                {
                    nomenclatures.Add(deletedParent);
                }
                var addedParent = match.AddedConnection.ParentObject as NomenclatureObject;
                if (addedParent == null)
                {
                    nomenclatures.Add(addedParent);
                }

                if (nomenclatures.Count() > 1)
                {
                    throw new System.Exception("подключения имеют разных размеров");
                }
                products.AddRange(nomenclatures);
            }

            foreach (var product in products)
            {
                var itemTMC = new ItemTMC();
                itemTMC.product = Nomenclature.CreateInstance(mdmReference.FindByPdmObject(product));
                var connections = action.GetChangeConnection();
                foreach (var connection in connections)
                {
                    if (connection.IsAdded)
                    {
                        itemTMC.newNomenclature = Nomenclature.CreateInstance(mdmReference.FindByPdmObject(connection.ChildObject as NomenclatureObject));
                    }
                    else if (connection.IsDeleted)
                    {
                        itemTMC.excluded = Nomenclature.CreateInstance(mdmReference.FindByPdmObject(connection.ChildObject as NomenclatureObject));
                    }
                }

            }
            return listTMC;
        }
    }
}
