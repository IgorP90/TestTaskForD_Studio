using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TestTaskForD_Studio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RequestController : ControllerBase
    {

        [HttpGet("/api/invoices/")]
        public IEnumerable<Invoice> Get(string sortValue = "InvoiceNumber",string sortMethod = "asc")
        {
            var n = Handler.GetAll();
            return Sorting.Sort((List<Invoice>)n, sortValue, sortMethod);
        }

        [HttpGet("/api/invoices/{id}")]
        public IEnumerable<Invoice> Get([FromQuery]long id)
        {
            return Handler.GetById(id);
        }

        [HttpPost]
        public void Post(List<Invoice> invoice)
        {
            Handler.Add(invoice);
        }

        [HttpPut("{id}")]
        public void Put(long id, List<Invoice> invoice)
        {
            Handler.Change(invoice, id);
        }
    }
}
