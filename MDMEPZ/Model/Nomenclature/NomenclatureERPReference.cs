namespace TFlex.DOCs.References.NomenclatureERP{
    using System;
    using TFlex.DOCs.Model.References;
    using TFlex.DOCs.Model.Structure;
    using TFlex.DOCs.Model.Classes;
    using TFlex.DOCs.Model;
    using System.Collections.Generic;
    using TFlex.DOCs.Model.Search;

    public partial class NomenclatureERPReference : SpecialReference<NomenclatureERPReferenceObject>
    {

        public partial class Factory
        {
        }

        public List<ReferenceObject> findObjectsByDenotation(String denotation)
        {
            return Find(getFilterNomenclatureByDenotation(denotation));
        }

        public List<ReferenceObject> findObjectsByName(String name)
        {
            return Find(getFilterNomenclatureByName(name));
        }
        private Filter getFilterNomenclatureByDenotation(String denotation)
        {
            Filter filter = new Filter(ParameterGroup);
            ReferenceObjectTerm term = new ReferenceObjectTerm(filter.Terms);
            term.Path.AddParameter(ParameterGroup.Parameters.Find(NomenclatureERPReferenceObject.FieldKeys.Denotation));
            term.Operator = ComparisonOperator.Equal;
            term.Value = denotation;
            filter.Validate();
            return filter;
        }

        private Filter getFilterNomenclatureByName(String name)
        {
            Filter filter = new Filter(ParameterGroup);
            ReferenceObjectTerm term = new ReferenceObjectTerm(filter.Terms);
            term.Path.AddParameter(ParameterGroup.Parameters.Find(NomenclatureERPReferenceObject.FieldKeys.Name));
            term.Operator = ComparisonOperator.Equal;
            term.Value = name;
            filter.Validate();
            return filter;
        }
    }}