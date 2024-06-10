namespace TFlex.DOCs.References.Operation
{
    using MDMEPZ.Dto;
    using MDMEPZ.Exception;
    using MDMEPZ.Service;
    using MDMEPZ.Util;
    using Newtonsoft.Json;
    using System.Linq;
    using TFlex.DOCs.Model.References;
    using TFlex.DOCs.Model.References.Nomenclature;
    using TFlex.DOCs.Model.Search;
    using TFlex.DOCs.References.NomenclatureERP;

    public partial class OperationReference : SpecialReference<OperationReferenceObject>
    {

        public partial class Factory
        {
        }
        /// <summary>
        /// Создание операции MDM с Определенным типом
        /// </summary>
        /// <param name="operation">Операция из .json</param>
        /// <returns>Объект справочника Операции MDM</returns>
        public ReferenceObject CreateReferenceObjectOperation(Operation operation,bool flag)
        {
            OperationReferenceObject operationReferenceObject = null;
            //var referenceNumenclatureERP = Connection.ReferenceCatalog.Find(3496).CreateReference();//справочник Номенклатуры ERP

            //bool flag = false;// false значит у объекта на входе не сборка
            //ServiceOperation service = new ServiceOperation(Connection);

            //var listNomenclature = service.GetNomenclatureFromAssemblyOperation(operation);
            //if(!listNomenclature.Any())
            //{
            //    foreach (var nomenclature in listNomenclature)
            //    {
            //        if(nomenclature.Class.IsAssembly)
            //        {
            //            flag = true;
            //        }
            //    }
            //}
            if (flag)
            {
                operationReferenceObject = CreateReferenceObject(Classes.AssemblyOperationType) as OperationReferenceObject;
            }
            else
            {
                operationReferenceObject = CreateReferenceObject(Classes.DefaultOperationType) as OperationReferenceObject;
            }

            //operationReferenceObject = CreateReferenceObject(Classes.AssemblyOperationType) as OperationReferenceObject;
            operationReferenceObject.StartUpdate();
            operationReferenceObject.Name.Value = operation.Наименование.Remove(0, 4);
            operationReferenceObject.Kod.Value = operation.Код;
            operationReferenceObject.NomerOperatsii.Value = operation.НомерОперации.Trim();
            operationReferenceObject.PoryadkovyyNomer.Value = operation.ПорядковыйНомер.Trim(new char[] { ' ', '.' });
            operationReferenceObject.UID.Value = operation.Ссылка.UID;
            operationReferenceObject.Vladelets.Value = operation.Владелец.UID;
            operationReferenceObject.Zakhod_UID.Value = operation.Заход.UID;
            return operationReferenceObject;
        }
    }
}
