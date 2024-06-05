using TFlex.DOCs.Model;
using TFlex.DOCs.References.MDM.Rank;

namespace MDMEPZ.Dto
{
    /// <summary>
    /// Разряд Работ
    /// </summary>
    public class TypeJobs
    {
        public string TYPE { get; set; }
        public string UID { get; set; }

        public static TypeJobs CreateInstance(ServerConnection connection, string number)
        {
            var instance = new TypeJobs();
            RankMDMReference typeJobsReference = new RankMDMReference(connection);
            var typeJob = typeJobsReference.FindTypeJob(number);
            instance.UID = typeJob.UID;
            instance.TYPE = null;
            return instance;
        }
    }
}