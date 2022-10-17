using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viewpoints.Classes;

namespace Viewpoints.Services
{
    public class ViewPointCalculator
    {
        public static void FindViewPoints(Dictionary<Element, double> elementsWithHeight, int numberOfViewPoints)
        {
            int counter = 0;

            foreach (var element in elementsWithHeight)
            {
                if (element.Key.alreadyChecked)
                    continue;

                var nodes = element.Key.nodes;
                var neighbours = GetElementNeighbours(nodes, elementsWithHeight);

                neighbours.Remove(element.Key);

                if (neighbours.Values.Any(n => n >= element.Value))
                {
                    neighbours.Where(n => n.Value <= element.Value).All(n => n.Key.alreadyChecked = true);
                }
                else
                {
                    Console.WriteLine(String.Concat(new object[] { "element_id: ", element.Key.id, ", value: <", element.Value, ">" }));
                    neighbours.All(n => n.Key.alreadyChecked = true);
                    counter++;
                }

                if (counter == numberOfViewPoints)
                    break;
            }
        }

        public static Dictionary<Element, double> GetElementNeighbours(List<int> nodes, Dictionary<Element, double> elementsWithHeight)
        {
            var n1 = nodes[0];
            var n2 = nodes[1];
            var n3 = nodes[2];

            return elementsWithHeight.Where(e => e.Key.nodes.Contains(n1)
                                                || e.Key.nodes.Contains(n2)
                                                || e.Key.nodes.Contains(n3))
                                     .ToDictionary(x => x.Key, x => x.Value);
        }

        public static Dictionary<Element, double> GetElementsWithHeight(Root landscape)
        {
            var elementsWithHeight = new Dictionary<Element, double>();

            foreach (var element in landscape.elements)
            {
                var height = landscape.values.Where(v => v.element_id == element.id)
                                             .FirstOrDefault();
                if (height != null)
                    elementsWithHeight.Add(element, height.value);
            }

            return ElementsOrderByHeight(elementsWithHeight);
        }

        public static Dictionary<Element, double> ElementsOrderByHeight(Dictionary<Element, double> elementWithHeight)
        {
            return elementWithHeight.OrderByDescending(e => e.Value).ToDictionary(e => e.Key, e => e.Value);
        }
    }
}
