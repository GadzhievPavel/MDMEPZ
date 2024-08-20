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
using TFlex.Model.Technology.References.Materials;
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
        public DepartamentDTO Departament { get; set; }
        /// <summary>
        /// комплектующие - ходящая номенклатура
        /// </summary>
        public List<NomenclatureFromComplectDTO> nomenclatures { get; set; }
        /// <summary>
        /// материалы - входящая номенклатура
        /// </summary>
        public List<MaterialApplicated> materials { get; set; }
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

            var complect = new List<NomenclatureFromComplectDTO>();
            ///комплектующие
            //operation.TryGetObjects(new Guid("25a393dc-8f97-4e25-aa68-30f8382cd756"), out complect);

            AssemblyTechnologicalOperation assemblyOperation = null;
            if (operation.Class.IsAssemblyTechnologicalOperation)
            {
                assemblyOperation = operation as AssemblyTechnologicalOperation;
                complect = getComplectNomenclatures(assemblyOperation, connection);
            }

            if (complect.Any())
            {
                operationPlm.nomenclatures = complect;
            }

            operationPlm.materials = new List<MaterialApplicated> { };

            ///материалы ТП
            var materialsTP = operation.GetObjects(new Guid("beeab0ff-1598-44b5-a2d4-32fdf0e98e90")).Cast<TechnologicalProcessMaterial>().ToList();
            foreach (var materialTP in materialsTP)
            {
                operationPlm.materials.Add(MaterialApplicated.CreateInstance(connection, materialTP));
            }

            operationPlm.employees = new List<EmployeePlmDto> { };
            ///исполнители
            var workers = operation.GetObjects(new Guid("3a7eab57-39e7-4bb7-92dd-aaa791be9fc4"));
            //var workers = operation.OperationWorkersGroup.Objects.Cast<WorkerReferenceObject>().ToList();
            foreach (var worker in workers)
            {
                operationPlm.employees.Add(EmployeePlmDto.CreateInstance(connection, worker));
            }

            return operationPlm;

        }
        /// <summary>
        /// возвращает комплектующие для сборочной операции
        /// </summary>
        /// <param name="operation">сборочная операция</param>
        /// <param name="connection">подключение</param>
        /// <returns></returns>
        public static List<NomenclatureFromComplectDTO> getComplectNomenclatures(AssemblyTechnologicalOperation operation, ServerConnection connection)
        {
            var dictNomenclatures = new Dictionary<NomenclatureReferenceObject, Double>();

            var producedNomenclature = operation.GetAssemblyNode();

            var complectLinks = operation.MaterialObjectsGroup.Objects.GetHierarchyLinks().Cast<NomenclatureHierarchyLink>();

            foreach (var complectLink in complectLinks)
            {
                if (dictNomenclatures.ContainsKey(complectLink.ChildObject))
                {
                    dictNomenclatures[complectLink.ChildObject] += complectLink.Amount;
                }
                else
                {
                    dictNomenclatures.Add(complectLink.ChildObject, complectLink.Amount);
                }
            }

            var listNomenclatures = new List<NomenclatureFromComplectDTO>();
            foreach (var pair in dictNomenclatures)
            {
                var mdm = pair.Key.GetObject(NomenclatureMDMReferenceObject.RelationKeys.Nomenclature) as NomenclatureMDMReferenceObject;
                listNomenclatures.Add(new NomenclatureFromComplectDTO()
                {
                    Nomenclature = NomenclatureWithRoute.CreateInstance(connection, mdm),
                    Count = pair.Value
                });
            }
            return listNomenclatures;
        }
    }
}
