//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TFlex.DOCs.References.FilterDetaliAssembling
{
	using System;
	using TFlex.DOCs.Model.References;
	using TFlex.DOCs.Model.Structure;
	using TFlex.DOCs.Model.Classes;
	using TFlex.DOCs.Model;
	
	
	/// <summary>
	/// Представляет описание справочника "Детали и сборки НСИ"
	/// </summary>
	public partial class FilterDetaliAssemblingReference
	{
		
		/// <summary>
		/// Представляет уникальный идентификатор (GUID) справочника "Детали и сборки НСИ"
		/// </summary>
		public static readonly System.Guid ReferenceId = new Guid("8f1fb6e7-1f6e-4778-9414-bb15838efe5b");
		
		/// <summary>
		/// Инициализирует новый экземпляр FilterDetaliAssemblingReference для работы с объектами справочника "Детали и сборки НСИ"
		/// </summary>
		public FilterDetaliAssemblingReference(TFlex.DOCs.Model.ServerConnection connection) : 
				base(connection, FilterDetaliAssemblingReference.ReferenceId)
		{
		}
		
		private FilterDetaliAssemblingReference(ParameterGroup masterGroup) : 
				base(masterGroup)
		{
		}
		
		/// <summary>
		/// Возвращает типы объектов справочника "Детали и сборки НСИ"
		/// </summary>
		public new FilterDetaliAssemblingTypes Classes
		{
			get
			{
				return ((FilterDetaliAssemblingTypes)(base.Classes));
			}
		}
		
		protected override FilterDetaliAssemblingReferenceObject CreateReferenceObjectForClass(ClassObject classObject)
		{
			FilterDetaliAssemblingType type = classObject as FilterDetaliAssemblingType;
			if ((type == null))
			{
				return null;
			}
			if (type.IsFilterDetaliAssemblingReferenceObject)
			{
				return new FilterDetaliAssemblingReferenceObject(this);
			}
			return new FilterDetaliAssemblingReferenceObject(this);
		}
		
		public partial class Factory : SpecialReferenceFactory<FilterDetaliAssemblingReference, FilterDetaliAssemblingTypes>
		{
			
			internal Factory()
			{
			}
			
			public override FilterDetaliAssemblingReference CreateReference(ParameterGroup masterGroup)
			{
				return new FilterDetaliAssemblingReference(masterGroup);
			}
			
			public override FilterDetaliAssemblingTypes CreateClassTree(ParameterGroup masterGroup)
			{
				return new FilterDetaliAssemblingTypes(masterGroup);
			}
		}
	}
}
