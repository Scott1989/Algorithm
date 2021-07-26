using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StdDraw
{
    /// <summary>
    /// 线条类定义
    /// </summary>
    public class Line
    {
        public Point begin { get; set; }
        public Point end { get; set; }

        public Line(Point begin, Point end)
        {
            this.begin = begin;
            this.end = end;
        }
    }
}
