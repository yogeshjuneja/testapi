
using COPDAPI.Filters;
using COPDAPI.Models;
using System.Web.Http;
using System.Data;
using Newtonsoft.Json;
using System.Net.Http;
using System.Web.Http.Cors;
using System.Net;
using System.Text;
using COPDAPI.Controllers.DoctorClaim;
using System.Web;

namespace COPDAPI.Controllers
{
    [AuthenticateFilter]
    [ActionFilters]
    [RoutePrefix("api/PolicyInfo")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PolicyInfoController : ApiController
    {
        DataTable dt = null;
        public void getDatatable()
        {
            dt = new DataTable();
            dt.Columns.Add("code", typeof(string));
            dt.Columns.Add("Message", typeof(string));
            DataRow dr = dt.NewRow();
            dr["code"] = "01";
            dr["Message"] = "Invalid Credential";
            dt.Rows.Add(dr);
        }

        //private IPolicyInfoService objIPolicyInfoService;
        //PolicyInfoService objPolicyInfoService = new PolicyInfoService();
        static readonly IPolicyInfoService objIPolicyInfoService = new PolicyInfoService();
        static readonly IDoctorClaim objIDoctorClaim = new DoctorClaimService();
        private PolicyInfoController()
        {
        }
        private PolicyInfoController(IPolicyInfoService _objIPolicyInfoService)
        {
            //this.objIPolicyInfoService = _objIPolicyInfoService;
        }

        // GET api/<controller>
        [CustomAuthenticate]
        [Route("{PolicyNumber}")]
        [HttpPost]
        // GET api/<controller>/5
        public string PolicyInfoDetails(string PolicyNumber)
        {
            DataTable objdt = objIPolicyInfoService.PolicyDetails(PolicyNumber);
            return JsonConvert.SerializeObject(objdt);
        }
        /// <summary>
        /// Created by : ASHISH SRIVASTAVA
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CustomAuthenticate]
        [Route("Mobile/{MobileNo}")]
        [HttpPost]
        public string MobileValidation(string MobileNo)
        {
            DataTable objdt = objIPolicyInfoService.ValidatePolicyDetail(MobileNo);
            return JsonConvert.SerializeObject(objdt);
        }
        /// <summary>
        /// Created by : ASHISH SRIVASTAVA
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CustomAuthenticate]
        [Route("Member/{PolicyNumber}")]
        [HttpPost]
        public string MemberDetails(string PolicyNumber)
        {
            DataTable objdt = objIPolicyInfoService.MemberDetails(PolicyNumber);
            return JsonConvert.SerializeObject(objdt);
        }
        /// <summary>
        /// Created by : ASHISH SRIVASTAVA
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CustomAuthenticate]
        [Route("MemberBenefit/{PolicyNumber}/{MemberCode}")]
        [HttpPost]
        public string MemberBenefitDetails(string PolicyNumber, string MemberCode)
        {
            DataTable objdt = objIPolicyInfoService.MemberBenefitDetails(PolicyNumber, MemberCode);
            return JsonConvert.SerializeObject(objdt);
        }

        /// <summary>
        /// Created by : ASHISH SRIVASTAVA
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CustomAuthenticate]
        [Route("MemberSum_Insured/{PolicyNumber}/{MemberCode}")]
        [HttpPost]
        public string MemberSum_Insured([FromBody] PolicyRequestObject request)
        {
            DataTable objdt = objIPolicyInfoService.MemberBenefitDetails(request.PolicyNumber, request.MemberCode);
            return JsonConvert.SerializeObject(objdt);
        }

        /// <summary>
        /// Created by : ASHISH SRIVASTAVA
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CustomAuthenticate]
        [Route("DCCoveredinfo/{PolicyNumber}/{MemberCode}")]
        [HttpPost]
        public string DCCoveredinfo(string PolicyNumber, string MemberCode)
        {
            DataTable objdt = objIPolicyInfoService.DCCoveredinfo(PolicyNumber, MemberCode);
            return JsonConvert.SerializeObject(objdt);
        }
        [CustomAuthenticate]
        [Route("DocPolicyDetails/{PolicyNumber}/{FirstName}/{doctorID}/{Insurance}/{TPAName?}")]
        [HttpPost]
        public HttpResponseMessage DocPolicyDetails(string PolicyNumber, string FirstName, string doctorID, string Insurance, string TPAName = "")
        {
            int flag = 0;
            DataSet objds = new DataSet();
            if (TPAName == "")
            {
                TPAName = Insurance;
            }
            if (Insurance == TPAName)
            {
                objds = objIPolicyInfoService.DocPolicyDetails(PolicyNumber, FirstName, doctorID, Insurance, TPAName);
            }
            else
            {
                objds = objIPolicyInfoService.DocPolicyDetailsMemberCode(PolicyNumber, FirstName, doctorID, Insurance, TPAName);
                if (objds.Tables[0].Rows.Count > 0)
                {
                    PolicyNumber = objds.Tables[0].Rows[0]["VCHPOlicyNumber"].ToString();
                }
            }

            if (objds.Tables.Count > 0)
            {

                DataSet objdsDoctor = objIDoctorClaim.DoctorDetails(doctorID, HttpContext.Current.Request.Headers["Token"].ToString());
                if (objdsDoctor.Tables[0].Rows.Count == 0)
                {
                    flag = 3;
                }
                if (flag != 3)
                {
                    DataSet objdsPolicyNumber = objIDoctorClaim.PolicySpecializationDetails(doctorID, HttpContext.Current.Request.Headers["Token"].ToString(), PolicyNumber);
                    if (objdsPolicyNumber.Tables[0].Rows.Count == 0)
                    {
                        flag = 4;
                    }
                }
                objds.Tables[0].TableName = "PolicyInfo";
                if (objds.Tables[0].Rows.Count == 0)
                {
                    if (objds.Tables[1].Rows.Count == 0)
                    {
                        flag = 1;
                        //getDatatable();
                        //dt.Rows[0]["code"] = "-100"; dt.Rows[0]["Message"] = "InValid Policy";
                        //dt.TableName = "Message";
                        //objds.Tables.Add(dt);
                    }
                }
                if (objds.Tables.Count > 1)
                {
                    objds.Tables[1].TableName = "Members";
                    if (objds.Tables[1].Rows.Count == 0 && flag == 0)
                    {
                        flag = 2;
                        //getDatatable();
                        //dt.Rows[0]["code"] = "-102"; dt.Rows[0]["Message"] = "InValid Member FirstName";
                        //dt.TableName = "Message";
                        //objds.Tables.Add(dt);
                    }
                }

                if (objds.Tables.Count > 2)
                    objds.Tables[2].TableName = "Covered";

                //if (flag == 0)
                //{
                //    getDatatable();
                //    dt.Rows[0]["code"] = "-200"; dt.Rows[0]["Message"] = "Policy Valid";
                //    dt.TableName = "Message";
                //    objds.Tables.Add(dt);
                //}
            }
            //return JsonConvert.SerializeObject(objds);
            var jsonString = "";
            if (flag == 0)
            {
                DataTable objdsOTP = objIDoctorClaim.OTPDetails(objds.Tables[0].Rows[0]["intContactMobile"].ToString(), HttpContext.Current.Request.UserHostAddress);
                if (objdsOTP.Rows.Count > 0)
                {
                    DataTable claimData = objdsOTP.Copy();
                    claimData.TableName = "OTPDetails";
                    objds.Tables.Add(claimData);

                }
                jsonString = "{ "
                       + JsonConvert.SerializeObject("code", Formatting.Indented) + ":" + JsonConvert.SerializeObject("-200", Formatting.Indented)
                        + "," + JsonConvert.SerializeObject("Message", Formatting.Indented) + ":" + JsonConvert.SerializeObject("Policy Valid", Formatting.Indented)
                      + ","
                    + JsonConvert.SerializeObject("Response", Formatting.Indented) + ":" + JsonConvert.SerializeObject(objds, Formatting.Indented) + " }";
                //jsonString = "{ "   
                //   + JsonConvert.SerializeObject("code", Formatting.Indented) + ":" + JsonConvert.SerializeObject("-200", Formatting.Indented)
                //    + "," + JsonConvert.SerializeObject(" Message", Formatting.Indented) + ":" + JsonConvert.SerializeObject("Policy Valid", Formatting.Indented)
                //  +","  + JsonConvert.SerializeObject(objds, Formatting.Indented) + " }";
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
                        + "," + JsonConvert.SerializeObject("Message", Formatting.Indented) + ":" + JsonConvert.SerializeObject("InValid Member FirstName", Formatting.Indented)
                      + ","
                    + JsonConvert.SerializeObject("Response", Formatting.Indented) + ":" + JsonConvert.SerializeObject(objds, Formatting.Indented) + " }";
            }
            else if (flag == 3)
            {
                jsonString = "{ "
                       + JsonConvert.SerializeObject("code", Formatting.Indented) + ":" + JsonConvert.SerializeObject("-113", Formatting.Indented)
                        + "," + JsonConvert.SerializeObject("Message", Formatting.Indented) + ":" + JsonConvert.SerializeObject("Not a empaneled doctor", Formatting.Indented)
                      + ","
                    + JsonConvert.SerializeObject("Response", Formatting.Indented) + ":" + JsonConvert.SerializeObject(objds, Formatting.Indented) + " }";
            }
            else if (flag == 4)
            {
                jsonString = "{ "
                       + JsonConvert.SerializeObject("code", Formatting.Indented) + ":" + JsonConvert.SerializeObject("-114", Formatting.Indented)
                        + "," + JsonConvert.SerializeObject("Message", Formatting.Indented) + ":" + JsonConvert.SerializeObject("Invalid Specialty, only valid for GP visit", Formatting.Indented)
                      + ","
                    + JsonConvert.SerializeObject("Response", Formatting.Indented) + ":" + JsonConvert.SerializeObject(objds, Formatting.Indented) + " }";
            }
            //var jsonString = JsonConvert.SerializeObject(objds);
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            return response;
        }
        [CustomAuthenticate]
        [Route("DCPolicyDetails/{PolicyNumber}/{FirstName}/{DC_ID}/{Insurance?}/{TPAName?}")]
        [HttpPost]
        public string DCPolicyDetails(string PolicyNumber, string FirstName, string DC_ID, string Insurance = "", string TPAName = "")
        {
            DataSet objds = new DataSet();
            if (Insurance == TPAName)
            {
                objds = objIPolicyInfoService.DCPolicyDetails(PolicyNumber, FirstName, DC_ID, Insurance, TPAName);
            }
            else
            {
                objds = objIPolicyInfoService.DCPolicyDetailsMemberCode(PolicyNumber, FirstName, DC_ID, Insurance, TPAName);                
            }
            // DataSet objds = objIPolicyInfoService.DCPolicyDetails(PolicyNumber, FirstName, DC_ID, Insurance, TPAName);
            if (objds.Tables.Count > 0)
            {
                objds.Tables[0].TableName = "PolicyInfo";
                if (objds.Tables.Count > 1)
                    objds.Tables[1].TableName = "Members";
                if (objds.Tables.Count > 2)
                    objds.Tables[2].TableName = "Covered";
            }
            return JsonConvert.SerializeObject(objds);
        }
    }
}