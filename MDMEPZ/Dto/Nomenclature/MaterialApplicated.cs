using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDMEPZ.Dto.Nomenclature
{
    /// <summary>
    /// Материал с указанием применяемости
    /// </summary>
    public class MaterialApplicated
    {
        public Nomenclature nomenclature {  get; set; }
        public Double amount {  get; set; }
        public UnitOfMeasurement unitOfMeasurement { get; set; }
    }
}
