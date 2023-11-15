using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDMEPZ.Util
{
    public class LogTFlex
    {
        private String path;

        public LogTFlex(string path)
        {
            this.path = path;
        }

        public void error(string info)
        {
            using(FileStream fstream = new FileStream(path, FileMode.OpenOrCreate))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("ERROR");
                sb.Append("\n");
                sb.Append(info);
                byte[] buffer = Encoding.Default.GetBytes(sb.ToString());
                fstream.Write(buffer, 0, buffer.Length);
            }
        }
    }
}
