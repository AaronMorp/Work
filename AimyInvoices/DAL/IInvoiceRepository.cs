﻿using AimyInvoices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace AimyInvoices.DAL
{
    interface IInvoiceRepository
    {
        IEnumerable<Invoice> SelectAll();
        Invoice SelectById(int Id);
        void Insert(Invoice obj);
        void Update(Invoice obj);
        void Delete(int Id);
        void Save();
        void AddInvoice(CreateInvoiceModel model);
        IEnumerable<Invoice> Search(string searchNames);
        IEnumerable<ParentChildViewModel> GetInformation();

    }
}
