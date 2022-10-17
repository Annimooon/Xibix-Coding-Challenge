using System;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Viewpoints.Classes;
using Viewpoints.Services;

public class Program
{
    static void Main(string[] args)
    {
        string path = args[0];
        int numberOfViewPoints = int.Parse(args[1]);

        var landscape = JsonService.JsonReader(path);
        var elementsWithHeight = ViewPointCalculator.GetElementsWithHeight(landscape);
        ViewPointCalculator.FindViewPoints(elementsWithHeight, numberOfViewPoints);
    }
}