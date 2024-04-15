using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace ShaperDrawer
{
    public abstract class Shape
    {
        public float _x, _y;
        
        public SplashKitSDK.Color _color;
        public bool _selected;
        public Shape(SplashKitSDK.Color color)
        {
            _x = 0.0f;
            _y = 0.0f;
            _color = color;
      
        }

        public Shape() : this(SplashKitSDK.Color.Yellow)
        {
        }

        public float X
        {
            get { return _x; }
            set { _x = value; }
        }

        public float Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public SplashKitSDK.Color Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public abstract void Draw();


        // Check if mouse is within the shape 
        public abstract bool IsAt(Point2D pt);

        public bool Selected
        {
            get { return _selected; }
            set { _selected = value; }
        }

        public abstract void DrawOutline();

        public virtual void SaveTo(StreamWriter writer)
        {
            writer.WriteColor(Color);
            writer.WriteLine(X);
            writer.WriteLine(Y);
        }

        public virtual void LoadFrom(StreamReader reader)
        {
            Color = reader.readColor();
            X = reader.readInteger();
            Y = reader.readInteger();
        }
    }
}
