using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viewpoints.Classes;
using Newtonsoft.Json;
using System.Reflection.Metadata.Ecma335;
using Newtonsoft.Json.Linq;
using System.Runtime.CompilerServices;

namespace Viewpoints.Services
{
    internal class JsonService
    {
        public static Root JsonReader(String path)
        {
            var root = new Root();

            using (StreamReader streamReader = new StreamReader(path))
            {
                var jReader = new JsonTextReader(streamReader);
                var jObject = JObject.Load(jReader);

                var jNodes = jObject.GetValue("nodes");
                foreach (var jNode in jNodes)
                {
                    root.nodes.Add(jNode.ToObject<Node>());
                }

                var jElements = jObject.GetValue("elements");
                foreach (var jElement in jElements)
                {
                    root.elements.Add(jElement.ToObject<Element>());
                }

                var jValues = jObject.GetValue("values");
                foreach (var jValue in jValues)
                {
                    root.values.Add(jValue.ToObject<Value>());
                }
                return root;
            }
        }
    }
}
