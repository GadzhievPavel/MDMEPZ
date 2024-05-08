namespace TFlex.DOCs.References.Performers{
    using MDMEPZ.Dto;
    using MDMEPZ.Util;
    using System;
    using System.Collections.Generic;
    using TFlex.DOCs.Model.References;


    public partial class PerformersReference : SpecialReference<PerformersReferenceObject>
    {

        public partial class Factory
        {
        }

        /// <summary>
        /// Получает из .json список исполнителей и создаёт их
        /// </summary>
        /// <param name="performers"></param>
        public List<ReferenceObject> CreateReferenceObjectPerformers(Operation performers)
        {
            List<ReferenceObject> listPerformers = new List<ReferenceObject>();

            var listPerformersJson = performers.Исполнители.ROWS;
            foreach (var performer in listPerformersJson)
            {

                var performerReferenceObject = CreateReferenceObject(performer);
                listPerformers.Add(performerReferenceObject);

            }
            return listPerformers;
        }
        /// <summary>
        /// Создаёт исполнителя
        /// </summary>
        /// <param name="performer"></param>
        /// <returns></returns>
        public ReferenceObject CreateReferenceObject(ExecutorsRows performer)
        {
            ReferenceObject professionTP = null;
            var referenceMDMProfession = Connection.ReferenceCatalog.Find(new Guid("6c55d27d-e87b-4d64-b9b5-4f7bce9456c6")).CreateReference();//справочник профессий
            var professionMDM = referenceMDMProfession.Find(performer.Профессия.UID);//нашёл по UID из .json объект в справочнике профессий MDM;

            if (professionMDM != null)
            {
                professionTP = professionMDM.GetObject(new Guid("1fe93298-7d24-4842-b885-3a70160ebe41"));//получил из MDM профессии -> профессию в поставке
            }

            var performersReferenceObject = CreateReferenceObject(Classes.MainPerformers) as PerformersReferenceObject;// СОЗДАЛИ ОБЪЕКТ В СПРАВОЧНИКЕ ИСПОЛНИТЕЛЬ ОПЕРАЦИИ
            performersReferenceObject.StartUpdate();
            performersReferenceObject.WorkersCount.Value = performer.КоличествоИсполнителей;
            performersReferenceObject.SetLinkedObject(PerformersReferenceObject.RelationKeys.PerformersToProfessions, professionTP);

            //performersReferenceObject.Rank.Value = performer.РазрядРабот.;
            return performersReferenceObject;
        }

    }

}