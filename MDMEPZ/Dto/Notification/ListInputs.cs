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

        public static ListInputs CreateInstance(MatchConnection matchConnection, ServerConnection connection)
        {
            var input = new ListInputs();
            var mdmReference = new NomenclatureMDMReference(connection);
            var nomSrc = mdmReference.FindByPdmObject(matchConnection.SourceConnection.ChildObject as NomenclatureObject);
            input.nomenclatureSrc = Nomenclature.CreateInstance(nomSrc);
            
            return input;
        }
    }
}
