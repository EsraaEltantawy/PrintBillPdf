﻿using PrintBillPdf.Models;
using Rotativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrintBillPdf.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        public ActionResult Index()
        {
            List<Customer> OrderAndCustomerList = db.Customers.ToList();
            return View(OrderAndCustomerList);
        }


        public ActionResult SaveOrder(string name, String address, Order[] order)
        {
            string result = "Error! Order Is Not Complete!";
            if (name != null && address != null && order != null)
            {
                var cutomerId = Guid.NewGuid();
                Customer model = new Customer();
                model.CustomerId = cutomerId;
                model.Name = name;
                model.Address = address;
                model.OrderDate = DateTime.Now;
                db.Customers.Add(model);

                foreach (var item in order)
                {
                    var orderId = Guid.NewGuid();
                    Order O = new Order();
                    O.OrderId = orderId;
                    O.ProductName = item.ProductName;
                    O.Quantity = item.Quantity;
                    O.Price = item.Price;
                    O.Amount = item.Amount;
                    O.CustomerId = cutomerId;
                    db.Orders.Add(O);
                }
                db.SaveChanges();
                result = "Success! Order Is Complete!";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
  public ActionResult PrintPDF(Guid id)
        {

            var Data = db.Orders.Where(x=>x.CustomerId==id);
            return new PartialViewAsPdf("_JobPrint", Data)
            {
                FileName = "TestPartialViewAsPdf.pdf"
            };
        }

        public ActionResult About()
        {
            List<Order> OrderAndCustomerList = db.Orders.ToList();
            return View(OrderAndCustomerList);
        }


        public ActionResult PrintPDFAll()
        {

            var Data = db.Orders.ToList();
            return new PartialViewAsPdf("_JobPrintAll", Data)
            {
                FileName = "TestPartialViewAsPdf.pdf"
            };
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}