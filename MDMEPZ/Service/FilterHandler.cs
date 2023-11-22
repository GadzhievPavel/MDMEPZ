using MDMEPZ.Model.FilterReference;
using MDMEPZ.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFlex.DOCs.Model;
using TFlex.DOCs.Model.References;
using TFlex.DOCs.Model.References.Nomenclature;
using TFlex.DOCs.References.EtalonDetailAndAssebly;
using TFlex.DOCs.References.EtalonElectronicCompoents;
using TFlex.DOCs.References.EtalonMaterial;
using TFlex.DOCs.References.EtalonOriginalMaket;
using TFlex.DOCs.References.EtalonProduct;
using TFlex.DOCs.References.EtalonProductOther;
using TFlex.DOCs.References.EtalonWorkpiece;
using TFlex.DOCs.References.FilterDetaliAssembling;
using TFlex.DOCs.References.FilterElectronicComponent;
using TFlex.DOCs.References.FilterMaterial;
using TFlex.DOCs.References.FilterOiginalMaket;
using TFlex.DOCs.References.FilterOtherProduct;
using TFlex.DOCs.References.FilterProduct;
using TFlex.DOCs.References.FilterStandartProduct;
using TFlex.DOCs.References.StandartProduct;
using TFlex.DOCs.References.Workpiece;

namespace MDMEPZ.Service
{
    public class FilterHandler
    {
        private ServerConnection connection;
        private EtalonDetailAndAsseblingReference etalonDetailAndAsseblingReference;
        private EtalonElectronicCompoentsReference etalonElectronicCompoentsReference;
        private EtalonMaterialReference etalonMaterialReference;
        private EtalonOriginalMaketReference etalonOriginalMaketReference;
        private EtalonProductOtherReference etalonProductOtherReference;
        private EtalonProductReference etalonProductReference;
        private EtalonStandartProductReference etalonStandartProductReference;
        private EtalonWorkpieceReference etalonWorkpieceReference;

        public FilterHandler(ServerConnection serverConnection)
        {
            this.connection = serverConnection;
            etalonDetailAndAsseblingReference = connection.ReferenceCatalog.Find(EtalonDetailAndAsseblingReference.ReferenceId).CreateReference() as EtalonDetailAndAsseblingReference;
            etalonElectronicCompoentsReference = connection.ReferenceCatalog.Find(EtalonElectronicCompoentsReference.ReferenceId).CreateReference() as EtalonElectronicCompoentsReference;
            etalonMaterialReference = connection.ReferenceCatalog.Find(EtalonMaterialReference.ReferenceId).CreateReference() as EtalonMaterialReference;
            etalonOriginalMaketReference = connection.ReferenceCatalog.Find(EtalonOriginalMaketReference.ReferenceId).CreateReference() as EtalonOriginalMaketReference;
            etalonProductOtherReference = connection.ReferenceCatalog.Find(EtalonProductOtherReference.ReferenceId).CreateReference() as EtalonProductOtherReference;
            etalonProductReference = connection.ReferenceCatalog.Find(EtalonProductReference.ReferenceId).CreateReference() as EtalonProductReference;
            etalonStandartProductReference = connection.ReferenceCatalog.Find(EtalonStandartProductReference.ReferenceId).CreateReference() as EtalonStandartProductReference;
            etalonWorkpieceReference = connection.ReferenceCatalog.Find(EtalonWorkpieceReference.ReferenceId).CreateReference() as EtalonWorkpieceReference;
        }

        public EtalonDetailAndAsseblingReferenceObject CreateEtalonDetailAssembling(FilterDetaliAssemblingReferenceObject obj)
        {
            var etalonDetailAssembling = etalonDetailAndAsseblingReference.CreateReferenceObject() as EtalonDetailAndAsseblingReferenceObject;
            etalonDetailAssembling.StartUpdate();
            etalonDetailAssembling.Nomenclature = obj.InputNomenclature;
            return etalonDetailAssembling;
        }

        public EtalonElectronicCompoentsReferenceObject CreateEtalonElectronicComponents(FilterElectronicComponentReferenceObject obj)
        {
            var etalonElectronicComponents = etalonElectronicCompoentsReference.CreateReferenceObject() as EtalonElectronicCompoentsReferenceObject;
            etalonElectronicComponents.StartUpdate();
            etalonElectronicComponents.Nomenclature = obj.InputNomenclature;
            return etalonElectronicComponents;
        }

        public EtalonMaterialReferenceObject CreateEtalonMaterial(FilterMaterialReferenceObject obj)
        {
            var etalonMaterial = etalonMaterialReference.CreateReferenceObject() as EtalonMaterialReferenceObject;
            etalonMaterial.StartUpdate();
            etalonMaterial.Nomenclature = obj.InputNomenclature;
            return etalonMaterial;
        }

        public EtalonOriginalMaketReferenceObject CreateEtalonOriginalMaket(FilterOriginalMaketReferenceObject obj)
        {
            var etalonOriginalMaket = etalonOriginalMaketReference.CreateReferenceObject() as EtalonOriginalMaketReferenceObject;
            etalonOriginalMaket.StartUpdate();
            etalonOriginalMaket.Nomenclature = obj.InputNomenclature;
            return etalonOriginalMaket;
        }

        public EtalonProductOtherReferenceObject CreateEtalonOtherProduct(FilterOtherProductReferenceObject obj)
        {
            var etalonOtherProduct = etalonProductOtherReference.CreateReferenceObject() as EtalonProductOtherReferenceObject;
            etalonOtherProduct.StartUpdate();
            etalonOtherProduct.Nomenclature = obj.InputNomenclature;
            return etalonOtherProduct;
        }

        public EtalonProductReferenceObject CreateEtalonProduct(FilterProductReferenceObject obj, NomenclatureObject nom)
        {
            var etalonProduct = etalonProductReference.CreateReferenceObject() as EtalonProductReferenceObject;
            etalonProduct.StartUpdate();
            etalonProduct.Nomenclature = obj.InputNomenclature;
            etalonProduct.Product = nom;
            return etalonProduct;
        }

        public EtalonStandartProductReferenceObject CreateEtalonStandartProduct(FilterStandartProductReferenceObject obj)
        {
            var etalonStandartProduct = etalonStandartProductReference.CreateReferenceObject() as EtalonStandartProductReferenceObject;
            etalonStandartProduct.StartUpdate();
            etalonStandartProduct.Nomenclature = obj.InputNomenclature;
            return etalonStandartProduct;
        }

        public EtalonWorkpieceReferenceObject CreateEtalonWorkpiece(FilterWorkpieceReferenceObject obj)
        {
            var etalonWorkpiece = etalonWorkpieceReference.CreateReferenceObject() as EtalonWorkpieceReferenceObject;
            etalonWorkpiece.StartUpdate();
            etalonWorkpiece.Nomenclature = obj.InputNomenclature;
            return etalonWorkpiece;
        }

        public static ReferenceObject CreateEtalon(ReferenceObject nsiObject, ReferenceObject nom, ServerConnection connection)
        {
            ReferenceObject etalon = null;
            var filterHandler = new FilterHandler(connection);
            if (nsiObject is FilterDetaliAssemblingReferenceObject)
            {
                var nsiDetaliAssembling = nsiObject as FilterDetaliAssemblingReferenceObject;
                if (!filterHandler.haveObjectInEtalon(filterHandler.etalonDetailAndAsseblingReference, nsiDetaliAssembling.InputNomenclature))
                {
                    etalon = filterHandler.CreateEtalonDetailAssembling(nsiObject as FilterDetaliAssemblingReferenceObject);
                }
            }
            else if (nsiObject is FilterElectronicComponentReferenceObject)
            {
                var nsiElectronicComponent = nsiObject as FilterElectronicComponentReferenceObject;
                if (!filterHandler.haveObjectInEtalon(filterHandler.etalonElectronicCompoentsReference, nsiElectronicComponent.InputNomenclature))
                {
                    etalon = filterHandler.CreateEtalonElectronicComponents(nsiObject as FilterElectronicComponentReferenceObject);
                }
            }
            else if (nsiObject is FilterMaterialReferenceObject)
            {
                var nsiMaterial = nsiObject as FilterMaterialReferenceObject;
                if (!filterHandler.haveObjectInEtalon(filterHandler.etalonMaterialReference, nsiMaterial.InputNomenclature))
                {
                    etalon = filterHandler.CreateEtalonMaterial(nsiObject as FilterMaterialReferenceObject);
                }
            }
            else if (nsiObject is FilterOriginalMaketReferenceObject)
            {
                var nsiOM = nsiObject as FilterOriginalMaketReferenceObject;
                if (filterHandler.haveObjectInEtalon(filterHandler.etalonOriginalMaketReference, nsiOM.InputNomenclature))
                {
                    etalon = filterHandler.CreateEtalonOriginalMaket(nsiObject as FilterOriginalMaketReferenceObject);
                }
            }
            else if (nsiObject is FilterOtherProductReferenceObject)
            {
                var nsiOtherProduct = nsiObject as FilterOtherProductReferenceObject;
                if (!filterHandler.haveObjectInEtalon(filterHandler.etalonProductOtherReference, nsiOtherProduct.InputNomenclature))
                {
                    etalon = filterHandler.CreateEtalonOtherProduct(nsiObject as FilterOtherProductReferenceObject);
                }
            }
            else if (nsiObject is FilterProductReferenceObject)
            {
                var nsiProduct = nsiObject as FilterProductReferenceObject;
                if (!filterHandler.haveObjectInEtalon(filterHandler.etalonProductReference, nsiProduct.InputNomenclature))
                {
                    etalon = filterHandler.CreateEtalonProduct(nsiObject as FilterProductReferenceObject, nom as NomenclatureObject);
                }
            }
            else if (nsiObject is FilterStandartProductReferenceObject)
            {
                var nsiStandartProduct = nsiObject as FilterStandartProductReferenceObject;
                if (!filterHandler.haveObjectInEtalon(filterHandler.etalonStandartProductReference, nsiStandartProduct.InputNomenclature))
                {
                    etalon = filterHandler.CreateEtalonStandartProduct(nsiObject as FilterStandartProductReferenceObject);
                }
            }
            else if (nsiObject is FilterWorkpieceReferenceObject)
            {
                var nsiWorkpiece = nsiObject as FilterWorkpieceReferenceObject;
                if(!filterHandler.haveObjectInEtalon(filterHandler.etalonWorkpieceReference, nsiWorkpiece.InputNomenclature))
                {
                    etalon = filterHandler.CreateEtalonWorkpiece(nsiObject as FilterWorkpieceReferenceObject);
                }
            }
            if (etalon != null)
            {
                etalon.EndUpdate("");
            }
            return etalon;
        }

        private bool haveObjectInEtalon(IFinderEtalonReference reference, ReferenceObject nomErp)
        {
            return reference.findObjectEtalonByNomenclatureERP(nomErp) == null ? false : true;
        }
    }
}
