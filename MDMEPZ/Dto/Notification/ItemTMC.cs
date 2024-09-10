using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDMEPZ.Dto.Notification
{
    /// <summary>
    /// Элемент списка ТМЦ
    /// </summary>
    public class ItemTMC
    {
        /// <summary>
        /// Изделие
        /// </summary>
        public Nomenclature product;
        /// <summary>
        /// Исключается
        /// </summary>
        public Nomenclature excluded;
        /// <summary>
        /// замена
        /// </summary>
        public Nomenclature newNomenclature;
    }
}
