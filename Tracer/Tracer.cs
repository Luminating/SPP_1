using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Reflection;
using System.Threading;

namespace SPP_1
{
    public class Tracer : ITracer
    {
        private ConcurrentQueue<TracerResult> resultQ = new ConcurrentQueue<TracerResult>();
        public void StartTrace()
        {
            TracerResult tracerResult = new TracerResult();
            StackTrace stackTrace = new StackTrace();
            MethodBase methodBase = stackTrace.GetFrame(1).GetMethod();
            tracerResult.methodName = methodBase.Name;
            tracerResult.className = methodBase.ReflectedType.Name;
            tracerResult.threadId = Thread.CurrentThread.ManagedThreadId;
            tracerResult.start = DateTime.Now;
            tracerResult.stop = DateTime.MinValue;
            resultQ.Enqueue(tracerResult);
        }

        public void StopTrace()
        {
            TracerResult tracerResult = new TracerResult();
            StackTrace stackTrace = new StackTrace();
            MethodBase methodBase = stackTrace.GetFrame(1).GetMethod();
            tracerResult.methodName = methodBase.Name;
            tracerResult.className = methodBase.ReflectedType.Name;
            tracerResult.threadId = Thread.CurrentThread.ManagedThreadId;
            tracerResult.start = DateTime.MinValue;
            tracerResult.stop = DateTime.Now;
            resultQ.Enqueue(tracerResult);
        }
        public TracerResult GetTracerResult()
        {
            return resultQ.TryDequeue(out TracerResult result) ? result : null;
        }

        static void Main(string[] args)
        {

        }
    }
}
