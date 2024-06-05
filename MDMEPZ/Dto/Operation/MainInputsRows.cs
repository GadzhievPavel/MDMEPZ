using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDMEPZ.Dto
{
    /// <summary>
    /// Строки основных входов
    /// </summary>
    public class MainInputsRows
    {
        public int НомерСтроки { get; set; }
        public NomenclatureOperation Номенклатура { get; set; }
        public MeasurementUnits ЕдиницаИзмерения { get; set; }
        public bool ИспользоватьФормулу { get; set; }
        public double Применяемость { get; set; }
        public EnterRoute Заход { get;set;}
        public TypeTMC ВидУчетаТМЦ { get; set; }
    }
}
