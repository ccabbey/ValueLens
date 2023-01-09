using System.Collections.Generic;
using System.Linq;

namespace ValueLens.NewConcept.Chart
{
    internal class SerieBase
    {
        public List<Point> Points { get; set; }

        public string Name { get; set; }

        public SerieBase(string name)
        {
            Points = new List<Point>();

            Name = name;

        }

        public void AddPoint(Point p)
        {
            if (Points != null)
                Points.Add(p);
        }

        public void AddPoint(IList<Point> plist)
        {
            if (plist != null && plist.Count > 0)
            {
                foreach (Point p in plist)
                    AddPoint(p);
            }
        }

        public void RemovePoint(Point p)
        {
            foreach (Point point in Points)
            {
                if (point == p)
                    Points.Remove(p);
            }
        }

        public void RemovePoint(IList<Point> plist)
        {
            if (plist != null && plist.Count > 0)
            {
                foreach (Point p in plist)
                    RemovePoint(p);
            }
        }

        public double[] GetXValues()
        {
            return Points.Select(p => p.X).ToArray();
        }

        public double[] GetYValues()
        {
            return Points.Select(p => p.Y).ToArray();
        }


    }
}
