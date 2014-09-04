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
        public HttpResponseMessage GetSomething()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Hello World");
        }

        public HttpResponseMessage GetDocsByDay(string startdate, string endDate)
        {
                Analytics getNumOfDocs = new Analytics();
                DateTime StartdateValue;
                DateTime EnddateValue;
                //validates the start date string as a date

                if (DateTime.TryParse(startdate, out StartdateValue))
                {
                //validates the end date string as a date
                    if (DateTime.TryParse(endDate, out EnddateValue))
                    {

                        getNumOfDocs.getActionCount(StartdateValue, EnddateValue, AuditEntry.DocumentIndexed); //need the object to pass startdate and enddate to
                        return Request.CreateResponse(HttpStatusCode.OK, "Correctly entered if statement with valid date and the number of documents indexed is " + getNumOfDocs);
                        //----->return Request.CreateResponse(HttpStatusCode.OK, "startdate = " + StartdateValue + " and endDate = " + EnddateValue);
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid end date please enter dates in the following format: mm/dd/yyyy");
                    }

            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid start date please enter dates in the following format: mm/dd/yyyy");
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