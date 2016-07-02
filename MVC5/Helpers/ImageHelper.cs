using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Web.Mvc;
using System.Collections.Generic;

namespace MVC5.Helpers
{
    public class ThumbnailActionResult : ActionResult
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public string Filename { get; set; }

        public ThumbnailActionResult(int w, int h, string name)
        {
            this.Width = w;
            this.Height = h;
            this.Filename = name;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            if (string.IsNullOrEmpty(Filename))
                throw new ArgumentNullException("FileName", "FileName parameter cannot be null or empty");

            string FilePath = context.HttpContext.Server.MapPath(context.HttpContext.Request.ApplicationPath) + @"App_Data\uploads\Originals\" + Filename;

            if (!File.Exists(FilePath))
                throw new FileNotFoundException(string.Format("File {0} could not be found", FilePath));

            Bitmap bmp = new Bitmap(FilePath);

            ImageFormat bmpFormat = bmp.RawFormat;
            try
            {
                if (bmp.Width < Width && bmp.Height < Height)
                {
                    if (bmpFormat.Equals(ImageFormat.Jpeg))
                    {
                        context.HttpContext.Response.ContentType = "image/JPEG";
                        bmp.Save(context.HttpContext.Response.OutputStream, ImageFormat.Jpeg);
                    }
                    else if (bmpFormat.Equals(ImageFormat.Png))
                    {
                        context.HttpContext.Response.ContentType = "image/PNG";
                        bmp.Save(context.HttpContext.Response.OutputStream, ImageFormat.Png);
                    }
                    else if (bmpFormat.Equals(ImageFormat.Tiff))
                    {
                        context.HttpContext.Response.ContentType = "image/TIFF";
                        bmp.Save(context.HttpContext.Response.OutputStream, ImageFormat.Tiff);
                    }

                    return;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                bmp.Dispose();
            }
            bmp = GenerateFinalImage(context, FilePath, bmp);
        }

        private Bitmap GenerateFinalImage(ControllerContext context, string fileName, Bitmap bmp)
        {
            Bitmap finalBmp = null;

            try
            {
                //here we make a Bitmap based on the file name sent
                bmp = new Bitmap(fileName);

                ImageFormat bmpFormat = bmp.RawFormat;


                //height, width and ratio values
                int w;
                int h;
                decimal ratio;

                //now we're deciding if the image is landscape or portrat
                if (bmp.Width > bmp.Height)
                {
                    ratio = (decimal)this.Width / bmp.Height;
                    w = this.Width;

                    decimal temp = bmp.Height * ratio;
                    h = (int)temp;
                }
                else
                {
                    ratio = (decimal)this.Height / bmp.Height;
                    h = Height;
                    decimal temp = bmp.Width * ratio;
                    w = (int)temp;
                }


                //Now we use the Graphics class to set it's clarity and to draw the final image.
                finalBmp = new Bitmap(w, h);
                Graphics gfx = Graphics.FromImage(finalBmp);
                //gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;
                gfx.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                gfx.FillRectangle(Brushes.White, 0, 0, w, h);
                gfx.DrawImage(bmp, 0, 0, w, h);

                if (bmpFormat.Equals(ImageFormat.Jpeg))
                {
                    context.HttpContext.Response.ContentType = "image/JPEG";
                    finalBmp.Save(context.HttpContext.Response.OutputStream, ImageFormat.Jpeg);
                }
                else if (bmpFormat.Equals(ImageFormat.Png))
                {
                    context.HttpContext.Response.ContentType = "image/PNG";
                    finalBmp.Save(context.HttpContext.Response.OutputStream, ImageFormat.Png);
                }
                else if (bmpFormat.Equals(ImageFormat.Tiff))
                {
                    context.HttpContext.Response.ContentType = "image/TIFF";
                    finalBmp.Save(context.HttpContext.Response.OutputStream, ImageFormat.Tiff);
                }

                //context.HttpContext.Response.ContentType = "image/JPEG";
                //finalBmp.Save(context.HttpContext.Response.OutputStream, ImageFormat.Jpeg);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                if (finalBmp != null) finalBmp.Dispose();
            }
            return bmp;
        }
    }
}