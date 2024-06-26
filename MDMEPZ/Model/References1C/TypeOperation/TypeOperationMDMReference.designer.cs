//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TFlex.DOCs.References.TypeOperationMDM
{
	using System;
	using TFlex.DOCs.Model.References;
	using TFlex.DOCs.Model.Structure;
	using TFlex.DOCs.Model.Classes;
	using TFlex.DOCs.Model;
	
	
	/// <summary>
	/// Представляет описание справочника "Вид техоперации"
	/// </summary>
	public partial class TypeOperationMDMReference
	{
		
		/// <summary>
		/// Представляет уникальный идентификатор (GUID) справочника "Вид техоперации"
		/// </summary>
		public static readonly System.Guid ReferenceId = new Guid("59bb66d0-4634-46bb-9c37-5e23231ef346");
		
		/// <summary>
		/// Инициализирует новый экземпляр TypeOperationMDMReference для работы с объектами справочника "Вид техоперации"
		/// </summary>
		public TypeOperationMDMReference(TFlex.DOCs.Model.ServerConnection connection) : 
				base(connection, TypeOperationMDMReference.ReferenceId)
		{
		}
		
		private TypeOperationMDMReference(ParameterGroup masterGroup) : 
				base(masterGroup)
		{
		}
		
		/// <summary>
		/// Возвращает типы объектов справочника "Вид техоперации"
		/// </summary>
		public new TypeOperationMDMTypes Classes
		{
			get
			{
				return ((TypeOperationMDMTypes)(base.Classes));
			}
		}
		
		protected override TypeOperationMDMReferenceObject CreateReferenceObjectForClass(ClassObject classObject)
		{
			TypeOperationMDMType type = classObject as TypeOperationMDMType;
			if ((type == null))
			{
				return null;
			}
			if (type.IsMainTypeOperation)
			{
				return new TypeOperationMDMReferenceObject(this);
			}
			return new TypeOperationMDMReferenceObject(this);
		}
		
		public partial class Factory : SpecialReferenceFactory<TypeOperationMDMReference, TypeOperationMDMTypes>
		{
			
			internal Factory()
			{
			}
			
			public override TypeOperationMDMReference CreateReference(ParameterGroup masterGroup)
			{
				return new TypeOperationMDMReference(masterGroup);
			}
			
			public override TypeOperationMDMTypes CreateClassTree(ParameterGroup masterGroup)
			{
				return new TypeOperationMDMTypes(masterGroup);
			}
		}
	}
}
