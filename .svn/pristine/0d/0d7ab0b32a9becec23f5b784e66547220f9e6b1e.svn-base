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
using COPDAPI.Controllers.DCClaim;

namespace COPDAPI.Controllers
{
    [AuthenticateFilter]
    [ActionFilters]
    [RoutePrefix("api/DCClaim")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DCClaimController : ApiController
    {

        static readonly IDCClaimService objDCService = new DCClaimService();

        [CustomAuthenticate]
        [Route("DCClaim")]
        [HttpPost]
        public string SaveDCClaim([FromBody] DiagnosticCenterClaim objDC)
        {
            objDC.Token = HttpContext.Current.Request.Headers["Token"].ToString();
            objDC.IP = HttpContext.Current.Request.UserHostAddress;
            DataTable objdt = objDCService.SaveDCClaim(objDC);
            return JsonConvert.SerializeObject(objdt);
        }

      
    }
}