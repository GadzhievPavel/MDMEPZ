//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TFlex.DOCs.References.NomenclatureERP
{
	using System;
	using TFlex.DOCs.Model.References;
	using TFlex.DOCs.Model.Structure;
	using TFlex.DOCs.Model.Classes;
	using TFlex.DOCs.Model;
    using TFlex.DOCs.References.NomenclatureMDM;


    /// <summary>
    /// Представляет описание справочника "Номенклатура ERP"
    /// </summary>
    public partial class NomenclatureMDMReference
	{
		
		/// <summary>
		/// Представляет уникальный идентификатор (GUID) справочника "Номенклатура ERP"
		/// </summary>
		public static readonly System.Guid ReferenceId = new Guid("93c1524e-1e80-4532-9a94-3d2ec65320c1");
		
		/// <summary>
		/// Инициализирует новый экземпляр NomenclatureERPReference для работы с объектами справочника "Номенклатура ERP"
		/// </summary>
		public NomenclatureMDMReference(TFlex.DOCs.Model.ServerConnection connection) : 
				base(connection, NomenclatureMDMReference.ReferenceId)
		{
			loadSupportReference();
		}
		
		private NomenclatureMDMReference(ParameterGroup masterGroup) : 
				base(masterGroup)
		{
			loadSupportReference();
		}
		
		/// <summary>
		/// Возвращает типы объектов справочника "Номенклатура ERP"
		/// </summary>
		public new NomenclatureMDMTypes Classes
		{
			get
			{
				return ((NomenclatureMDMTypes)(base.Classes));
			}
		}
		
		protected override NomenclatureMDMReferenceObject CreateReferenceObjectForClass(ClassObject classObject)
		{
			NomenclatureMDMType type = classObject as NomenclatureMDMType;
			if ((type == null))
			{
				return null;
			}
			if (type.IsNomenclatureERP)
			{
				return new NomenclatureERPReferenceObject(this);
			}
			if (type.IsNomenclatureITRP)
			{
				return new NomenclatureITRPReferenceObject(this);
			}
			return new NomenclatureMDMReferenceObject(this);
		}
		
		public partial class Factory : SpecialReferenceFactory<NomenclatureMDMReference, NomenclatureMDMTypes>
		{
			
			internal Factory()
			{
			}
			
			public override NomenclatureMDMReference CreateReference(ParameterGroup masterGroup)
			{
				return new NomenclatureMDMReference(masterGroup);
			}
			
			public override NomenclatureMDMTypes CreateClassTree(ParameterGroup masterGroup)
			{
				return new NomenclatureMDMTypes(masterGroup);
			}
		}
	}
}
