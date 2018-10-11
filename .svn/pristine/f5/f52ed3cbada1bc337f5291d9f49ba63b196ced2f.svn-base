using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using COPDAPI.Filters;
using COPDAPI.Models;
using Newtonsoft.Json;
using System.Web;
using System.Data;
using System.Web.Http.Cors;


namespace COPDAPI.Controllers.DC
{
    [AuthenticateFilter]
    [ActionFilters]
    [RoutePrefix("api/DiagnosticCenter")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DCController : ApiController
    {

        static readonly IDCService objDCService = new DCServices();

        [CustomAuthenticate]
        [Route("{AddDC}")]
        [HttpPost]        
        public string SaveDiagnosticCenter([FromBody] DCClaimRequest objDCRequest)
        {
            objDCRequest.Token = HttpContext.Current.Request.Headers["Token"].ToString();
            objDCRequest.IP = HttpContext.Current.Request.UserHostAddress;
            DataTable objdt = objDCService.SaveDiagnosticCenter(objDCRequest);
            return JsonConvert.SerializeObject(objdt);
        }


        [Route("Report")]
        [HttpPost]
        public string AddReport()
        {
            objDCService.SaveReport();
            return "success";
        }

        
    }
}
