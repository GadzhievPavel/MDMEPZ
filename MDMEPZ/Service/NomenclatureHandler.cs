﻿using DeveloperUtilsLibrary;
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
using TFlex.DOCs.Model.Search;
using TFlex.DOCs.References.FilterDetaliAssembling;
using TFlex.DOCs.References.FilterElectronicComponent;
using TFlex.DOCs.References.FilterMaterial;
using TFlex.DOCs.References.FilterOiginalMaket;
using TFlex.DOCs.References.FilterOtherProduct;
using TFlex.DOCs.References.FilterProduct;
using TFlex.DOCs.References.FilterStandartProduct;
using TFlex.DOCs.References.FilterUserManual;
using TFlex.DOCs.References.NomenclatureERP;
using TFlex.DOCs.References.Workpiece;

namespace MDMEPZ.Service
{
    public class NomenclatureHandler
    {
        private ServerConnection ServerConnection;
        private NomenclatureMDMReferenceObject nomenclatureERP;
        private FilterDetaliAssemblingReference filterDetaliAssemblingReference;
        private FilterElectronicComponentReference filterElectronicComponentReference;
        private FilterMaterialReference filterMaterialReference;
        private FilterOriginalMaketReference originalMaketReference;
        private FilterOtherProductReference otherProductReference;
        private FilterProductReference productReference;
        private FilterStandartProductReference standartProductReference;
        private FilterWorkpieceReference workpieceReference;
        private FilterUserManualReference filterUserManualReference;

        public NomenclatureHandler(ServerConnection connection, NomenclatureMDMReferenceObject nomenclatureERP)
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
            filterUserManualReference = connection.ReferenceCatalog.Find(FilterUserManualReference.ReferenceId).CreateReference() as FilterUserManualReference;
            this.nomenclatureERP = nomenclatureERP;
        }

        public ReferenceObject CreateFilterDetaliAndAssembling()
        {
            var filterDetaliAssembling = filterDetaliAssemblingReference.CreateReferenceObject() as FilterDetaliAssemblingReferenceObject;
            filterDetaliAssembling.StartUpdate();
            filterDetaliAssembling.InputNomenclature = nomenclatureERP;
            return filterDetaliAssembling;
        }

        public ReferenceObject CreateFilterDetaliAndAssemblingAsEtalon()
        {
            var filterDetaliAssembling = filterDetaliAssemblingReference.CreateReferenceObject() as FilterDetaliAssemblingReferenceObject;
            filterDetaliAssembling.StartUpdate();
            filterDetaliAssembling.InputNomenclature = nomenclatureERP;
            filterDetaliAssembling.Classification.Value = ValueNSI.standard;
            //filterDetaliAssembling.Name.Value = filterDetaliAssembling.Id.ToString();
            return filterDetaliAssembling;
        }

        public ReferenceObject CreateFilterWorkpiece()
        {
            var filterWorkpiece = workpieceReference.CreateReferenceObject() as FilterWorkpieceReferenceObject;
            filterWorkpiece.StartUpdate();
            filterWorkpiece.InputNomenclature = nomenclatureERP;
            return filterWorkpiece;
        }

        public ReferenceObject CreateFilterWorkpieceAsEtalon()
        {
            var filterWorkpiece = workpieceReference.CreateReferenceObject() as FilterWorkpieceReferenceObject;
            filterWorkpiece.StartUpdate();
            filterWorkpiece.InputNomenclature = nomenclatureERP;
            filterWorkpiece.Classification.Value = ValueNSI.standard;
            //filterWorkpiece.Name.Value = filterWorkpiece.Id.ToString();
            return filterWorkpiece;
        }

        public ReferenceObject CreateFilterProduct()
        {
            var filterProduct = productReference.CreateReferenceObject() as FilterProductReferenceObject;
            filterProduct.StartUpdate();
            filterProduct.InputNomenclature = nomenclatureERP;
            return filterProduct;
        }

        public ReferenceObject CreateFilterProductAsEtalon()
        {
            var filterProduct = productReference.CreateReferenceObject() as FilterProductReferenceObject;
            filterProduct.StartUpdate();
            filterProduct.InputNomenclature = nomenclatureERP;
            filterProduct.Classification.Value = ValueNSI.standard;
            //filterProduct.Name.Value = filterProduct.Id.ToString();
            return filterProduct;
        }

        public ReferenceObject CreateFilterMaterial()
        {
            var filterMaterial = filterMaterialReference.CreateReferenceObject() as FilterMaterialReferenceObject;
            filterMaterial.StartUpdate();
            filterMaterial.InputNomenclature = nomenclatureERP;
            return filterMaterial;
        }

        public ReferenceObject CreateFilterMaterialAsEtalon()
        {
            var filterMaterial = filterMaterialReference.CreateReferenceObject() as FilterMaterialReferenceObject;
            filterMaterial.StartUpdate();
            filterMaterial.InputNomenclature = nomenclatureERP;
            filterMaterial.Classification.Value = ValueNSI.standard;
            //filterMaterial.Name.Value = filterMaterial.Id.ToString();
            return filterMaterial;
        }

        public ReferenceObject CreateFilterOriginalMaket()
        {
            var filterOriginalMaket = originalMaketReference.CreateReferenceObject() as FilterOriginalMaketReferenceObject;
            filterOriginalMaket.StartUpdate();
            filterOriginalMaket.InputNomenclature = nomenclatureERP;
            return filterOriginalMaket;
        }

        public ReferenceObject CreateFilterOriginalMaketAsEtalon()
        {
            var filterOriginalMaket = originalMaketReference.CreateReferenceObject() as FilterOriginalMaketReferenceObject;
            filterOriginalMaket.StartUpdate();
            filterOriginalMaket.InputNomenclature = nomenclatureERP;
            filterOriginalMaket.Classification.Value = ValueNSI.standard;
            //filterOriginalMaket.Name.Value = filterOriginalMaket?.Id.ToString();
            return filterOriginalMaket;
        }

        public ReferenceObject CreateFilterOtherProduct()
        {
            var filterOtherProduct = otherProductReference.CreateReferenceObject() as FilterOtherProductReferenceObject;
            filterOtherProduct.StartUpdate();
            filterOtherProduct.InputNomenclature = nomenclatureERP;
            return filterOtherProduct;
        }

        public ReferenceObject CreateFilterOtherProductAsEtalon()
        {
            var filterOtherProduct = otherProductReference.CreateReferenceObject() as FilterOtherProductReferenceObject;
            filterOtherProduct.StartUpdate();
            filterOtherProduct.InputNomenclature = nomenclatureERP;
            filterOtherProduct.Classification.Value = ValueNSI.standard;
            //filterOtherProduct.Name.Value = filterOtherProduct?.Id.ToString();
            return filterOtherProduct;
        }

        public ReferenceObject CreateFilterStandardProduct()
        {
            var filterStandartProduct = standartProductReference.CreateReferenceObject() as FilterStandartProductReferenceObject;
            filterStandartProduct.StartUpdate();
            filterStandartProduct.InputNomenclature = nomenclatureERP;
            return filterStandartProduct;
        }

        public ReferenceObject CreateFilterStandardProductAsEtalon()
        {
            var filterStandartProduct = standartProductReference.CreateReferenceObject() as FilterStandartProductReferenceObject;
            filterStandartProduct.StartUpdate();
            filterStandartProduct.InputNomenclature = nomenclatureERP;
            filterStandartProduct.Classification.Value = ValueNSI.standard;
            //filterStandartProduct.Name.Value = filterStandartProduct?.Id.ToString();
            return filterStandartProduct;
        }

        public ReferenceObject CreateFilterElectronicComponent()
        {
            var filterElectronicComponent = filterElectronicComponentReference.CreateReferenceObject() as FilterElectronicComponentReferenceObject;
            filterElectronicComponent.StartUpdate();
            filterElectronicComponent.InputNomenclature = nomenclatureERP;
            return filterElectronicComponent;
        }
        public ReferenceObject CreateFilterElectronicComponentAsEtalon()
        {
            var filterElectronicComponent = filterElectronicComponentReference.CreateReferenceObject() as FilterElectronicComponentReferenceObject;
            filterElectronicComponent.StartUpdate();
            filterElectronicComponent.InputNomenclature = nomenclatureERP;
            filterElectronicComponent.Classification.Value = ValueNSI.standard;
            //filterElectronicComponent.Name.Value = filterElectronicComponent?.Id.ToString();
            return filterElectronicComponent;
        }

        public ReferenceObject CreateFilterUserManual()
        {
            var filterUserManual = filterUserManualReference.CreateReferenceObject() as FilterUserManualReferenceObject;
            filterUserManual.StartUpdate();
            filterUserManual.InputNomenclature = nomenclatureERP;
            return filterUserManual;
        }

        public ReferenceObject CreateFilterUserManualAsEtalon()
        {
            var filterUserManual = filterUserManualReference.CreateReferenceObject() as FilterUserManualReferenceObject;
            filterUserManual.StartUpdate();
            filterUserManual.InputNomenclature = nomenclatureERP;
            filterUserManual.Classification.Value = ValueNSI.standard;
            return filterUserManual;
        }

        public static ReferenceObject CreateObjectInNsiLayer(ServerConnection connection, NomenclatureObject nomenclature)
        {
            if (nomenclature.GetObject(NomenclatureMDMReferenceObject.RelationKeys.Nomenclature) == null)
            {
                throw new NullReferenceException("у объекта ЭСИ отсутствует связанная номенклатура в Номенклатуре ERP");
            }

            var handler = new NomenclatureHandler(connection, nomenclature.
                    GetObject(NomenclatureMDMReferenceObject.RelationKeys.Nomenclature) as NomenclatureMDMReferenceObject);

            var referenceNomenclature = nomenclature.Reference;
            ReferenceObject nsiObject = null;

            if (nomenclature.Class.IsAssembly || nomenclature.Class.IsDetail)
            {
                if (!handler.haveObjectInLayerNsi(handler.filterDetaliAssemblingReference, handler.nomenclatureERP))
                {
                    nsiObject = handler.CreateFilterDetaliAndAssemblingAsEtalon();
                }
            }

            else if (nomenclature.Class.IsPiece)
            {
                if (!handler.haveObjectInLayerNsi(handler.workpieceReference, handler.nomenclatureERP))
                {
                    nsiObject = handler.CreateFilterWorkpieceAsEtalon();
                }
            }

            else if (nomenclature.Class.IsProduct)
            {
                if (!handler.haveObjectInLayerNsi(handler.productReference, handler.nomenclatureERP))
                {
                    nsiObject = handler.CreateFilterProductAsEtalon();
                }
            }

            else if (nomenclature.Class.IsBaseClassFor(referenceNomenclature.Classes.Find("Материал")))
            {
                if (!handler.haveObjectInLayerNsi(handler.filterMaterialReference, handler.nomenclatureERP))
                {
                    nsiObject = handler.CreateFilterMaterialAsEtalon();
                }
            }

            else if (nomenclature.Class.Name == "Оригинал макет")
            {
                if(!handler.haveObjectInLayerNsi(handler.originalMaketReference, handler.nomenclatureERP))
                {
                    nsiObject = handler.CreateFilterOriginalMaketAsEtalon();
                }
            }

            else if (nomenclature.Class.IsStandardItem)
            {
                if(!handler.haveObjectInLayerNsi(handler.standartProductReference, handler.nomenclatureERP))
                {
                    nsiObject = handler.CreateFilterStandardProductAsEtalon();
                }
            }

            else if (nomenclature.Class.Name == "Прочее изделие")
            {
                if(!handler.haveObjectInLayerNsi(handler.otherProductReference, handler.nomenclatureERP))
                {
                    nsiObject = handler.CreateFilterOtherProductAsEtalon();
                }
            }

            else if (nomenclature.Class.IsBaseClassFor(referenceNomenclature.Classes.Find("Электронный компонент")))
            {
                if(!handler.haveObjectInLayerNsi(handler.filterElectronicComponentReference, handler.nomenclatureERP))
                {
                    nsiObject = handler.CreateFilterElectronicComponentAsEtalon();
                }
            }
            else if(nomenclature.Class.Name == "Руководство по эксплуатации")
            {
                if(!handler.haveObjectInLayerNsi(handler.filterElectronicComponentReference, handler.nomenclatureERP))
                {
                    nsiObject = handler.CreateFilterUserManualAsEtalon();
                }
            }

            if (nsiObject != null)
            {
                nsiObject.EndUpdate("");
            }

            return nsiObject;
        }

        private bool haveObjectInLayerNsi(IFinderNsiReference referece, ReferenceObject erpNom)
        {
            return referece.findObjectByNomenclatureERP(erpNom) != null ? true : false;
        }
    }
}
