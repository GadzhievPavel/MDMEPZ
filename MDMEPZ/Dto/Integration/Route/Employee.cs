using MDMEPZ.Dto.AnotherDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDMEPZ.Dto.Integration.Route
{
    public class EmployeePlmDto
    {
        public Profession profession {get; set;}
        public TypeJobs typeJobs { get; set; }
        public float unitNormalize { get; set; }
        public int amount { get; set; }
        public float pieceTime { get; set; }
        public float coeffPieceTime { get; set; }
        public float preparatoryFinalTime { get; set; }
    }
}
