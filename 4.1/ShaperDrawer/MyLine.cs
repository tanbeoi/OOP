using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace ShaperDrawer
{
    internal class MyLine : Shape 
    {
        public MyLine(SplashKitSDK.Color color) : base(color)
        {
            
        }

        public MyLine() : this(SplashKitSDK.Color.Red)
        {
        }

        public override void Draw()
        {
            if (Selected)
            {
                DrawOutline();
            }

            SplashKit.DrawLine(_color, _x, _y, _x + 100, _y + 100);
        }

        public override bool IsAt(Point2D pt)
        {
            float endX = _x + 100;
            float endY = _y + 100;
            
            // Use the distance from point to line formula
            double distance = Math.Abs((endY - _y) * pt.X + (_x - endX) * pt.Y + (endX * _y - endY * _x)) /
                              Math.Sqrt((endY - _y) * (endY - _y) + (endX - _x) * (endX - _x));
            return distance <= 2; 
        }

        public override void DrawOutline()
        {
            SplashKit.FillCircle(SplashKitSDK.Color.Black, _x, _y, 2);
            SplashKit.FillCircle(SplashKitSDK.Color.Black, _x + 100, _y + 100, 2);
        }

    }
}
