using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SPP_1
{
    class JSONSerializer<T> : ISerializer<T>
    {
        public string Serialize(T obj)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            return JsonSerializer.Serialize(obj, options);
        }
    }
}
