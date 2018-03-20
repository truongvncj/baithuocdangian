using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using baithuocdangian.Models;

namespace baithuocdangian.Controllers.Admin.QuanlyAdmin
{
    public class AdministratorController : Controller
    {
        // GET: Administrator
        thuocdangianEntities db = new thuocdangianEntities();
        public ActionResult AdministratorIndex(int? page)
        {
            if (Session["ten"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            if (Request.Cookies["Username"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var query = db.tbl_Admin.ToList();
            return View(query.ToPagedList(pageNumber,pageSize));
        }
        public ActionResult AdministratorAdd()
        {

            if (Session["ten"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            if (Request.Cookies["Username"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            return View();
        }
        
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AdministratorAdd(FormCollection fc, tbl_Admin ad)
        {
            string user = fc["user"].ToString();
            string pass = fc["pass"].ToString();
            string fullname = fc["fullname"].ToString();
            string ngaysinh = fc["ngaysinh"].ToString();
            string cmt = fc["cmt"].ToString();
            string email = fc["email"].ToString();
            string phone = fc["phone"].ToString();
            string address = fc["Content"].ToString();
            string phanquyen = fc["phanquyen"].ToString();
            ad.Username = user;
            ad.Password = pass;
            ad.Fullname = fullname;
            ad.Dateofbirth = DateTime.Parse(ngaysinh);
            ad.Cmt = cmt;
            ad.Email = email;
            ad.Phone = phone;
            ad.Address = address;
            ad.Role = int.Parse(phanquyen);
            db.tbl_Admin.Add(ad);
            db.SaveChanges();
            return RedirectToAction("AdministratorIndex", "Administrator");
        }
        public ActionResult AdministratorEdit(int id)
        {

            if (Session["ten"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            if (Request.Cookies["Username"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            var query = db.tbl_Admin.First(m => m.Id == id);
            return View(query);
        }
       
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AdministratorEdit(FormCollection fc , int id)
        {
            string user = fc["user"].ToString();
            string pass = fc["pass"].ToString();
            string fullname = fc["fullname"].ToString();
            string ngaysinh = fc["ngaysinh"].ToString();
             string cmt = fc["cmt"].ToString();
            string email = fc["email"].ToString();
            string phone = fc["phone"].ToString();
            string address = fc["diachi"].ToString();
            string phanquyen = fc["phanquyen"].ToString();
            var ad = db.tbl_Admin.First(m => m.Id == id);
            ad.Username = user;
            ad.Password = pass;
            ad.Fullname = fullname;
            ad.Dateofbirth = DateTime.Parse(ngaysinh);
            ad.Cmt = cmt;

            ad.Email = email;
            ad.Phone = phone;
            ad.Address = address;
            ad.Role = int.Parse(phanquyen);
            UpdateModel(ad);
            db.SaveChanges();
            return RedirectToAction("AdministratorIndex", "Administrator");
        }
        public ActionResult AdministratorDetail(int id)
        {

            if (Session["ten"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            if (Request.Cookies["Username"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            var query = db.tbl_Admin.First(m => m.Id == id);
            return View(query);
        }
        public ActionResult Thongtincanhan()
        {
            if (Session["ten"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            if (Request.Cookies["Username"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            int id = Convert.ToInt32(Session["id"].ToString());
            var query = db.tbl_Admin.Where(p => p.Id == id).First();
            return View(query);
        }
        public ActionResult Chinhsuathongtin()
        {
            if (Session["ten"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            if (Request.Cookies["Username"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            int id = Convert.ToInt32(Session["id"].ToString());
            var ad = db.tbl_Admin.First(p => p.Id == id);
            return View(ad);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Chinhsuathongtin(FormCollection fc)
        {
            int id = Convert.ToInt32(Session["id"].ToString());
           
            
            string user = fc["user"].ToString();
            string pass = fc["pass"].ToString();
            string fullname = fc["fullname"].ToString();
            string ngaysinh = fc["ngaysinh"].ToString();
             string cmt = fc["cmt"].ToString();
            string email = fc["email"].ToString();
            string phone = fc["phone"].ToString();
            string address = fc["diachi"].ToString();
            var ad = db.tbl_Admin.First(p => p.Id == id);
            ad.Username = user;
            ad.Password = pass;
            ad.Fullname = fullname;
            ad.Dateofbirth = DateTime.Parse(ngaysinh);
            ad.Cmt = cmt;

            ad.Email = email;
            ad.Phone = phone;
            ad.Address = address;
            UpdateModel(ad);
            db.SaveChanges();
            return RedirectToAction("Default", "Admin");
        }
        public ActionResult Thaydoimatkhau()
        {
            if (Session["ten"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            if (Request.Cookies["Username"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            int id = Convert.ToInt32(Session["id"].ToString());
            var ad = db.tbl_Admin.First(p => p.Id == id);
            return View(ad);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Thaydoimatkhau(FormCollection fc)
        { 

            int id = Convert.ToInt32(Session["id"].ToString());
            var ad = db.tbl_Admin.First(p => p.Id == id);
            string matkhaucu = fc["matkhaucu"].ToString();
            string matkhaumoi = fc["matkhaumoi"].ToString();
             if(ad.Password==matkhaucu)
             {
                 ad.Password = matkhaumoi;
                 UpdateModel(ad);
                 db.SaveChanges();
                
                 return RedirectToAction("Login", "Admin");

             }
             else
             {
                 ViewBag.thongbao = "mật khẩu cũ chưa đúng,xin mời nhập lại";
                 return View(ad);

             }
            
        }

        [HttpPost]
        [ValidateInput(false)]

        public ActionResult AdministratorRemove(int id)
        {
            if (Session["ten"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            if (Request.Cookies["Username"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            var query = db.tbl_Admin.First(m => m.Id == id);
            db.tbl_Admin.Remove(query);
            db.SaveChanges();
            return RedirectToAction("AdministratorIndex", "Administrator");
        }
    }
}