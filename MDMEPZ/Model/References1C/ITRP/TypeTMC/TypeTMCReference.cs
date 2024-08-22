namespace TFlex.DOCs.References.TypeTMC{	using System;	using TFlex.DOCs.Model.References;	using TFlex.DOCs.Model.Structure;	using TFlex.DOCs.Model.Classes;	using TFlex.DOCs.Model;
    using TFlex.DOCs.Model.Search;
    using System.Linq;

    public partial class TypeTMCReference : SpecialReference<TypeTMCReferenceObject>	{				public partial class Factory		{		}		public TypeTMCReferenceObject FindByGuid1C(Guid guid)
		{
			return this.Find(Filter.Parse($"[UID 1C] = '{guid}'", ParameterGroup)).FirstOrDefault() as TypeTMCReferenceObject;
		}	}}