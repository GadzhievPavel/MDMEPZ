using MDMEPZ.Dto;
using MDMEPZ.Exception;
using System.Collections.Generic;
using System.Linq;
using TFlex.DOCs.Model;
using TFlex.DOCs.Model.References.Nomenclature;
using TFlex.DOCs.Model.Search;
using TFlex.DOCs.References.NomenclatureERP;

namespace MDMEPZ.Service
{
    public class ServiceOperation
    {
        private ServerConnection connection;

        public ServiceOperation(ServerConnection connection)
        {
            this.connection = connection;
        }

        public bool isAssemblyOperation(Operation operation)
        {
            var referenceNumenclatureERP = connection.ReferenceCatalog.Find(NomenclatureERPReference.ReferenceId).CreateReference();//справочник Номенклатуры ERP
            var ownerIN = operation.ОсновныеВходы;
            if (ownerIN != null)
            {
                var listRows = operation.ОсновныеВходы.ROWS;
                if (listRows != null)
                {
                    foreach (var row in listRows)
                    {
                        var searchUID = row.Номенклатура.UID;
                        var result = referenceNumenclatureERP.Find(Filter.Parse($"[GUID(1C)] = '{searchUID}'", referenceNumenclatureERP.ParameterGroup)).FirstOrDefault();
                        if (result != null)
                        {
                            var objESI = result.GetObject(NomenclatureERPReferenceObject.RelationKeys.Nomenclature) as NomenclatureObject;
                            if (objESI != null)
                            {

                                if (objESI.Class.IsAssembly)
                                {
                                    return true;
                                }
                            }
                            else
                            {
                                throw new ExceptionIntegration("У объекта в Номенклатура ERP " + result + " отсутствует связанный объект с ЭСИ!");
                            }
                        }
                        else
                        {
                            throw new ExceptionIntegration("Основные входы присутствуют, но объект в НоменклатуреERP с заданным UID - " + searchUID + " отсутствует!");
                        }
                    }
                }
            }
            return false;
        }
        public List<NomenclatureObject> GetNomenclatureFromAssemblyOperation(Operation operation)
        {
            List<NomenclatureObject> listNomenclature = new List<NomenclatureObject>();
            var referenceNumenclatureERP = connection.ReferenceCatalog.Find(NomenclatureERPReference.ReferenceId).CreateReference();//справочник Номенклатуры ERP
            var ownerIN = operation.ОсновныеВходы;
            if (ownerIN != null)
            {
                var listRows = operation.ОсновныеВходы.ROWS;
                if (listRows != null)
                {
                    foreach (var row in listRows)
                    {
                        var searchUID = row.Номенклатура.UID;
                        var result = referenceNumenclatureERP.Find(Filter.Parse($"[GUID(1C)] = '{searchUID}'", referenceNumenclatureERP.ParameterGroup)).FirstOrDefault();
                        if (result != null)
                        {
                            var objESI = result.GetObject(NomenclatureERPReferenceObject.RelationKeys.Nomenclature) as NomenclatureObject;
                            if (objESI != null)
                            {

                                listNomenclature.Add(objESI);
                            }
                            else
                            {
                                throw new ExceptionIntegration("У объекта в Номенклатура ERP " + result + " отсутствует связанный объект с ЭСИ!");
                            }
                        }
                        else
                        {
                            throw new ExceptionIntegration("Основные входы присутствуют, но объект в НоменклатуреERP с заданным UID - " + searchUID + " отсутствует!");
                        }
                    }
                }
            }
            return listNomenclature;
        }
    }
}
