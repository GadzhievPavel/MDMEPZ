//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TFlex.DOCs.References.VariantsMaterials
{
	using System;
	using TFlex.DOCs.Model.References;
	using TFlex.DOCs.Model.Structure;
	using TFlex.DOCs.Model.Classes;
	using TFlex.DOCs.Model;
	
	
	/// <summary>
	/// Представляет описание справочника "Варианты материалов"
	/// </summary>
	public partial class VariantsMaterialsReference
	{
		
		/// <summary>
		/// Представляет уникальный идентификатор (GUID) справочника "Варианты материалов"
		/// </summary>
		public static readonly System.Guid ReferenceId = new Guid("5239e8ff-beb1-4023-afaa-b4cae8568d6f");
		
		/// <summary>
		/// Инициализирует новый экземпляр VariantsMaterialsReference для работы с объектами справочника "Варианты материалов"
		/// </summary>
		public VariantsMaterialsReference(TFlex.DOCs.Model.ServerConnection connection) : 
				base(connection, VariantsMaterialsReference.ReferenceId)
		{
		}
		
		private VariantsMaterialsReference(ParameterGroup masterGroup) : 
				base(masterGroup)
		{
		}
		
		/// <summary>
		/// Возвращает типы объектов справочника "Варианты материалов"
		/// </summary>
		public new VariantsMaterialsTypes Classes
		{
			get
			{
				return ((VariantsMaterialsTypes)(base.Classes));
			}
		}
		
		protected override VariantsMaterialsReferenceObject CreateReferenceObjectForClass(ClassObject classObject)
		{
			VariantsMaterialsType type = classObject as VariantsMaterialsType;
			if ((type == null))
			{
				return null;
			}
			if (type.IsVariantsMaterialsReferenceObject)
			{
				return new VariantsMaterialsReferenceObject(this);
			}
			return new VariantsMaterialsReferenceObject(this);
		}
		
		public partial class Factory : SpecialReferenceFactory<VariantsMaterialsReference, VariantsMaterialsTypes>
		{
			
			internal Factory()
			{
			}
			
			public override VariantsMaterialsReference CreateReference(ParameterGroup masterGroup)
			{
				return new VariantsMaterialsReference(masterGroup);
			}
			
			public override VariantsMaterialsTypes CreateClassTree(ParameterGroup masterGroup)
			{
				return new VariantsMaterialsTypes(masterGroup);
			}
		}
	}
}