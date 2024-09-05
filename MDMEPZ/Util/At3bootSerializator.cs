using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDMEPZ.Util
{
    /// <summary>
    /// Класс с методами для сериализации данных
    /// </summary>
    public class At3bootSerializator
    {
        /// <summary>
        /// Сохраняет сериализованный объект в файл
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dto">объект для сериализации</param>
        /// <param name="path">путь для сохранения данных</param>
        /// <returns></returns>
        public string saveFile<T>(T dto, string path)
        {
            var str = JsonConvert.SerializeObject(dto, Formatting.Indented);

            UTF8Encoding encoding = new UTF8Encoding();
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                var bytes = encoding.GetBytes(str);
                fs.Write(bytes, 0, bytes.Length);
            }

            return str;
        }
    }
}
