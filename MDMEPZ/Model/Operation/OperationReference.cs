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
        /// �������� �������� MDM � ������������ �����
        /// </summary>
        /// <param name="operation">�������� �� .json</param>
        /// <returns>������ ����������� �������� MDM</returns>
        public ReferenceObject CreateReferenceObjectOperation(Operation operation)
        {
            var operationReferenceObject = CreateReferenceObject(Classes.AssemblyOperationType) as OperationReferenceObject;
            operationReferenceObject.StartUpdate();
            operationReferenceObject.Name.Value = operation.������������.Remove(0,3);
            operationReferenceObject.Kod.Value = operation.���;
            operationReferenceObject.NomerOperatsii.Value = operation.�������������.Trim();
            operationReferenceObject.PoryadkovyyNomer.Value = operation.���������������.Trim(new char[]{' ','.'});
            operationReferenceObject.UID.Value = operation.������.UID;
            operationReferenceObject.Vladelets.Value = operation.��������.UID;
            operationReferenceObject.Zakhod_UID.Value = operation.�����.UID;
            return operationReferenceObject;
        }
        public ReferenceObject CreateReferenceObjectPerformers (Operation performer)
        {

        }
    }
}
