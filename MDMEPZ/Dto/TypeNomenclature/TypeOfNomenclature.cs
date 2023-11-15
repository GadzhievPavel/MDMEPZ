using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFlex.DOCs.References.TypeNomenclatureERP;

namespace MDMEPZ.Dto
{
    public class TypeOfNomenclature
    {
        public static TypeOfNomenclature CreateInstance(TypeNomenclatureERPReferenceObject typeRefObj)
        {
            if (typeRefObj == null)
            {
                return null;
            }
            var type = new TypeOfNomenclature();
            type.guid1C = typeRefObj.GUID_1C.GetString();
            type.name = typeRefObj.Name;
            return type;
        }
        public string name { get; set; }
        public string guid1C { get; set; }
    }
}
