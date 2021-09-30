using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace SPP_1
{
    public class XMLSerializer<T> : ISerializer<T>
    {
        public String Serialize(T obj)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(T));
            StringWriter sw = new StringWriter();
            formatter.Serialize(sw, obj);
            return sw.ToString();
        }
    }
}
