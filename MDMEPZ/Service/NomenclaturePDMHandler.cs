using MDMEPZ.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFlex.DOCs.Model;
using TFlex.DOCs.Model.Diagnostics;
using TFlex.DOCs.Model.Parameters;
using TFlex.DOCs.Model.References;
using TFlex.DOCs.Model.References.Nomenclature;
using TFlex.DOCs.Model.Search;
using TFlex.DOCs.Model.Structure;
using TFlex.DOCs.References.NomenclatureERP;

namespace MDMEPZ.Service
{
    public class NomenclaturePDMHandler
    {
        private NomenclatureReference nomenclaturePdmReference;
        private ServerConnection connection;
        public NomenclaturePDMHandler(ServerConnection connectionInfo) {
            this.connection = connectionInfo;
            nomenclaturePdmReference = connection.ReferenceCatalog.Find(SpecialReference.Nomenclature).CreateReference() as NomenclatureReference;
        }

        public List<ReferenceObject> findNomenclatureByDenotation(string denotation)
        {
            var listNomenclatures = nomenclaturePdmReference.Find(getFilterNomenclatureByDenotation(denotation));
            return listNomenclatures;
        }

        private Filter getFilterNomenclatureByDenotation(String denotation)
        {
            Filter filter = new Filter(nomenclaturePdmReference.ParameterGroup);
            ReferenceObjectTerm term = new ReferenceObjectTerm(filter.Terms);
            term.Path.AddParameter(nomenclaturePdmReference.ParameterGroup.Parameters.Find(NomenclatureObject.FieldKeys.Denotation));
            term.Operator = ComparisonOperator.Equal;
            term.Value = denotation;

            filter.Validate();
            return filter;
        }

        public void setNomenclatureParameterInMDM(NomenclatureObject nom, Guid link, ReferenceObject obj)
        {
            var mdm = nom.GetObject(NomenclatureMDMReferenceObject.RelationKeys.Nomenclature);
            mdm.StartUpdate();
            mdm.SetLinkedObject(link, obj);
            mdm.EndUpdate($"в мдм для номенклатуры {nom} по связи {link} записано значение {obj}");
        }


        public void setNomenclatureParameterInMDM(NomenclatureObject nom, Guid link, object o)
        {
            var mdm = nom.GetObject(NomenclatureMDMReferenceObject.RelationKeys.Nomenclature);
            mdm.StartUpdate();
            mdm[link].Value = o;
            mdm.EndUpdate($"в мдм для номенклатуры {nom} по связи {link} записано значение {o}");
        }
    }
}
