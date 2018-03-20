using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using baithuocdangian.Models;
using PagedList;
using PagedList.Mvc;

namespace baithuocdangian.Controllers.Admin.Quanlynoidung.Quanlynhomnoidung
{
    public class GroupProductController : Controller
    {
        
        // GET: GroupProduct
        thuocdangianEntities context = new thuocdangianEntities();
        public ActionResult GroupProductIndex(int? page,catchuoi a)
        {


            if (Session["ten"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            if (Request.Cookies["Username"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            var query=context.tbl_Danhmuc.ToList();
            for(int i=0;i<query.Count;i++)
            {
                ViewBag.sang = a.layChuoi(query[i].Mo_ta,100);
           } 
          
            
            
            
            
           
            int pageSite = 10;
            int pageNumber = (page??1);
           
            return View(query.ToPagedList(pageNumber,pageSite));
        }
        public ActionResult GroupProductCreate()
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
        public ActionResult GroupProductCreate(FormCollection fc,tbl_Danhmuc dm)
        {
            String tieude = fc["Name"].ToString();
            String mota = fc["Content"].ToString();
            String thutu = fc["thutu"].ToString();
            String hienthi = fc["txtactive"].ToString();
            dm.Name = tieude;
            dm.Mo_ta = mota;
            dm.Thu_tu = int.Parse(thutu);
           if(hienthi=="false")
           {
               dm.Hien_thi = false; 
           }
            else
           {
               dm.Hien_thi = true;
           }
           context.tbl_Danhmuc.Add(dm);
           context.SaveChanges();



           return RedirectToAction("GroupProductIndex", "GroupProduct");
        }
        public ActionResult GroupProductEdit(int id)
        {
            if (Session["ten"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            if (Request.Cookies["Username"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            var query = context.tbl_Danhmuc.First(m => m.Id == id);
            return View(query);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult GroupProductEdit(FormCollection fc, int id)
        {
            String tieude = fc["Name"].ToString();
            String mota = fc["Mo_ta"].ToString();
            String thutu = fc["thutu"].ToString();
            String hienthi = fc["txtactive"].ToString();
            var danhmuc = context.tbl_Danhmuc.First(m => m.Id ==id);
            danhmuc.Id = id;
            danhmuc.Name = tieude;
            danhmuc.Mo_ta = mota;
            danhmuc.Thu_tu = int.Parse(thutu);
            if(hienthi=="false")
            {
                danhmuc.Hien_thi = false;
            }
            else
            {
                danhmuc.Hien_thi = true;
            }
            UpdateModel(danhmuc);
            context.SaveChanges();


            return RedirectToAction("GroupProductIndex", "GroupProduct");
        }
        public ActionResult GroupProductRemove(int id)
        {
            if (Session["ten"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            if (Request.Cookies["Username"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            var query = context.Noi_dung.First(m => m.Id == id);
            context.Noi_dung.Remove(query);
            context.SaveChanges();
            return RedirectToAction("GroupProductIndex", "GroupProduct");
        }
     
    }
}