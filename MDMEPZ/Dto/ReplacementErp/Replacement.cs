using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDMEPZ.Dto.ReplacementErp
{
    public class Replacement
    {
        /// <summary>
        /// исходная номенклатура
        /// </summary>
        public string baseNomenclature {  get; set; }
        /// <summary>
        /// номенклатура заменитель
        /// </summary>
        public string replacement {  get; set; }
        /// <summary>
        /// применяемость
        /// </summary>
        public string applicability { get; set; }
        /// <summary>
        /// начало действия
        /// </summary>
        public string dateStart { get; set; }
        /// <summary>
        /// завершение действия
        /// </summary>
        public string dateEnd { get; set; }
        /// <summary>
        /// guid 1c
        /// </summary>
        public string guid1C { get; set; }
    }
}
