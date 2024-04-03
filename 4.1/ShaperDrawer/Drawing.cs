using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace ShaperDrawer
{
    internal class Drawing
    {
        private readonly List<Shape> _shapes; //list of shapes
        private Color _background;

        public Drawing(Color background)
        {
            _shapes = new List<Shape>();
            _background = background;

        }

        public Color Background
        {
            get { return _background; }
            set { _background = value; }
        }

        public Drawing() : this(Color.White)
        {
            
        }

        public int ShapeCount()
        { return _shapes.Count; }

        public void AddShape(Shape s)
        {
            _shapes.Add(s);
        }

        public bool RemoveShape(Shape s)
        {
            if (_shapes.Contains(s))
            {
                _shapes.Remove(s);
                return true;
            }
            return false;
            
        }

        public void SelectShapeAt(Point2D pt)
        {
            foreach (Shape s in _shapes)
            {
                if (!s.Selected)
                {
                    s.Selected = s.IsAt(pt);
                }
                else
                {
                    s.Selected = !s.IsAt(pt);
                }
            }
        }

        //create a list of shapes that are to be deleted 
        public List<Shape> SelectedShapes
        {
            get
            {
                List<Shape> shapes = new List<Shape>();
                foreach (Shape s in _shapes)
                {
                    if (s.Selected == true)
                        { shapes.Add(s); }
                }
                return shapes;
            }
        }

        public void Draw()
        {
            SplashKit.ClearScreen(_background); //change color of background to _background color 
            foreach (Shape s in _shapes)
            {
                s.Draw();
            }
        }


    }
}

