using System.Collections.Generic;
using System.Linq;

namespace TestTaskForD_Studio
{
    public class Sorting
    {

        public static IEnumerable<Invoice> Sort(List<Invoice> invoices, string sortValue, string sortMethod)
        {
            List<Invoice> ls = new List<Invoice>();

            if (sortMethod == "asc") //Ascending ^
            {
                if (sortValue == "DateCreation")
                {
                    ls = invoices.OrderBy(i => i.DateCreation).ToList();
                }
                else if (sortValue == "InvoiceNumber")
                {
                    ls = invoices.OrderBy(i => i.InvoiceNumber).ToList();
                }
                else if (sortValue == "InvoiceProcessingStatus")
                {
                    ls = invoices.OrderBy(i => i.InvoiceProcessingStatus).ToList();
                }
                else if (sortValue == "InvoiceAmount")
                {
                    ls = invoices.OrderBy(i => i.InvoiceAmount).ToList();
                }
                else if (sortValue == "InvoicePaymentMethod")
                {
                    ls = invoices.OrderBy(i => i.InvoicePaymentMethod).ToList();
                }
                else
                {
                }
            }
            else if (sortMethod == "desc") //Descending v
            {
                if (sortValue == "DateCreation")
                {
                    ls = invoices.OrderByDescending(i => i.DateCreation).ToList();
                }
                else if (sortValue == "InvoiceNumber")
                {
                    ls = invoices.OrderByDescending(i => i.InvoiceNumber).ToList();
                }
                else if (sortValue == "InvoiceProcessingStatus")
                {
                    ls = invoices.OrderByDescending(i => i.InvoiceProcessingStatus).ToList();
                }
                else if (sortValue == "InvoiceAmount")
                {
                    ls = invoices.OrderByDescending(i => i.InvoiceAmount).ToList();
                }
                else if (sortValue == "InvoicePaymentMethod")
                {
                    ls = invoices.OrderByDescending(i => i.InvoicePaymentMethod).ToList();
                }
                else
                {
                }
            }
            else
            {
            }
            return ls;       
        }
    }
}
