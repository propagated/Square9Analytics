using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Square9Analytics.Logic;
using Square9Analytics.Objects;

namespace Square9Analytics.Controllers
{
    /// <summary>
    /// API Endpoint for action-based analytics data requests.
    /// </summary>
    public class ActionsController : AnalyticsController
    {
        // GET api/actions
        [ActionName("hello")]
        public HttpResponseMessage GetSomething()
        {
            return Request.CreateResponse(HttpStatusCode.OK, 7);
        }

        [ActionName("indexed")]
        public HttpResponseMessage GetDocsByDay(string startdate, string endDate)
        {
            Analytics getNumOfDocs = new Analytics();
            DateTime StartdateValue;
            DateTime EnddateValue;

            //Validates the startdate and endDate strings as a dates
            if (DateTime.TryParse(startdate, out StartdateValue) && DateTime.TryParse(endDate, out EnddateValue))
            {
                Int32 docCount = getNumOfDocs.getActionCount(StartdateValue, EnddateValue, AuditEntry.DocumentIndexed); //need the object to pass startdate and enddate to

                return Request.CreateResponse(HttpStatusCode.OK, docCount);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "An invalid date was entered. Please enter dates in the following format: mm/dd/yyyy");
            }
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