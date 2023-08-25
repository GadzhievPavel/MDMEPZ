namespace TFlex.DOCs.References.UnitOfMeasurement{	using System;	using TFlex.DOCs.Model.References;	using TFlex.DOCs.Model.Structure;	using TFlex.DOCs.Model.Classes;	using TFlex.DOCs.Model;
	using MDMEPZ.Dto;
	using MDMEPZ.Util;

	public partial class UnitOfMeasurementReference : SpecialReference<UnitOfMeasurementReferenceObject>	{		public ReferenceObject CreateReferenceObject(UnitOfMeasurement unitOfMeasurement)
		{
			var obj = this.CreateReferenceObject() as UnitOfMeasurementReferenceObject;
			obj.StartUpdate();
			obj.GUID_1C.Value = new Guid(unitOfMeasurement.guid1C);
			obj.Name.Value = unitOfMeasurement.name;
			return obj;
		}		public partial class Factory		{		}	}}