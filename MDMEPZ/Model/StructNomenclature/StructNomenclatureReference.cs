namespace TFlex.DOCs.References.StructNomenclature
    using System.Collections.Generic;
    using TFlex.DOCs.References.NomenclatureERP;
    using TFlex.DOCs.Model.Search;
    using TFlex.DOCs.References.ConnectionNomenclatures;
    using System.Linq;

    public partial class StructNomenclatureReference : SpecialReference<StructNomenclatureReferenceObject>
		{
			var filter = Filter.Parse($"[������������ �� ERP]->[GUID(1C)] = '{nomERP.GUID1C}'", ParameterGroup);
			return Find(filter).FirstOrDefault();
		{
			var structObject = CreateReferenceObject() as StructNomenclatureReferenceObject;
			structObject.NomenclatureERP = nomERP;
			return structObject;
		}