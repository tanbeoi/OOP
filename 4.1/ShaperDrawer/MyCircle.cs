using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaperDrawer
{
    internal class MyCircle : Shape
    {
        private int _radius;
        public MyCircle(int radius, SplashKitSDK.Color color) : base(color) 
        {
            _radius = radius;
        }

        public int Radius
        {
            get { return _radius; }
            set { _radius = value; }
        }

        public MyCircle() : this(50, SplashKitSDK.Color.Blue)
        {
        }

        public override void Draw()
        {
            if (Selected)
            {
                DrawOutline();
            }

            SplashKit.FillCircle(_color, _x + _radius, _y + _radius, _radius);
        }

    
        public override bool IsAt(Point2D pt)
        {
            double centerX = _x + _radius;
            double centerY = _y + _radius;

            //Math.Sqrt calculates the square root of a number while
            //Math.Pow calculates the power of a number
            double distance = Math.Sqrt(Math.Pow(pt.X - centerX, 2) + Math.Pow(pt.Y - centerY, 2));
            return distance <= _radius;
        }

        public override void DrawOutline()
        {
            SplashKit.FillCircle(SplashKitSDK.Color.Black, _x + _radius, _y + _radius, _radius + 2);
        }
    }
}
