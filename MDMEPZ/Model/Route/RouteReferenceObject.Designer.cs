//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TFlex.DOCs.References.Route
{
	using System;
	using TFlex.DOCs.Model.References;
	using TFlex.DOCs.Model.Structure;
	using TFlex.DOCs.Model.References.Links;
	using TFlex.DOCs.Model.Classes;
	using TFlex.DOCs.Model.Parameters;
	
	
	/// <summary>
	/// Представляет объект справочника "Маршруты ERP"
	/// </summary>
	public partial class RouteReferenceObject
	{
		
		internal RouteReferenceObject(RouteReference reference) : 
				base(reference)
		{
		}
		
		/// <summary>
		/// Возвращает описание типа объекта
		/// </summary>
		public new RouteType Class
		{
			get
			{
				return ((RouteType)(base.Class));
			}
		}
		
		/// <summary>
		/// Возвращает параметр "Наименование"
		/// </summary>
		public StringParameter Name
		{
			get
			{
				return ((StringParameter)(this[FieldKeys.Name]));
			}
		}
		
		/// <summary>
		/// Возвращает параметр "UID"
		/// </summary>
		public StringParameter UID
		{
			get
			{
				return ((StringParameter)(this[FieldKeys.UID]));
			}
		}

		public StringParameter Kod
		{
			
			get
			{
				if (Class.IsRouteType)
					return ((StringParameter)(this[FieldKeys.Kod]));
				return null;
			}
		}
		public StringParameter Vladelets
		{

			get
			{
				if (Class.IsRouteType)
					return ((StringParameter)(this[FieldKeys.Vladelets]));
				return null;
			}
		}
		public Int32Parameter NomerStroki
		{

			get
			{
				if (Class.IsRoutePointType)
					return ((Int32Parameter)(this[FieldKeys.NomerStroki]));
				return null;
			}
		}

		public StringParameter Ssylka_zakhoda
		{

			get
			{
				if (Class.IsRouteType)
					return ((StringParameter)(this[FieldKeys.Ssylka_zakhoda]));
				return null;
			}
		}

		public StringParameter NaimenovanieKratkoe
		{

			get
			{
				if (Class.IsRouteType)
					return ((StringParameter)(this[FieldKeys.NaimenovanieKratkoe]));
				return null;
			}
		}

		/// <summary>
		/// Возвращает или задаёт связанный объект справочника "МаршрутыMDM" по связи "Цехопереход ТП"
		/// </summary>
		public ReferenceObject DepartamentTransition
		{
			get
			{
				return GetObject(RelationKeys.Visit_Link);
			}
			set
			{
				SetLinkedObject(RelationKeys.Visit_Link, value);
			}
		}

		/// <summary>
		/// Возвращает или задает объект справочника по связи "Маршрут ТП"
		/// </summary>
		public ReferenceObject RoutePdm
		{
			get
			{
				return GetObject(RelationKeys.RoutePdm);
			}
			set
			{
				SetLinkedObject(RelationKeys.RoutePdm, value);
			}
		}
        /// <summary>
        /// Возвращает значение параметра "Актуальность записи"
        /// </summary>
        public bool IsActual
        {
            get
            {
                return ((BooleanParameter)this[FieldKeys.IsActual]).Value;
            }
        }
        /// <summary>
        /// Задать значение актуальности 
        /// </summary>
        /// <param name="flag"></param>
        public void SetActual(bool flag)
        {
            this[FieldKeys.IsActual].Value = flag;
        }

        /// <summary>
        /// Уникальные идентификаторы (GUID) параметров справочника "Маршруты ERP"
        /// </summary>
        public class FieldKeys
		{
			
			/// <summary>
			/// Представляет уникальный идентификатор (GUID) параметра "Наименование"
			/// </summary>
		   public static readonly Guid Name = new Guid("9ab109a1-3e83-4475-afa3-890674bef1a4");

			/// <summary>
			/// Представляет уникальный идентификатор (GUID) параметра "UID"
			/// </summary>
		   public static readonly Guid UID = new Guid("ce6f666b-327b-4d6c-a185-5431695ce64c");

			/// <summary>
			/// Представляет уникальный идентификатор (GUID) параметра "Код"
			/// </summary>
		   public static readonly Guid Kod = new Guid("0a6ea952-fe32-4b52-9f52-856010af842d");

			/// <summary>
			/// Представляет уникальный идентификатор (GUID) параметра "Владелец"
			/// </summary>
		   public static readonly Guid Vladelets = new Guid("6f0ed7e9-c184-4803-bc83-c6793d4bf7d1");

			/// <summary>
			/// Представляет уникальный идентификатор (GUID) параметра "НомерСтроки"
			/// </summary>
		   public static readonly Guid NomerStroki = new Guid("e34612c6-2359-4900-b1c0-53fe8324a560");
			/// <summary>
			/// /// Представляет уникальный идентификатор (GUID) параметра "Ссылка захода"
			/// </summary>
			public static readonly Guid Ssylka_zakhoda = new Guid("d79c2d6e-e42e-4c7c-ab7b-14b1efb99689");
			/// <summary>
			/// /// Представляет уникальный идентификатор (GUID) параметра "НаименованиеКраткое"
			/// </summary>
			public static readonly Guid NaimenovanieKratkoe = new Guid("e40f6e0c-dd2f-4995-a6f3-af26a013aa0e");
            /// <summary>
            /// /// Представляет уникальный идентификатор (GUID) параметра "Актуальность записи"
            /// </summary>
            public static readonly Guid IsActual = new Guid("95acd848-7321-4b11-9741-99fff64b3c83");

		}
		/// <summary>
		/// Уникальные идентификаторы (GUID) связей и списков объектов справочника "Профессия"
		/// </summary>
		public class RelationKeys
		{

			/// <summary>
			/// Представляет уникальный идентификатор (GUID) связи "Цехопереход ТП"
			/// </summary>
			public static readonly Guid Visit_Link = new Guid("fa0e7fe8-e827-4ed6-b6ab-8cd02fc691f5");

            /// <summary>
            /// Представляет уникальный идентификатор (GUID) связи "Маршрут ТП"
            /// </summary>
            public static readonly Guid RoutePdm = new Guid("e513105a-438c-465d-97a4-b9fc4db54b38");

		}
	}
}
