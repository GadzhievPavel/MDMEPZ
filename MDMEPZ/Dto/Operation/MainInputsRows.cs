using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Операция
{
    /// <summary>
    /// Строки основных входов
    /// </summary>
    public class MainInputsRows
    {
        public int НомерСтроки { get; set; }
        public Nomenclature Номенклатура { get; set; }
        public MeasurementUnits ЕдиницаИзмерения { get; set; }
        public bool ИспользоватьФормулу { get; set; }
        public int Применяемость { get; set; }
        public EnterRoute Заход { get;set;}
        public TypeTMC ВидУчетаТМЦ { get; set; }
    }
}
