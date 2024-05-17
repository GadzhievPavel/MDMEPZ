namespace TFlex.DOCs.References.TypeJobMDM{	using System;	using TFlex.DOCs.Model.References;	using TFlex.DOCs.Model.Structure;	using TFlex.DOCs.Model.Classes;	using TFlex.DOCs.Model;
    using TFlex.DOCs.Model.Search;
    using System.Linq;

    public partial class TypeJobMDMReference : SpecialReference<TypeJobMDMReferenceObject>	{				public partial class Factory		{		}		public TypeJobMDMReferenceObject FindTypeJob(string number)
		{
			return Find(Filter.Parse($"[Код] = '{number}'", this.ParameterGroup)).FirstOrDefault() as TypeJobMDMReferenceObject;
		}	}}