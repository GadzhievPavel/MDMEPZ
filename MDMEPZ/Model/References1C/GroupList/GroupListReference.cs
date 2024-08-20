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
    using TFlex.DOCs.Model.Search;
    using System.Linq;
    using MDMEPZ.Model;

    public partial class GroupListReference : SpecialReference<GroupListReferenceObject>, IFindService
    {

        public partial class Factory
        {
        }

        public ReferenceObject CreateReferenceObject(GroupOfList groupOfList)
        {
            var o = CreateReferenceObject() as GroupListReferenceObject;
            o.StartUpdate();
            o.Name.Value = groupOfList.name;
            o.GUID_1C.Value = new Guid(groupOfList.guid1C);
            return o;
        }

        public ReferenceObject FindByGuid1C(Guid guid)
        {
            return Find(Filter.Parse($"[GUID(1C)] = '{guid}'",this.ParameterGroup)).FirstOrDefault();
        }

        public ReferenceObject FindByGuid1C(Nomenclature product)
        {
            if (product.groupOfList is null)
            {
                return null;
            }
            if (product.groupOfList.guid1C is null)
            {
                return null;
            }

            //var groupListReference = this.Connection.ReferenceCatalog.Find(GroupListReference.ReferenceId).CreateReference() as GroupListReference;
            return FindByGuid1C(new Guid(product.groupOfList.guid1C));
        }
    }
}
