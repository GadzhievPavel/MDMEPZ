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
        /// �������� �������� MDM � ������������ �����
        /// </summary>
        /// <param name="operation">�������� �� .json</param>
        /// <returns>������ ����������� �������� MDM</returns>
        public ReferenceObject CreateReferenceObjectOperation(Operation operation,bool flag)
        {
            OperationReferenceObject operationReferenceObject = null;
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
            operationReferenceObject.Name.Value = operation.������������.Remove(0, 4);
            operationReferenceObject.Kod.Value = operation.���;
            operationReferenceObject.NomerOperatsii.Value = operation.�������������.Trim();
            operationReferenceObject.PoryadkovyyNomer.Value = operation.���������������.Trim(new char[] { ' ', '.' });
            operationReferenceObject.UID.Value = operation.������.UID;
            operationReferenceObject.Vladelets.Value = operation.��������.UID;
            operationReferenceObject.Zakhod_UID.Value = operation.�����.UID;
            operationReferenceObject.Podrazdelenie.Value = operation.�������������.UID;
            return operationReferenceObject;
        }
    }
}
