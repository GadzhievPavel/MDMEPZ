using TFlex.DOCs.Model.References;
using TFlex.DOCs.References.Profession;

namespace MDMEPZ.Dto
{
    /// <summary>
    /// Профессия
    /// </summary>
    public class Profession
    {
        public string TYPE { get; set; }
        public string UID { get; set; }

        public static Profession CreateInstance(ProfessionReferenceObject profession)
        {
            var instance = new Profession();
            instance.TYPE = null;
            instance.UID = profession.UID;
            return instance;
        }
    }
}