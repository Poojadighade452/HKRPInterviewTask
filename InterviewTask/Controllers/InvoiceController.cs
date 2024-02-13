using InterviewTask.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InterviewTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        InvoiceDBContext _db;
        public InvoiceController(InvoiceDBContext db)
        {
            _db = db;

        }
        [HttpGet]
        public IActionResult GetAllInvoices()
        {

            var model = _db.Invoices.ToList();
            return Ok(model);

        }
        [HttpPost]
        public IActionResult CreateInvoices(Invoice invoice)
        {
            try
            {
                _db.Invoices.Add(invoice);
                _db.SaveChanges();
                return Ok(invoice);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public IActionResult UpdateInvoices( Invoice invoice)
        {
            try
            {
                if (invoice == null || invoice.InvoiceID == 0)
                {
                    if (invoice == null)
                    {
                        return BadRequest("Customer data is invaid");
                    }
                    else if (invoice.InvoiceID == 0)

                    {
                        return BadRequest("Customer id  is invalid");
                    }
                }
                var customer = _db.Invoices.Find(invoice.InvoiceID);
                if (customer == null)
                {
                    return NotFound($"Customer Not found with id {invoice.InvoiceID}");
                }
                customer.CustomerName = invoice.CustomerName;
                customer.MobileNumber = invoice.MobileNumber;
                customer.InvoiceNumber= invoice.InvoiceNumber;
                customer.ActualAmount = invoice.ActualAmount;
                customer.Discount = invoice.Discount;
                customer.PaidAmount = invoice.PaidAmount;
                customer.PaymentMode = invoice.PaymentMode;


                _db.SaveChanges();
                return Ok(invoice);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                var customer = _db.Invoices.Find(id);
                if (customer == null)
                {
                    return NotFound($"Customer not found with id {id}");
                }
                _db.Invoices.Remove(customer);
                _db.SaveChanges();

                return Ok("Customer details delete successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }  

       
}
