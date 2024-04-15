using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using SplashKitSDK;

namespace ShaperDrawer
{
    internal class MyRectangle : Shape
    {
        public int _width, _height;
        public MyRectangle(SplashKitSDK.Color color, float x, float y, int width, int height) : base(color)
        {
            _width = width;
            _height = height;
            _x = x;
            _y = y;
        }

        public MyRectangle() : this(SplashKitSDK.Color.Green, 0.0f, 0.0f, 100, 100)
        {
        }

        public override bool IsAt(Point2D pt)
        {
            return (pt.X >= _x && pt.X <= _x + _width && pt.Y >= _y && pt.Y <= _y + _height);
        }

        public override void Draw()
        {
            if (Selected)
            {
                DrawOutline();
            }

            SplashKit.FillRectangle(_color, _x, _y, _width, _height);
        }

        public override void DrawOutline()
        {
            SplashKit.FillRectangle(SplashKitSDK.Color.Black, _x - 2, _y - 2, _width + 4, _height + 4);
        }

        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Rectangle");
            base.SaveTo(writer);
            writer.WriteLine(_width);
            writer.WriteLine(_height);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            _width = reader.readInteger();
            _height = reader.readInteger();
        }
        
    }
}
