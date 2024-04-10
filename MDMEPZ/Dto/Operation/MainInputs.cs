using System.Collections.Generic;

namespace ClassLibrary1.Операция
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