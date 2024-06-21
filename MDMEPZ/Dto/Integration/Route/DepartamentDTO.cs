using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFlex.DOCs.Model;
using TFlex.DOCs.Model.References;
using TFlex.DOCs.References.Devision;

namespace MDMEPZ.Dto.Integration.Route
{
    public class DepartamentDTO
    {
        public string Name { get; set; }
        public string NumberDivision { get; set; }
        public string UID { get; set; }
        public string TFlexUID { get; set; }
        public DepartamentDTO Parent { get; set; }

        public static DepartamentDTO CreateInstance(DevisionReferenceObject division, ServerConnection connection)
        {
            if (division == null) throw new ArgumentNullException($"Подразделение null");
            var departament = new DepartamentDTO();
            departament.Name = division.Name;
            departament.UID = division.UID;
            departament.TFlexUID = division.GroupAndUsers.Guid.ToString();

            departament.Parent = new DepartamentDTO();

            DevisionReference devisionReference = new DevisionReference(connection);
            ///получение родительского подразделения
            var parentObjectPDM = division.GroupAndUsers.Parent;
            var devisionParent = devisionReference.FindByLinkedObject(parentObjectPDM) as DevisionReferenceObject;

            departament.Parent.UID = devisionParent.UID;
            departament.Parent.Name = devisionParent.Name;
            departament.Parent.TFlexUID = devisionParent.GroupAndUsers.Guid.ToString();

            return departament;
        }
    }
}
