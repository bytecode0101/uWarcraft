using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uwarcraft.Game
{
    public class PathFinder
    {
        List<FinderBot> Bots;
        List<Point> Visited;
        List<FinderBot> toKill;
        int[] x = new int[] { -1, 0, 1, 1, 1, 0, -1, -1 };
        bool FirstRun = true;
        int[] y = new int[] { -1, -1, -1, 0, 1, 1, 1, 0 };
        public PathFinder() { Bots = new List<FinderBot>(); }

        public List<Point> FindPath(Map M, Point StartPos, Point Target)
        {
            Console.WriteLine("Searching for a path from "+StartPos.ToString()+" to "+Target.ToString());
            
            Bots = new List<FinderBot>(); //we already had Bots initialized in the constructor - Andrei P.

            toKill = new List<FinderBot>();
            
            Visited = new List<Point>();

            List<Point> Path = new List<Point>();

            while (Path.Count==0)
            {
                if(!FirstRun&&Bots.Count==0)
                {
                    Console.WriteLine("They all died :(");
                    break;
                }

                Path = PathFound(Target);

                if (Bots.Count == 0 && FirstRun)
                {
                    Spread(M, StartPos);
                    FirstRun = false;
                }
                else
                {
                    int L = Bots.Count;
                    for (int i = 0; i < L; i++)
                    {
                        Spread(M, Bots[i]);
                        toKill.Add(Bots[i]);
                    }

                    toKill.ForEach(B => Bots.Remove(B));
                }


            }
            
            return Path;
        }

        void Spread(Map M, Point StartPos)
        {
            Visited.Add(StartPos);
            for (int i = 0; i < 8; i++)
            {
                Point ToAdd = new Point(StartPos.x + x[i], StartPos.y + y[i]);

                if (M.isValidForUnit(ToAdd) && Visited.FindAll(P => P == ToAdd).Count == 0)
                {
                    Bots.Add(new FinderBot(StartPos, ToAdd));
                    Visited.Add(ToAdd);
                }
            }
        }
        
        void Spread(Map M, FinderBot Bot)
        {
            for (int i = 0; i < 8; i++)
            {
                Point ToAdd = new Point(Bot.Path[Bot.Path.Count - 1].x + x[i], Bot.Path[Bot.Path.Count - 1].y + y[i]);

                if (M.isValidForUnit(ToAdd) && Visited.FindAll(P => P == ToAdd).Count == 0)
                {
                    Bots.Add(new FinderBot(Bot.Path, ToAdd));
                    Visited.Add(ToAdd);
                }
            }
        }

        List<Point> PathFound(Point Target)
        {
            foreach (FinderBot Bot in Bots)
            {
                if (Bot.TargetFound(Target))
                {
                    Console.WriteLine("Path Found. Visited = " + Visited.Count);
                    return Bot.Path;
                }
            }
            
            return new List<Point>();
        }


    }
}
