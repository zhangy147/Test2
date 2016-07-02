using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTest.Helpers;


namespace WebTest.Controllers
{

    public class ThumbnailControllerBase : Controller
    {
        protected internal virtual ThumbnailActionResult Thumbnail(int w, int h, string file)
        {
            return new ThumbnailActionResult(w, h, file);
        }
    }


    public partial class ThumbnailController : ThumbnailControllerBase
    {
        public virtual ThumbnailActionResult Generate(int width, int height, string file)
        {
            return Thumbnail(width, height, file);
        }
    }
}