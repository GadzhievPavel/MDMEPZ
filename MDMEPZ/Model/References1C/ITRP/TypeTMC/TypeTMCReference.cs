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

    public partial class TypeTMCReference : SpecialReference<TypeTMCReferenceObject>
	{
		
		public partial class Factory
		{
		}

		public ReferenceObject CreateReferenceObject(TypeTmcForNomenclature typeTmc)
		{
			var o = CreateReferenceObject() as TypeTMCReferenceObject;
			o.StartUpdate();
			o.Name.Value = typeTmc.name;
			o.UID1C.Value = typeTmc.UID;
			o.EndUpdate("создание объекта тип TMC");
			return o;
		}

		public TypeTMCReferenceObject FindByGuid1C(Guid guid)
		{
			return this.Find(Filter.Parse($"[UID 1C] = '{guid}'", ParameterGroup)).FirstOrDefault() as TypeTMCReferenceObject;
		}
	}
}
