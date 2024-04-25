using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDMEPZ.Dto
{
    /// <summary>
    /// Классификатор типов операций 
    /// </summary>
    public class TypeOperationMDM
    {
        public bool OBJECT { get; set; }
        public string NEW { get; set; }
        public bool SAVE { get; set; }
        public bool Предопределенный { get; set; }
        public LinkTypeOperation Ссылка { get; set; }
        public bool ПометкаУдаления { get; set; }
        public bool ЭтоГруппа { get; set; }
        public OwnerOperation Родитель { get; set; }
        public string Наименование { get; set; }
        public string Код { get; set; }
    }
}
