﻿using MDMEPZ.Util;
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

        public EtalonStandartProductReferenceObject CreateEtalonStandartProduct(FilterStandartProductReferenceObject obj) {
            var etalonStandartProduct = etalonStandartProductReference.CreateReferenceObject()as EtalonStandartProductReferenceObject;
            etalonStandartProduct.StartUpdate();
            etalonStandartProduct.Nomenclature = obj.InputNomenclature;
            return etalonStandartProduct;
        }

        public EtalonWorkpieceReferenceObject CreateEtalonWorkpiece(FilterWorkpieceReferenceObject obj) {
            var etalonWorkpiece = etalonWorkpieceReference.CreateReferenceObject() as EtalonWorkpieceReferenceObject;
            etalonWorkpiece.StartUpdate();
            etalonWorkpiece.Nomenclature = obj.InputNomenclature;
            return etalonWorkpiece;
        }

    }
}