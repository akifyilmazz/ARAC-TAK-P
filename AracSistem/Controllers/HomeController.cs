using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AracSistem.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        #region Faturalar
        public ActionResult invoices()
        {
            return View("invoices/invoices");
        }
        #region Fatura Ekle
        public ActionResult addInvoices()
        {
            return View("invoices/addInvoices/addInvoices");
        }
        #endregion
        #region Faturalar
        public ActionResult updateInvoices()
        {
            return View("invoices/updateInvoices/updateInvoices");
        }
        #endregion
        #endregion

        #region Musteriler
        public ActionResult Customers()
        {
            return View("Customers/Customers");
        }
        #region Musteri Ekle
        public ActionResult addCustomer()
        {
            return View("Customers/addCustomer/addCustomer");
        }
        #endregion
        #region Müsteri Guncelle
        public ActionResult updateCustomer()
        {
            return View("Customers/updateCustomer/updateCustomer");
        }
        #endregion
        #endregion

        #region Stoklar
        public ActionResult Stocks()
        {
            return View("Stocks/Stocks");
        }
        #region Stok Ekle
        public ActionResult addStocks()
        {
            return View("Stocks/addStocks/addStocks");
        }
        #endregion
        #region Stok Guncelle
        public ActionResult updateStocks()
        {
            return View("Stocks/updateStocks/updateStocks");
        }
        #endregion
        #endregion

        #region Araclar
        public ActionResult Cars()
        {
            return View("Cars/Cars");
        }
        #region Arac Ekle
        public ActionResult addCars()
        {
            return View("Cars/addCars/addCars");
        }
        #endregion
        #region Arac Guncelle
        public ActionResult updateCars()
        {
            return View("Cars/updateCars/updateCars");
        }
        #endregion
        #endregion

        #region Arac Detay
        public ActionResult CarsDetails()
        {
            return View("CarsDetails/CarsDetails");
        }
        #endregion

        #region Stok Detay
        public ActionResult StocksDetails()
        {
            return View("StocksDetails/StocksDetails");
        }
        #endregion

        #region  Müşteri Detay
        public ActionResult CustomerDetails()
        {
            return View("CustomerDetails/CustomerDetails");
        }
        #endregion

        #region Fatura Detay
        public ActionResult invocesDetails()
        {
            return View("invocesDetails/invocesDetails");
        }
        #endregion
    }
}