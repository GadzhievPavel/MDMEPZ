namespace TFlex.DOCs.References.GroupList
{
	using System;
	using TFlex.DOCs.Model.References;
	using TFlex.DOCs.Model.Structure;
	using TFlex.DOCs.Model.Classes;
	using TFlex.DOCs.Model;
    using MDMEPZ.Dto;
    using MDMEPZ.Util;
    using TFlex.DOCs.Model.Parameters;
    using TFlex.DOCs.Model.Desktop;

    public partial class GroupListReference : SpecialReference<GroupListReferenceObject>
	{
		
		public partial class Factory
		{
		}

		public ReferenceObject CreateReferenceObject(GroupOfList groupOfList)
		{
			var o = CreateReferenceObject() as GroupListReferenceObject;
			o.StartUpdate();
			o.Name.Value = groupOfList.Name;
			o.GUID_1C.Value = new Guid(groupOfList.Guid1C);
			o.EndChanges();
			return o;
		}
	}
}
