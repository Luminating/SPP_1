﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPP_1
{
    interface ITracer
    {
        public void StartTrace();
        public void StopTrace();
        public TracerResult GetTracerResult();
    }
}
