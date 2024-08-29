namespace TFlex.DOCs.References.NomenclatureMDM{	using System;	using TFlex.DOCs.Model.References;	using TFlex.DOCs.Model.Structure;	using TFlex.DOCs.Model.References.Links;	using TFlex.DOCs.Model.Classes;	using TFlex.DOCs.Model.Parameters;
    using TFlex.DOCs.References.NomenclatureERP;
    using MDMEPZ.Dto.ITRP;
    using TFlex.DOCs.References.TypeTMC;
    using System.Linq;

    public partial class NomenclatureITRPReferenceObject : NomenclatureMDMReferenceObject	{		public void Update(NomenclatureItrpMain nomenclatureItrp)
		{
			this.Name.Value = nomenclatureItrp.Наименование;
			this.NameForInput.Value = nomenclatureItrp.НаименованиеДляВвода;
			this.NameFull.Value = nomenclatureItrp.НаименованиеПолное;
			this.Denotation.Value = nomenclatureItrp.Обозначение;
			this.Code.Value = nomenclatureItrp.Код;
			this.ID53.Value = nomenclatureItrp.ID53;
			this.Articul.Value = nomenclatureItrp.Артикул;
			this.TypeReproduction = nomenclatureItrp.ВидВоспроизводства;

			var typeTMCReference = new TypeTMCReference(this.Reference.Connection);
            if(nomenclatureItrp.ВидУчетаТМЦ is null )
            {
                this.TypeTMC = null;
            }
            else
            {
                var typeTMC = typeTMCReference.FindByGuid1C(new Guid(nomenclatureItrp.ВидУчетаТМЦ.UID));
                this.TypeTMC = typeTMC;
            }
			

			var unitsOfMesurementITRPReferenceObjects = this.GetUnitOfMesurementITRPReferenceObjects();
			foreach( var unit in unitsOfMesurementITRPReferenceObjects)
			{
				unit.StartUpdate();
				unit.Delete();
				unit.EndUpdate("");
			}

            var baseUnitMeasurement = nomenclatureItrp.БазоваяЕдиницаИзмерения;
            if (baseUnitMeasurement != null)
            {
                var baseUnitReferenceObject = CreateUnitsOfMeasurement(NomenclatureITRPReferenceObject.TypesOfListUnitsOfMeasurement.BaseUnitOfMeasurementClass);
                baseUnitReferenceObject.UID = baseUnitMeasurement.UID;
                baseUnitReferenceObject.Name = baseUnitMeasurement.Наименование;
                baseUnitReferenceObject.EndUpdate("создана единица измерения");
            }
            var unitStorageRemains = nomenclatureItrp.ЕдиницаХраненияОстатков;
            if (unitStorageRemains != null)
            {
                var unitStorageRemainsReferenceObject = CreateUnitsOfMeasurement(NomenclatureITRPReferenceObject.TypesOfListUnitsOfMeasurement.UnitOfMeasurementStorageRemainsClass);
                unitStorageRemainsReferenceObject.UID = unitStorageRemains.UID;
                unitStorageRemainsReferenceObject.Name = unitStorageRemains.Наименование;
                unitStorageRemainsReferenceObject.EndUpdate("создана единица измерения");
            }
            var unitAccountInProduction = nomenclatureItrp.ЕдиницаУчетаВПроизводстве;
            if (unitAccountInProduction != null)
            {
                var unitAccountInProductionReferenceObject = CreateUnitsOfMeasurement(NomenclatureITRPReferenceObject.TypesOfListUnitsOfMeasurement.UnitOfMeasurementAccountInProduction);
                unitAccountInProductionReferenceObject.UID = unitAccountInProduction.UID;
                unitAccountInProductionReferenceObject.Name = unitAccountInProduction.Наименование;
                unitAccountInProductionReferenceObject.EndUpdate("создана единица измерения");
            }

            var units = this.GetUnits();
            foreach (var unit in units)
            {
                unit.StartUpdate();
                unit.Delete();
                unit.EndUpdate("");
            }

            var unitsDto = nomenclatureItrp.Единицы;
            if (unitsDto != null)
            {
                foreach (var unit in unitsDto)
                {
                    if (unit != null)
                    {
                        var unitReferenceObject = CreateUnit();
                        unitReferenceObject.Koeff = unit.ЕдиницыИзмеренияКоэффициент;
                        unitReferenceObject.Code = unit.ЕдиницыИзмеренияКод;
                        unitReferenceObject.UID = unit.UID;
                        unitReferenceObject.Name = unit.ЕдиницыИзмеренияНаименование;
                        unitReferenceObject.EndUpdate("создание единицы");
                    }
                }
            }
        }	}}