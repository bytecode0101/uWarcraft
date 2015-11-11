using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uwarcraft.Game
{
    class FinderBot
    {
        public List<Point> Path;
        public FinderBot(Point StartPos, Point Position)
        {
            Path = new List<Point>();
            Path.Add(StartPos);
            Path.Add(Position);
        }
        public FinderBot(List<Point> Path, Point Position) 
        {
            this.Path = new List<Point>();
            this.Path.AddRange(Path);
            this.Path.Add(Position);
        }
        public bool TargetFound(Point TargetPoint)
        {
            return Path[Path.Count - 1] == TargetPoint;
        }
        public string GetPathString()
        {
            return string.Join(" ; ", Path);
        }
        public override string ToString()
        {
            return GetPathString();
        }
    }
}
