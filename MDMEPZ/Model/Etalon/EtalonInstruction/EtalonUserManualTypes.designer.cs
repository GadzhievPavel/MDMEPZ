//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TFlex.DOCs.References.EtalonUserManual
{
	using System;
	using TFlex.DOCs.Model.References;
	using TFlex.DOCs.Model.Structure;
	using TFlex.DOCs.Model.Classes;
	
	
	/// <summary>
	/// Представляет типы объектов справочника "Эталоны руководства по эксплуатации"
	/// </summary>
	public partial class EtalonUserManualTypes
	{
		
		internal EtalonUserManualTypes(ParameterGroup group) : 
				base(group)
		{
		}
		
		/// <summary>
		/// Возвращает описание типа объектов "Эталоны руководства по эксплуатации"
		/// </summary>
		public EtalonUserManualType EtalonUserManual
		{
			get
			{
				return Find(Keys.EtalonUserManual);
			}
		}
		
		protected override EtalonUserManualType CreateClassObject(Guid classGuid)
		{
			return new EtalonUserManualType(this);
		}
		
		/// <summary>
		/// Уникальные идентификаторы (GUID) типов объектов справочника "Эталоны руководства по эксплуатации"
		/// </summary>
		public class Keys
		{
			
			/// <summary>
			/// Представляет уникальный идентификатор (GUID) типа "Эталоны руководства по эксплуатации"
			/// </summary>
		   public static readonly Guid EtalonUserManual = new Guid("b20a510b-a488-4f3d-b672-f6eae7b65e80");

		}
	}
}