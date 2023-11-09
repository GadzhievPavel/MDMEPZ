namespace TFlex.DOCs.References.ConnectionNomenclatures{	using System;	using TFlex.DOCs.Model.References;	using TFlex.DOCs.Model.Structure;	using TFlex.DOCs.Model.Classes;
    using TFlex.DOCs.Model;
    using TFlex.DOCs.References.NomenclatureERP;
    using MDMEPZ.Dto;
    using System.Collections.Generic;
    using TFlex.DOCs.Model.Search;
    using System.Linq;

    public partial class ConnectionNomenclaturesReference : SpecialReference<ConnectionNomenclaturesReferenceObject>	{
        private NomenclatureERPReference nomenclatureReference;
        public partial class Factory		{		}

        private void loadReference()
        {
            nomenclatureReference = this.Connection.ReferenceCatalog.Find(NomenclatureERPReference.ReferenceId).CreateReference() as NomenclatureERPReference;
        }

        public ReferenceObject CreateReferenceObject(ConnectionNomenclatures connection)
        {
            var connectionRefObj = CreateReferenceObject() as ConnectionNomenclaturesReferenceObject;
            connectionRefObj.Amount.Value = connection.amount;
            connectionRefObj.CurrentParam.Value = connection.parent;
            connectionRefObj.ChildParam.Value = connection.child;
            connectionRefObj.Child = nomenclatureReference.findObjectByGuid1C(connection.child);
            connectionRefObj.Current = nomenclatureReference.findObjectByGuid1C(connection.parent);
            return connectionRefObj;
        }

        public List<ConnectionNomenclaturesReferenceObject> findConnectionByParentNomenclature(NomenclatureERPReferenceObject nomErp)
        {
            var filter = Filter.Parse($"[родительский объект] = '{nomErp.GUID1C}'", ParameterGroup);
            return Find(filter).Cast<ConnectionNomenclaturesReferenceObject>().ToList();
        }
    }}