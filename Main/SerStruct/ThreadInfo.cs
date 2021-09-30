using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.SerSruct
{
    [Serializable]
    public class ThreadInfo 
    {
        public int threadId { get; set; } 
        public double time { get; set; }
        public List<MethodInfo> methods { get; set; }

        public ThreadInfo()
        {
            this.methods = new List<MethodInfo>();
        }
    }
}
