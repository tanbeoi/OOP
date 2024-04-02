using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace ShaperDrawer
{
    internal class Shape
    {
        private float _x, _y;
        private int _width, _height;
        private SplashKitSDK.Color _color;
        private bool _selected;
        public Shape()
        {
            _x = 0.0f;
            _y = 0.0f;
            _width = 100;
            _height = 100;
            _color = SplashKitSDK.Color.Green;
      
        }

        public void X (float x)
        {
            _x = x;
        }

        public void Y (float y)
        {
            _y = y;
        }

        public void Color (SplashKitSDK.Color clr)
        {
            _color = clr;
        }
        public void Draw()
        {
            if (_selected) { DrawOutline(); }
            SplashKit.FillRectangle(_color, _x, _y, _width, _height);

        }

        public bool IsAt(Point2D pt)
        {
            return (pt.X >= _x && pt.X <= _x + _width && pt.Y >= _y && pt.Y <= _y + _height);
           
        }
        
        public bool Selected
        {
            get { return _selected; }
            set { _selected = value; }
        }

        public void DrawOutline()
        {
            SplashKit.FillRectangle(SplashKitSDK.Color.Black, _x - 2, _y - 2, _width + 4, _height + 4);
        }
           
    }
}
