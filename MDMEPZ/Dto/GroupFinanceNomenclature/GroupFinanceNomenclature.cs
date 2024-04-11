using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFlex.DOCs.References.CategoryProduct;
using TFlex.DOCs.References.GroupFinanceNomenclature;

namespace MDMEPZ.Dto
{
    public class GroupFinanceNomenclature
    {
        public static GroupFinanceNomenclature CreateInstance(GroupFinanceNomenclatureReferenceObject groupFinance)
        {
            if (groupFinance == null) return null;
            var group = new GroupFinanceNomenclature();
            group.guid1C = groupFinance.GUID1C.GetString();
            group.name = groupFinance.Name;
            return group;
        }

        public string name { get; set; }
        public string guid1C { get; set; }
    }
}
