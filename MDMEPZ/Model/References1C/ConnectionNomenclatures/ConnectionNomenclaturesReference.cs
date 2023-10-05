namespace TFlex.DOCs.References.ConnectionNomenclatures{	using System;	using TFlex.DOCs.Model.References;	using TFlex.DOCs.Model.Structure;	using TFlex.DOCs.Model.Classes;	using TFlex.DOCs.Model;
    using MDMEPZ.Dto;

    public partial class ConnectionNomenclaturesReference : SpecialReference<ConnectionNomenclaturesReferenceObject>	{				public partial class Factory		{		}		public ReferenceObject CreateReferenceObject(ConnectionNomenclatures connectionsNomenclature)
		{
			var o = CreateReferenceObject() as ConnectionNomenclaturesReferenceObject;
			o.Amount.Value = connectionsNomenclature.amount;
			//o.AddChildrenNomenclature()
			return o;
		}	}}