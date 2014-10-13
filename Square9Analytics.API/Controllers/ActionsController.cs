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


        //Actions Route
        [ActionName("GetData")]
        public HttpResponseMessage GetData(string startdate, string endDate, string action, string username = "")
        {
            try
            {
                Analytics getNumOfDocs = new Analytics(); //DEPRICATED
                DateTime StartdateValue;
                DateTime EnddateValue;

                //Validates the startdate and endDate strings as a dates
                if (DateTime.TryParse(startdate, out StartdateValue) && DateTime.TryParse(endDate, out EnddateValue))
                {
                    AuditAction InputAction = AuditAction.Indexed;
                    switch (action.ToLower())
                    {
                        case "indexed":
                            InputAction = AuditAction.Indexed;
                            break;
                        case "annotationupdate":
                            InputAction = AuditAction.AnnotationUpdate;
                            break;
                        case "emailed":
                            InputAction = AuditAction.Emailed;
                            break;
                        case "printed":
                            InputAction = AuditAction.Printed;
                            break;
                        case "deleted":
                            InputAction = AuditAction.Deleted;
                            break;
                        case "viewed":
                            InputAction = AuditAction.Viewed;
                            break;
                        case "overthrowpete":
                            Random rnd = new Random();
                            int OverThrown = rnd.Next(1, 11);
                            if (OverThrown == 10)
                            {
                                return Request.CreateErrorResponse(HttpStatusCode.OK, "You successfully took Pete's throne!");
                            }
                            else
                            {
                                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Your attempt to overthrow Pete was in vain.");
                            }
                        default:
                            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "An invalid action was entered.");
                    }

                    float docCount = getNumOfDocs.getActionCount(StartdateValue, EnddateValue, InputAction); //need the object to pass startdate and enddate to
                    //AuditLog DataReturn = new AuditLog(getAuditLog(StartdateValue, enddateValue, InputAction, username));

                    //var jsonDataReturn = JsonConvert.SerializeObject<Dictionary<string, dynamic>>(DataReturn);

                    if (username == "")
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, docCount); //docCount to be replaced by jsonDataReturn
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, username + " has been accepted.");
                    }
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