//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TFlex.DOCs.References.MDM.Rank
{
	using System;
	using TFlex.DOCs.Model.References;
	using TFlex.DOCs.Model.Structure;
	using TFlex.DOCs.Model.Classes;
	using TFlex.DOCs.Model;
	
	
	/// <summary>
	/// Представляет описание справочника "Разряд работ"
	/// </summary>
	public partial class RankMDMReference
	{
		
		/// <summary>
		/// Представляет уникальный идентификатор (GUID) справочника "Разряд работ"
		/// </summary>
		public static readonly System.Guid ReferenceId = new Guid("862578ee-a916-4db6-8753-13dc61520ede");
		
		/// <summary>
		/// Инициализирует новый экземпляр RankReference для работы с объектами справочника "Разряд работ"
		/// </summary>
		public RankMDMReference(TFlex.DOCs.Model.ServerConnection connection) : 
				base(connection, RankMDMReference.ReferenceId)
		{
		}
		
		private RankMDMReference(ParameterGroup masterGroup) : 
				base(masterGroup)
		{
		}
		
		/// <summary>
		/// Возвращает типы объектов справочника "Разряд работ"
		/// </summary>
		public new RankMDMTypes Classes
		{
			get
			{
				return ((RankMDMTypes)(base.Classes));
			}
		}
		
		protected override RankMDMReferenceObject CreateReferenceObjectForClass(ClassObject classObject)
		{
			RankMDMType type = classObject as RankMDMType;
			if ((type == null))
			{
				return null;
			}
			if (type.IsMainRankRype)
			{
				return new RankMDMReferenceObject(this);
			}
			return new RankMDMReferenceObject(this);
		}
		
		public partial class Factory : SpecialReferenceFactory<RankMDMReference, RankMDMTypes>
		{
			
			internal Factory()
			{
			}
			
			public override RankMDMReference CreateReference(ParameterGroup masterGroup)
			{
				return new RankMDMReference(masterGroup);
			}
			
			public override RankMDMTypes CreateClassTree(ParameterGroup masterGroup)
			{
				return new RankMDMTypes(masterGroup);
			}
		}
	}
}
