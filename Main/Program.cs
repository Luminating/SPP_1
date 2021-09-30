using System;
using System.Threading;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

using Main.SerSruct;

namespace SPP_1
{
    class Program
    {
        static Tracer tracer = new Tracer();
        static void Main(string[] args)
        {
            sum(3, 5);
            dif(545, 389);
            Thread thread = new Thread(func1);
            thread.Start();
            dif(3, 5);
            mult(1234, 5678);
            Thread.Sleep(100);

            List<ThreadInfo> serList = CreateSerializationList(tracer);
            XMLSerializer<List<ThreadInfo>> serializer = new XMLSerializer<List<ThreadInfo>>();
            Writer writer = new Writer();
            writer.write(serializer.Serialize(serList));
        }

        static List<ThreadInfo> CreateSerializationList(Tracer tracer) {
            SortedDictionary<int, List<TracerResult>> dict = new SortedDictionary<int, List<TracerResult>>();
            TracerResult result;

            while ((result = tracer.GetTracerResult()) != null)
            {
                if (!dict.ContainsKey(result.threadId))
                {
                    dict.Add(result.threadId, new List<TracerResult>());
                }
                dict[result.threadId].Add(result);
            }

            List<ThreadInfo> serializationList = new List<ThreadInfo>();

            foreach (KeyValuePair<int, List<TracerResult>> kvp in dict)
            {
                ThreadInfo currThread = new ThreadInfo();
                double threadTime = 0;
                currThread.threadId = kvp.Key;
                serializationList.Add(currThread);
                Stack<MethodInfo> methodsStack = new Stack<MethodInfo>();

                foreach (TracerResult currentRes in kvp.Value)
                {
                    if (!currentRes.start.Equals(DateTime.MinValue)) // start method
                    {
                        MethodInfo currMethod = new MethodInfo();
                        currMethod.name = currentRes.methodName;
                        currMethod.className = currentRes.className;
                        currMethod.time = (currentRes.start - DateTime.MinValue).TotalMilliseconds;
                        

                        if (methodsStack.Count == 0)
                        {
                            currThread.methods.Add(currMethod);
                        }
                        else
                        {
                            methodsStack.Peek().methods.Add(currMethod);
                        }
                        methodsStack.Push(currMethod);
                    }
                    else // stop method
                    {
                        double startTime = methodsStack.Peek().time;
                        methodsStack.Pop().time = (currentRes.stop - DateTime.MinValue).TotalMilliseconds - startTime;
                        threadTime += (currentRes.stop - DateTime.MinValue).TotalMilliseconds - startTime;
                    }
                }
                currThread.time = threadTime;
            }
            return serializationList;
        }
        static void func2()
        {
            tracer.StartTrace();
            Console.WriteLine("func2");
            tracer.StopTrace();
        }
        static void func1()
        {
            tracer.StartTrace();
            func2();
            Console.WriteLine("func1");
            tracer.StopTrace();
        }

        static int mult(int x, int y)
        {
            tracer.StartTrace();
            int result = x * y;
            tracer.StopTrace();
            return result;
        }
        static int sum(int x, int y)
        {
            tracer.StartTrace();
            int result = x + y;
            mult(5, 3);
            dif(345, 344);
            tracer.StopTrace();
            return result;
        }

        static int dif(int x, int y)
        {
            tracer.StartTrace();
            int result = x - y;
            tracer.StopTrace();
            return result;
        }
    }
}
