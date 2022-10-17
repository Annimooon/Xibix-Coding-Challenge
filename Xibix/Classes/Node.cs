using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Viewpoints.Classes
{
    public class Node
    {
        public int id { get; set; }
        public double x { get; set; }
        public double y { get; set; }
    }
}
