using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using ApplicationLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GmailController : ControllerBase
    {
        private IEmailSender sender;

        public GmailController(IEmailSender sender)
        {
            this.sender = sender;
        }

        // GET: api/Mail
        [HttpGet]
        public void Get(string email)
        {

            sender.Subject = "Registration is accept";
            sender.ToEmail = email;
            sender.Body = "Midsda";
            sender.Send();
            
        }

        // GET: api/Mail/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Mail
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Mail/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
