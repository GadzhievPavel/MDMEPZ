namespace TFlex.DOCs.References.GroupFinanceNomenclature
{
	using System;
	using TFlex.DOCs.Model.References;
	using TFlex.DOCs.Model.Structure;
	using TFlex.DOCs.Model.Classes;
	using TFlex.DOCs.Model;
    using MDMEPZ.Dto;
    using MDMEPZ.Util;
    using MDMEPZ.Model;
    using TFlex.DOCs.Model.Search;
    using System.Linq;

    public partial class GroupFinanceNomenclatureReference : SpecialReference<GroupFinanceNomenclatureReferenceObject>, IFindService
	{
		
		public partial class Factory
		{
		}

		public ReferenceObject CreateReferenceObject(GroupFinanceNomenclature groupFinanceNomenclature)
		{
			var group = CreateReferenceObject() as GroupFinanceNomenclatureReferenceObject;
			group.Name.Value = groupFinanceNomenclature.name;
			group.GUID1C.Value = new Guid(groupFinanceNomenclature.guid1C);
			return group;
		}

        public ReferenceObject FindByGuid1C(Guid guid)
        {
			return Find(Filter.Parse($"[GUID1C] = '{guid}'", this.ParameterGroup)).FirstOrDefault();
        }

        public ReferenceObject FindByGuid1C(Nomenclature nomenclature)
        {
            if (nomenclature is null)
            {
                return null;
            }
            if (nomenclature.financialGroup is null)
            {
                return null;
            }
            if (nomenclature.financialGroup.guid1C is null)
            {
                return null;
            }
            return FindByGuid1C(new Guid(nomenclature.financialGroup.guid1C));
        }
    }
}
