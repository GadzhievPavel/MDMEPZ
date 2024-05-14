using MDMEPZ.Dto;
using MDMEPZ.Exception;
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
using TFlex.DOCs.References.StructureTypes;

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
            referenceERP  = connection.ReferenceCatalog.Find(NomenclatureERPReference.ReferenceId).CreateReference() as NomenclatureERPReference;

            structureTypesReference = serverConnection.ReferenceCatalog.Find(StructureTypesReference.ReferenceId).CreateReference() as StructureTypesReference;
            structureType = structureTypesReference.Find("Производственно-технологическая") as StructureTypesReferenceObject;
            FillNomenclature(rootProduct);
        }

        private void FillNomenclature(NomenclatureObject nom)
        {
            nomenclatures.Add(nom);
            var childrenLinks = nom.Children.GetHierarchyLinks().Cast<NomenclatureHierarchyLink>();
            var links = childrenLinks.Where(link => link.StructureTypes.Contains(structureType)).ToList();
            foreach ( var link in links )
            {
                var child = link.ChildObject;
                nomenclatures.Add((NomenclatureObject)child);
                FillNomenclature((NomenclatureObject)child);
            }
        }

        public void CreateNomenclatureInMDM()
        {
            foreach ( var nom in nomenclatures)
            {
                try
                {
                    referenceERP.CreateReferenceObject(nom);
                }
                catch
                {
                    throw new ExceptionIntegration($"{nom} не удалось создать в MDM");
                }
            }
        }
    }
}
