namespace TFlex.DOCs.References.UnitOfMeasurement{	using System;	using TFlex.DOCs.Model.References;	using TFlex.DOCs.Model.Structure;	using TFlex.DOCs.Model.Classes;	using TFlex.DOCs.Model;
	using MDMEPZ.Util;
    using MDMEPZ.Dto;
    using MDMEPZ.Model;
    using TFlex.DOCs.Model.Search;
    using System.Linq;

    public partial class UnitOfMeasurementReference : SpecialReference<UnitOfMeasurementReferenceObject>, IFindService	{		public partial class Factory		{		}		/// <summary>
		/// Создание объекта на основе DTO
		/// </summary>
		/// <param name="unitOfMeasurement"></param>
		/// <returns></returns>		public ReferenceObject CreateReferenceObject(UnitOfMeasurement unitOfMeasurement)
		{
			var obj = this.CreateReferenceObject() as UnitOfMeasurementReferenceObject;
			obj.StartUpdate();
			obj.GUID_1C.Value = new Guid(unitOfMeasurement.guid1C);
			obj.Name.Value = unitOfMeasurement.name;
			return obj;
		}

        public ReferenceObject FindByGuid1C(Guid guid)
        {
            return Find(Filter.Parse($"[GUID(1C)] = '{guid}'", this.ParameterGroup)).First();
        }

		public ReferenceObject FindByName(String name)
		{
			return Find(Filter.Parse($"[Наименование] = '{name}'", this.ParameterGroup)).First();
		}
    }}