namespace TFlex.DOCs.References.TypeJobMDM
    using TFlex.DOCs.Model.Search;
    using System.Linq;

    public partial class TypeJobMDMReference : SpecialReference<TypeJobMDMReferenceObject>
		{
			return Find(Filter.Parse($"[���] = '{number}'", this.ParameterGroup)).FirstOrDefault() as TypeJobMDMReferenceObject;
		}