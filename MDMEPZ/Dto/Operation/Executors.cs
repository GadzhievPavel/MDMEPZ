using System.Collections.Generic;

namespace ClassLibrary1.Операция
{
    /// <summary>
    /// Исполнители
    /// </summary>
    public class Executors
    {
        public string TYPE { get; set; }
        public ExecutorsColumns COLUMNS { get; set; }
        public List<ExecutorsRows> ROWS { get; set; }


    }
}