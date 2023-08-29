using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDMEPZ.Dto
{
    /// <summary>
    ///     Справочник "Товарные категории"
    /// </summary>
    public class ProductCategory
    {
        // Наименование
        public string Name { get; set; }
        
        // GUID (1C)
        public string Guid1C { get; set; }
    }
}
