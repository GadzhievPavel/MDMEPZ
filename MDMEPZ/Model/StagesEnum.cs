using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDMEPZ.Model
{
    public class StagesMDM
    {
        /// <summary>
        /// Стадия "Фильтрация"
        /// </summary>
        public static readonly Guid filtering = new Guid("5c40376d-e2bf-4435-a8ec-277ed4f83424");
        /// <summary>
        /// Стадия "Эталон"
        /// </summary>
        public static readonly Guid etalon = new Guid("f26404ef-7ff1-41d4-a841-dfb4bab1aac9");
        /// <summary>
        /// Стадия "Эквивалент"
        /// </summary>
        public static readonly Guid equivalent = new Guid("5f43271d-8ef2-4430-bb66-12511f162166");
        /// <summary>
        /// Стадия "Обработана"
        /// </summary>
        public static readonly Guid completed = new Guid("67eb4f1f-ea82-4c10-bfc9-924746a8908a");
        /// <summary>
        /// Стадия "Создан"
        /// </summary>
        public static readonly Guid create = new Guid("0a3baea2-2b43-448b-8351-61e1ca334abe");
        /// <summary>
        /// Стадия "Заполнен"
        /// </summary>
        public static readonly Guid fill = new Guid("4be2aa55-c477-4e37-87b0-c1ef72531e29");
    }
}
