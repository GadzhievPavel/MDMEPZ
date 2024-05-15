namespace TFlex.DOCs.References.Performers
{
    using MDMEPZ.Dto;
    using MDMEPZ.Util;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TFlex.DOCs.Model.References;
    using TFlex.DOCs.References.Profession;
    using TFlex.DOCs.References.Rank;

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
            if (listPerformersJson.Count != 0)
            {
                foreach (var performer in listPerformersJson)
                {

                    if (performer.Профессия.UID != "")
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
            RankReferenceObject _rankMDM = null;
            var referenceMDMProfession = Connection.ReferenceCatalog.Find(new Guid("6c55d27d-e87b-4d64-b9b5-4f7bce9456c6")).CreateReference();//справочник профессий
            var referenceMDMRank = Connection.ReferenceCatalog.Find(new Guid("862578ee-a916-4db6-8753-13dc61520ede")).CreateReference();//Справочник разрядов

            if (referenceMDMProfession != null)
            {
                ReferenceObject professionMDM = referenceMDMProfession.Find(ProfessionReferenceObject.FieldKeys.UID, performer.Профессия.UID).First();//нашёл по UID из .json объект в справочнике профессий MDM;
                if (professionMDM != null)
                {
                    professionTP = professionMDM.GetObject(new Guid("1fe93298-7d24-4842-b885-3a70160ebe41"));//получил из MDM профессии -> профессию в поставке
                }
            }
            else
            {
                throw new Exception("не найден справочник для поиска професиии МДМ");
            }

            if (referenceMDMRank != null)
            {
                ReferenceObject rankMDM = referenceMDMRank.Find(RankReferenceObject.FieldKeys.UID, performer.РазрядРабот.UID).First();//поиск по uid разряд работ из данных .json в справочнике MDM рязрядов
                _rankMDM = rankMDM as RankReferenceObject;
            }

            var performersReferenceObject = CreateReferenceObject(Classes.MainPerformers) as PerformersReferenceObject;// СОЗДАЛИ ОБЪЕКТ В СПРАВОЧНИКЕ ИСПОЛНИТЕЛЬ ОПЕРАЦИИ
            performersReferenceObject.StartUpdate();
            performersReferenceObject.WorkersCount.Value = performer.КоличествоИсполнителей;
            if (professionTP != null)
            {
                // var _professionTP = professionTP as ProfessionReferenceObject;
                performersReferenceObject.SetLinkedObject(PerformersReferenceObject.RelationKeys.PerformersToProfessions, professionTP);
                // performersReferenceObject.Name.Value = _professionTP.Name;//отдельно записываю имя т.к. в диалоге отображается отдельным параметром, а не параметром связи
            }

            if (_rankMDM != null)
            {
                performersReferenceObject.Rank.Value = (int)_rankMDM.Kod;//использую код, т.к. он приходит обработанным и имеет значение как и номер разряда(только цифра)
            }

            performersReferenceObject.EndUpdate("");
            return performersReferenceObject;
        }

    }

}

