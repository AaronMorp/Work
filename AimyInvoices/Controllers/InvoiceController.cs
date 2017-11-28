using AimyInvoices.DAL;
using AimyInvoices.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Dynamic;
using System;

namespace AimyInvoices.Controllers
{
    public class InvoiceController : Controller
    {
        private IInvoiceRepository repository = null;
        public InvoiceController()
        {
            this.repository = new InvoiceRepository();
        }

        public void InvoicesController(InvoiceRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult Index()
        {
            // List<Invoice> model = (List<Invoice>)repository.SelectAll();
            // MultipleModel mymodel = new MultipleModel();
            // mymodel.Billings = repository.GetBilling();
            // mymodel.Children = repository.GetChild();
            // mymodel.Invoices = repository.SelectAll();
            List<ParentChildViewModel> model = (List<ParentChildViewModel>)repository.GetInformation();
            return View(model);
        }

        public ActionResult New()
        {
            return View();
        }

        public ActionResult Insert(Invoice obj)
        {
            repository.Insert(obj);
            try
            {
                repository.Save();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting
                        // the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
            return View();
        }

        public ActionResult Edit(int Id)
        {
            Invoice existing = repository.SelectById(Id);
            return View(existing);
        }

        public ActionResult Update(Invoice obj)
        {
            repository.Update(obj);
            repository.Save();
            return View();
        }

        public ActionResult ConfirmDelete(int Id)
        {
            Invoice existing = repository.SelectById(Id);
            return View(existing);
        }

        public ActionResult Delete(int Id)
        {
            repository.Delete(Id);
            repository.Save();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int Id)
        {
            Invoice names = repository.SelectById(Id);
            return View(names);
        }

        [HttpGet]
        public ActionResult Search(string searchNames)
        {
            var result = repository.Search(searchNames);
            var list = JsonConvert.SerializeObject(result,
                Formatting.None,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                });
            return Json(list, JsonRequestBehavior.AllowGet);
        }

       [HttpPost]
       public ActionResult Create(ParentChildViewModel model, int Id)
        {
            repository.AddInvoice(model, Id);
            repository.Save();
            return Json(model);
        }

    }
}

