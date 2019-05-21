using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeCRUD.Models.DBModel;
namespace EmployeeCRUD.Controllers
{
    public class ProductController : Controller
    {
        private MyShopEntities db = null;

        public ProductController()
        {
            db = new MyShopEntities();
        }
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult GetAllPrroduct()
        {
            List<Product> products = null;
            try
            {
                products = db.Products.ToList();
            }
            catch { }

            return Json(products, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult GetPrroductbyId(int id)
        {
            Product product = null;
            try
            {
                product = db.Products.Find(id);
            }
            catch { }

            return Json(product, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddProduct()
        {
            return View();
        }


        [HttpPost]
        public JsonResult AddProduct(Product model)
        {
            string resultMSg = null;
            try
            {
                if (!model.Equals(null))
                {
                    db.Products.Add(model);
                    int resultId = db.SaveChanges();
                    resultMSg = resultId > 0 ? "Data Saved Successfully!" : "Data Saved Failed!";
                }
            }
            catch (Exception ex){ resultMSg = ex.Message; }
            return Json(resultMSg, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateProduct(Product model)
        {
            string resultMSg = null;
            try
            {
                if (!model.Equals(null))
                {
                    Product selectedProduct = db.Products.Find(model.Id);
                    selectedProduct.Name = model.Name;
                    selectedProduct.Price = model.Price;
                    selectedProduct.ProductCatagoryId = model.ProductCatagoryId;
                    int resultId = db.SaveChanges();
                    resultMSg = resultId > 0 ? "Data Updated Successfully!" : "Data Update Failed!";
                }
            }
            catch (Exception ex) { resultMSg = ex.Message; }
            return Json(resultMSg, JsonRequestBehavior.AllowGet);
        }

    }
}