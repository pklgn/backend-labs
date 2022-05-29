// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ScrumBoardWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardColumnsController : ControllerBase
    {
        // GET: api/<BoardColumnsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<BoardColumnsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BoardColumnsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BoardColumnsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BoardColumnsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
