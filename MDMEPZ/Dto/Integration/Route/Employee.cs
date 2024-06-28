using MDMEPZ.Dto.AnotherDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFlex.DOCs.Model;
using TFlex.DOCs.Model.References;
using TFlex.DOCs.References.Performers;
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
        public double pieceTime { get; set; }
        /// <summary>
        /// Коэффициент штучного времени
        /// </summary>
        public double coeffPieceTime { get; set; }
        /// <summary>
        /// Подготовительно-заключительное время
        /// </summary>
        public double preparatoryFinalTime { get; set; }
        /// <summary>
        /// степень механизации
        /// </summary>
        public int auto { get; set; }

        public static EmployeePlmDto CreateInstance(ServerConnection connection, ReferenceObject worker)
        {
            var employeePlm = new EmployeePlmDto();

            if(worker is null)
            {
                return employeePlm;
            }
            //профессия
            var profession = worker.GetObject(new Guid("2f1acb06-b20a-4fe5-897f-045138476351")).GetObject(ProfessionReferenceObject.RelationKeys.ProfessionPDM) as ProfessionReferenceObject;
            employeePlm.profession = Profession.CreateInstance(profession);


            var performer = worker as PerformersReferenceObject;
            //employeePlm.typeJobs = TypeJobs.CreateInstance(connection, worker[PerformersReferenceObject.FieldKeys.Rank].Value.ToString());
            employeePlm.typeJobs = TypeJobs.CreateInstance(connection, performer.Rank.Value.ToString());
            //employeePlm.unitNormalize = (float)worker[WorkerReferenceObject.FieldKeys.EN].Value;
            employeePlm.unitNormalize = performer.RationingUnit;
            employeePlm.amount = performer.WorkersCount;
            //employeePlm.amount = worker[WorkerReferenceObject.FieldKeys.WorkCount].GetInt32();
            employeePlm.pieceTime = performer.PieceTime;
            //employeePlm.pieceTime = (float)worker[WorkerReferenceObject.FieldKeys.PieceTime].Value;
            employeePlm.coeffPieceTime = performer.TimeKoef;
            //employeePlm.coeffPieceTime = (float)worker[WorkerReferenceObject.FieldKeys.TimeKoef].Value;
            employeePlm.preparatoryFinalTime = performer.PrepTime;
            //employeePlm.preparatoryFinalTime = (float)worker[WorkerReferenceObject.FieldKeys.PrepTime].Value;
            employeePlm.auto = performer.MechanizationLevel;
            //employeePlm.auto = (int)worker[WorkerReferenceObject.FieldKeys.AutoRange].Value;

            return employeePlm;
        }
    }
}
