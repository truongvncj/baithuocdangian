using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using baithuocdangian.Models;
using PagedList;
using PagedList.Mvc;

namespace baithuocdangian.Controllers.Admin.Quanlynoidung.Quanlynoidung
{
    public class ProductController : Controller
    {
        // GET: Product
        thuocdangianEntities context = new thuocdangianEntities();
        public ActionResult ProductIndex(int? page, string search = null)
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
              List<Noi_dung> noidungs;
           
            if(search !=null)
            {

                noidungs = context.Noi_dung.Where(x => x.Name.ToLower().Contains(search.ToLower())).ToList();




            }
           
            else 
            {
                noidungs = context.Noi_dung.ToList();
            }
            
            return View(noidungs.ToPagedList(pageNumber,pageSize));

 
        }
        public JsonResult getNodungs(string term)
        {
            List<string> noidungs;


            noidungs = context.Noi_dung.Where(x => x.Name.StartsWith(term)).Select(y => y.Name).ToList();





            return Json(noidungs, JsonRequestBehavior.AllowGet);

        }
        public ActionResult ProductAdd()
        {
            if (Session["ten"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            if (Request.Cookies["Username"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            ViewBag.theloai = new SelectList(context.tbl_Danhmuc, "id", "Name");
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ProductAdd(FormCollection fc, Noi_dung nd)
        {
            String name = fc["name"].ToString();
            String mota = fc["mota"].ToString();
            String noidung = fc["noidung"].ToString();
            String anhminhhoa = fc["anhminhhoa"].ToString();
            String ngaydang = fc["ngaydang"].ToString();
            String thutu = fc["thutu"].ToString();
            String hienthi = fc["txtactive"].ToString();
            String theloai = fc["theloai"].ToString();
            nd.Name = name;
            nd.Mo_ta = mota;
            nd.Noi_dung1 = noidung;
            nd.Anh_minh_hoa = anhminhhoa;
            //String ngay = ngaydang.Substring(3, 2) + "/" + ngaydang.Substring(0, 2) + "/" + ngaydang.Substring(6, 4);
            //nd.Ngay_cap_nhat = DateTime.Parse(ngay);
            nd.Ngay_cap_nhat = DateTime.Parse(ngaydang);
            nd.Thu_tu = int.Parse(thutu);
            nd.Id_danhmuc = int.Parse(theloai);
            if (theloai == "false")
            {
                nd.Hien_thi = false;
            }
            else
            {
                nd.Hien_thi = true;
            }
            context.Noi_dung.Add(nd);
            context.SaveChanges();



            return RedirectToAction("ProductIndex", "Product");

        }
        public ActionResult ProductEdit(int id)
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
            ViewBag.theloai = new SelectList(context.tbl_Danhmuc,"Id","Name",query.Id_danhmuc);
            
            return View(query);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ProductEdit (FormCollection fc ,int id)
        {
            String name = fc["name"].ToString();
            String mota = fc["Mo_ta"].ToString();
            String noidung = fc["Noi_dung1"].ToString();
            String anhminhhoa = fc["anhminhhoa"].ToString();
            String ngaydang = fc["ngaydang"].ToString();
            String thutu = fc["thutu"].ToString();
            String hienthi = fc["txtactive"].ToString();
            String theloai = fc["theloai"].ToString();
           var nd= context.Noi_dung.First(m => m.Id == id);
           nd.Id = id;
           nd.Name = name;
           nd.Mo_ta = mota;
           nd.Noi_dung1 = noidung;
           nd.Anh_minh_hoa = anhminhhoa;
           //String ngay = ngaydang.Substring(3, 2) + "/" + ngaydang.Substring(0, 2) + "/" + ngaydang.Substring(6, 4);
           //nd.Ngay_cap_nhat = DateTime.Parse(ngay);
           nd.Ngay_cap_nhat = DateTime.Parse(ngaydang);
            nd.Thu_tu = int.Parse(thutu);
            nd.Id_danhmuc = int.Parse(theloai);
            if(hienthi=="false")
            {
                nd.Hien_thi = false;
            }
            else
            {
                nd.Hien_thi = true;
            }
            UpdateModel(nd);
            context.SaveChanges();

            return RedirectToAction("ProductIndex", "Product");
        }
        public ActionResult ProductRemove(int id)
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
            return RedirectToAction("ProductIndex", "Product");


        }
    }
}