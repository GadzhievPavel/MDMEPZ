namespace TFlex.DOCs.References.Operation
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
        {
            var operationReferenceObject = CreateReferenceObject(Classes.AssemblyOperationType) as OperationReferenceObject;
            operationReferenceObject.StartUpdate();
            operationReferenceObject.Name.Value = operation.������������;
            operationReferenceObject.Kod.Value = operation.���;
            operationReferenceObject.NomerOperatsii.Value = operation.�������������;
            operationReferenceObject.PoryadkovyyNomer.Value = operation.���������������;
            operationReferenceObject.UID.Value = operation.������.UID;
            operationReferenceObject.Vladelets.Value = operation.��������.UID;
            operationReferenceObject.Zakhod_UID.Value = operation.�����.UID;
            return operationReferenceObject;
        }
    }