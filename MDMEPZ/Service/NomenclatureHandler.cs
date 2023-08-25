using MDMEPZ.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFlex.DOCs.Model;
using TFlex.DOCs.Model.References;
using TFlex.DOCs.References.FilterDetaliAssembling;
using TFlex.DOCs.References.FilterElectronicComponent;
using TFlex.DOCs.References.FilterMaterial;
using TFlex.DOCs.References.FilterOiginalMaket;
using TFlex.DOCs.References.FilterOtherProduct;
using TFlex.DOCs.References.FilterProduct;
using TFlex.DOCs.References.FilterStandartProduct;
using TFlex.DOCs.References.NomenclatureERP;
using TFlex.DOCs.References.Workpiece;

namespace MDMEPZ.Service
{
    public class NomenclatureHandler
    {
        private ServerConnection ServerConnection;
        private NomenclatureERPReferenceObject nomenclatureERP;
        private FilterDetaliAssemblingReference filterDetaliAssemblingReference;
        private FilterElectronicComponentReference filterElectronicComponentReference;
        private FilterMaterialReference filterMaterialReference;
        private FilterOriginalMaketReference originalMaketReference;
        private FilterOtherProductReference otherProductReference;
        private FilterProductReference productReference;
        private FilterStandartProductReference standartProductReference;
        private FilterWorkpieceReference workpieceReference;

        public NomenclatureHandler(ServerConnection connection, NomenclatureERPReferenceObject nomenclatureERP)
        {
            this.ServerConnection = connection;
            filterDetaliAssemblingReference = connection.ReferenceCatalog.Find(FilterDetaliAssemblingReference.ReferenceId).CreateReference() as FilterDetaliAssemblingReference;
            filterElectronicComponentReference = connection.ReferenceCatalog.Find(FilterElectronicComponentReference.ReferenceId).CreateReference() as FilterElectronicComponentReference;
            filterMaterialReference = connection.ReferenceCatalog.Find(FilterMaterialReference.ReferenceId).CreateReference() as FilterMaterialReference;
            originalMaketReference = connection.ReferenceCatalog.Find(FilterOriginalMaketReference.ReferenceId).CreateReference() as FilterOriginalMaketReference;
            otherProductReference = connection.ReferenceCatalog.Find(FilterOtherProductReference.ReferenceId).CreateReference() as FilterOtherProductReference;
            productReference = connection.ReferenceCatalog.Find(FilterProductReference.ReferenceId).CreateReference() as FilterProductReference;
            standartProductReference = connection.ReferenceCatalog.Find(FilterStandartProductReference.ReferenceId).CreateReference() as FilterStandartProductReference;
            workpieceReference = connection.ReferenceCatalog.Find(FilterWorkpieceReference.ReferenceId).CreateReference() as FilterWorkpieceReference;
            this.nomenclatureERP = nomenclatureERP;
        }

        public ReferenceObject CreateDetaliAndAssembling()
        {
            var filterDetaliAssembling = filterDetaliAssemblingReference.CreateReferenceObject() as FilterDetaliAssemblingReferenceObject;
            filterDetaliAssembling.StartUpdate();
            filterDetaliAssembling.InputNomenclature = nomenclatureERP;
            //filterDetaliAssembling.Name.Value = filterDetaliAssembling.Id.ToString();
            return filterDetaliAssembling;
        }

        public ReferenceObject CreateWorkpiece()
        {
            var filterWorkpiece = workpieceReference.CreateReferenceObject() as FilterWorkpieceReferenceObject;
            filterWorkpiece.StartUpdate();
            filterWorkpiece.InputNomenclature = nomenclatureERP;
            //filterWorkpiece.Name.Value = filterWorkpiece.Id.ToString();
            return filterWorkpiece;
        }

        public ReferenceObject CreateProduct()
        {
            var filterProduct = productReference.CreateReferenceObject() as FilterProductReferenceObject;
            filterProduct.StartUpdate();
            filterProduct.InputNomenclature = nomenclatureERP;
            //filterProduct.Name.Value = filterProduct.Id.ToString();
            return filterProduct;
        }

        public ReferenceObject CreateMaterial()
        {
            var filterMaterial = filterMaterialReference.CreateReferenceObject() as FilterMaterialReferenceObject;
            filterMaterial.StartUpdate();
            filterMaterial.InputNomenclature = nomenclatureERP;
            //filterMaterial.Name.Value = filterMaterial.Id.ToString();
            return filterMaterial;
        }

        public ReferenceObject CreateOriginalMaket()
        {
            var filterOriginalMaket = originalMaketReference.CreateReferenceObject() as FilterOriginalMaketReferenceObject;
            filterOriginalMaket.StartUpdate();
            filterOriginalMaket.InputNomenclature = nomenclatureERP;
            //filterOriginalMaket.Name.Value = filterOriginalMaket?.Id.ToString();
            return filterOriginalMaket;
        }

        public ReferenceObject CreateOtherProduct()
        {
            var filterOtherProduct = otherProductReference.CreateReferenceObject() as FilterOtherProductReferenceObject;
            filterOtherProduct.StartUpdate();
            filterOtherProduct.InputNomenclature = nomenclatureERP;
            //filterOtherProduct.Name.Value = filterOtherProduct?.Id.ToString();
            return filterOtherProduct;
        }

        public ReferenceObject CreateStandardProduct()
        {
            var filterStandartProduct = standartProductReference.CreateReferenceObject() as FilterStandartProductReferenceObject;
            filterStandartProduct.StartUpdate();
            filterStandartProduct.InputNomenclature = nomenclatureERP;
            //filterStandartProduct.Name.Value = filterStandartProduct?.Id.ToString();
            return filterStandartProduct;
        }

        public ReferenceObject CreateElectronicComponent()
        {
            var filterElectronicComponent = filterElectronicComponentReference.CreateReferenceObject() as FilterElectronicComponentReferenceObject;
            filterElectronicComponent.StartUpdate();
            filterElectronicComponent.InputNomenclature = nomenclatureERP;
            //filterElectronicComponent.Name.Value = filterElectronicComponent?.Id.ToString();
            return filterElectronicComponent;
        }

    }
}
