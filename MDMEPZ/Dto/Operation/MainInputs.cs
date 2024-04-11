using System.Collections.Generic;

namespace MDMEPZ.Dto
{
    /// <summary>
    /// Основные Входы
    /// </summary>
    public class MainInputs
    {
        public string TYPE { get; set; }
        public MainInputsColumns COLUMNS { get; set; }
        public List<MainInputsRows> ROWS { get; set; }
    }
}