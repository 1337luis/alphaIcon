using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alphaIcon
{
    static class alphaIcon
    {
        public static Icon convertToIco( Bitmap work )
        {
            if( work.Height > 128 || work.Width > 128 || work.Width > 128 && work.Height > 128 )
            {
                work = new Bitmap( work, 128, 128 );
            }
            Bitmap myBitmap = work;
            IntPtr Hicon = myBitmap.GetHicon();
            Icon newIcon = Icon.FromHandle(Hicon);
            return newIcon;

        }
        public static void saveIcon( string Path, Icon icon )
        {
            System.IO.FileStream f = new System.IO.FileStream(Path, System.IO.FileMode.OpenOrCreate);
            icon.Save( f );
            f.Close();
            f.Dispose();
        }
        public static Bitmap createLogo( char Text )
        {
            int Size = 128;
            Bitmap icon = new Bitmap(Size, Size);
            Graphics m = Graphics.FromImage(icon);
            m.Clear( Color.Blue );
            m.SmoothingMode = SmoothingMode.AntiAlias;
            m.InterpolationMode = InterpolationMode.HighQualityBicubic;
            m.PixelOffsetMode = PixelOffsetMode.HighQuality;
            Font myFont = new Font("Tahoma", 85);
            Brush myBrush = new SolidBrush(Color.White);

            m.DrawString( Text.ToString(), myFont, myBrush, 0, 0 );
            return icon;
        }
        public static Bitmap createLogo( char Text, int Size, Color ForeColor, Color BackColor, Font myFont, int coordenadaX, int coordenadaY )
        {
            Bitmap icon = new Bitmap(Size, Size);
            Graphics m = Graphics.FromImage(icon);
            m.SmoothingMode = SmoothingMode.AntiAlias;
            m.InterpolationMode = InterpolationMode.HighQualityBicubic;
            m.PixelOffsetMode = PixelOffsetMode.HighQuality;
            Brush fore = new SolidBrush(ForeColor);

            m.Clear( BackColor );
            m.DrawString( Text.ToString(), myFont, fore, coordenadaX, coordenadaY );
            return icon;
        }
        public static Bitmap createLogo( logoParameters param )
        {
            Bitmap icon = new Bitmap(param.size, param.size);
            Graphics m = Graphics.FromImage(icon);
            m.SmoothingMode = SmoothingMode.AntiAlias;
            m.InterpolationMode = InterpolationMode.HighQualityBicubic;
            m.PixelOffsetMode = PixelOffsetMode.HighQuality;
            Brush fore = new SolidBrush(param.foreColor);

            m.Clear( param.backColor );
            m.DrawString( param.letter.ToString(), param.font, fore, param.textoX, param.textoY );
            return icon;
        }
        public static Bitmap createLogo( char letter, Color backColor, Color foreColor, logoBaseParameters param )
        {
            Bitmap icon = new Bitmap(param.size, param.size);
            Graphics m = Graphics.FromImage(icon);
            m.SmoothingMode = SmoothingMode.AntiAlias;
            m.InterpolationMode = InterpolationMode.HighQualityBicubic;
            m.PixelOffsetMode = PixelOffsetMode.HighQuality;
            m.CompositingQuality = CompositingQuality.HighQuality;
            m.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            Brush fore = new SolidBrush(foreColor);

            m.Clear( backColor );
            m.DrawString( letter.ToString(), param.font, fore, param.textoX, param.textoY );
            return icon;
        }
        public static Bitmap cropBitmap( Bitmap work, int fromX, int fromY, int toX, int toY )
        {
            int w = toX - fromX, h = toY - fromY;
            int aX = 0, aY = 0;
            Bitmap final = new Bitmap(w, h);
            for( int x = fromX; x < toX; x++ )
            {
                for( int y = fromY; y < toY; y++ )
                {
                    Color ac = work.GetPixel(x, y);
                    final.SetPixel( aX, aY, ac );
                    aX++; aY++;
                }
            }
            return final;
        }
        public static Bitmap resizeBitmap( Bitmap toResize, int newSizeX, int newSizeY )
        {
            Bitmap final = new Bitmap(toResize, newSizeX, newSizeY);
            return final;
        }
        public static Bitmap resizeBitmap( Bitmap toResize, int newSize )
        {
            int x = toResize.Width, y = toResize.Height;
            int newY = (y * newSize) / x;
            return new Bitmap( toResize, newSize, newY );
        }
        public struct logoParameters
        {
            public char letter;
            public int size;
            public Color foreColor;
            public Color backColor;
            public Font font;
            public int textoX;
            public int textoY;
        }
        public struct logoBaseParameters
        {
            public int size;
            public Font font;
            public int textoX;
            public int textoY;
        }
    }
}
