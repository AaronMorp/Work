﻿using AimyInvoices.Models;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace AimyInvoices.DAL
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private InvoiceContext db = null;

        public InvoiceRepository()
        {
            this.db = new InvoiceContext();
        }

        public InvoiceRepository(InvoiceContext db)
        {
            this.db = db;
        }

        public IEnumerable<Invoice> Search(string searchNames)
        {
            var searchResult = db.Invoice.Select(x => x).Where(i => i.CreatedBy.Contains(searchNames));
            return searchResult.ToList();
        }

        public IEnumerable<ParentChildViewModel> GetInformation()
        {
            var Query = (from i in db.Invoice
                        join b in db.Billing on i.BillingId equals b.Id
                        join u in db.User on b.UserId equals u.Id
                        join c in db.Contact on u.ContactId equals c.Id
               
                        where i.BillingId == b.Id
                        select new
                        {
                            FirstName = c.FirstName + " " + c.LastName,
                            MiddleName = c.MiddleName,
                            LastName = c.LastName,
                            Id = i.Id,
                            BillingId = i.BillingId,
                            Reference = i.Reference,
                            AmountDue = i.AmountDue,
                            DueDate = i.DueDate,
                            TotalAmount = i.TotalAmount,
                            InvoiceDate = i.InvoiceDate
                        }).ToList().Select(x => new ParentChildViewModel()
                              {
                            FirstName = x.FirstName + " "+ x.MiddleName + " " + x.LastName,                                             
                            Id = x.Id,
                            BillingId = x.BillingId,
                            Reference = x.Reference,
                            AmountDue = x.AmountDue,
                            DueDate = x.DueDate,
                            TotalAmount = x.TotalAmount,
                            InvoiceDate = x.InvoiceDate
                       
                                  }).ToList(); 
                                  
                return (Query.Take(50).ToList());
        }

        public void Delete(int Id)
        {
            Invoice existing = db.Invoice.Find(Id);
            db.Invoice.Remove(existing);
        }

        public void Insert(Invoice obj)
        {
            db.Invoice.Add(obj);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public IEnumerable<Invoice> SelectAll()
        {
            return db.Invoice.Take(50).ToList();
        }

        public Invoice SelectById(int Id)
        {
            return db.Invoice.Find(Id);
        }

        public void Update(Invoice obj)
        {
            db.Entry(obj).State = EntityState.Modified;
        }

        public void AddInvoice(CreateInvoiceModel model)
        {
            var billingSaved = new List<Billing>();
            Billing billing;
            billing = new Billing
            {
                UserId = model.Id,
                SiteId = model.SiteId,
                OriginalCost = model.OriginalCost,
                EstimatedCost = model.EstimatedCost,
                CreatedOn = model.CreatedOn,
                UpdatedOn=model.UpdatedOn,
                IsActive=model.IsActive,
                CreatedBy=model.CreatedBy,
                UpdatedBy=model.UpdatedBy
            };
            billingSaved.Add(billing);
            db.Billing.Add(billing);
            var billingId = billing.Id;

            var invoiceDetails = new Invoice
            {
                BillingId = billingId,
                Email = model.Email,
                StatusId=model.StatusId,
                IsActive=model.IsActive,
                Reference = model.Reference,
                Description = model.Description,
                DueDate = model.DueDate,
                PeriodEnd = model.PeriodEnd,
                PeriodStart = model.PeriodStart,
                InvoiceDate = model.InvoiceDate,
                TotalAmount = model.TotalAmount   ,
                CreatedBy=model.CreatedBy,
                UpdatedBy=model.UpdatedBy,
                CreatedOn=model.CreatedOn,
                UpdatedOn=model.UpdatedOn,
                AmountDue=model.Due
            };
            db.Invoice.Add(invoiceDetails);

            var invoiceId = invoiceDetails.Id;
            var lines = model.InvoiceLine;

            if(lines != null) { 
            var invoiceLines = new List<InvoiceLine>();
                {
                    foreach (var line in lines)
                    {
                        var invoiceLine = new InvoiceLine
                        {
                            InvoiceId = invoiceId,
                            Amount = line.Amount,
                            IsActive = model.IsActive,
                            CreatedBy = model.CreatedBy,
                            UpdatedBy = model.UpdatedBy,
                            CreatedOn = model.CreatedOn,
                            UpdatedOn = model.UpdatedOn,
                            Description = line.Description,
                            Quantity = line.Quantity,
                            UnitPrice = line.UnitPrice,
                            
                        };
                        invoiceLines.Add(invoiceLine);
                        invoiceDetails.InvoiceLines.Add(invoiceLine);
                        db.Entry(model).State = EntityState.Modified;
                        db.SaveChanges();
                      
                    }
                    
                }
               
            }
           

        }
    }
}
