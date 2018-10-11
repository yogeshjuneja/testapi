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
using COPDAPI.Controllers.DoctorClaim;

namespace COPDAPI.Controllers.PharmacyClaim
{
    [AuthenticateFilter]
    [ActionFilters]
    [RoutePrefix("api/PharmacyClaim")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PharmacyClaimController : ApiController
    {
        static readonly IPharmacyClaimService objPCService = new PharmacyClaimService();
        static readonly IDoctorClaim objDoctorClaimService = new DoctorClaimService();
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

        [CustomAuthenticate]
        [Route("{PClaim}")]
        [HttpPost]
        public string SavePCClaim([FromBody]  PharmacyClaimRequest objPC)
        {
            int flag = 0;

            try
            {

                getDatatable();
                objPC.Token = HttpContext.Current.Request.Headers["Token"].ToString();
                objPC.IP = HttpContext.Current.Request.UserHostAddress;
                if (string.IsNullOrEmpty(objPC.TPC_ClaimClient))
                {
                    flag = 1;
                    dt.Rows[0]["code"] = "-110"; dt.Rows[0]["Message"] = "Please Provide ClientId";

                }
                /// Policy Number
                else if (string.IsNullOrEmpty(objPC.TPC_PolicyNumber))
                {
                    flag = 1;
                    dt.Rows[0]["code"] = "-110"; dt.Rows[0]["Message"] = "Please Provide Policy Number";

                }
                //CheckIs Policy Valid
                else if (!objDoctorClaimService.CheckIsPolicyValid(objPC.TPC_PolicyNumber))
                {
                    flag = 1;
                    dt.Rows[0]["code"] = "-100"; dt.Rows[0]["Message"] = "Invalid Policy";
                }
                ///Client Id  
                else if (!(objDoctorClaimService.GetClientCode(objPC.TPC_PolicyNumber) == objPC.TPC_ClaimClient))
                {
                    flag = 1;
                    dt.Rows[0]["code"] = "-105"; dt.Rows[0]["Message"] = "Invalid Client Id";
                }
                /// Member Code
                else if (string.IsNullOrEmpty(objPC.TPC_MemberCode))
                {
                    flag = 1;
                    dt.Rows[0]["code"] = "-110"; dt.Rows[0]["Message"] = "Please Provide Member Code";

                }

                /// Patient Name
                else if (string.IsNullOrEmpty(objPC.TPC_PatientName))
                {
                    flag = 1;
                    dt.Rows[0]["code"] = "-110"; dt.Rows[0]["Message"] = "Please Provide Patient Name";

                }
                ///Patient Age

                else if (string.IsNullOrEmpty(objPC.TPC_PatientMobile))
                {
                    flag = 1;
                    dt.Rows[0]["code"] = "-110"; dt.Rows[0]["Message"] = "Please Provide Mobile Number";
                }
                ///Appointment Date
                else if (string.IsNullOrEmpty(objPC.TPC_AppointmentDate))
                {
                    flag = 1;
                    dt.Rows[0]["code"] = "-110"; dt.Rows[0]["Message"] = "Please Provide Medicine Provide Date";
                }
                ///DoctorId
                else if (objPC.TPC_ID == 0)
                {
                    flag = 1;
                    dt.Rows[0]["code"] = "-110"; dt.Rows[0]["Message"] = "Please Provide Pharmacy ID";
                }
                ///Doctor Name
                else if (string.IsNullOrEmpty(objPC.TPC_Name))
                {
                    flag = 1;
                    dt.Rows[0]["code"] = "-110"; dt.Rows[0]["Message"] = "Please Provide Pharmacy Name";
                }
                ///DC_ClaimedAmount
                else if (string.IsNullOrEmpty(objPC.TPC_ClaimedAmount))
                {
                    flag = 1;
                    dt.Rows[0]["code"] = "-110"; dt.Rows[0]["Message"] = "Please Provide Claimed Amount";
                }

                else if (objPC.TPC_ClaimedAmount == "0")
                {
                    flag = 1;
                    dt.Rows[0]["code"] = "-106"; dt.Rows[0]["Message"] = "Claimed Amount Cannot be 0";
                }
                //DocumentUrl           

                ///Check IsPolicy MemberValid
                else if (!objDoctorClaimService.CheckIsPolicyMemberValid(objPC.TPC_PolicyNumber, objPC.TPC_MemberCode))
                {
                    flag = 1;
                    dt.Rows[0]["code"] = "-107"; dt.Rows[0]["Message"] = "Invalid Member Code";
                }
            }
            catch (Exception ex)
            {
                flag = 1;
                dt.Rows[0]["code"] = "-500"; dt.Rows[0]["Message"] = ex.ToString();
            }
            if (flag == 0)
            {

                DataTable objdt = objPCService.SavePCClaim(objPC);
                var jsonString = "{ "
                            + JsonConvert.SerializeObject("code", Formatting.Indented) + ":" + JsonConvert.SerializeObject("-200", Formatting.Indented)
                             + "," + JsonConvert.SerializeObject("Message", Formatting.Indented) + ":" + JsonConvert.SerializeObject("Policy Valid", Formatting.Indented)
                           + ","
                         + JsonConvert.SerializeObject("Response", Formatting.Indented) + ":" + JsonConvert.SerializeObject(objdt, Formatting.Indented) + " }";
                return jsonString;

            }
            else
            {
                var jsonString = "{ "
                           + JsonConvert.SerializeObject("code", Formatting.Indented) + ":" + JsonConvert.SerializeObject("-200", Formatting.Indented)
                            + "," + JsonConvert.SerializeObject("Message", Formatting.Indented) + ":" + JsonConvert.SerializeObject("Policy Valid", Formatting.Indented)
                          + ","
                        + JsonConvert.SerializeObject("Response", Formatting.Indented) + ":" + JsonConvert.SerializeObject(dt, Formatting.Indented) + " }";
                return jsonString;
                //return JsonConvert.SerializeObject(dt);

            }

        }
    }
}