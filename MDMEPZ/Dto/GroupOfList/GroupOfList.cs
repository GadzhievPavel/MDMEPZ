using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFlex.DOCs.References.GroupList;

namespace MDMEPZ.Dto
{
    public class GroupOfList
    {
        public static GroupOfList CreateInstance(GroupListReferenceObject groupRefObj)
        {
            if (groupRefObj == null) return null;

            var group = new GroupOfList();
            group.name = groupRefObj.Name;
            group.guid1C = groupRefObj.GUID_1C.GetString();
            return group;
        }
        public string name { get; set; }
        public string guid1C { get; set; }
    }
}
