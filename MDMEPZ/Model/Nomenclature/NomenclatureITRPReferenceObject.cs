namespace TFlex.DOCs.References.NomenclatureMDM{	using System;	using TFlex.DOCs.Model.References;	using TFlex.DOCs.Model.Structure;	using TFlex.DOCs.Model.References.Links;	using TFlex.DOCs.Model.Classes;	using TFlex.DOCs.Model.Parameters;
    using TFlex.DOCs.References.NomenclatureERP;
    using MDMEPZ.Dto.ITRP;
    using TFlex.DOCs.References.TypeTMC;
    using System.Linq;

    public partial class NomenclatureITRPReferenceObject : NomenclatureMDMReferenceObject	{		public void Update(NomenclatureItrpMain nomenclatureItrp)
		{
			this.Name.Value = nomenclatureItrp.������������;
			this.NameForInput.Value = nomenclatureItrp.��������������������;
			this.NameFull.Value = nomenclatureItrp.������������������;
			this.Denotation.Value = nomenclatureItrp.�����������;
			this.Code.Value = nomenclatureItrp.���;
			this.ID53.Value = nomenclatureItrp.ID53;
			this.Articul.Value = nomenclatureItrp.�������;
			this.TypeReproduction = nomenclatureItrp.������������������;

			var typeTMCReference = new TypeTMCReference(this.Reference.Connection);
            if(nomenclatureItrp.����������� is null )
            {
                this.TypeTMC = null;
            }
            else
            {
                var typeTMC = typeTMCReference.FindByGuid1C(new Guid(nomenclatureItrp.�����������.UID));
                this.TypeTMC = typeTMC;
            }
			

			var unitsOfMesurementITRPReferenceObjects = this.GetUnitOfMesurementITRPReferenceObjects();
			foreach( var unit in unitsOfMesurementITRPReferenceObjects)
			{
				unit.StartUpdate();
				unit.Delete();
				unit.EndUpdate("");
			}

            var baseUnitMeasurement = nomenclatureItrp.�����������������������;
            if (baseUnitMeasurement != null)
            {
                var baseUnitReferenceObject = CreateUnitsOfMeasurement(NomenclatureITRPReferenceObject.TypesOfListUnitsOfMeasurement.BaseUnitOfMeasurementClass);
                baseUnitReferenceObject.UID = baseUnitMeasurement.UID;
                baseUnitReferenceObject.Name = baseUnitMeasurement.������������;
                baseUnitReferenceObject.EndUpdate("������� ������� ���������");
            }
            var unitStorageRemains = nomenclatureItrp.�����������������������;
            if (unitStorageRemains != null)
            {
                var unitStorageRemainsReferenceObject = CreateUnitsOfMeasurement(NomenclatureITRPReferenceObject.TypesOfListUnitsOfMeasurement.UnitOfMeasurementStorageRemainsClass);
                unitStorageRemainsReferenceObject.UID = unitStorageRemains.UID;
                unitStorageRemainsReferenceObject.Name = unitStorageRemains.������������;
                unitStorageRemainsReferenceObject.EndUpdate("������� ������� ���������");
            }
            var unitAccountInProduction = nomenclatureItrp.�������������������������;
            if (unitAccountInProduction != null)
            {
                var unitAccountInProductionReferenceObject = CreateUnitsOfMeasurement(NomenclatureITRPReferenceObject.TypesOfListUnitsOfMeasurement.UnitOfMeasurementAccountInProduction);
                unitAccountInProductionReferenceObject.UID = unitAccountInProduction.UID;
                unitAccountInProductionReferenceObject.Name = unitAccountInProduction.������������;
                unitAccountInProductionReferenceObject.EndUpdate("������� ������� ���������");
            }

            var units = this.GetUnits();
            foreach (var unit in units)
            {
                unit.StartUpdate();
                unit.Delete();
                unit.EndUpdate("");
            }

            var unitsDto = nomenclatureItrp.�������;
            if (unitsDto != null)
            {
                foreach (var unit in unitsDto)
                {
                    if (unit != null)
                    {
                        var unitReferenceObject = CreateUnit();
                        unitReferenceObject.Koeff = unit.���������������������������;
                        unitReferenceObject.Code = unit.�������������������;
                        unitReferenceObject.UID = unit.UID;
                        unitReferenceObject.Name = unit.����������������������������;
                        unitReferenceObject.EndUpdate("�������� �������");
                    }
                }
            }
        }	}}