using NotificationsEPZ;
using NotificationsEPZ.Changes.ListObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFlex.DOCs.Model;
using TFlex.DOCs.Model.References.Nomenclature;
using TFlex.DOCs.References.NomenclatureERP;

namespace MDMEPZ.Dto.Notification
{
    /// <summary>
    /// Список входы
    /// </summary>
    public class ListInputs
    {
        /// <summary>
        /// номенклатура
        /// </summary>
        public Nomenclature nomenclatureSrc { get; set; }
        /// <summary>
        /// Использовать задел
        /// </summary>
        public bool usingZadel { get; set; }
        /// <summary>
        /// применяемость
        /// </summary>
        public double countBefore { get; set; }
        /// <summary>
        /// применяемость после
        /// </summary>
        public double countAfter { get; set; }
        /// <summary>
        /// применяемость замены
        /// </summary>
        public double countZamen { get; set; }
        /// <summary>
        /// Замена
        /// </summary>
        public NomenclatureWithRoute nomenclatureNew { get; set; }

        public static ListInputs CreateInstance(Change change, MatchConnection matchConnection, ServerConnection connection)
        {
            var input = new ListInputs();
            var mdmReference = new NomenclatureMDMReference(connection);
            var nomSrc = mdmReference.FindByPdmObject(matchConnection.SourceConnection.ChildObject as NomenclatureObject);
            input.nomenclatureSrc = Nomenclature.CreateInstance(nomSrc);
            input.usingZadel = change.UsingZadel;
            input.countBefore = (matchConnection.SourceConnection as NomenclatureHierarchyLink).Amount;

            return input;
        }

        /// <summary>
        /// СОздания входа номенклатур заменяющихся
        /// </summary>
        /// <param name="change"></param>
        /// <param name="action"></param>
        /// <param name="connection"></param>
        /// <returns></returns>
        public static ListInputs CreateSwapListInput(Change change, NotificationsEPZ.Changes.ListObjects.Action action, ServerConnection connection)
        {
            var input = new ListInputs();
            var mdmReference = new NomenclatureMDMReference(connection);

            var sourceConnection = action.GetChangeConnection().Find(m => m.IsDeleted);
            var newConnection = action.GetChangeConnection().Find(m => m.IsAdded);

            return input;
        }


    }
}
