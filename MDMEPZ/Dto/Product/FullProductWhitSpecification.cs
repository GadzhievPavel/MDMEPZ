using MDMEPZ.Dto.ReplacementErp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDMEPZ.Dto
{
    ///Набор передающихся данных
    public class FullProductWhitSpecification
    {
        ///Список передаваемой номенклатуры
        public Nomenclature[] nomenclatures {  get; set; }
        ///Список подключений номенклатуры
        public ConnectionNomenclatures[] specification { get; set; }
        ///Список замен
        public Replacement[] replacements { get; set; }
    }
}
