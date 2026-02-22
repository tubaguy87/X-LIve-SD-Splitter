// Creates a valid .ico file from a PNG (Vista+ format: embedded PNG).
// Usage: CreateIco.exe <input.png> <output.ico>
// Resizes to 256x256 for best compatibility with Visual Studio and Windows.

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;

class CreateIco
{
    const int IcoSize = 256;

    static int Main(string[] args)
    {
        if (args.Length != 2)
        {
            Console.Error.WriteLine("Usage: CreateIco <input.png> <output.ico>");
            return 1;
        }
        string pngPath = args[0];
        string icoPath = args[1];
        if (!File.Exists(pngPath))
        {
            Console.Error.WriteLine("File not found: " + pngPath);
            return 1;
        }
        byte[] png;
        using (var bmp = (Bitmap)Image.FromFile(pngPath))
        {
            if (bmp.Width == IcoSize && bmp.Height == IcoSize)
            {
                png = File.ReadAllBytes(pngPath);
            }
            else
            {
                using (var resized = new Bitmap(IcoSize, IcoSize))
                {
                    using (var g = Graphics.FromImage(resized))
                    {
                        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        g.SmoothingMode = SmoothingMode.HighQuality;
                        g.DrawImage(bmp, 0, 0, IcoSize, IcoSize);
                    }
                    using (var ms = new MemoryStream())
                    {
                        resized.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        png = ms.ToArray();
                    }
                }
            }
        }
        if (png.Length < 24) { Console.Error.WriteLine("Invalid PNG"); return 1; }
        int width = (png[16] << 24) | (png[17] << 16) | (png[18] << 8) | png[19];
        int height = (png[20] << 24) | (png[21] << 16) | (png[22] << 8) | png[23];
        using (var fs = File.Create(icoPath))
        using (var bw = new BinaryWriter(fs))
        {
            bw.Write((ushort)0);
            bw.Write((ushort)1);
            bw.Write((ushort)1);
            bw.Write((byte)0);  // 0 = 256 in ICO
            bw.Write((byte)0);
            bw.Write((byte)0);
            bw.Write((byte)0);
            bw.Write((ushort)0);
            bw.Write((ushort)32);
            bw.Write((uint)png.Length);
            bw.Write((uint)(6 + 16));
            bw.Write(png);
        }
        Console.WriteLine("Created: " + icoPath);
        return 0;
    }
}
