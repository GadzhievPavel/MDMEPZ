using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDMEPZ.Dto.ITRP
{/// <summary>
/// Основной класс номенклатуры ИТРП
/// </summary>
    public class NomenclatureITRP_Main
    {
        public string Наименование { get;set; }
        public string Код { get; set; }
        public BaseUnitsOfMeasurement БазоваяЕдиницаИзмерения { get; set; }
        public TypeReproductionITRP ВидВоспроизводства { get; set; }
        public TypeTMC ВидУчетаТМЦ { get; set; }

    }
}
