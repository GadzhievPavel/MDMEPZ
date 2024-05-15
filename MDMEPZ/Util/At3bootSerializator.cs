using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDMEPZ.Util
{
    public class At3bootSerializator
    {
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
