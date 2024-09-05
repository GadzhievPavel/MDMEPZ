using NotificationsEPZ;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFlex.DOCs.Model;
using TFlex.DOCs.References.NomenclatureERP;

namespace MDMEPZ.Dto.Notification
{
    public class NotificationITRPDTO
    {
        /// <summary>
        /// Номер извещения в ИТРП
        /// </summary>
        public string NumberNotificationITRP { get; set; }
        /// <summary>
        /// Дата создания извещения в ИТРП
        /// </summary>
        public string DateCreate {  get; set; }
        /// <summary>
        /// Дата действия с
        /// </summary>
        public string DateActionSince { get; set; }
        /// <summary>
        /// Комплект
        /// </summary>
        public bool IsComplect {  get; set; }
        /// <summary>
        /// Задел по
        /// </summary>
        public Nomenclature ZadelOn { get; set; }
        /// <summary>
        /// Номер извещения
        /// </summary>
        public string NumberNotice { get; set; }
        /// <summary>
        /// номер базового извещения в ИТРП
        /// </summary>
        public string NumberITRPBaseNotice { get; set; }
        /// <summary>
        /// Обозначение базового извещения
        /// </summary>
        public string NumberBaseNotice { get; set; }
        /// <summary>
        /// Комментарий
        /// </summary>
        public string Comment {  get; set; }
        /// <summary>
        /// Список ТМЦ
        /// </summary>
        public List<Nomenclature> ListTMC {  get; set; }
        /// <summary>
        /// Список входы
        /// </summary>
        public List<ListInputs> ListInputsNomenclatures { get; set;}

        public static NotificationITRPDTO CreateInstance(NotificationEPZ notification, ServerConnection serverConnection)
        {
            var noticeDto = new NotificationITRPDTO();
            noticeDto.NumberNotificationITRP = notification.NumberNotificationITRP;
            noticeDto.DateActionSince = notification.DateActionSince;
            noticeDto.IsComplect = notification.IsComplect;
            var mdmReference = new NomenclatureMDMReference(serverConnection);
            noticeDto.ZadelOn = Nomenclature.CreateInstance(mdmReference.FindByPdmObject(notification.ZadelOn));
            noticeDto.NumberNotice = notification.Denotation;
            noticeDto.NumberBaseNotice = notification.SourceNotice.Denotation;
            noticeDto.NumberITRPBaseNotice = notification.SourceNotice.NumberNotificationITRP;
            noticeDto.Comment = notification.Comment;
            noticeDto.ListTMC = new List<Nomenclature>();
            foreach (var item in notification.getFullUsingAreas())
            {
                noticeDto.ListTMC.Add(Nomenclature.CreateInstance(mdmReference.FindByPdmObject(item)));
            }

            //foreach(var item in notification)

            return noticeDto;
        }
    }
}
