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
        /// �������� �� .json ������ ������������ � ������ ��
        /// </summary>
        /// <param name="performers"></param>
        public List<ReferenceObject> CreateReferenceObjectPerformers(Operation performers)
        {
            List<ReferenceObject> listPerformers = new List<ReferenceObject>();
            //LogTFlex a = new LogTFlex("D:\\temp"+DateTime.Now+".txt");
           // a.error("����� ����");
            var listPerformersJson = performers.�����������.ROWS;
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
                        throw new Exception("����� � foreach � ������� ������������ �� ������������ ���");
                    }
                }
            }
            else
            {
                throw new Exception("������ ������������ ������ ������");
            }
            return listPerformers;
        }
        /// <summary>
        /// ������ �����������
        /// </summary>
        /// <param name="performer"></param>
        /// <returns></returns>
        public ReferenceObject CreateReferenceObject(ExecutorsRows performer)
        {
            ReferenceObject professionTP = null;
            var referenceMDMProfession = Connection.ReferenceCatalog.Find(new Guid("6c55d27d-e87b-4d64-b9b5-4f7bce9456c6")).CreateReference();//���������� ���������
            if (referenceMDMProfession != null)
            {
                ReferenceObject professionMDM = referenceMDMProfession.Find(ProfessionReferenceObject.FieldKeys.UID,performer.���������.UID).First();//����� �� UID �� .json ������ � ����������� ��������� MDM;
                if (professionMDM != null)
                {
                    professionTP = professionMDM.GetObject(new Guid("1fe93298-7d24-4842-b885-3a70160ebe41"));//������� �� MDM ��������� -> ��������� � ��������
                }
            }

            var performersReferenceObject = CreateReferenceObject(Classes.MainPerformers) as PerformersReferenceObject;// ������� ������ � ����������� ����������� ��������
            performersReferenceObject.StartUpdate();
            performersReferenceObject.WorkersCount.Value = performer.����������������������;
            if (professionTP!=null)
            {
                performersReferenceObject.SetLinkedObject(PerformersReferenceObject.RelationKeys.PerformersToProfessions, professionTP);
            }
           
            performersReferenceObject.EndUpdate("");
            //performersReferenceObject.Rank.Value = performer.�����������.;
            return performersReferenceObject;
        }

    }

}

