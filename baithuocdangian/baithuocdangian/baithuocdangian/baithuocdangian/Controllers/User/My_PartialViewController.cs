using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using baithuocdangian.Models;
using System.Collections;

namespace baithuocdangian.Controllers.User
{
    public class My_PartialViewController : Controller
    {
        // GET: My_PartialView
        thuocdangianEntities context = new thuocdangianEntities();
        public ActionResult Menu()
        {
            var query = context.tbl_Danhmuc.ToList();
                
            return PartialView(query);
        }

        public ActionResult Quangcao_Left()

        {
            
            var query = context.Noi_dung.Take(15).OrderByDescending(m => m.Id).ToList();
           
            return PartialView(query);

        }
        public ActionResult Quangcao()
        {
            var query = context.tbl_Banner.OrderByDescending(m=>m.Id).ToList();
            return PartialView(query);


        }
        public ActionResult Slider_Footer()
        {
            return PartialView();
        }
        public ActionResult Footer()
        {
            var query = context.tbl_Config.ToList();
            
            return PartialView(query);
        }


        public ActionResult Slider_index()
        {

            string chuoi = "";
            string dong = "";
            string row = "";

            string dm = "";
            string dn = "";
            string box = "";
            int gid;
            catchuoi a = new catchuoi();
            
            
            var category = context.tbl_Danhmuc.ToList();
            for (int i = 0; i < category.Count; i++)
            {
                if (category[i].Hien_thi == true)
                {
                    gid = category[i].Id;
                    
                    var products = context.Noi_dung.OrderByDescending(m => m.Id).Where(m => m.Id_danhmuc == gid).ToList();
                    if (gid == 1)
                    {

                        dm += "" + category[i].Name + "";

                        for (int j = 0; j < products.Count; j++)
                        {
                            if (j == 0)
                            {
                               
                                chuoi += "<a href=\"../../Home/Detail?id=" + products[j].Id + "\">";
                                chuoi += "<img src=\"" + products[j].Anh_minh_hoa + "\" />";
                                chuoi += "</a>";
                                chuoi += "<div id=\"nenden\">";
                                chuoi += "<a href=\"../../Home/Detail?id=" + products[j].Id + " \">" + products[j].Name + "</a>";
                                chuoi += "<p>";
                                chuoi += a.layChuoi(products[j].Mo_ta, 150);
                                chuoi += "</p>";

                                chuoi += "</div>";
                                }
                            
                            else if (j < 7)
                            {
                                
                                    dong += "<li>";
                                    dong += "<a href=\"../../Home/Detail?id=" + products[j].Id + " \">" + products[j].Name + "</a>";
                                    dong += "</li>";
                                
                            }
                            else if (j <= 10)
                            {
                                 
                                row += " <li id=\"left\">";
                                row += "<a href=\"../../Home/Detail?id=" + products[j].Id + " \">";



                                row += "<img src=\"" + products[j].Anh_minh_hoa + "\" />"; ;

                                row += "</a>";
                                row += "<h2>";
                                row += "<a href=\"../../Home/Detail?id=" + products[j].Id + " \">" + products[j].Name + "</a>";
                                row += "</h2>";
                                row += "</li>";
                                
                                    
                            }
                        }


                    }

                    else
                    {

                        box += "<div class=\"title-box\">";
                        box += "<span>" + category[i].Name + "</span>";
                        box += "</div>";
                        box += "<div class=\"clear\"></div>";
                        box += "<div class=\"box-1\">";

                        for (int j = 0; j < products.Count; j++)
                        {

                            if (j == 0)
                            {
                                box += "<div class=\"box-left\">";
                                box += "<a href=\"../../Home/Detail?id=" + products[j].Id + "\">";
                                box += "<img class=\"attachment-anhlonhome wp-post-image\" width=\"300\" height=\"250\" alt=\"toi\" src=\"" + products[j].Anh_minh_hoa + "\" />";
                                box += "</a>";

                                box += "<h2>";

                                box += "<a href=\"../../Home/Detail?id=" + products[j].Id + " \">" + products[j].Name + "</a>";
                                box += "<h2/>";



                                box += "<p>";

                                box += a.layChuoi(products[j].Mo_ta, 150);
                                box += "<p/>";
                                box += "</div>";

                            }
                            else if (j < 5)
                            {
                                box += "<div class=\"box-right\">";
                                box += "<div class=\"box-right-box\">";
                                box += "<ul>";
                                box += "<li class=\"chuabaianhnho\">";
                                box += "<a href=\"../../Home/Detail?id=" + products[j].Id + "\">";
                                box += "<img class=\"attachment-anhdaidien wp-post-image\" width=\"100\" height=\"100\" alt=\"ngua ung thu\"src=\"" + products[j].Anh_minh_hoa + "\" /> ";
                                box += " </a>";
                                box += "<h2 class=\"titlebaianhnho\">";
                                box += "<a href=\"../../Home/Detail?id=" + products[j].Id + " \">" + products[j].Name + "</a>";
                                box += "</h2>";
                                box += "<p class=\"motabaianhnho\">";
                                
                                
                                     
                                   box += a.layChuoi (products[j].Mo_ta,150);
                                   
                               
                                box += "</p>";
                                box += " </li>";
                                box += "</ul>";
                                box += "</div>";
                                box += "</div>";
                            }
                        }
                        box += "</div>";
                        box += "<div class=\"clear\"></div>";
                    }

                }
            }
                ViewBag.View = chuoi;
                ViewBag.sang = dong;
                ViewBag.row = row;
                ViewBag.dm = dm;
                ViewBag.box = box;
                ViewBag.dn = dn;
                return PartialView();
            }
     
        public ActionResult Tinlienquan()
        {
            var query = context.Noi_dung.Take(20).ToList();

            return PartialView(query);
        }


    }
}
