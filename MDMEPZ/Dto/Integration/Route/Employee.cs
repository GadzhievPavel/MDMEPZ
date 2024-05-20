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
        /// <summary>
        /// профессия
        /// </summary>
        public Profession profession { get; set; }
        /// <summary>
        /// Разряд рабочего
        /// </summary>
        public TypeJobs typeJobs { get; set; }
        /// <summary>
        /// Единица нормирования
        /// </summary>
        public float unitNormalize { get; set; }
        /// <summary>
        /// Количество рабочих
        /// </summary>
        public int amount { get; set; }
        /// <summary>
        /// штучное время
        /// </summary>
        public float pieceTime { get; set; }
        /// <summary>
        /// Коэффициент штучного времени
        /// </summary>
        public float coeffPieceTime { get; set; }
        /// <summary>
        /// Подготовительно-заключительное время
        /// </summary>
        public float preparatoryFinalTime { get; set; }
        /// <summary>
        /// степень механизации
        /// </summary>
        public int auto { get; set; }

        public static EmployeePlmDto CreateInstance(ServerConnection connection, WorkerReferenceObject worker)
        {
            var employeePlm = new EmployeePlmDto();

            if(worker is null)
            {
                return employeePlm;
            }
            //профессия
            var profession = worker.TPWorkerProfession.GetObject(ProfessionReferenceObject.RelationKeys.ProfessionPDM) as ProfessionReferenceObject;
            employeePlm.profession = Profession.CreateInstance(profession);

            employeePlm.typeJobs = TypeJobs.CreateInstance(connection, worker.Rank.Value.ToString());
            employeePlm.unitNormalize = (float)worker.EN.Value;
            employeePlm.amount = worker[WorkerReferenceObject.FieldKeys.WorkCount].GetInt32();
            employeePlm.pieceTime = (float)worker[WorkerReferenceObject.FieldKeys.PieceTime].Value;
            employeePlm.coeffPieceTime = (float)worker[WorkerReferenceObject.FieldKeys.TimeKoef].Value;
            employeePlm.preparatoryFinalTime = (float)worker[WorkerReferenceObject.FieldKeys.PrepTime].Value;
            employeePlm.auto = (int)worker[WorkerReferenceObject.FieldKeys.AutoRange].Value;
            return employeePlm;
        }
    }
}
