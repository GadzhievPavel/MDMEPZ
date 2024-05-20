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

        public void CreateNomenclatureInMDM()
        {
            foreach (var nom in nomenclatures)
            {
                try
                {
                    referenceERP.CreateReferenceObject(nom);
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

        public string SendBom(string path)
        {
            var bomService = new BomService(connection ,rootProduct, nomenclatures);
            return bomService.GetBom(path);
        }
    }
}
