using DemoShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoShoppingCart.Controllers
{
    public class CartController : Controller
    {
        //
        // GET: /Cart/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add(int? Id)
        {
            ShoppingCart.Cart.Add(Id);
            var info = new
            {
                ShoppingCart.Cart.Count,
                ShoppingCart.Cart.Amout
            };
            return Json(info, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Update(int? Id)
        {
            foreach (var p in ShoppingCart.Cart.Items)
            {
                var id = p.Id.ToString();
                p.Quantity = int.Parse(Request[id]);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Remove(int? Id)
        {
            ShoppingCart.Cart.Remove(Id);
            var info = new
            {
                ShoppingCart.Cart.Count,
                ShoppingCart.Cart.Amout
            };
            return Json(info, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Clear()
        {
            ShoppingCart.Cart.Clear();
            return RedirectToAction("Index");
        }
    }
}