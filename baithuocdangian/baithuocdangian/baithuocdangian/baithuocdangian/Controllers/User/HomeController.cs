using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using baithuocdangian.Models;
using PagedList;
using PagedList.Mvc;

namespace baithuocdangian.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        thuocdangianEntities context = new thuocdangianEntities();
        public ActionResult Index()
        {
            

            return View();
        }
       
        public ActionResult Category(int? page,int id)
        {
            //System.Threading.Thread.Sleep(4000);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            string chuoi="";
            var query = context.tbl_Danhmuc.Where(m => m.Id==id).ToList();
            
             for(int i=0;i<query.Count;i++)
             {
              chuoi += "<h1 class=\"titlecate\">";
            chuoi+=""+query[i].Name+"";
                
              chuoi+="</h1>";
            chuoi+="<div class=\"description\">";
           chuoi+="<p>";
           chuoi += "" + query[i].Mo_ta + "";
                  chuoi+=" </p>";
           chuoi+="</div>";
             }
            
            if (query == null)
            {
                Response.StatusCode = 404;
                return null;
            }


            List<Noi_dung> nd = context.Noi_dung.Where(n => n.Id_danhmuc == id).OrderBy(n => n.Thu_tu).ToList();
            if (nd.Count == 0)
            {
                ViewBag.hienthi = "không có bài viết nào trong chủ đề này";

            }
            ViewBag.chuoi = chuoi;
           
            return View(nd.ToPagedList(pageNumber,pageSize));
        }
        public ActionResult Detail(int id)
        {
            string row="";
            var query = context.Noi_dung.SingleOrDefault(m => m.Id == id);
            if(query.Id==id)
            {
                 row+="<div class=\"fb-comments\" data-href=\"https://www.facebook.com/caythuocvithuoc?fref=ts/\" data-width=\"675\" data-numposts=\"5\" data-colorscheme=\"light\">";
                row+="</div>";
            }
            ViewBag.row = row;
            return View(query);
        }


        public ActionResult Search( int? page,string search = null)
        {
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
          
    }
}