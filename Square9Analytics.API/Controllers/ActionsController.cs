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
        public HttpResponseMessage GetIndexed(string startdate, string endDate, string username)
        {
            try
            {
                Analytics getNumOfDocs = new Analytics(); //DEPRICATED
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
        public HttpResponseMessage GetIndexed(string startdate, string endDate)
        {

            try
            {
                Analytics getNumOfDocs = new Analytics(); //DEPRICATED
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


        //AnnotationUpdate Route
        [ActionName("AnnotationUpdate")]
        public HttpResponseMessage GetAnnotations(string startdate, string endDate, string username)
        {
            try
            {
                Analytics getNumOfDocs = new Analytics(); //DEPRICATED
                DateTime StartdateValue;
                DateTime EnddateValue;

                //Validates the startdate and endDate strings as a dates
                if (DateTime.TryParse(startdate, out StartdateValue) && DateTime.TryParse(endDate, out EnddateValue))
                {
                    float docCount = getNumOfDocs.getActionCount(StartdateValue, EnddateValue, AuditAction.AnnotationUpdate); //need the object to pass startdate and enddate to
                    //AuditLog DataReturn = new AuditLog(getAuditLog(StartdateValue, enddateValue, AuditAction.AnnotationUpdate, username));

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

        [ActionName("AnnotationUpdate")]
        public HttpResponseMessage GetAnnotations(string startdate, string endDate)
        {
            try
            {
                Analytics getNumOfDocs = new Analytics(); //DEPRICATED
                DateTime StartdateValue;
                DateTime EnddateValue;

                //Validates the startdate and endDate strings as a dates
                if (DateTime.TryParse(startdate, out StartdateValue) && DateTime.TryParse(endDate, out EnddateValue))
                {
                    float docCount = getNumOfDocs.getActionCount(StartdateValue, EnddateValue, AuditAction.AnnotationUpdate); //need the object to pass startdate and enddate to
                    //AuditLog DataReturn = new AuditLog(getAuditLog(StartdateValue, enddateValue, AuditAction.AnnotationUpdate));

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


        //Emailed Route
        [ActionName("Emailed")]
        public HttpResponseMessage GetEmailed(string startdate, string endDate, string username)
        {
            try
            {
                Analytics getNumOfDocs = new Analytics(); //DEPRICATED
                DateTime StartdateValue;
                DateTime EnddateValue;

                //Validates the startdate and endDate strings as a dates
                if (DateTime.TryParse(startdate, out StartdateValue) && DateTime.TryParse(endDate, out EnddateValue))
                {
                    float docCount = getNumOfDocs.getActionCount(StartdateValue, EnddateValue, AuditAction.Emailed); //need the object to pass startdate and enddate to
                    //AuditLog DataReturn = new AuditLog(getAuditLog(StartdateValue, enddateValue, AuditAction.Emailed, username));

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

        [ActionName("Emailed")]
        public HttpResponseMessage GetEmailed(string startdate, string endDate)
        {
            try
            {
                Analytics getNumOfDocs = new Analytics(); //DEPRICATED
                DateTime StartdateValue;
                DateTime EnddateValue;

                //Validates the startdate and endDate strings as a dates
                if (DateTime.TryParse(startdate, out StartdateValue) && DateTime.TryParse(endDate, out EnddateValue))
                {
                    float docCount = getNumOfDocs.getActionCount(StartdateValue, EnddateValue, AuditAction.Emailed); //need the object to pass startdate and enddate to
                    //AuditLog DataReturn = new AuditLog(getAuditLog(StartdateValue, enddateValue, AuditAction.Emailed));

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


        //Printed Route
        [ActionName("Printed")]
        public HttpResponseMessage GetPrinted(string startdate, string endDate, string username)
        {
            try
            {
                Analytics getNumOfDocs = new Analytics(); //DEPRICATED
                DateTime StartdateValue;
                DateTime EnddateValue;

                //Validates the startdate and endDate strings as a dates
                if (DateTime.TryParse(startdate, out StartdateValue) && DateTime.TryParse(endDate, out EnddateValue))
                {
                    float docCount = getNumOfDocs.getActionCount(StartdateValue, EnddateValue, AuditAction.Printed); //need the object to pass startdate and enddate to
                    //AuditLog DataReturn = new AuditLog(getAuditLog(StartdateValue, enddateValue, AuditAction.Printed, username));

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

        [ActionName("Printed")]
        public HttpResponseMessage GetPrinted(string startdate, string endDate)
        {
            try
            {
                Analytics getNumOfDocs = new Analytics(); //DEPRICATED
                DateTime StartdateValue;
                DateTime EnddateValue;

                //Validates the startdate and endDate strings as a dates
                if (DateTime.TryParse(startdate, out StartdateValue) && DateTime.TryParse(endDate, out EnddateValue))
                {
                    float docCount = getNumOfDocs.getActionCount(StartdateValue, EnddateValue, AuditAction.Printed); //need the object to pass startdate and enddate to
                    //AuditLog DataReturn = new AuditLog(getAuditLog(StartdateValue, enddateValue, AuditAction.Printed));

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


        //Deleted Route
        [ActionName("Deleted")]
        public HttpResponseMessage GetDeleted(string startdate, string endDate, string username)
        {
            try
            {
                Analytics getNumOfDocs = new Analytics(); //DEPRICATED
                DateTime StartdateValue;
                DateTime EnddateValue;

                //Validates the startdate and endDate strings as a dates
                if (DateTime.TryParse(startdate, out StartdateValue) && DateTime.TryParse(endDate, out EnddateValue))
                {
                    float docCount = getNumOfDocs.getActionCount(StartdateValue, EnddateValue, AuditAction.Deleted); //need the object to pass startdate and enddate to
                    //AuditLog DataReturn = new AuditLog(getAuditLog(StartdateValue, enddateValue, AuditAction.Deleted, username));

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

        [ActionName("Deleted")]
        public HttpResponseMessage GetDeleted(string startdate, string endDate)
        {
            try
            {
                Analytics getNumOfDocs = new Analytics(); //DEPRICATED
                DateTime StartdateValue;
                DateTime EnddateValue;

                //Validates the startdate and endDate strings as a dates
                if (DateTime.TryParse(startdate, out StartdateValue) && DateTime.TryParse(endDate, out EnddateValue))
                {
                    float docCount = getNumOfDocs.getActionCount(StartdateValue, EnddateValue, AuditAction.Deleted); //need the object to pass startdate and enddate to
                    //AuditLog DataReturn = new AuditLog(getAuditLog(StartdateValue, enddateValue, AuditAction.Deleted));

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


        //Viewed Route
        [ActionName("Viewed")]
        public HttpResponseMessage GetViewed(string startdate, string endDate, string username)
        {
            try
            {
                Analytics getNumOfDocs = new Analytics(); //DEPRICATED
                DateTime StartdateValue;
                DateTime EnddateValue;

                //Validates the startdate and endDate strings as a dates
                if (DateTime.TryParse(startdate, out StartdateValue) && DateTime.TryParse(endDate, out EnddateValue))
                {
                    float docCount = getNumOfDocs.getActionCount(StartdateValue, EnddateValue, AuditAction.Viewed); //need the object to pass startdate and enddate to
                    //AuditLog DataReturn = new AuditLog(getAuditLog(StartdateValue, enddateValue, AuditAction.Viewed, username));

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

        [ActionName("Viewed")]
        public HttpResponseMessage GetViewed(string startdate, string endDate)
        {
            try
            {
                Analytics getNumOfDocs = new Analytics(); //DEPRICATED
                DateTime StartdateValue;
                DateTime EnddateValue;

                //Validates the startdate and endDate strings as a dates
                if (DateTime.TryParse(startdate, out StartdateValue) && DateTime.TryParse(endDate, out EnddateValue))
                {
                    float docCount = getNumOfDocs.getActionCount(StartdateValue, EnddateValue, AuditAction.Viewed); //need the object to pass startdate and enddate to
                    //AuditLog DataReturn = new AuditLog(getAuditLog(StartdateValue, enddateValue, AuditAction.Viewed));

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