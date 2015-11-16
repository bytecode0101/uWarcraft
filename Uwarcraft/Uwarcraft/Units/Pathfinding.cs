using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uwarcraft.Game;

namespace Uwarcraft.Units
{
    public class Pathfinding
    {
        public class Node
        {
            public Point point;
            public Node parent;
            public int g;
            public int f;
        }

        Map map;
        Point me;
        Point target;
        int range;

        public Pathfinding(Map ma, Point m, Point t, int r)
        {
            map = ma;
            me = m;
            target = t;
            range = r;
        }

        public List<Point> Astar()
        {
            List<Node> closed = new List<Node>();
            List<Node> open = new List<Node>();
            int[] a = new int[8] { 1, 1, 1, 0, 0, -1, -1, -1 };
            int[] b = new int[8] { -1, 0, 1, -1, 1, -1, 0, 1 };
            Node current;
            open.Add(new Node { point = me, parent = null, g = 0, f = 0 + h(me) });

            while (open.Count != 0)
            {
                current = Promising(open);
                if ((Math.Pow((current.point.x - target.x) , 2) + Math.Pow((current.point.y - target.y) , 2)) < Math.Pow(range , 2))
                {
                    return buildPath(current);
                }
                open.Remove(current);
                closed.Add(current);
                for (int i = 0; i < 8; i++)
                {
                    if (!(map.isValidForUnit(new Point(current.point.x + a[i], current.point.y + b[i]))))
                    {
                        continue;
                    }
                    foreach (Node item in closed)
                    {
                        if ((item.point.x== current.point.x + a[i])&& (item.point.y == current.point.y + b[i]))
                        {
                            continue;
                        }
                    }
                    bool inOpen = false;
                    //Node same = new Node();
                    foreach (Node item in open)
                    {
                        if ((item.point.x == current.point.x + a[i]) && (item.point.y == current.point.y + b[i]))
                        {
                            inOpen = true;
                            if ((current.g + 1) >= item.g)
                            {
                                break;
                            }
                            else
                            {
                                item.parent = current;
                                item.g = current.g + 1;
                                item.f = current.g + 1 + h(item.point);
                                break;
                            }                            
                            //same = item;
                        }
                    }
                    if (!inOpen)
                    {
                        Point p = new Point(current.point.x + a[i], current.point.y + b[i]);
                        open.Add(new Node { point = p, parent = current, g=current.g+1, f=(current.g+1+h(p))});
                    }
                    //else if ((current.g+1)>=same.g)
                    //{
                    //    continue;
                    //}
                    //else
                    //{
                    //    same.parent = current;
                    //    same.g = current.g + 1;
                    //    same.f = current.g + 1 + h(same.point);
                    //}
                }
            }

            return new List<Point> { new Point(666, 666) };
        }

        private Node Promising(List<Node> l)
        {
            Node r = l[0];
            for (int i = 1; i < l.Count; i++)
            {
                if (l[i].f < r.f)
                {
                    r = l[i];
                }
            }
            return r;
        }

        private List<Point> buildPath(Node node)
        {
            Node n = node;
            List<Point> res = new List<Point>();
            while (n.point != me)
            {
                res.Add(n.point);
                n = n.parent;
            }
            return res;
        }

        private int h(Point p)
        {
            return Math.Max(Math.Abs(p.x - target.x), Math.Abs(p.y - target.y));
        }
    }
}
