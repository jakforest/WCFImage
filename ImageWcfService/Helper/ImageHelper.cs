using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace ImageWcfService.Helper
{
    public static class ImageHelper
    {

        /// <summary>
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        public static System.Drawing.Image ResizeImage(this System.Drawing.Image image, int width, int height)
        {
            if ((image.Height < height) && (image.Width < width))
                return image;
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }
            return destImage;
        }

        public static byte[] ResizeImage(this byte[] imageBytes, int width, int height)
        {
            try
            {
                using (MemoryStream streamInput = new MemoryStream(imageBytes))
                {
                    System.Drawing.Image image = new Bitmap(streamInput);
                    ImageFormat oldFormat = image.RawFormat;
                    image = image.ResizeImage(width, height);
                    byte[] result = image.GetBytes(oldFormat);
                    return result;
                }
            }
            catch (Exception ex)
            {
                return imageBytes;
            }
        }

        public static byte[] GetThumbnail(this byte[] imageBytes, int width, int height)
        {
            try
            {
                using (MemoryStream streamInput = new MemoryStream(imageBytes))
                {
                    System.Drawing.Image image = new Bitmap(streamInput);
                    System.Drawing.Image.GetThumbnailImageAbort deleg = new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback);
                    System.Drawing.Image thumbnail = image.GetThumbnailImage(width, height, deleg, IntPtr.Zero);
                    byte[] result = thumbnail.GetBytes(image.RawFormat);
                    return result;
                }
            }
            catch (Exception ex)
            {
                return imageBytes;
            }
        }

        public static byte[] GetBytes(this System.Drawing.Image image, ImageFormat imageFormat)
        {
            using (MemoryStream outStream = new MemoryStream())
            {
                image.Save(outStream, imageFormat);
                outStream.Seek(0, SeekOrigin.Begin);
                byte[] result = new byte[outStream.Length];
                outStream.Read(result, 0, (int)outStream.Length);
                return result;
            }
        }

        private static bool ThumbnailCallback()
        {
            return false;
        }
    }
}