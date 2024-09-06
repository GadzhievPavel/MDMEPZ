using MDMEPZ.Dto;
using MDMEPZ.Dto.Notification;
using NotificationsEPZ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFlex.DOCs.Model;
using TFlex.DOCs.Model.References;
using TFlex.DOCs.Model.References.Nomenclature;
using TFlex.DOCs.References.NomenclatureERP;

namespace MDMEPZ.Service.Integration
{
    public class NoticeService
    {
        private ServerConnection connection;
        /// <summary>
        /// Обертка представляющая извещение
        /// </summary>
        private NotificationEPZ notificationEPZ;
        /// <summary>
        /// Формируемый DTO извещения
        /// </summary>
        private NotificationITRPDTO notificationITRPDTO;
        private NomenclatureMDMReference mdmReference;

        private DesignContextsReference designContextsReference;
        private DesignContextObject modificationDesignContextObject;



        public NoticeService(ServerConnection connection, NotificationEPZ notificationEPZ)
        {
            this.connection = connection;
            this.notificationEPZ = notificationEPZ;
            mdmReference = new NomenclatureMDMReference(connection);
            designContextsReference = new DesignContextsReference(connection);
            modificationDesignContextObject = designContextsReference.Find("Изменения") as DesignContextObject;
        }

        /// <summary>
        /// Возвращает электронное извещение
        /// </summary>
        /// <returns></returns>
        public NotificationITRPDTO GetNotificationITRPDTO()
        {
            this.notificationITRPDTO = new NotificationITRPDTO();
            notificationITRPDTO.NumberNotificationITRP = notificationEPZ.NumberNotificationITRP;
            notificationITRPDTO.DateActionSince = notificationEPZ.DateActionSince;
            notificationITRPDTO.IsComplect = notificationEPZ.IsComplect;
            notificationITRPDTO.ZadelOn = Nomenclature.CreateInstance(mdmReference.FindByPdmObject(notificationEPZ.ZadelOn));
            notificationITRPDTO.NumberNotice = notificationEPZ.Denotation;
            notificationITRPDTO.NumberBaseNotice = notificationEPZ.SourceNotice.Denotation;
            notificationITRPDTO.NumberITRPBaseNotice = notificationEPZ.SourceNotice.NumberNotificationITRP;
            notificationITRPDTO.Comment = notificationEPZ.Comment;

            notificationITRPDTO.ListTMC = new List<Nomenclature>();

            notificationEPZ.UpdateInContext(GetConfigurationSettings(modificationDesignContextObject));
            var usingAreas = notificationEPZ.getFullUsingAreas();
            foreach ( var area in usingAreas)
            {
                notificationITRPDTO.ListTMC.Add(Nomenclature.CreateInstance(mdmReference.FindByPdmObject(area)));
            }

            return notificationITRPDTO;
        }

        private ListInputs CreateListInputs(Change change)
        {
            return null;
        }
        private ConfigurationSettings GetConfigurationSettings(DesignContextObject designContext)
        {
            var config = new ConfigurationSettings(connection)
            {
                ApplyDesignContext = true,
                ShowDeletedInDesignContextLinks = true,
                DesignContext = designContext
            };
            return config;
        }
    }
}
