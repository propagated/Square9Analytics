using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Newtonsoft.Json;

namespace Square9Analytics.Controllers
{
    /// <summary>
    /// Parent Class for other controllers. Put shared controller or misc endpoints here.
    /// </summary>
    public class AnalyticsController : ApiController
    {
        // GET api/users
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Retrieved");
        }
    }
}
