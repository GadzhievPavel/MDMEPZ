namespace TFlex.DOCs.References.GroupFinanceNomenclature
    using MDMEPZ.Dto;
    using MDMEPZ.Util;
    using MDMEPZ.Model;
    using TFlex.DOCs.Model.Search;
    using System.Linq;

    public partial class GroupFinanceNomenclatureReference : SpecialReference<GroupFinanceNomenclatureReferenceObject>, IFindService
		{
			var group = CreateReferenceObject() as GroupFinanceNomenclatureReferenceObject;
			group.Name.Value = groupFinanceNomenclature.name;
			group.GUID1C.Value = new Guid(groupFinanceNomenclature.guid1C);
			return group;
		}

        public ReferenceObject FindByGuid1C(Guid guid)
        {
			return Find(Filter.Parse($"[GUID1C] = '{guid}'", this.ParameterGroup)).First();
        }
    }