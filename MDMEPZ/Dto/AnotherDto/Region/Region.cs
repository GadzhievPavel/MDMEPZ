using MDMEPZ.Dto.AnotherDto.Division;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDMEPZ.Dto.AnotherDto.Region
{
    public class Region
    {
        public ReferenceRegion Ссылка { get; set; }
        public OwnerRegion Владелец { get; set; }
        public string Наименование { get; set; }
        public string Код { get; set; }

    }
}
