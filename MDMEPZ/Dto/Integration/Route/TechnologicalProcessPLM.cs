

using MDMEPZ.Dto;
using System.Collections.Generic;
using System.Linq;
using TFlex.DOCs.Model;
using TFlex.DOCs.References.NomenclatureERP;
using TFlex.Model.Technology.References.TechnologyElements;

namespace MDMEPZ.Dto.Integration.Route
{
    public class TechnologicalProcessPLM
    {
        public string Name { get; set; }
        public string Denotation { get; set; }
        public List<Nomenclature> ProducedNomenclatures { get; set; }
        public List<OperationPlm> Operations { get; set; }

        public static TechnologicalProcessPLM CreateInstance(ServerConnection connection, StructuredTechnologicalProcess process)
        {
            var processPlm = new TechnologicalProcessPLM();
            processPlm.Name = process.Name;
            processPlm.Denotation = process.Denotation;
            processPlm.ProducedNomenclatures = new List<Nomenclature>();
            var dseObjects = process.ProducedDSEGroup.ToList();
            foreach (var dseObject in dseObjects)
            {
                var mdmObject = dseObject.GetObject(NomenclatureERPReferenceObject.RelationKeys.Nomenclature) as NomenclatureERPReferenceObject;
                processPlm.ProducedNomenclatures.Add(Nomenclature.CreateInstance(mdmObject));
            }

            processPlm.Operations = new List<OperationPlm>();
            var operations = process.GetOperations(true).ToList();

            foreach(var operation in operations)
            {
                processPlm.Operations.Add(OperationPlm.CreateInstance(connection, operation));
            }

            return processPlm;
        }
    }
}
