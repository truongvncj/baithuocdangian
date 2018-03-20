using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using baithuocdangian.Models;

namespace baithuocdangian.Controllers.Admin.Administrator
{
    public class AdminController : Controller
    {
        thuocdangianEntities context = new thuocdangianEntities();
        // GET: Admin
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection fc  )
        {
            String username = fc["UserName"].ToString();
            String password = fc["pass"].ToString();

            tbl_Admin ad = context.tbl_Admin.SingleOrDefault (n => n.Username == username && n.Password == password);
            if(  ad!=null)
            {
                Session["id"] = ad.Id;
                Session["ten"] = username.ToString();
                
              
                Session["mk"] = password.ToString();
                
                Session["role"] = ad.Role;
                String role = Session["role"].ToString();
                HttpCookie UserCookie = new HttpCookie("Username");

                UserCookie.Values["UserNameText"] = username.ToString();
                UserCookie.Values["PasswordText"] = password.ToString();
                UserCookie.Expires = DateTime.Now.AddHours(2);
                Response.Cookies.Add(UserCookie);
               
                return RedirectToAction("Default", "Admin");
            }
            else
            {

                ViewBag.ThongBao = "tài khoản hoặc mật khẩu sai";
                return View();
            }
                
                 
          
        }
        public ActionResult Default()
        {
            if(Session["ten"]==null)
            {
               return RedirectToAction("Login", "Admin");
            }
            //if (Request.Cookies["Username"] == null)
            //{
            //    return RedirectToAction("Login", "Admin");
            //}
            return View();
        }
        public ActionResult Logout()
        {
            var cookie = new HttpCookie("Username") { Expires = DateTime.Now.AddHours(-1) };
            Response.Cookies.Add(cookie);
            Session["IsLogin"] = 0;
            return RedirectToAction("Login", "Admin");
        }
    }
}