//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TFlex.DOCs.References.ReplacementERP
{
	using System;
	using TFlex.DOCs.Model.References;
	using TFlex.DOCs.Model.Structure;
	using TFlex.DOCs.Model.Classes;
	using TFlex.DOCs.Model;
	
	
	/// <summary>
	/// Представляет описание справочника "Замены ERP"
	/// </summary>
	public partial class ReplacementERPReference
	{
		
		/// <summary>
		/// Представляет уникальный идентификатор (GUID) справочника "Замены ERP"
		/// </summary>
		public static readonly System.Guid ReferenceId = new Guid("0e37cf06-e7ee-435f-8f68-71d7c0eccba7");
		
		/// <summary>
		/// Инициализирует новый экземпляр ReplacementERPReference для работы с объектами справочника "Замены ERP"
		/// </summary>
		public ReplacementERPReference(TFlex.DOCs.Model.ServerConnection connection) : 
				base(connection, ReplacementERPReference.ReferenceId)
		{
			loadSupportReference();
		}
		
		private ReplacementERPReference(ParameterGroup masterGroup) : 
				base(masterGroup)
		{
			loadSupportReference();
		}
		
		/// <summary>
		/// Возвращает типы объектов справочника "Замены ERP"
		/// </summary>
		public new ReplacementERPTypes Classes
		{
			get
			{
				return ((ReplacementERPTypes)(base.Classes));
			}
		}
		
		protected override ReplacementERPReferenceObject CreateReferenceObjectForClass(ClassObject classObject)
		{
			ReplacementERPType type = classObject as ReplacementERPType;
			if ((type == null))
			{
				return null;
			}
			if (type.IsReplacementERPReferenceObject)
			{
				return new ReplacementERPReferenceObject(this);
			}
			return new ReplacementERPReferenceObject(this);
		}
		
		public partial class Factory : SpecialReferenceFactory<ReplacementERPReference, ReplacementERPTypes>
		{
			
			internal Factory()
			{
			}
			
			public override ReplacementERPReference CreateReference(ParameterGroup masterGroup)
			{
				return new ReplacementERPReference(masterGroup);
			}
			
			public override ReplacementERPTypes CreateClassTree(ParameterGroup masterGroup)
			{
				return new ReplacementERPTypes(masterGroup);
			}
		}
	}
}
