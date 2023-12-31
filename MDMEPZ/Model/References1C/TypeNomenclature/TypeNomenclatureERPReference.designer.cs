//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TFlex.DOCs.References.TypeNomenclatureERP
{
	using System;
	using TFlex.DOCs.Model.References;
	using TFlex.DOCs.Model.Structure;
	using TFlex.DOCs.Model.Classes;
	using TFlex.DOCs.Model;
	
	
	/// <summary>
	/// Представляет описание справочника "Типы номенклатуры"
	/// </summary>
	public partial class TypeNomenclatureERPReference
	{
		
		/// <summary>
		/// Представляет уникальный идентификатор (GUID) справочника "Типы номенклатуры"
		/// </summary>
		public static readonly System.Guid ReferenceId = new Guid("41fd6b00-7bc9-48d7-90c9-dec4d141347a");
		
		/// <summary>
		/// Инициализирует новый экземпляр TypeNomenclatureERPReference для работы с объектами справочника "Типы номенклатуры"
		/// </summary>
		public TypeNomenclatureERPReference(TFlex.DOCs.Model.ServerConnection connection) : 
				base(connection, TypeNomenclatureERPReference.ReferenceId)
		{
		}
		
		private TypeNomenclatureERPReference(ParameterGroup masterGroup) : 
				base(masterGroup)
		{
		}
		
		/// <summary>
		/// Возвращает типы объектов справочника "Типы номенклатуры"
		/// </summary>
		public new TypeNomenclatureERPTypes Classes
		{
			get
			{
				return ((TypeNomenclatureERPTypes)(base.Classes));
			}
		}
		
		protected override TypeNomenclatureERPReferenceObject CreateReferenceObjectForClass(ClassObject classObject)
		{
			TypeNomenclatureERPType type = classObject as TypeNomenclatureERPType;
			if ((type == null))
			{
				return null;
			}
			if (type.IsTypeNomenclatureERPReferenceObject)
			{
				return new TypeNomenclatureERPReferenceObject(this);
			}
			return new TypeNomenclatureERPReferenceObject(this);
		}
		
		public partial class Factory : SpecialReferenceFactory<TypeNomenclatureERPReference, TypeNomenclatureERPTypes>
		{
			
			internal Factory()
			{
			}
			
			public override TypeNomenclatureERPReference CreateReference(ParameterGroup masterGroup)
			{
				return new TypeNomenclatureERPReference(masterGroup);
			}
			
			public override TypeNomenclatureERPTypes CreateClassTree(ParameterGroup masterGroup)
			{
				return new TypeNomenclatureERPTypes(masterGroup);
			}
		}
	}
}
