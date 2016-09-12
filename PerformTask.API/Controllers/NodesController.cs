using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PerformTask.API.Controllers
{
    public class NodesController : ApiController
    {

        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok();
        }


        [HttpPost]
        public IHttpActionResult Add([FromBody] string node)
        {

            return Ok();
        }
    }
}
