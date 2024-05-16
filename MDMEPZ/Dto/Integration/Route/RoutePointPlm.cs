using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFlex.DOCs.Model.References;

namespace MDMEPZ.Dto.Integration.Route
{
    public class RoutePointPlm
    {
        public string Name { get; set; }
        public string NumberDepartament { get; set; }
        public double DurationHour { get; set; }
        public double PreparatoryTimeHour { get; set; }
        public double FinalTimeHour { get; set; }
        public TechnologicalProcessPLM TechProcess { get; set; }

        public static RoutePointPlm CreateInstance(ReferenceObject routePoint)
        {
            if(!routePoint.Class.Guid.Equals(new Guid("25fad9d1-be23-4f4b-9afc-581b6d96b992")))
            {
                return null;
            }

            var routePointPlm = new RoutePointPlm();
            ///Наименование цехоперехода
            routePointPlm.Name = routePoint[new Guid("f97e40ea-3c79-4013-b1ea-383a2f09454d")].GetString() ?? string.Empty;
            ///Код отдела
            routePointPlm.NumberDepartament = routePoint.GetObject(new Guid("30888ac1-d215-478f-aaf2-915be9aa9066"))[new Guid("15372720-40fe-4c5a-bfe1-edd30c5e5b78")].GetString();
            ///Длительность
            routePointPlm.DurationHour = routePoint[new Guid("66536b01-dabb-418c-830c-1d396c1d1b24")].GetDouble();
            ///Подготовительное время
            routePointPlm.PreparatoryTimeHour = routePoint[new Guid("d1d78728-6215-4873-909b-35ebb7baebd9")].GetDouble();
            ///Заключительное время
            routePointPlm.FinalTimeHour = routePoint[new Guid("b11cf76e-e026-47b0-9e0b-5c63f9d95d01")].GetDouble();
            ///Ссылочный техпроцесс
            var techProcess = routePoint.GetObject(new Guid("2c0aed62-4ad9-4152-8138-18e94c4ffbe6"));

            routePointPlm.TechProcess = TechnologicalProcessPLM.
        }
    }
}
