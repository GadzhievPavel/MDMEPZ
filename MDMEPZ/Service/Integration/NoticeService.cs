using MDMEPZ.Dto;
using MDMEPZ.Dto.Notification;
using NotificationsEPZ;
using NotificationsEPZ.Changes.ListObjects;
using NotificationsEPZ.Changes.ListObjects.Actions;
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

        private ListTMCService tmcServiceList;


        public NoticeService(ServerConnection connection, NotificationEPZ notificationEPZ)
        {
            this.connection = connection;
            this.notificationEPZ = notificationEPZ;
            mdmReference = new NomenclatureMDMReference(connection);
            designContextsReference = new DesignContextsReference(connection);
            modificationDesignContextObject = designContextsReference.Find("Изменения") as DesignContextObject;
            tmcServiceList = new ListTMCService(connection);
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
            notificationITRPDTO.ZadelOn = Nomenclature.CreateInstance(notificationEPZ.ZadelOn?.
                GetObject(NomenclatureMDMReferenceObject.RelationKeys.Nomenclature) as NomenclatureMDMReferenceObject);
            notificationITRPDTO.NumberNotice = notificationEPZ.Denotation;

            var sourceNotices = notificationEPZ.SourceNotices;
            if (sourceNotices != null)
            {
                if (sourceNotices.Any())
                {
                    notificationITRPDTO.NumberBaseNotice = notificationEPZ.SourceNotices.First()?.Denotation;
                    notificationITRPDTO.NumberITRPBaseNotice = notificationEPZ.SourceNotices.First()?.NumberNotificationITRP;
                }
            }

            notificationITRPDTO.Comment = notificationEPZ.Comment;
            notificationEPZ.UpdateInContext(GetConfigurationSettings(modificationDesignContextObject));

            notificationITRPDTO.ListTMC = new List<ItemTMC>();


            var changes = notificationEPZ.Changes;
            ///Заполнение списка ТМС
            //if (changes.Any()){
            //    foreach (var change in changes)
            //    {
            //        var actions = change.Actions;
            //        var usingAreasList = change.UsingAreas;
            //        List<MatchConnection> matches = new List<MatchConnection>();
            //        foreach(var area in usingAreasList)
            //        {
            //            matches.AddRange(area.GetMatchConnections());
            //        }
            //        foreach(var action in actions)
            //        {
            //            notificationITRPDTO.ListTMC.AddRange(tmcServiceList.getListTMC(matches, action));
            //        }
            //    }
            //}


            return notificationITRPDTO;
        }

        private List<ListInputs> CreateListInputs(Change change)
        {
            var listInputs = new List<ListInputs>();
            var actions = change.Actions;
            foreach (var action in actions)
            {
                var input = new ListInputs();
                if (action.TypeGuid.Equals(TypeActionsChange.SWAP))
                {

                }
                else if (action.TypeGuid.Equals(TypeActionsChange.ADD))
                {

                }
                else if (action.TypeGuid.Equals(TypeActionsChange.CHANGE))
                {
                    action.GetChangeConnection();
                }
                else if (action.TypeGuid.Equals(TypeActionsChange.DELETED))
                {

                }
            }
            return listInputs;
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
