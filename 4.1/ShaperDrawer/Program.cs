using System;
using System.Runtime.InteropServices;
using SplashKitSDK;
using System.IO;

namespace ShaperDrawer
{
    public class Program
    {
        private enum ShapeKind
        {
            Rectangle,
            Circle,
            Line
        }

        public static void Main()
        {
            Window window = new Window("Shape Drawer", 800, 600);
            Drawing myDrawing = new Drawing();
            ShapeKind kindToAdd = ShapeKind.Circle;

            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();

                if (SplashKit.KeyTyped(KeyCode.RKey))
                {
                    kindToAdd = ShapeKind.Rectangle;
                }

                if (SplashKit.KeyTyped(KeyCode.CKey))
                {
                    kindToAdd = ShapeKind.Circle;
                }

                if (SplashKit.KeyTyped(KeyCode.LKey))
                {
                    kindToAdd = ShapeKind.Line;
                }

                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    Shape newShape;

                    switch(kindToAdd)
                    {
                        case ShapeKind.Circle:
                            newShape = new MyCircle();
                            break;

                        case ShapeKind.Line:
                            newShape = new MyLine();
                            break;

                        default:
                            newShape = new MyRectangle();
                            break;
                    }

                    newShape.X = SplashKit.MouseX();
                    newShape.Y = SplashKit.MouseY();
                    myDrawing.AddShape(newShape);
                }

                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    myDrawing.Background = SplashKit.RandomColor();
                }

                if (SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    myDrawing.SelectShapeAt(SplashKit.MousePosition());
                }

                if (SplashKit.KeyTyped(KeyCode.DeleteKey) || SplashKit.KeyTyped(KeyCode.BackspaceKey))
                {
                    List<Shape> selectedShapes = myDrawing.SelectedShapes;
                    foreach (Shape s in selectedShapes)
                    {
                        myDrawing.RemoveShape(s);
                    }
                }

                if (SplashKit.KeyTyped(KeyCode.SKey))
                {
                    // Get the directory of the .csproj file
                    string directory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

                    // Construct the relative file path
                    string filePath = System.IO.Path.Combine(directory, "TestDrawing.txt");

                    myDrawing.Save(filePath);
                }

                if (SplashKit.KeyTyped(KeyCode.OKey))
                {
                    try
                    {
                        // Get the directory of the .csproj file
                        string directory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

                        // Construct the relative file path
                        string filePath = System.IO.Path.Combine(directory, "TestDrawing.txt");

                        myDrawing.Load(filePath);
                    }
                    catch (Exception e)
                    {
                        Console.Error.WriteLine("Error loading file: {0}", e.Message);
                    }
                }

                myDrawing.Draw();


                SplashKit.RefreshScreen();
            } while (!window.CloseRequested);

            
        }
    }
}
