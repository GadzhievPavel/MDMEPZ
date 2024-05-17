using MDMEPZ.Dto.AnotherDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFlex.DOCs.Model;
using TFlex.DOCs.Model.References;
using TFlex.DOCs.References.Profession;
using TFlex.Model.Technology.References.TechnologyElements.OperationWorkers;

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

        public static EmployeePlmDto CreateInstance(ServerConnection connection, WorkerReferenceObject worker)
        {
            var employeePlm = new EmployeePlmDto();
            //профессия
            var profession = worker.TPWorkerProfession.GetObject(ProfessionReferenceObject.RelationKeys.ProfessionPDM) as ProfessionReferenceObject;
            employeePlm.profession = Profession.CreateInstance(profession);

            employeePlm.typeJobs = TypeJobs.CreateInstance(connection, worker.Rank.Value.ToString());
        }
    }
}
