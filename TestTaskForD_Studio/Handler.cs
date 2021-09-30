using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace TestTaskForD_Studio
{
    class Handler
    {
        private static readonly string fileName = "Invoices.csv";

        public static IEnumerable<Invoice> GetAll()
        {

            var lines = File.ReadLines(fileName, Encoding.UTF8);

            return from line in lines
                   let fields = line.Split(";")
                   select new Invoice
                   {
                       DateCreation = DateTime.Parse(fields[0]),
                       InvoiceNumber = long.Parse(fields[1]),
                       InvoiceProcessingStatus = byte.Parse(fields[2]),
                       InvoiceAmount = double.Parse(fields[3]),
                       InvoicePaymentMethod = byte.Parse(fields[4])
                   }; 
        }

        public static IEnumerable<Invoice> GetById(long id)
        {
            var lines = File.ReadLines(fileName, Encoding.UTF8);

            return from line in lines
                   let fields = line.Split(";")
                   where long.Parse(fields[1]) == id
                   select new Invoice
                   {
                       DateCreation = DateTime.Parse(fields[0]),
                       InvoiceNumber = long.Parse(fields[1]),
                       InvoiceProcessingStatus = byte.Parse(fields[2]),
                       InvoiceAmount = double.Parse(fields[3]),
                       InvoicePaymentMethod = byte.Parse(fields[4])
                   };
        }

        public static void Add(List<Invoice> invoice)
        {
            var ls = GetAll();
            var maxId = from l in ls
                        select ls.Max(x=> x.InvoiceNumber);

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
            };
            using (var stream = File.Open(fileName, FileMode.Append))
            using (var writer = new StreamWriter(stream))
            using (var csv = new CsvWriter(writer, config))
            {
                csv.WriteRecords(invoice);
            }
        }

        public static void Change(List<Invoice> invoice, long id)
        {

        }
    }
}
