using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheWayShopProject.Models;

namespace TheWayShopProject.Controllers
{
    public class HomeController : Controller
    {
        private Model1 db = new Model1();

        public ActionResult IndexCustomer()
        {
            return View();
        }

        public ActionResult IndexAdmin()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Admin o)
        {
            var admin = db.Admins.FirstOrDefault(x => x.ADMIN_NAME == o.ADMIN_NAME && x.ADMIN_PASSWORD == o.ADMIN_PASSWORD);
            if (admin != null)
            {
                return RedirectToAction("IndexAdmin");
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid username or password. Please try again.";
                return View();
            }
        }

        public ActionResult Feedback()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        public ActionResult DisplayProduct(int? id)
        {
            Shop s = new Shop();

            s.Cat = db.Categories.ToList();
            if (id == null)
            {
                s.Pro = db.Products.ToList();
            }
            else
            {
                s.Pro = db.Products.Where(m => m.CATEGORY_FID == id).ToList();
            }

            return View(s);
        }

        public ActionResult Cart()
        {
            return View();
        }

        public ActionResult AddToCart(int id)
        {
            List<Product> list;
            if (Session["myCart"] == null) 
            {
               list = new List<Product>();
            }
            else
            {
                list = (List<Product>)Session["myCart"];
            }

            list.Add(db.Products.Where(p => p.PRODUCT_ID == id).FirstOrDefault());
            Session["myCart"] = list;
            list[list.Count - 1].PRO_QUANTITY = 1;
           
            return RedirectToAction("Cart");

        }

        public ActionResult MinusFromCart(int RowNo)
        {
            List<Product> list = (List<Product>)Session["myCart"];
            list[RowNo].PRO_QUANTITY--;
            Session["myCart"] = list;

            return RedirectToAction("Cart");

        }

        public ActionResult PlusFromCart(int RowNo)
        {
            List<Product> list = (List<Product>)Session["myCart"];
            list[RowNo].PRO_QUANTITY++;
            Session["myCart"] = list;

            return RedirectToAction("Cart");

        }

        public ActionResult RemoveFromCart(int RowNo)
        {
            List<Product> list = (List<Product>)Session["myCart"];
            list.RemoveAt(RowNo);
            Session["myCart"] = list;

            return RedirectToAction("Cart");
        }


        public ActionResult PayNow(ORDER o)
        {
            o.ORDER_DATE = System.DateTime.Now;
            o.ORDER_STATUS = "Paid";
            o.ORDER_TYPE = "Sale";
            Session["Order"] = o;

            return Redirect("https://www.sandbox.paypal.com/cgi-bin/webscr?cmd=_xclick&business=haseebullahkhan710@gmail.com&item_name=TheWayShopProduct&return=https://localhost:44362/Home/OrderBooked&amount=" + double.Parse(Session["totalAmount"].ToString())/ 300);
        }

        public ActionResult OrderBooked()
        {
            ORDER o= (ORDER)Session["Order"];

            return View();
        }
    }
}
