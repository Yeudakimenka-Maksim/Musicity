using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Mvc.PL.Infrastructure
{
    public class CaptchaImage : IDisposable
    {
        #region Fields & Properties

        public const string CaptchaValueKey = "CaptchaImageText";
        private readonly Random random = new Random();
        private string familyName;

        private string Text { get; set; }
        public Bitmap Image { get; set; }
        private int Width { get; set; }
        private int Height { get; set; }

        #endregion

        #region Constructors

        public CaptchaImage(string s, int width, int height)
        {
            Text = s;
            SetDimensions(width, height);
            GenerateImage();
        }

        public CaptchaImage(string s, int width, int height, string familyName)
        {
            Text = s;
            SetDimensions(width, height);
            SetFamilyName(familyName);
            GenerateImage();
        }

        #endregion

        #region Private methods

        private void SetDimensions(int aWidth, int aHeight)
        {
            if (aWidth <= 0)
                throw new ArgumentOutOfRangeException("aWidth", aWidth,
                    "Argument out of range, must be greater than zero.");
            if (aHeight <= 0)
                throw new ArgumentOutOfRangeException("aHeight", aHeight,
                    "Argument out of range, must be greater than zero.");
            Width = aWidth;
            Height = aHeight;
        }

        private void SetFamilyName(string aFamilyName)
        {
            try
            {
                using (new Font(aFamilyName, 12F))
                    familyName = aFamilyName;
            }
            catch
            {
                familyName = FontFamily.GenericSerif.Name;
            }
        }

        private void GenerateImage()
        {
            var bitmap = new Bitmap(Width, Height, PixelFormat.Format32bppArgb);

            using (var graphics = Graphics.FromImage(bitmap))
            {
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                var rect = new Rectangle(0, 0, Width, Height);

                var hatchBrush = new HatchBrush(HatchStyle.SmallConfetti, Color.LightGray, Color.White);
                graphics.FillRectangle(hatchBrush, rect);

                SizeF size;
                float fontSize = rect.Height + 1;
                Font font;
                do
                {
                    fontSize--;
                    font = new Font(familyName, fontSize, FontStyle.Bold);
                    size = graphics.MeasureString(Text, font);
                } while (size.Width > rect.Width);

                var format = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };

                var path = new GraphicsPath();
                path.AddString(Text, font.FontFamily, (int) font.Style, font.Size, rect, format);
                const float v = 4F;
                PointF[] points =
                {
                    new PointF(random.Next(rect.Width) / v, random.Next(rect.Height) / v),
                    new PointF(rect.Width - random.Next(rect.Width) / v, random.Next(rect.Height) / v),
                    new PointF(random.Next(rect.Width) / v, rect.Height - random.Next(rect.Height) / v),
                    new PointF(rect.Width - random.Next(rect.Width) / v, rect.Height - random.Next(rect.Height) / v)
                };
                var matrix = new Matrix();
                matrix.Translate(0F, 0F);
                path.Warp(points, rect, matrix, WarpMode.Perspective, 0F);

                hatchBrush = new HatchBrush(HatchStyle.LargeConfetti, Color.LightGray, Color.DarkGray);
                graphics.FillPath(hatchBrush, path);

                int m = Math.Max(rect.Width, rect.Height);
                for (int i = 0; i < (int) (rect.Width * rect.Height / 30F); i++)
                {
                    int x = random.Next(rect.Width);
                    int y = random.Next(rect.Height);
                    int w = random.Next(m / 50);
                    int h = random.Next(m / 50);
                    graphics.FillEllipse(hatchBrush, x, y, w, h);
                }

                font.Dispose();
                hatchBrush.Dispose();
            }

            Image = bitmap;
        }

        #endregion

        #region IDisposable implementation

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                Image.Dispose();
        }

        #endregion
    }
}