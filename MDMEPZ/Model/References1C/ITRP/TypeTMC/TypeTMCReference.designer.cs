//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TFlex.DOCs.References.TypeTMC
{
	using System;
	using TFlex.DOCs.Model.References;
	using TFlex.DOCs.Model.Structure;
	using TFlex.DOCs.Model.Classes;
	using TFlex.DOCs.Model;
	
	
	/// <summary>
	/// Представляет описание справочника "Вид учета ТМЦ"
	/// </summary>
	public partial class TypeTMCReference
	{
		
		/// <summary>
		/// Представляет уникальный идентификатор (GUID) справочника "Вид учета ТМЦ"
		/// </summary>
		public static readonly System.Guid ReferenceId = new Guid("04d65c5d-200c-4b04-823c-5b2132450141");
		
		/// <summary>
		/// Инициализирует новый экземпляр TypeTMCReference для работы с объектами справочника "Вид учета ТМЦ"
		/// </summary>
		public TypeTMCReference(TFlex.DOCs.Model.ServerConnection connection) : 
				base(connection, TypeTMCReference.ReferenceId)
		{
		}
		
		private TypeTMCReference(ParameterGroup masterGroup) : 
				base(masterGroup)
		{
		}
		
		/// <summary>
		/// Возвращает типы объектов справочника "Вид учета ТМЦ"
		/// </summary>
		public new TypeTMCTypes Classes
		{
			get
			{
				return ((TypeTMCTypes)(base.Classes));
			}
		}
		
		protected override TypeTMCReferenceObject CreateReferenceObjectForClass(ClassObject classObject)
		{
			TypeTMCType type = classObject as TypeTMCType;
			if ((type == null))
			{
				return null;
			}
			if (type.IsTypeTMC)
			{
				return new TypeTMCReferenceObject(this);
			}
			return new TypeTMCReferenceObject(this);
		}
		
		public partial class Factory : SpecialReferenceFactory<TypeTMCReference, TypeTMCTypes>
		{
			
			internal Factory()
			{
			}
			
			public override TypeTMCReference CreateReference(ParameterGroup masterGroup)
			{
				return new TypeTMCReference(masterGroup);
			}
			
			public override TypeTMCTypes CreateClassTree(ParameterGroup masterGroup)
			{
				return new TypeTMCTypes(masterGroup);
			}
		}
	}
}