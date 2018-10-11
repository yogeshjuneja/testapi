using COPDAPI.Filters;
using COPDAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Cors;

namespace COPDAPI.Controllers.Pharmacy
{
    [AuthenticateFilter]
    [ActionFilters]
    [RoutePrefix("api/Pharmacy")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PharmacyController : ApiController
    {
        static readonly IPharmacy PharmacyClaim = new PharmacyService();

        [CustomAuthenticate]
        [Route("PolicyInfo")]
        [HttpPost]
        public HttpResponseMessage PolicyDetail(PharmacyRequestObject request)
        {
            int flag = 0;
            DataSet objds = PharmacyClaim.GetPharmacyPolicyInfo(request.PolicyNumber, request.FirstName);
            if (objds.Tables.Count > 0)
            { 
                if (objds.Tables[0].Rows.Count == 0)
                {
                    if (objds.Tables[1].Rows.Count == 0)
                    {
                        flag = 1;                        
                    }
                }
                if (objds.Tables.Count > 1)
                { 
                    if (objds.Tables[1].Rows.Count == 0 && flag == 0)
                    {
                        flag = 2;                        
                    }
                } 
            }
            var jsonString = "";
            if (flag == 0)
            {
                jsonString = "{ "
                       + JsonConvert.SerializeObject("code", Formatting.Indented) + ":" + JsonConvert.SerializeObject("-200", Formatting.Indented)
                        + "," + JsonConvert.SerializeObject("Message", Formatting.Indented) + ":" + JsonConvert.SerializeObject("Policy Valid", Formatting.Indented)
                      + ","
                    + JsonConvert.SerializeObject("Response", Formatting.Indented) + ":" + JsonConvert.SerializeObject(objds, Formatting.Indented) + " }";                
            }
            else if (flag == 1)
            {
                jsonString = "{ "
                       + JsonConvert.SerializeObject("code", Formatting.Indented) + ":" + JsonConvert.SerializeObject("-100", Formatting.Indented)
                        + "," + JsonConvert.SerializeObject("Message", Formatting.Indented) + ":" + JsonConvert.SerializeObject("InValid Policy", Formatting.Indented)
                      + ","
                    + JsonConvert.SerializeObject("Response", Formatting.Indented) + ":" + JsonConvert.SerializeObject(objds, Formatting.Indented) + " }";
            }
            else if (flag == 2)
            {
                jsonString = "{ "
                       + JsonConvert.SerializeObject("code", Formatting.Indented) + ":" + JsonConvert.SerializeObject("-102", Formatting.Indented)
                        + "," + JsonConvert.SerializeObject("Message", Formatting.Indented) + ":" + JsonConvert.SerializeObject("Invalid Member FirstName", Formatting.Indented)
                      + ","
                    + JsonConvert.SerializeObject("Response", Formatting.Indented) + ":" + JsonConvert.SerializeObject(objds, Formatting.Indented) + " }";
            }

            var response = Request.CreateResponse(HttpStatusCode.OK);
         
            response.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            return response;
            //return jsonString;
        }

    }
}
