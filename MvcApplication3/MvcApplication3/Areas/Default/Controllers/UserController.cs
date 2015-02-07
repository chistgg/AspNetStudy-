using MvcApplication3.Controllers;
using MvcApplication3.Models.ModelViews;
using MvcApplication3.Tools;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication3.Areas.Default.Controllers
{
    public class UserController : BaseController
    {
        //
        // GET: /User/

        public ActionResult UserCheck()
        {
            if (!RepositoryUser.Users.Equals(null))
            {
                var users = RepositoryUser.Users.ToList();
                return View(users);
            }
            else
                return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            var userView = new UserView();
            return View(userView);
        }

        [HttpPost]
        public ActionResult Register(UserView userView)
        {
            
            if (userView.Captcha != (string)Session[CaptchaImage.CAPTCHA_VALUE_KEY])
            {
                ModelState.AddModelError("Captcha", "Текст с картинки введен неверно");
            }
            var existEmail = RepositoryUser.Users.Any(p => string.Compare(p.Email, userView.Email) == 0);
            
            if (existEmail)
                ModelState.AddModelError("Email", "Пальзавутил с таким иминим ужы сущстуит!!111))0)");
            
            if (ModelState.IsValid)
            {
                var user = (MvcApplication3.Models.User)ModelMapper.Map(userView, typeof(UserView), typeof(MvcApplication3.Models.User));
                user.ActivatedDate = DateTime.Now;          //для проверки
                user.AddedDate = DateTime.Now;
                user.LastVisitDate = DateTime.Now;
                RepositoryUser.CreateUser(user);
                return RedirectToAction("UserCheck");
            }
            return View(userView);
        }

        public ActionResult Captcha()
        {
            Session[CaptchaImage.CAPTCHA_VALUE_KEY] = new Random(DateTime.Now.Millisecond).Next(1111, 9999).ToString();
            var ci = new CaptchaImage(Session[CaptchaImage.CAPTCHA_VALUE_KEY].ToString(), 211, 50, "Arial");

            // Change the response headers to output a JPEG image.
            this.Response.Clear();
            this.Response.ContentType = "image/jpeg";

            // Write the image to the response stream in JPEG format.
            ci.Image.Save(this.Response.OutputStream, ImageFormat.Jpeg);

            // Dispose of the CAPTCHA image object.
            ci.Dispose();
            return null;
        }

    }
}
