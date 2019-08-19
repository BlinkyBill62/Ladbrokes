using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ladbrokes.Models;
using System.Collections;

namespace Ladbrokes.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private string service;
        private bool expected;

        public ValuesController(string service)
        {
            this.service = service;
        }

        public ValuesController(bool expected)
        {
            this.expected = expected;
        }

       // GET api/values
       [HttpGet]
        public bool Get()
        {
            List<int> message = PopulateMessage("1,2,0,7,4,4,0");
            return CheckMessage(message, PopulateMessage(""));
        }
     

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet("{codename}")]
        public bool Get(string codename)
        {
            List<int> message = PopulateMessage("1,2,4,0,0,7,5");
            return CheckMessage(message, PopulateMessage(codename));

        }


        [HttpGet("{codename}")]
        public bool Get(List<int> codename)
        {
            List<int> message = PopulateMessage("1,2,4,0,0,7,5");
            return CheckMessage(message, codename);

        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        public List<int> PopulateMessage(string message)
        {
            List<int> listmessage = new List<int>();
            try
            {
                listmessage = message.Split(',').Select(Int32.Parse).ToList();
            }
            catch
            {
                listmessage.Add(0);
            }
            return listmessage;
        }

        public bool CheckMessage(List<int> message, List<int> codename)
        {
            int i1 = 0;
            int validity = 0;

            for (int i2 = 0; i2 < message.Count; i2++)
            {
                if (message[i2] == codename[i1])
                {
                    validity = validity + 1;
                    if (i1 < codename.Count - 1) { i1 = i1 + 1; }
                }
            }
            if (validity == codename.Count) { return true; } else { return false; }
        }

    }
}
