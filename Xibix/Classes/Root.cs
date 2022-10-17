using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Viewpoints.Classes
{
    public class Root
    {
        public Root()
        {
            nodes = new List<Node>();
            elements = new List<Element>();
            values = new List<Value>();
        }
        public List<Node> nodes { get; set; }
        public List<Element> elements { get; set; }
        public List<Value> values { get; set; }
        
    }
}
