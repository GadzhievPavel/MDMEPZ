namespace TFlex.DOCs.References.TypeTMC
{
	using System;
	using TFlex.DOCs.Model.References;
	using TFlex.DOCs.Model.Structure;
	using TFlex.DOCs.Model.Classes;
	using TFlex.DOCs.Model;
    using TFlex.DOCs.Model.Search;
    using System.Linq;
    using MDMEPZ.Dto.ITRP;
    using MDMEPZ.Util;
    using DeveloperUtilsLibrary;
    using MDMEPZ.Exception;

    public partial class TypeTMCReference : SpecialReference<TypeTMCReferenceObject>
	{
		
		public partial class Factory
		{
		}

		public ReferenceObject CreateReferenceObject(TypeTmcForNomenclature typeTmc)
		{
			if (!Validator.isValidGUID(typeTmc.UID))
			{
				throw new ExceptionIntegration($"Невозможно создать объект Вид ТМЦ {typeTmc.name} из-за неверного GUID");
			} 
			var o = CreateReferenceObject() as TypeTMCReferenceObject;
			o.StartUpdate();
			o.Name.Value = typeTmc.name;
			o.UID1C.Value = typeTmc.UID;
			o.EndUpdate("создание объекта тип TMC");
			return o;
		}

		public TypeTMCReferenceObject FindByGuid1C(Guid guid)
		{
			try
			{
                return this.Find(Filter.Parse($"[UID 1C] = '{guid}'", ParameterGroup)).First() as TypeTMCReferenceObject;
			}
			catch
			{
				throw new ExceptionFinder($"тип ТМЦ не найден {guid}");
			}
			
		}
	}
}
