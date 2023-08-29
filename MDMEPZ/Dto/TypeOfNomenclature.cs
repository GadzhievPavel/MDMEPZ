using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDMEPZ.Dto
{
    /// <summary>
    ///     Справочник "Тип номенклатуры"
    /// </summary>
    public class TypeOfNomenclature
    {
        // Наименование
        public string Name { get; set; }
        
        // GUID (1C)
        public string Guid1C { get; set; }
    }
}
