namespace TFlex.DOCs.References.Performers
{
    using MDMEPZ.Dto;
    using MDMEPZ.Util;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TFlex.DOCs.Model.References;
    using TFlex.DOCs.References.Profession;

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
            //LogTFlex a = new LogTFlex("D:\\temp"+DateTime.Now+".txt");
           // a.error("Зашёл сюда");
            var listPerformersJson = performers.Исполнители.ROWS;
            if (listPerformersJson.Any())
            {
                foreach (var performer in listPerformersJson)
                {

                    if (performer != null)
                    {

                        var performerReferenceObject = CreateReferenceObject(performer);
                        if (performerReferenceObject != null)
                        {
                            listPerformers.Add(performerReferenceObject);
                        }
                    }
                    else
                    {
                        throw new Exception("зашёл в foreach с списком исполнителей но исполнителей нет");
                    }
                }
            }
            else
            {
                throw new Exception("список исполнителей пришёл пустым");
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
            if (referenceMDMProfession != null)
            {
                ReferenceObject professionMDM = referenceMDMProfession.Find(ProfessionReferenceObject.FieldKeys.UID,performer.Профессия.UID).First();//нашёл по UID из .json объект в справочнике профессий MDM;
                if (professionMDM != null)
                {
                    professionTP = professionMDM.GetObject(new Guid("1fe93298-7d24-4842-b885-3a70160ebe41"));//получил из MDM профессии -> профессию в поставке
                }
            }

            var performersReferenceObject = CreateReferenceObject(Classes.MainPerformers) as PerformersReferenceObject;// СОЗДАЛИ ОБЪЕКТ В СПРАВОЧНИКЕ ИСПОЛНИТЕЛЬ ОПЕРАЦИИ
            performersReferenceObject.StartUpdate();
            performersReferenceObject.WorkersCount.Value = performer.КоличествоИсполнителей;
            if (professionTP!=null)
            {
                performersReferenceObject.SetLinkedObject(PerformersReferenceObject.RelationKeys.PerformersToProfessions, professionTP);
            }
           
            performersReferenceObject.EndUpdate("");
            //performersReferenceObject.Rank.Value = performer.РазрядРабот.;
            return performersReferenceObject;
        }

    }

}

