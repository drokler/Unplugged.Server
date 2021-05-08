using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.SignalR;

namespace Unplugged.Server.Utils
{
    public static class ImageUtils
    {
        public static string GetSmallBase64(string source)
        {
            const int size = 390;
            const int quality = 75;
            var raw = Convert.FromBase64String(source);
            using var mStream = new MemoryStream(raw);

            using var image = new Bitmap(mStream);
            int width, height;
            if (image.Width > image.Height)
            {
                width = size;
                height = Convert.ToInt32(image.Height * size / (double)image.Width);
            }
            else
            {
                width = Convert.ToInt32(image.Width * size / (double)image.Height);
                height = size;
            }
            var resized = new Bitmap(width, height);
            using var graphics = Graphics.FromImage(resized);
            graphics.CompositingQuality = CompositingQuality.HighSpeed;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.CompositingMode = CompositingMode.SourceCopy;
            graphics.DrawImage(image, 0, 0, width, height);

            using var output = new MemoryStream();
            var qualityParamId = Encoder.Quality;
            var encoderParameters = new EncoderParameters(1);
            encoderParameters.Param[0] = new EncoderParameter(qualityParamId, quality);
           
            resized.Save(output, ImageFormat.Jpeg);

            output.Seek(0, SeekOrigin.Begin);
            return Convert.ToBase64String(output.ToArray());
        }
    }
}