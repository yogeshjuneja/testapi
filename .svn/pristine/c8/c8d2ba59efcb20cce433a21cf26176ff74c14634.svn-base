using COPDAPI.Filters;
using COPDAPI.Models;
using Newtonsoft.Json;
using System;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Script.Serialization;
namespace COPDAPI.Controllers.DoctorClaim
{
    [AuthenticateFilter]
    [ActionFilters]
    [RoutePrefix("api/DoctorClaim")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DoctorClaimController : ApiController
    {
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
        [Route("{AddClaim}")]
        [HttpPost]
        // GET api/<controller>/5
        public HttpResponseMessage SaveDoctorClaim([FromBody] DoctorClaimRequest objDoctorClaimRequest)
        {

            int flag = 0;

            try
            {

                getDatatable();
                objDoctorClaimRequest.Token = HttpContext.Current.Request.Headers["Token"].ToString();
                objDoctorClaimRequest.IP = HttpContext.Current.Request.UserHostAddress;
                /// Client ID
                if (string.IsNullOrEmpty(objDoctorClaimRequest.ClientId))
                {
                    flag = 1;
                    dt.Rows[0]["code"] = "-110"; dt.Rows[0]["Message"] = "Please Provide ClientId";

                    //jsonString = "{ "
                    //   + JsonConvert.SerializeObject("code", Formatting.Indented) + ":" + JsonConvert.SerializeObject("-110", Formatting.Indented)
                    //    + "," + JsonConvert.SerializeObject("Message", Formatting.Indented) + ":" + JsonConvert.SerializeObject("Please Provide ClientId", Formatting.Indented)
                    //  + ","
                    //+ JsonConvert.SerializeObject("Response", Formatting.Indented) + ":" + JsonConvert.SerializeObject(objdt, Formatting.Indented) + " }";
                }
                /// Policy Number
                else if (string.IsNullOrEmpty(objDoctorClaimRequest.PolicyNumber))
                {
                    flag = 1;
                    dt.Rows[0]["code"] = "-110"; dt.Rows[0]["Message"] = "Please Provide Policy Number";

                    //jsonString = "{ "
                    //   + JsonConvert.SerializeObject("code", Formatting.Indented) + ":" + JsonConvert.SerializeObject("-110", Formatting.Indented)
                    //    + "," + JsonConvert.SerializeObject("Message", Formatting.Indented) + ":" + JsonConvert.SerializeObject("Please Provide Policy Number", Formatting.Indented)
                    //  + ","
                    //+ JsonConvert.SerializeObject("Response", Formatting.Indented) + ":" + JsonConvert.SerializeObject(objdt, Formatting.Indented) + " }";
                }
                //CheckIs Policy Valid
                else if (!objDoctorClaimService.CheckIsPolicyValid(objDoctorClaimRequest.PolicyNumber))
                {
                    flag = 1;
                    dt.Rows[0]["code"] = "-100"; dt.Rows[0]["Message"] = "Invalid Policy";
                    //jsonString = "{ "
                    //   + JsonConvert.SerializeObject("code", Formatting.Indented) + ":" + JsonConvert.SerializeObject("-100", Formatting.Indented)
                    //    + "," + JsonConvert.SerializeObject("Message", Formatting.Indented) + ":" + JsonConvert.SerializeObject("Invalid Policy", Formatting.Indented)
                    //  + ","
                    //+ JsonConvert.SerializeObject("Response", Formatting.Indented) + ":" + JsonConvert.SerializeObject(objdt, Formatting.Indented) + " }";
                }
                ///Client Id  
                else if (!(objDoctorClaimService.GetClientCode(objDoctorClaimRequest.PolicyNumber) == objDoctorClaimRequest.ClientId))
                {
                    flag = 1;
                    dt.Rows[0]["code"] = "-105"; dt.Rows[0]["Message"] = "Invalid Client Id";
                    //jsonString = "{ "
                    //   + JsonConvert.SerializeObject("code", Formatting.Indented) + ":" + JsonConvert.SerializeObject("-105", Formatting.Indented)
                    //    + "," + JsonConvert.SerializeObject("Message", Formatting.Indented) + ":" + JsonConvert.SerializeObject("Invalid Client Id", Formatting.Indented)
                    //  + ","
                    //+ JsonConvert.SerializeObject("Response", Formatting.Indented) + ":" + JsonConvert.SerializeObject(objdt, Formatting.Indented) + " }";
                }
                /// Member Code
                else if (string.IsNullOrEmpty(objDoctorClaimRequest.MemberCode))
                {
                    flag = 1;
                    dt.Rows[0]["code"] = "-110"; dt.Rows[0]["Message"] = "Please Provide Member Code";
                    //jsonString = "{ "
                    //   + JsonConvert.SerializeObject("code", Formatting.Indented) + ":" + JsonConvert.SerializeObject("-110", Formatting.Indented)
                    //    + "," + JsonConvert.SerializeObject("Message", Formatting.Indented) + ":" + JsonConvert.SerializeObject("Please Provide Member Code", Formatting.Indented)
                    //  + ","
                    //+ JsonConvert.SerializeObject("Response", Formatting.Indented) + ":" + JsonConvert.SerializeObject(objdt, Formatting.Indented) + " }";

                }

                /// Patient Name
                else if (string.IsNullOrEmpty(objDoctorClaimRequest.PatientName))
                {
                    flag = 1;
                    dt.Rows[0]["code"] = "-110"; dt.Rows[0]["Message"] = "Please Provide Patient Name";
                    //jsonString = "{ "
                    //   + JsonConvert.SerializeObject("code", Formatting.Indented) + ":" + JsonConvert.SerializeObject("-110", Formatting.Indented)
                    //    + "," + JsonConvert.SerializeObject("Message", Formatting.Indented) + ":" + JsonConvert.SerializeObject("Please Provide Patient Name", Formatting.Indented)
                    //  + ","
                    //+ JsonConvert.SerializeObject("Response", Formatting.Indented) + ":" + JsonConvert.SerializeObject(objdt, Formatting.Indented) + " }";

                }
                ///Patient Age

                //else if (string.IsNullOrEmpty(objDoctorClaimRequest.PatientAge))
                //{
                //    flag = 1;
                //    jsonString = "{ "
                //       + JsonConvert.SerializeObject("code", Formatting.Indented) + ":" + JsonConvert.SerializeObject("-110", Formatting.Indented)
                //        + "," + JsonConvert.SerializeObject("Message", Formatting.Indented) + ":" + JsonConvert.SerializeObject("Please Provide Patient Age", Formatting.Indented)
                //      + ","
                //    + JsonConvert.SerializeObject("Response", Formatting.Indented) + ":" + JsonConvert.SerializeObject(objdt, Formatting.Indented) + " }";
                //}
                //else if (Convert.ToInt32(objDoctorClaimRequest.PatientAge) > 150)
                //{
                //    flag = 1;
                //    jsonString = "{ "
                //       + JsonConvert.SerializeObject("code", Formatting.Indented) + ":" + JsonConvert.SerializeObject("-112", Formatting.Indented)
                //        + "," + JsonConvert.SerializeObject("Message", Formatting.Indented) + ":" + JsonConvert.SerializeObject("Age cannot be Greater than 150", Formatting.Indented)
                //      + ","
                //    + JsonConvert.SerializeObject("Response", Formatting.Indented) + ":" + JsonConvert.SerializeObject(objdt, Formatting.Indented) + " }";
                //}
                ///Patient Gender
                else if (string.IsNullOrEmpty(objDoctorClaimRequest.PatientGender))
                {
                    flag = 1;

                    dt.Rows[0]["code"] = "-110"; dt.Rows[0]["Message"] = "Please Provide Gender";
                    //jsonString = "{ "
                    //   + JsonConvert.SerializeObject("code", Formatting.Indented) + ":" + JsonConvert.SerializeObject("-110", Formatting.Indented)
                    //    + "," + JsonConvert.SerializeObject("Message", Formatting.Indented) + ":" + JsonConvert.SerializeObject("Please Provide Gender", Formatting.Indented)
                    //  + ","
                    //+ JsonConvert.SerializeObject("Response", Formatting.Indented) + ":" + JsonConvert.SerializeObject(objdt, Formatting.Indented) + " }";

                }
                ///Patient Mobile 
                else if (string.IsNullOrEmpty(objDoctorClaimRequest.PatientMobile))
                {
                    flag = 1;
                    dt.Rows[0]["code"] = "-110"; dt.Rows[0]["Message"] = "Please Provide Mobile Number";
                    //jsonString = "{ "
                    //   + JsonConvert.SerializeObject("code", Formatting.Indented) + ":" + JsonConvert.SerializeObject("-110", Formatting.Indented)
                    //    + "," + JsonConvert.SerializeObject("Message", Formatting.Indented) + ":" + JsonConvert.SerializeObject("Please Provide Mobile Number", Formatting.Indented)
                    //  + ","
                    //+ JsonConvert.SerializeObject("Response", Formatting.Indented) + ":" + JsonConvert.SerializeObject(objdt, Formatting.Indented) + " }";
                }
                ///Appointment Date
                else if (string.IsNullOrEmpty(objDoctorClaimRequest.AppointmentDate))
                {
                    flag = 1;
                    dt.Rows[0]["code"] = "-110"; dt.Rows[0]["Message"] = "Please Provide AppointmentDate";
                    //jsonString = "{ "
                    //   + JsonConvert.SerializeObject("code", Formatting.Indented) + ":" + JsonConvert.SerializeObject("-110", Formatting.Indented)
                    //    + "," + JsonConvert.SerializeObject("Message", Formatting.Indented) + ":" + JsonConvert.SerializeObject("Please Provide AppointmentDate", Formatting.Indented)
                    //  + ","
                    //+ JsonConvert.SerializeObject("Response", Formatting.Indented) + ":" + JsonConvert.SerializeObject(objdt, Formatting.Indented) + " }";
                }
                ///DoctorId
                else if (string.IsNullOrEmpty(objDoctorClaimRequest.DoctorId))
                {
                    flag = 1;
                    dt.Rows[0]["code"] = "-110"; dt.Rows[0]["Message"] = "Please Provide DoctorId";
                    //jsonString = "{ "
                    //   + JsonConvert.SerializeObject("code", Formatting.Indented) + ":" + JsonConvert.SerializeObject("-110", Formatting.Indented)
                    //    + "," + JsonConvert.SerializeObject("Message", Formatting.Indented) + ":" + JsonConvert.SerializeObject("Please Provide DoctorId", Formatting.Indented)
                    //  + ","
                    //+ JsonConvert.SerializeObject("Response", Formatting.Indented) + ":" + JsonConvert.SerializeObject(objdt, Formatting.Indented) + " }";
                }
                ///Doctor Name
                else if (string.IsNullOrEmpty(objDoctorClaimRequest.DoctorName))
                {
                    flag = 1;
                    dt.Rows[0]["code"] = "-110"; dt.Rows[0]["Message"] = "Please Provide Doctor Name";
                    //jsonString = "{ "
                    //   + JsonConvert.SerializeObject("code", Formatting.Indented) + ":" + JsonConvert.SerializeObject("-110", Formatting.Indented)
                    //    + "," + JsonConvert.SerializeObject("Message", Formatting.Indented) + ":" + JsonConvert.SerializeObject("Please Provide Doctor Name", Formatting.Indented)
                    //  + ","
                    //+ JsonConvert.SerializeObject("Response", Formatting.Indented) + ":" + JsonConvert.SerializeObject(objdt, Formatting.Indented) + " }";
                }
                ///DC_ClaimedAmount
                else if (string.IsNullOrEmpty(objDoctorClaimRequest.DC_ClaimedAmount))
                {
                    flag = 1;
                    dt.Rows[0]["code"] = "-110"; dt.Rows[0]["Message"] = "Please Provide Claimed Amount";
                    //jsonString = "{ "
                    //   + JsonConvert.SerializeObject("code", Formatting.Indented) + ":" + JsonConvert.SerializeObject("-110", Formatting.Indented)
                    //    + "," + JsonConvert.SerializeObject("Message", Formatting.Indented) + ":" + JsonConvert.SerializeObject("Please Provide Claimed Amount", Formatting.Indented)
                    //  + ","
                    //+ JsonConvert.SerializeObject("Response", Formatting.Indented) + ":" + JsonConvert.SerializeObject(objdt, Formatting.Indented) + " }";
                }

                else if (objDoctorClaimRequest.DC_ClaimedAmount == "0")
                {
                    flag = 1;
                    dt.Rows[0]["code"] = "-106"; dt.Rows[0]["Message"] = "Claimed Amount Cannot be 0";
                    //jsonString = "{ "
                    //   + JsonConvert.SerializeObject("code", Formatting.Indented) + ":" + JsonConvert.SerializeObject("-106", Formatting.Indented)
                    //    + "," + JsonConvert.SerializeObject("Message", Formatting.Indented) + ":" + JsonConvert.SerializeObject("Claimed Amount Cannot be 0", Formatting.Indented)
                    //  + ","
                    //+ JsonConvert.SerializeObject("Response", Formatting.Indented) + ":" + JsonConvert.SerializeObject(objdt, Formatting.Indented) + " }";
                }
                //DocumentUrl
                else if (objDoctorClaimRequest.DocumentUrl == null)
                {
                    flag = 1;
                    dt.Rows[0]["code"] = "-110"; dt.Rows[0]["Message"] = "Please Provide Document URL";
                    //jsonString = "{ "
                    //   + JsonConvert.SerializeObject("code", Formatting.Indented) + ":" + JsonConvert.SerializeObject("-110", Formatting.Indented)
                    //    + "," + JsonConvert.SerializeObject("Message", Formatting.Indented) + ":" + JsonConvert.SerializeObject("Please Provide Document URL", Formatting.Indented)
                    //  + ","
                    //+ JsonConvert.SerializeObject("Response", Formatting.Indented) + ":" + JsonConvert.SerializeObject(objdt, Formatting.Indented) + " }";
                }

                ///Check IsPolicy MemberValid
                else if (!objDoctorClaimService.CheckIsPolicyMemberValid(objDoctorClaimRequest.PolicyNumber, objDoctorClaimRequest.MemberCode))
                {
                    flag = 1;
                    dt.Rows[0]["code"] = "-107"; dt.Rows[0]["Message"] = "Invalid Member Code";
                    //jsonString = "{ "
                    //   + JsonConvert.SerializeObject("code", Formatting.Indented) + ":" + JsonConvert.SerializeObject("-107", Formatting.Indented)
                    //    + "," + JsonConvert.SerializeObject("Message", Formatting.Indented) + ":" + JsonConvert.SerializeObject("Invalid Member Code", Formatting.Indented)
                    //  + ","
                    //+ JsonConvert.SerializeObject("Response", Formatting.Indented) + ":" + JsonConvert.SerializeObject(objdt, Formatting.Indented) + " }";
                }
                // Success

                //if (flag == 0)
                //{
                //    objdt = objDoctorClaimService.SaveDoctorClaim(objDoctorClaimRequest);
                //    jsonString = JsonConvert.SerializeObject(objdt, Formatting.Indented);
                //    //jsonString = "{"
                //    //       + JsonConvert.SerializeObject("code", Formatting.Indented) + ":" + JsonConvert.SerializeObject("-200", Formatting.Indented)
                //    //        + "," + JsonConvert.SerializeObject("Message", Formatting.Indented) + ":" + JsonConvert.SerializeObject("Claim has been Submitted Successfully!", Formatting.Indented)
                //    //      + ","
                //    //    + JsonConvert.SerializeObject("Response", Formatting.Indented) + ":" + JsonConvert.SerializeObject(objdt, Formatting.Indented) + " }";
                //}
            }
            catch (Exception ex)
            {
                flag = 1;
                dt.Rows[0]["code"] = "-500"; dt.Rows[0]["Message"] = ex.ToString();
                //jsonString = "{ "
                //   + JsonConvert.SerializeObject("code", Formatting.Indented) + ":" + JsonConvert.SerializeObject("-500", Formatting.Indented)
                //    + "," + JsonConvert.SerializeObject("Message", Formatting.Indented) + ":" + JsonConvert.SerializeObject(ex.ToString(), Formatting.Indented)
                //  + ","
                //+ JsonConvert.SerializeObject("Response", Formatting.Indented) + ":" + JsonConvert.SerializeObject(objdt, Formatting.Indented) + " }";
            }
            if (flag == 0)
            {

                DataSet objds = objDoctorClaimService.SaveDoctorClaim(objDoctorClaimRequest);
                objds.Tables[0].TableName = "Claim";
                var jsonString = JsonConvert.SerializeObject(objds.Tables[0]);
                jsonString = jsonString.Replace("[", string.Empty);
                jsonString = jsonString.Replace("]", string.Empty);
                var response = Request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                return response;
            }
            else
            {
                var jsonString = JsonConvert.SerializeObject(dt);
                var response = Request.CreateResponse(HttpStatusCode.OK);
                jsonString = jsonString.Replace("[", string.Empty);
                jsonString = jsonString.Replace("]", string.Empty);
                response.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                return response;
            }
            //return CommonFunction.DataTableToJSONWithStringBuilder(objdt);
            //return new HttpResponseMessage()
            //{
            //    Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json")
            //};
        }

    }
}
