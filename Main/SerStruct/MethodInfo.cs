using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Main.SerSruct
{
    [Serializable]
    public class MethodInfo
    {
        public String name { get; set; }
        public String className { get; set; }
        public double time { get; set; }
        public List<MethodInfo> methods { get; set; }

        public MethodInfo()
        {
            this.methods = new List<MethodInfo>();
        }
    }
}
