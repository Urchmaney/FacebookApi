using FacebookTest.Models;
using FacebookTest.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FacebookTest.Controllers
{
    public class FbController : Controller
    {
        // GET: Fb
        public ActionResult Index(string code)
        {
            var absoluteUri = "http://"+Request.Url.Authority + "/Fb/";

            Session["code"] = code;

            string url = string.Format("https://graph.facebook.com/oauth/access_token?client_id={0}&redirect_uri={1}&client_secret={2}&code={3}",
                ConfigurationManager.AppSettings["ClientId"], absoluteUri, ConfigurationManager.AppSettings["ClientSecret"], code);

            Session["access_token"]=ServiceWorker.GetFromAccessTokenUrl(url);

            return RedirectToAction("FbActivity");
        }
       
        public ActionResult FbActivity()
        {
            string url = "https://graph.facebook.com/me?fields=id,name,email&access_token=" + Session["access_token"];
            var model = ServiceWorker.GetFromUrlClient<FacebookUserModel>(url);
            if (Session["currentUser"] == null)
            {
                Session["currentUser"] = model.email;
            }
            else
            {
                if (Session["currentUser"] as string != model.email)
                {
                    Session["currentUser"] = null;
                    var absoluteUrl = "http://" + Request.Url.Authority + "/Fb/";

                    ViewBag.url = new MvcHtmlString(string.Format("https://www.facebook.com/v2.10/dialog/oauth?client_id={0}&redirect_uri={1}", ConfigurationManager.AppSettings["ClientId"], absoluteUrl));
                    return View("LogoutHelper");
                }
            }
          
            return View(model);
        }

        public ActionResult GetCode()
        {
            string scope = "email,read_custom_friendlists";
            ViewBag.url = new MvcHtmlString(string.Format("https://graph.facebook.com/oauth/authorize?client_id={0}&redirect_uri={1}&scope={2}",
                            ConfigurationManager.AppSettings["ClientId"], "http://" + Request.Url.Authority + "/Fb/", scope));
            //Response.Redirect("google.com");
            return View();

        }
    }
}