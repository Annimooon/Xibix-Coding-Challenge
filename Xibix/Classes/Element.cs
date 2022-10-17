using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viewpoints.Classes
{
    public class Element
    {
        public int id { get; set; }
        public List<int> nodes { get; set; }

        public bool alreadyChecked { get; set; }
    }
}
