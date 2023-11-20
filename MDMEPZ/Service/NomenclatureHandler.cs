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


        public static ReferenceObject CreateObjectInNsiLayer(ServerConnection connection, NomenclatureObject nomenclature)
        {
            if (nomenclature.GetObject(NomenclatureERPReferenceObject.RelationKeys.Nomenclature) == null)
            {
                throw new NullReferenceException("у объекта ЭСИ отсутствует связанная номенклатура в Номенклатуре ERP");
            }

            var handler = new NomenclatureHandler(connection, nomenclature.
                    GetObject(NomenclatureERPReferenceObject.RelationKeys.Nomenclature) as NomenclatureERPReferenceObject);
            var referenceNomenclature = nomenclature.Reference;
            ReferenceObject nsiObject = null;
            if (nomenclature.Class.IsAssembly || nomenclature.Class.IsDetail)
            {
                nsiObject = handler.CreateFilterDetaliAndAssemblingAsEtalon();
            }

            else if (nomenclature.Class.IsPiece)
            {
                nsiObject = handler.CreateFilterWorkpieceAsEtalon();
            }

            else if (nomenclature.Class.IsProduct)
            {
                nsiObject = handler.CreateFilterProductAsEtalon();
            }

            else if (nomenclature.Class.IsBaseClassFor(referenceNomenclature.Classes.Find("Материал")))
            {
                nsiObject = handler.CreateFilterMaterialAsEtalon();
            }

            else if (nomenclature.Class.Name == "Оригинал макет")
            {
                nsiObject = handler.CreateFilterOriginalMaketAsEtalon();
            }

            else if (nomenclature.Class.IsStandardItem)
            {
                nsiObject = handler.CreateFilterStandardProductAsEtalon();
            }

            else if (nomenclature.Class.Name == "Прочее изделие")
            {
                nsiObject = handler.CreateFilterOtherProductAsEtalon();
            }

            else if (nomenclature.Class.IsBaseClassFor(referenceNomenclature.Classes.Find("Электронный компонент")))
            {
                nsiObject = handler.CreateFilterElectronicComponentAsEtalon();
            }

            if(nsiObject != null) {
                nsiObject.EndUpdate("");
            }

            return nsiObject;
        }
    }
}
