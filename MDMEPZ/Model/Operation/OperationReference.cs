namespace TFlex.DOCs.References.Operation
{
    using MDMEPZ.Dto;
    using MDMEPZ.Util;
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
        public ReferenceObject CreateReferenceObjectOperation(Operation operation)
        {

            OperationReferenceObject operationReferenceObject = null;
            var referenceNumenclatureERP = Connection.ReferenceCatalog.Find(3496).CreateReference();//���������� ������������ ERP

            bool flag = false;// false ������ � ������� �� ����� �� ������
            var listRows = operation.�������������.ROWS;
            foreach (var row in listRows)
            {
                var result = referenceNumenclatureERP.Find(Filter.Parse($"[GUID(1C)] = '{row.�����.UID}'", referenceNumenclatureERP.ParameterGroup)).First();
                if (result != null)
                {
                    var objESI = result.GetObject(NomenclatureERPReferenceObject.RelationKeys.Nomenclature);
                    if (objESI != null && (objESI.Class.Guid.Equals(NomenclatureTypes.Keys.Assembly.ToString()) || objESI.Class.Guid.Equals(NomenclatureTypes.Keys.AssemblyNode)))
                    {
                        flag = true;
                    }
                }

            }

            if (flag)
            {
                operationReferenceObject = CreateReferenceObject(Classes.AssemblyOperationType) as OperationReferenceObject;
            }
            else
            {
                operationReferenceObject = CreateReferenceObject(Classes.DefaultOperationType) as OperationReferenceObject;
            }


            operationReferenceObject.StartUpdate();
            operationReferenceObject.Name.Value = operation.������������.Remove(0, 4);
            operationReferenceObject.Kod.Value = operation.���;
            operationReferenceObject.NomerOperatsii.Value = operation.�������������.Trim();
            operationReferenceObject.PoryadkovyyNomer.Value = operation.���������������.Trim(new char[] { ' ', '.' });
            operationReferenceObject.UID.Value = operation.������.UID;
            operationReferenceObject.Vladelets.Value = operation.��������.UID;
            operationReferenceObject.Zakhod_UID.Value = operation.�����.UID;
            return operationReferenceObject;
        }
    }
}
