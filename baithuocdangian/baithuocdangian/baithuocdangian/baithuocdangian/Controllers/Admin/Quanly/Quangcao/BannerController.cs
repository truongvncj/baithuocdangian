using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using baithuocdangian.Models;
using PagedList.Mvc;
using PagedList;

namespace baithuocdangian.Controllers.Admin.Quanly.Quangcao
{
    public class BannerController : Controller
    {
        // GET: Banner
        thuocdangianEntities db = new thuocdangianEntities();

        public ActionResult Index(int? page, catchuoi a)
        {
            if (Session["ten"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            if (Request.Cookies["Username"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }

            int pageSite = 10;
            int pageNumber = (page ?? 1);
            var query=db.tbl_Banner.ToList();
            return View(query.ToPagedList(pageNumber,pageSite));
        }
        public ActionResult CreateBanner()
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
        public ActionResult CreateBanner( FormCollection fc,tbl_Banner qc)
        {
            String name = fc["Name"].ToString();
            String img = fc["anhminhhoa"].ToString();
            String linkweb = fc["linkweb"].ToString();
            String thutu = fc["thutu"].ToString();
            String active = fc["txtactive"].ToString();
            qc.Name = name;
            qc.Duong_dan = img;
            qc.Link = linkweb;
            qc.Thu_tu = int.Parse(thutu);
            if(active=="false")
            {
                qc.Trang_thai =false;
            }
            else
            {
                qc.Trang_thai = true;
            }
            db.tbl_Banner.Add(qc);
            db.SaveChanges();
            return RedirectToAction("Index","Banner");
        }

        public ActionResult EditBanner(int id)
        {
            if (Session["ten"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            if (Request.Cookies["Username"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            var query = db.tbl_Banner.First(m => m.Id == id);

            return View(query);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditBanner(FormCollection fc, int id)
        {

            String name = fc["Name"].ToString();
            String img = fc["anhminhhoa"].ToString();
            String linkweb = fc["linkweb"].ToString();
            String thutu = fc["thutu"].ToString();
            String active = fc["txtactive"].ToString();
            var qc = db.tbl_Banner.First(m => m.Id == id);
            qc.Name = name;
            qc.Duong_dan = img;
            qc.Link = linkweb;
            qc.Thu_tu = int.Parse(thutu);
            if (active == "false")
            {
                qc.Trang_thai = false;
            }
            else
            {
                qc.Trang_thai = true;
            }
            UpdateModel(qc);
            db.SaveChanges();
            return RedirectToAction("Index", "Banner");
        }
        public ActionResult RemoveBanner(int id)
        {
            if (Session["ten"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            if (Request.Cookies["Username"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            var query = db.tbl_Banner.First(m => m.Id == id);
            db.tbl_Banner.Remove(query);
            db.SaveChanges();
            return RedirectToAction("Index", "Banner");


        }
    }
}