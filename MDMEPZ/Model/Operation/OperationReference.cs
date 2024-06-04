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
        /// Создание операции MDM с Определенным типом
        /// </summary>
        /// <param name="operation">Операция из .json</param>
        /// <returns>Объект справочника Операции MDM</returns>
        public ReferenceObject CreateReferenceObjectOperation(Operation operation)
        {

            OperationReferenceObject operationReferenceObject = null;
            var referenceNumenclatureERP = Connection.ReferenceCatalog.Find(3496).CreateReference();//справочник Номенклатуры ERP

            bool flag = false;// false значит у объекта на входе не сборка
            var listRows = operation.ОсновныеВходы.ROWS;
            foreach (var row in listRows)
            {
                var result = referenceNumenclatureERP.Find(Filter.Parse($"[GUID(1C)] = '{row.Заход.UID}'", referenceNumenclatureERP.ParameterGroup)).First();
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
