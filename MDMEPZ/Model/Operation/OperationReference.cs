namespace TFlex.DOCs.References.Operation
{
    using MDMEPZ.Dto;
    using MDMEPZ.Util;
    using TFlex.DOCs.Model.References;


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
        public ReferenceObject CreateReferenceObjectOperation(Operation operation)
        {
            var operationReferenceObject = CreateReferenceObject(Classes.AssemblyOperationType) as OperationReferenceObject;
            operationReferenceObject.StartUpdate();
            operationReferenceObject.Name.Value = operation.Наименование.Remove(0,3);
            operationReferenceObject.Kod.Value = operation.Код;
            operationReferenceObject.NomerOperatsii.Value = operation.НомерОперации.Trim();
            operationReferenceObject.PoryadkovyyNomer.Value = operation.ПорядковыйНомер.Trim(new char[]{' ','.'});
            operationReferenceObject.UID.Value = operation.Ссылка.UID;
            operationReferenceObject.Vladelets.Value = operation.Владелец.UID;
            operationReferenceObject.Zakhod_UID.Value = operation.Заход.UID;
            return operationReferenceObject;
        }
        public ReferenceObject CreateReferenceObjectPerformers (Operation performer)
        {

        }
    }
}
