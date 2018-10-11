using BLLCOPD;
using COPDAPI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;

namespace COPDAPI.Controllers.DoctorClaim
{
    public class DoctorClaimService : IDoctorClaim
    {
        BLLDoctorClaim objBLLDoctorClaim = new BLLDoctorClaim();
        BLLPolicyInfo objBLLPolicyInfo = new BLLPolicyInfo();
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
        public DataSet SaveDoctorClaim(DoctorClaimRequest objDoctorRequestClaim)
        {

            //if (CheckIsPolicyMemberValid(objDoctorRequestClaim.PolicyNumber, objDoctorRequestClaim.MemberCode) == true)
            //{
            objBLLDoctorClaim.SpType = 1;
            objBLLDoctorClaim.ClientId = objDoctorRequestClaim.ClientId;
            if (!string.IsNullOrEmpty(objDoctorRequestClaim.Token))
                objBLLDoctorClaim.Token = objDoctorRequestClaim.Token;
            //else
            //{
            //    getDatatable();
            //    dt.Rows[0]["code"] = "-110"; dt.Rows[0]["Message"] = "Please Provide Token";
            //    return dt;
            //}
            if (!string.IsNullOrEmpty(objDoctorRequestClaim.IP))
                objBLLDoctorClaim.IP = objDoctorRequestClaim.IP;
            objBLLDoctorClaim.PatientName = objDoctorRequestClaim.PatientName;
            objBLLDoctorClaim.MemberCode = objDoctorRequestClaim.MemberCode;
            if (!string.IsNullOrEmpty(objDoctorRequestClaim.PatientAddress))
                objBLLDoctorClaim.PatientAddress = objDoctorRequestClaim.PatientAddress;
            if (!string.IsNullOrEmpty(objDoctorRequestClaim.PatientAge))
                objBLLDoctorClaim.PatientAddress = objDoctorRequestClaim.PatientAge;          
            objBLLDoctorClaim.PatientGender = objDoctorRequestClaim.PatientGender;
            objBLLDoctorClaim.PatientMobile = objDoctorRequestClaim.PatientMobile;

            //else if (phone(objDoctorRequestClaim.PatientMobile) == false)
            //{
            //    getDatatable();
            //    dt.Rows[0]["code"] = "-111"; dt.Rows[0]["Message"] = "Please Provide Valid Mobile Number";
            //    return dt;
            //}



            objBLLDoctorClaim.PolicyNumber = objDoctorRequestClaim.PolicyNumber;
            objBLLDoctorClaim.DC_Diagnosis = objDoctorRequestClaim.DC_Diagnosis;
            objBLLDoctorClaim.AppointmentDate = objDoctorRequestClaim.AppointmentDate;
            objBLLDoctorClaim.DoctorId = objDoctorRequestClaim.DoctorId;
            objBLLDoctorClaim.DoctorName = objDoctorRequestClaim.DoctorName;
            objBLLDoctorClaim.DC_ClaimedAmount = objDoctorRequestClaim.DC_ClaimedAmount;
            objBLLDoctorClaim.DCDocument = objDoctorRequestClaim.DCDocument;
            objBLLDoctorClaim.PharmacyDocument = objDoctorRequestClaim.PharmacyDocument;
            if (objDoctorRequestClaim.DocumentUrl != null)
            {
                if (objDoctorRequestClaim.DocumentUrl.Count > 0)
                {
                    objBLLDoctorClaim.DC_DocumentUrl = "";
                    objBLLDoctorClaim.DC_DocumentName = "";
                    foreach (var item in objDoctorRequestClaim.DocumentUrl)
                    {
                        objBLLDoctorClaim.DC_DocumentUrl += item.DocumentUrl + "|";
                        //if (!string.IsNullOrEmpty(item.DocumentName))
                        objBLLDoctorClaim.DC_DocumentName += item.DocumentName + "|";

                    }
                }
            }       
            DataSet objds = objBLLDoctorClaim.ExecuteDataset(objBLLDoctorClaim);
            DownloadPrescription();
            return objds;

        }
        [MTAThread]
        void DownloadPrescription()
        {
            try
            {
                WebClient client = new WebClient();
                string baseurl =  ConfigurationManager.AppSettings["websiteURL"].ToString() + "Home/DoctorDownload";
                Stream data = client.OpenRead(baseurl);
                StreamReader reader = new StreamReader(data);
                string s = reader.ReadToEnd();
                data.Close();
                reader.Close();
            }
            catch (Exception)
            {

                 
            }
        }
        public bool CheckIsPolicyValid(string PolicyNumber)
        {
            bool isValid = false;
            try
            {

                objBLLPolicyInfo.Sptype = 1;
                objBLLPolicyInfo.PolicyNumber = PolicyNumber;
                DataSet objDs = objBLLPolicyInfo.ExecuteDataset(objBLLPolicyInfo);
                if (objDs.Tables[0].Rows.Count > 0)
                {
                    isValid = true;
                }
            }
            catch (Exception ex)
            {

                string error = ex.Message;
            }
            return isValid;
        }

        public bool CheckIsPolicyMemberValid(string PolicyNumber, string MemberCode)
        {
            bool IsValid = false;
            try
            {
                BLLPolicyInfo objPolicyInfo = new BLLPolicyInfo();
                objPolicyInfo.Sptype = 3;
                objPolicyInfo.PolicyNumber = PolicyNumber;
                objPolicyInfo.vchMemberCode = MemberCode;
                DataSet objDs = objPolicyInfo.ExecuteDataset(objPolicyInfo);
                if (objDs.Tables[0].Rows.Count > 0)
                    IsValid = true;

            }
            catch (Exception ex)
            {

                string error = ex.Message;
            }
            return IsValid;
        }

        public string GetClientCode(string PolicyNumber)
        {
            string ClientCode = "";
            try
            {
                BLLPolicyInfo objBLLPolicyInfo = new BLLPolicyInfo();
                objBLLPolicyInfo.Sptype = 1;
                objBLLPolicyInfo.PolicyNumber = PolicyNumber;
                DataSet objDs = objBLLPolicyInfo.ExecuteDataset(objBLLPolicyInfo);
                if (objDs.Tables[0].Rows.Count > 0)
                {

                    ClientCode = objDs.Tables[0].Rows[0]["vchClientCode"].ToString();
                }
            }
            catch (Exception ex)
            {

                string error = ex.Message;
            }
            return ClientCode;
        }
        public bool CheckMemberValid(string PolicyNumber, string MemberCode)
        {
            objBLLPolicyInfo.Sptype = 3;
            objBLLPolicyInfo.PolicyNumber = PolicyNumber;
            objBLLPolicyInfo.vchMemberCode = MemberCode;
            DataSet objds = objBLLPolicyInfo.ExecuteDataset(objBLLPolicyInfo);
            if (objds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return true;
            }
        }
        public bool phone(string no)
        {
            Regex expr = new Regex(@"^((\+){0,1}91(\s){0,1}(\-){0,1}(\s){0,1}){0,1}9[0-9](\s){0,1}(\-){0,1}(\s){0,1}[1-9]{1}[0-9]{7}$");
            if (expr.IsMatch(no))
            {
                return true;
            }
            else return false;
        }

        public DataSet DoctorDetails(string DoctorID, string Token)
        {
            objBLLDoctorClaim.SpType = 6;
            objBLLDoctorClaim.DoctorId = DoctorID;
            objBLLDoctorClaim.Token = Token;
            return objBLLDoctorClaim.ExecuteDataset(objBLLDoctorClaim);
        }
        public DataSet PolicySpecializationDetails(string DoctorID, string Token,string PolicyNumber)
        {
            objBLLDoctorClaim.SpType = 7;
            objBLLDoctorClaim.DoctorId = DoctorID;
            objBLLDoctorClaim.Token = Token;
            objBLLDoctorClaim.PolicyNumber = PolicyNumber;
            return objBLLDoctorClaim.ExecuteDataset(objBLLDoctorClaim);
        }
        BLLSendMail objBLLSendMail = new BLLSendMail();
        public DataTable OTPDetails(string PatientMobile,string strIP)
        {
            Random rnd = new Random();
            int otp = rnd.Next(99999);
            string strMessage = "OTP for Mediconnect Policy Verfication is " + otp.ToString() +". Please do not share this with anyone" ;
            objBLLSendMail.SMSSend(PatientMobile, strMessage);
            objBLLDoctorClaim.SpType =8;
            objBLLDoctorClaim.PatientMobile = PatientMobile;
            objBLLDoctorClaim.IP = strIP;
            objBLLDoctorClaim.PolicyNumber = otp.ToString(); 
            return objBLLDoctorClaim.ExecuteDataset(objBLLDoctorClaim).Tables[0];
        }

        //public bool CheckAppointmentDate(string date)
        //{
        //    string input = "Date of Birth : 07/12/1989";
        //    Regex regex = new Regex(@"\s*(?<date>\d+/\d+/\d+)");
        //    Match match = regex.Match(input);
        //    if (match.Success)
        //    {

        //        string dateString = match.Groups["date"].Value;
        //        DateTime date = DateTime.Parse(dateString, System.Globalization.DateTimeFormatInfo.InvariantInfo);
        //    }
        //}
    }
}