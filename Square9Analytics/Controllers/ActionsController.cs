using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Square9Analytics.Controllers
{
    /// <summary>
    /// API Endpoint for action-based analytics data requests.
    /// </summary>
    public class ActionsController : AnalyticsController
    {
        // GET api/actions
        public HttpResponseMessage GetSomething()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Hello World");
        }

        // POST api/actions
        public HttpResponseMessage Post([FromBody]string value)
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Posted");
        }

        // DELETE api/actions/5
        public HttpResponseMessage Delete(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Deleted");
        }
    }
}