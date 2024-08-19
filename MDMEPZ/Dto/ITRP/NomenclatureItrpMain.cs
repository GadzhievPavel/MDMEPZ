using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDMEPZ.Dto.ITRP
{/// <summary>
/// Основной класс номенклатуры ИТРП
/// </summary>
    public class NomenclatureItrpMain
    {
        public string Наименование { get;set; }
        public string НаименованиеДляВвода { get; set; }
        public string НаименованиеПолное { get; set; }
        public int ID53 { get; set; }
        public string Артикул {  get; set; }
        public string Код { get; set; }
        public TypeTmcForNomenclature ВидУчетаТМЦ { get; set; }
        public BaseUnitsOfMeasurement БазоваяЕдиницаИзмерения { get; set; }
        public BaseUnitsOfMeasurement ЕдиницаХраненияОстатков { get; set; }
        public BaseUnitsOfMeasurement ЕдиницаУчетаВПроизводстве {  get; set; }
        public string ВидВоспроизводства { get; set; }
        public List<FullUnitOfMeasurementItrp> Единицы { get; set;}
        //public TypeReproductionITRP ВидВоспроизводства { get; set; }


    }
}
