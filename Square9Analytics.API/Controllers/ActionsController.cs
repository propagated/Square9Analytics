using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Square9Analytics.Logic;
using Square9Analytics.Objects;
using Newtonsoft.Json;

namespace Square9Analytics.Controllers
{
    /// <summary>
    /// API Endpoint for action-based analytics data requests.
    /// </summary>
    public class ActionsController : AnalyticsController
    {
        // GET api/actions
        [ActionName("Hello")]
        public HttpResponseMessage GetSomething()
        {
            return Request.CreateResponse(HttpStatusCode.OK, 7);
        }

        //Indexed Route
        [ActionName("Indexed")]
        public HttpResponseMessage GetDocsByDay(string startdate, string endDate, string username)
        {
            try
            {
                Analytics getNumOfDocs = new Analytics();
                DateTime StartdateValue;
                DateTime EnddateValue;

                //Validates the startdate and endDate strings as a dates
                if (DateTime.TryParse(startdate, out StartdateValue) && DateTime.TryParse(endDate, out EnddateValue))
                {
                    float docCount = getNumOfDocs.getActionCount(StartdateValue, EnddateValue, AuditAction.Indexed); //need the object to pass startdate and enddate to
                    //AuditLog DataReturn = new AuditLog(getAuditLog(StartdateValue, enddateValue, AuditAction.Indexed, username));

                    //var jsonDataReturn = JsonConvert.SerializeObject<Dictionary<string, dynamic>>(DataReturn);

                    //return Request.CreateResponse(HttpStatusCode.OK, docCount); //docCount to be replaced by jsonDataReturn
                    return Request.CreateResponse(HttpStatusCode.OK, username + " has been accepted.");
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "An invalid date was entered. Please enter dates in the following format: mm/dd/yyyy");
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [ActionName("Indexed")]
        public HttpResponseMessage GetDocsByDay(string startdate, string endDate)
        {

            try
            {
                Analytics getNumOfDocs = new Analytics();
                DateTime StartdateValue;
                DateTime EnddateValue;

                //Validates the startdate and endDate strings as a dates
                if (DateTime.TryParse(startdate, out StartdateValue) && DateTime.TryParse(endDate, out EnddateValue))
                {
                    float docCount = getNumOfDocs.getActionCount(StartdateValue, EnddateValue, AuditAction.Indexed); //need the object to pass startdate and enddate to
                    //AuditLog DataReturn = new AuditLog(getAuditLog(StartdateValue, enddateValue, AuditAction.Indexed));

                    //var jsonDataReturn = JsonConvert.SerializeObject<Dictionary<string, dynamic>>(DataReturn);

                    return Request.CreateResponse(HttpStatusCode.OK, docCount); //docCount to be replaced by jsonDataReturn
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "An invalid date was entered. Please enter dates in the following format: mm/dd/yyyy");
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
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