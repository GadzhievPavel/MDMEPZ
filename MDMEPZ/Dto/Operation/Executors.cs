using System.Collections.Generic;

namespace MDMEPZ.Dto
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