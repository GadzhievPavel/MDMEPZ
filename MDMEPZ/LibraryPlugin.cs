using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFlex.DOCs.Model;
using TFlex.DOCs.Model.Plugins;
using TFlex.DOCs.Model.References;
using TFlex.DOCs.References.ApplicabiltyMaterials;
using TFlex.DOCs.References.CategoryProduct;
using TFlex.DOCs.References.ConnectionNomenclatures;
using TFlex.DOCs.References.Devision;
using TFlex.DOCs.References.EtalonDetailAndAssebly;
using TFlex.DOCs.References.EtalonElectronicCompoents;
using TFlex.DOCs.References.EtalonMaterial;
using TFlex.DOCs.References.EtalonOriginalMaket;
using TFlex.DOCs.References.EtalonProduct;
using TFlex.DOCs.References.EtalonProductOther;
using TFlex.DOCs.References.EtalonUserManual;
using TFlex.DOCs.References.EtalonWorkpiece;
using TFlex.DOCs.References.FilterDetaliAssembling;
using TFlex.DOCs.References.FilterElectronicComponent;
using TFlex.DOCs.References.FilterMaterial;
using TFlex.DOCs.References.FilterOiginalMaket;
using TFlex.DOCs.References.FilterOtherProduct;
using TFlex.DOCs.References.FilterProduct;
using TFlex.DOCs.References.FilterStandartProduct;
using TFlex.DOCs.References.FilterUserManual;
using TFlex.DOCs.References.GroupFinanceNomenclature;
using TFlex.DOCs.References.GroupList;
using TFlex.DOCs.References.NomenclatureERP;
using TFlex.DOCs.References.Operation;
using TFlex.DOCs.References.ReplacementERP;
using TFlex.DOCs.References.Route;
using TFlex.DOCs.References.SpecificationERP;
using TFlex.DOCs.References.StandartProduct;
using TFlex.DOCs.References.StructNomenclature;
using TFlex.DOCs.References.TypeNomenclatureERP;
using TFlex.DOCs.References.TypeOperationMDM;
using TFlex.DOCs.References.TypeReproductionERP;
using TFlex.DOCs.References.UnitOfMeasurement;
using TFlex.DOCs.References.Workpiece;
using TFlex.PdmFramework.Resolve;

namespace MDMEPZ
{
    public class LibraryPlugin : IPluginLibrary
    {
        public void OnCreatingReferenceVisualRepresentation(Reference reference, IModelVisualRepresentation VisualRepresentation)
        {
            
        }

        public void OnCreatingVisualRepresentation(IModelVisualRepresentation VisualRepresentation)
        {

        }

        public void RegisterPlugin()
        {
            AssemblyResolver.Instance.AddDirectory(@"C:\Program Files (x86)\T-FLEX DOCs 17\Program");
            ///filters NSI
            ReferenceCatalog.RegisterSpecialReference(FilterDetaliAssemblingReference.ReferenceId, new FilterDetaliAssemblingReference.Factory());
            ReferenceCatalog.RegisterSpecialReference(FilterElectronicComponentReference.ReferenceId, new FilterElectronicComponentReference.Factory());
            ReferenceCatalog.RegisterSpecialReference(FilterMaterialReference.ReferenceId, new FilterMaterialReference.Factory());
            ReferenceCatalog.RegisterSpecialReference(FilterOriginalMaketReference.ReferenceId, new FilterOriginalMaketReference.Factory());
            ReferenceCatalog.RegisterSpecialReference(FilterOtherProductReference.ReferenceId, new FilterOtherProductReference.Factory());
            ReferenceCatalog.RegisterSpecialReference(FilterProductReference.ReferenceId, new FilterProductReference.Factory());
            ReferenceCatalog.RegisterSpecialReference(FilterWorkpieceReference.ReferenceId, new FilterWorkpieceReference.Factory());
            ReferenceCatalog.RegisterSpecialReference(FilterStandartProductReference.ReferenceId, new FilterStandartProductReference.Factory());
            ReferenceCatalog.RegisterSpecialReference(FilterUserManualReference.ReferenceId, new FilterUserManualReference.Factory());
            
            ReferenceCatalog.RegisterSpecialReference(NomenclatureERPReference.ReferenceId, new NomenclatureERPReference.Factory());

            //reference 1C
            //ReferenceCatalog.RegisterSpecialReference(ApplicabiltyMaterialsReference.ReferenceId, new ApplicabiltyMaterialsReference.Factory());
            ReferenceCatalog.RegisterSpecialReference(CategoryProductReference.ReferenceId, new CategoryProductReference.Factory());
            ReferenceCatalog.RegisterSpecialReference(ConnectionNomenclaturesReference.ReferenceId, new ConnectionNomenclaturesReference.Factory());
            ReferenceCatalog.RegisterSpecialReference(GroupListReference.ReferenceId, new GroupListReference.Factory());
            ReferenceCatalog.RegisterSpecialReference(ReplacementERPReference.ReferenceId, new ReplacementERPReference.Factory());
            ReferenceCatalog.RegisterSpecialReference(SpecificationERPReference.ReferenceId, new SpecificationERPReference.Factory());
            ReferenceCatalog.RegisterSpecialReference(TypeNomenclatureERPReference.ReferenceId, new TypeNomenclatureERPReference.Factory());
            ReferenceCatalog.RegisterSpecialReference(TypeReproductionERPReference.ReferenceId, new TypeReproductionERPReference.Factory());
            ReferenceCatalog.RegisterSpecialReference(UnitOfMeasurementReference.ReferenceId, new UnitOfMeasurementReference.Factory());
            ReferenceCatalog.RegisterSpecialReference(GroupFinanceNomenclatureReference.ReferenceId, new GroupFinanceNomenclatureReference.Factory());
            
            
            //etalon
            ReferenceCatalog.RegisterSpecialReference(EtalonDetailAndAsseblingReference.ReferenceId, new EtalonDetailAndAsseblingReference.Factory());
            ReferenceCatalog.RegisterSpecialReference(EtalonElectronicCompoentsReference.ReferenceId, new EtalonElectronicCompoentsReference.Factory());
            ReferenceCatalog.RegisterSpecialReference(EtalonMaterialReference.ReferenceId, new EtalonMaterialReference.Factory());
            ReferenceCatalog.RegisterSpecialReference(EtalonOriginalMaketReference.ReferenceId, new EtalonOriginalMaketReference.Factory());
            ReferenceCatalog.RegisterSpecialReference(EtalonProductOtherReference.ReferenceId, new EtalonProductOtherReference.Factory());
            ReferenceCatalog.RegisterSpecialReference(EtalonProductReference.ReferenceId, new EtalonProductReference.Factory());
            ReferenceCatalog.RegisterSpecialReference(EtalonWorkpieceReference.ReferenceId, new EtalonWorkpieceReference.Factory());
            ReferenceCatalog.RegisterSpecialReference(EtalonStandartProductReference.ReferenceId, new EtalonStandartProductReference.Factory());
            ReferenceCatalog.RegisterSpecialReference(EtalonUserManualReference.ReferenceId, new EtalonUserManualReference.Factory());

            ReferenceCatalog.RegisterSpecialReference(StructNomenclatureReference.ReferenceId, new StructNomenclatureReference.Factory());

            //route(test)
            ReferenceCatalog.RegisterSpecialReference(RouteReference.ReferenceId, new RouteReference.Factory());
            ReferenceCatalog.RegisterSpecialReference(DevisionReference.ReferenceId, new DevisionReference.Factory());
            ReferenceCatalog.RegisterSpecialReference(OperationReference.ReferenceId, new OperationReference.Factory());
            ReferenceCatalog.RegisterSpecialReference(TypeOperationMDMReference.ReferenceId, new TypeOperationMDMReference.Factory());
        }
    }
}
