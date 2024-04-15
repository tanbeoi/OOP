using System;
using System.IO;
using SplashKitSDK;

namespace ShaperDrawer
{
    public static class ExtensionMethods
    {
        public static int readInteger(this StreamReader reader)
        {
            return Convert.ToInt32(reader.ReadLine());
        }

        public static float readSingle(this StreamReader reader)
        {
            return Convert.ToSingle(reader.ReadLine());
        }

        public static Color readColor(this StreamReader reader)
        {
            return Color.RGBColor(reader.readSingle(), reader.readSingle(), reader.readSingle());
        }

        public static void WriteColor(this StreamWriter writer, Color clr)
        {
            writer.WriteLine("{0}\n{1}\n{2}", clr.R, clr.G, clr.B);
        }
    }
}
