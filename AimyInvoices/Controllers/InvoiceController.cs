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
        public ActionResult AddInvoice(CreateInvoiceModel model)
        {
            if (ModelState.IsValid)
            {
                repository.AddInvoice(model);
                repository.Save();

            }
            return RedirectToAction("Index");
        }
        //[HttpPost]
        //public ActionResult AddInvoice(CreateInvoiceModel model)
        //{
        //    InvoiceContext _db = new InvoiceContext();
        //    if (ModelState.IsValid)
        //    {
        //        var billingSaved = new List<Billing>();
        //        Billing billing;
        //        billing = new Billing
        //        {
        //            UserId = model.Id,
        //            SiteId = model.SiteId,
        //            OriginalCost = model.OriginalCost,
        //            EstimatedCost = model.EstimatedCost,
        //            CreatedOn = model.CreatedOn,
        //            UpdatedOn = model.UpdatedOn,
        //            IsActive = model.IsActive,
        //            CreatedBy = model.CreatedBy,
        //            UpdatedBy = model.UpdatedBy
        //        };
        //        billingSaved.Add(billing);
        //        _db.Billing.Add(billing);
        //        var billingId = billing.Id;

        //        var invoiceDetails = new Invoice
        //        {
        //            BillingId = billingId,
        //            Email = model.Email,
        //            StatusId = model.StatusId,
        //            IsActive = model.IsActive,
        //            Reference = model.Reference,
        //            Description = model.Description,
        //            DueDate = model.DueDate,
        //            PeriodEnd = model.PeriodEnd,
        //            PeriodStart = model.PeriodStart,
        //            InvoiceDate = model.InvoiceDate,
        //            TotalAmount = model.TotalAmount,
        //            CreatedBy = model.CreatedBy,
        //            UpdatedBy = model.UpdatedBy,
        //            CreatedOn = model.CreatedOn,
        //            UpdatedOn = model.UpdatedOn,
        //            AmountDue = model.Due
        //        };
        //        _db.Invoice.Add(invoiceDetails);

        //        var invoiceId = invoiceDetails.Id;
        //        var lines = model.InvoiceLine;

        //        if (lines != null)
        //        {
        //            var invoiceLines = new List<InvoiceLine>();
        //            {
        //                foreach (var line in lines)
        //                {
        //                    var invoiceLine = new InvoiceLine
        //                    {
        //                        InvoiceId = invoiceId,
        //                        Amount = line.Amount,
        //                        IsActive = model.IsActive,
        //                        CreatedBy = model.CreatedBy,
        //                        UpdatedBy = model.UpdatedBy,
        //                        CreatedOn = model.CreatedOn,
        //                        UpdatedOn = model.UpdatedOn,
        //                        Description = line.Description,
        //                        Quantity = line.Quantity,
        //                        UnitPrice = line.UnitPrice,

        //                    };
        //                    invoiceLines.Add(invoiceLine);
        //                    invoiceDetails.InvoiceLines.Add(invoiceLine);
        //                    _db.SaveChanges();

        //                }

        //            }

        //        }

        //    }
        //    return RedirectToAction("Index");
        //}

    }
}

