using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StdDraw
{
    public class Draw
    {
        /// <summary>
        /// 绘制指定点对象
        /// </summary>
        /// <param name="point"></param>
        public static void DrawPoint(Point point)
        {

        }

        /// <summary>
        /// 绘制指定线对象
        /// </summary>
        /// <param name="p"></param>
        public static void DrawLine(Line l)
        {

        }

        /// <summary>
        /// 绘制指定矩形对象
        /// </summary>
        /// <param name="r"></param>
        public static void DrawRectangle(Rectangle r)
        {

        }

        /// <summary>
        /// 绘制指定圆对象
        /// </summary>
        /// <param name="c"></param>
        public static void DrawCircle(Circle c)
        {

        }

        /// <summary>
        /// 在指定的坐标位置，绘制文本信息
        /// </summary>
        /// <param name="start"></param>
        /// <param name="text"></param>
        public static void DrawText(Point start, string text)
        {

        }

        /// <summary>
        /// 根据指定的point清单列表，将相连的点进行进行绘制
        /// </summary>
        /// <param name="points"></param>
        public static void DrawPath(List<Point> points)
        {
            if (points == null || points.Count < 1)
            {
                return;
            }else if (points.Count == 1)
            {
                DrawPoint(points[0]);
            }else
            {
                for (int i = 0; i < points.Count - 1; i++)
                {
                    Line line = new Line(points[i], points[i + 1]);
                    DrawLine(line);
                }
            }
        }


    }
}
