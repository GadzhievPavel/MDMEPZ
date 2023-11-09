using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDMEPZ.Dto
{
    public class FullProductWhitSpecification
    {
        public Nomenclature[] nomenclatures {  get; set; }
        public ConnectionNomenclatures[] specification { get; set; }
    }
}
