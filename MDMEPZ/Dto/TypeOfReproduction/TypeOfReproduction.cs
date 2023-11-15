using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFlex.DOCs.References.TypeReproductionERP;

namespace MDMEPZ.Dto
{
    public class TypeOfReproduction
    {
        public static TypeOfReproduction CreateInstance(TypeReproductionERPReferenceObject type)
        {
            if (type == null) { return null; }
            var typeReproduction = new TypeOfReproduction();
            typeReproduction.name = type.Name;
            typeReproduction.guid1C = type.GUID_1C.GetString();
            return typeReproduction;
        }
        public string name { get; set; }
        public string guid1C { get; set; }
    }
}
