using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SPP_1
{
    class Writer : IWriter
    {
        public void write(String str)
        {
            Console.WriteLine(str);
        }

        public void write(string str, string fileName)
        {
            File.WriteAllText(fileName, str);
        }
    }
}
