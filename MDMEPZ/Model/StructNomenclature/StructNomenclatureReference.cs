namespace TFlex.DOCs.References.StructNomenclature{	using System;	using TFlex.DOCs.Model.References;	using TFlex.DOCs.Model.Structure;	using TFlex.DOCs.Model.Classes;	using TFlex.DOCs.Model;
    using System.Collections.Generic;
    using TFlex.DOCs.References.NomenclatureERP;
    using TFlex.DOCs.Model.Search;
    using TFlex.DOCs.References.ConnectionNomenclatures;
    using System.Linq;

    public partial class StructNomenclatureReference : SpecialReference<StructNomenclatureReferenceObject>	{				public partial class Factory		{		}		public ReferenceObject findPairByConnection(ConnectionNomenclaturesReferenceObject conn)
		{
			var filter = Filter.Parse($"[������������ �� ERP]->[GUID(1C)] = '{conn.CurrentParam}' � [�������� �������].[������������ �� ERP]->[GUID(1C)] = '{conn.ChildParam}'", ParameterGroup);
			return Find(filter).First();		}	}}