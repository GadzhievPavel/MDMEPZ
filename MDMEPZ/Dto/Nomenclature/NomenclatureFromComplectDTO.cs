using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDMEPZ.Dto
{
    /// <summary>
    /// Объект описывающий номенклатуру, входящую в комплект на операцию
    /// </summary>
    public class NomenclatureFromComplectDTO
    {
        public NomenclatureWithRoute Nomenclature{get; set;}
        public Double Count;

    }
}
