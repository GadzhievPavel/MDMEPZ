using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFlex.DOCs.References.NomenclatureERP;

namespace MDMEPZ.Dto
{
    public class NomenclatureShortDto
    {
        public string name { get; set; }
        public string guid1C { get; set; }
        public static NomenclatureShortDto CreateInstance(NomenclatureERPReferenceObject nomenclatureErp)
        {
            var nom = new NomenclatureShortDto();
            nom.guid1C = nomenclatureErp.GUID1C.ToString();
            nom.name = nomenclatureErp.Name.Value;
            return nom;
        }
    }
}
