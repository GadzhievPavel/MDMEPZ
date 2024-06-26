//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TFlex.DOCs.References.Profession
{
	using System;
	using TFlex.DOCs.Model.References;
	using TFlex.DOCs.Model.Structure;
	using TFlex.DOCs.Model.Classes;
	using TFlex.DOCs.Model;
	
	
	/// <summary>
	/// Представляет описание справочника "Профессия"
	/// </summary>
	public partial class ProfessionReference
	{
		
		/// <summary>
		/// Представляет уникальный идентификатор (GUID) справочника "Профессия"
		/// </summary>
		public static readonly System.Guid ReferenceId = new Guid("6c55d27d-e87b-4d64-b9b5-4f7bce9456c6");
		
		/// <summary>
		/// Инициализирует новый экземпляр ProfessionReference для работы с объектами справочника "Профессия"
		/// </summary>
		public ProfessionReference(TFlex.DOCs.Model.ServerConnection connection) : 
				base(connection, ProfessionReference.ReferenceId)
		{
		}
		
		private ProfessionReference(ParameterGroup masterGroup) : 
				base(masterGroup)
		{
		}
		
		/// <summary>
		/// Возвращает типы объектов справочника "Профессия"
		/// </summary>
		public new ProfessionTypes Classes
		{
			get
			{
				return ((ProfessionTypes)(base.Classes));
			}
		}
		
		protected override ProfessionReferenceObject CreateReferenceObjectForClass(ClassObject classObject)
		{
			ProfessionType type = classObject as ProfessionType;
			if ((type == null))
			{
				return null;
			}
			if (type.IsMainProfessionType)
			{
				return new ProfessionReferenceObject(this);
			}
			return new ProfessionReferenceObject(this);
		}
		
		public partial class Factory : SpecialReferenceFactory<ProfessionReference, ProfessionTypes>
		{
			
			internal Factory()
			{
			}
			
			public override ProfessionReference CreateReference(ParameterGroup masterGroup)
			{
				return new ProfessionReference(masterGroup);
			}
			
			public override ProfessionTypes CreateClassTree(ParameterGroup masterGroup)
			{
				return new ProfessionTypes(masterGroup);
			}
		}
	}
}
