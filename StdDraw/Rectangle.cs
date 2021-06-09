using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StdDraw
{
    /// <summary>
    /// 矩形类定义
    /// </summary>
    public class Rectangle
    {
        public Point topLeft { get; set; }                  //矩形的左上角坐标

        public Point bottomRight { get; set; }           //矩形右下脚坐标
    }
}
