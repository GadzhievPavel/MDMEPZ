using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFlex.DOCs.Model;
using TFlex.DOCs.Model.References;
using TFlex.DOCs.Model.References.Nomenclature;
using TFlex.DOCs.References.Devision;
using TFlex.DOCs.References.EtalonMaterial;
using TFlex.DOCs.References.NomenclatureERP;
using TFlex.DOCs.References.Sortament;
using TFlex.Model.Technology.References.TechnologyElements;
using TFlex.Model.Technology.References.TechnologyElements.OperationWorkers;

namespace MDMEPZ.Dto.Integration.Route
{
    public class OperationPlm
    {
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Обозначение
        /// </summary>
        public string Denotation { get; set; }
        /// <summary>
        /// номер операции
        /// </summary>
        public string NumberOperation { get; set; }
        /// <summary>
        /// номер подразделения
        /// </summary>
        public string NumberDepartament { get; set; }
        /// <summary>
        /// подразделение
        /// </summary>
        public DepartamentDTO Departament {  get; set; }
        /// <summary>
        /// комплектующие - ходящая номенклатура
        /// </summary>
        public List<NomenclatureWithRoute> nomenclatures { get; set; }
        /// <summary>
        /// материалы - входящая номенклатура
        /// </summary>
        public List<Nomenclature> materials { get; set; }
        /// <summary>
        /// сотрудники
        /// </summary>
        public List<EmployeePlmDto> employees { get; set; }

        public static OperationPlm CreateInstance(ServerConnection connection, StructuredTechnologicalOperation operation)
        {
            var operationPlm = new OperationPlm();
            operationPlm.Name = operation.Name;
            operationPlm.Denotation = operation.Code.GetString();
            ///номер подразделения
            //operationPlm.NumberDepartament = operation.ProductionUnit[new Guid("15372720-40fe-4c5a-bfe1-edd30c5e5b78")].GetString();
            var divisionReference = connection.ReferenceCatalog.Find(DevisionReference.ReferenceId).CreateReference() as DevisionReference;
            var divisionObject = divisionReference.FindByLinkedObject(operation.ProductionUnit) as DevisionReferenceObject;
            operationPlm.Departament = DepartamentDTO.CreateInstance(divisionObject, connection);
            ///номер операции
            operationPlm.NumberOperation = operation[new Guid("814ba811-e651-4d5a-ba7d-29123a4e353a")].GetString();

            List<ReferenceObject> complect = new List<ReferenceObject>();
            ///комплектующие
            //operation.TryGetObjects(new Guid("25a393dc-8f97-4e25-aa68-30f8382cd756"), out complect);

            AssemblyTechnologicalOperation assemblyOperation = null;
            if (operation.Class.IsAssemblyTechnologicalOperation)
            {
                assemblyOperation = operation as AssemblyTechnologicalOperation;
                complect = assemblyOperation.MaterialObjectsGroup.Objects.ToList();
            }


            if (complect.Any())
            {
                operationPlm.nomenclatures = new List<NomenclatureWithRoute>();
                foreach (var obj in complect)
                {
                    var nom = (NomenclatureObject)obj;
                    var mdm = nom.GetObject(NomenclatureERPReferenceObject.RelationKeys.Nomenclature) as NomenclatureERPReferenceObject;
                    operationPlm.nomenclatures.Add( NomenclatureWithRoute.CreateInstance(connection, mdm));
                }
            }

            operationPlm.materials = new List<Nomenclature> { };
            ///материалы ТП
            var materialsTP = operation.GetObjects(new Guid("beeab0ff-1598-44b5-a2d4-32fdf0e98e90"));
            foreach (var materialTP in materialsTP)
            {
                //to do переделать поиск материала через эталоны и эквиваленты
                ///материал
                //var material = materialTP.GetObject(new Guid("f0d0e7da-5b72-4ece-abaf-e958503f7b1e")) as SortamentReferenceObject;
                //var materialPDM = material.GetLinkedNomenclatureObject();
                //NomenclatureERPReference nomenclatureERP = new NomenclatureERPReference(connection);
                //var nomMaterial = nomenclatureERP.FindByPdmObject(materialPDM);
                //operationPlm.materials.Add(Nomenclature.CreateInstance(nomMaterial));
            }

            operationPlm.employees = new List<EmployeePlmDto> { };
            ///исполнители
            var workers = operation.GetObjects(new Guid("3a7eab57-39e7-4bb7-92dd-aaa791be9fc4"));
            foreach (var worker in workers)
            {
                operationPlm.employees.Add(EmployeePlmDto.CreateInstance(connection, worker as WorkerReferenceObject));
            }

            return operationPlm;

        }
    }
}
