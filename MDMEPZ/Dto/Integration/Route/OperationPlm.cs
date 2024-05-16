using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFlex.DOCs.Model.References;
using TFlex.DOCs.Model.References.Nomenclature;
using TFlex.DOCs.References.NomenclatureERP;
using TFlex.Model.Technology.References.TechnologyElements;

namespace MDMEPZ.Dto.Integration.Route
{
    public class OperationPlm
    {
        public string Name { get; set; }
        public string Denotation { get; set; }
        public string NumberOperation { get; set; }
        public string NumberDepartament { get; set; }
        public List<NomenclatureWithRoute> nomenclatures { get; set; }
        public List<Nomenclature> materials { get; set; }
        public List<EmployeePlmDto> employees { get; set; }

        public static OperationPlm CreateInstance(StructuredTechnologicalOperation operation)
        {
            var operationPlm = new OperationPlm();
            operationPlm.Name = operation.Name;
            operationPlm.Denotation = operation.Code.GetString();
            ///номер подразделения
            operationPlm.NumberDepartament = operation.ProductionUnit[new Guid("15372720-40fe-4c5a-bfe1-edd30c5e5b78")].GetString();
            ///номер операции
            operationPlm.NumberOperation = operation[new Guid("814ba811-e651-4d5a-ba7d-29123a4e353a")].GetString();

            List<ReferenceObject> complect = new List<ReferenceObject>();
            ///комплектующие
            operation.TryGetObjects(new Guid("25a393dc-8f97-4e25-aa68-30f8382cd756"), out complect);

            if (complect != null)
            {
                operationPlm.nomenclatures = new List<NomenclatureWithRoute>();
                foreach (var obj in complect)
                {
                    var nom = (NomenclatureObject)obj;
                    var mdm = nom.GetObject(NomenclatureERPReferenceObject.RelationKeys.Nomenclature) as NomenclatureERPReferenceObject;
                    operationPlm.nomenclatures.Add(NomenclatureWithRoute.CreateInstance(mdm));
                }
            }


            ///материалы
            var materialsTP = operation.MaterialObjectsGroup.Objects.ToList();
            
        }
    }
}
