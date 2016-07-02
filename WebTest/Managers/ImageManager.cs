using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebTest.Helpers;

namespace WebTest.Managers
{
    public class ImageManager
    {
        static ImageManager imgManager;

        public static ImageManager Instance
        {
            get
            {
                if (imgManager == null)
                {
                    imgManager = new ImageManager();
                }
                return imgManager;
            }
        }

        protected internal virtual ThumbnailActionResult Thumbnail(int w, int h, string file)
        {
            return new ThumbnailActionResult(w, h, file);
        }

        public virtual ThumbnailActionResult Generate(int width, int height, string file)
        {
            return Thumbnail(width, height, file);
        }

    }

}