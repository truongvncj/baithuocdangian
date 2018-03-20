using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using baithuocdangian.Models;

namespace baithuocdangian.Controllers.Admin.Quanly.Cauhinh
{
    public class ConfigController : Controller
    {
        // GET: Config
        thuocdangianEntities db = new thuocdangianEntities();

        public ActionResult Index()
        {
            if (Session["ten"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            if (Request.Cookies["Username"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            IList<tbl_Config> _lConfig = db.tbl_Config.ToList();

            return View(_lConfig);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Index(FormCollection fc)
        {
            string content = fc["Content"].ToString(); // Lấy chuỗi của cái textarea nhé.
            db.tbl_Config.First().Thontin_coppy = content; // Vì bảng này của mình chỉ có 1 thằng(1 bản ghi). Nên mình chỉ cần .First() là lấy đc. k cần id của nó,thế Fisrt là gì ,anh nói kĩ hơn em phát nào. First là thằng đầu tiên. @@,rồi,ok. sửa luôn a lấy bài
            db.SaveChanges();
            IList<tbl_Config> _lConfig = db.tbl_Config.ToList(); // Truyền lại về cho view 1 list. Vì view nhận model là 1 list nên phải truyền 1 list.
            return View(_lConfig);
        }
    }
    
}