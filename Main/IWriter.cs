using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPP_1
{
    interface IWriter
    {
        public void write(String str);
        public void write(String str, String fileName);
    }
}
