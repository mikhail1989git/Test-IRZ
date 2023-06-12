using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.model.Common
{
    internal class DecompressGZIP
    {
        public static string Decompress(Stream stream)
        {
            StringBuilder sb = new StringBuilder();

            using (GZipStream gz = new GZipStream(stream, CompressionMode.Decompress))
            {
                byte[] buf = new byte[1024];

                int count = 0;
                do
                {
                    count = gz.Read(buf, 0, buf.Length);
                    sb.Append(Encoding.UTF8.GetString(buf, 0, count));
                } while (count > 0);
            }

            return sb.ToString();
        }
    }
}
