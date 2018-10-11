using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLLCOPD;
using COPDAPI.Models;
using System.Data;
using System;
using System.Text.RegularExpressions;
using COPDAPI.Controllers.DC;

namespace COPDAPI.Controllers.DCClaim
{
    public class DCClaimService : IDCClaimService
    {
        BLLDiagnosticCenterClaim objBLLDCClaim = new BLLDiagnosticCenterClaim();
        static readonly IDCService objDCService = new DCServices();
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

        /// <summary>
        /// Add DC Claim Details
        /// </summary>
        /// <param name="objDCClaim"></param>
        /// <returns></returns>
        public DataTable SaveDCClaim(DiagnosticCenterClaim objDCClaim)
        {
            try
            {
                if (CheckIsPolicyValid(objDCClaim.TDCC_PolicyNumber))
                {

                    if (CheckIsPolicyMemberValid(objDCClaim.TDCC_PolicyNumber, objDCClaim.TDCC_MemberCode))
                    {
                        objBLLDCClaim.SpType = 1;
                        objBLLDCClaim.Token = objDCClaim.Token;
                        objBLLDCClaim.TDCC_ClaimID = objDCClaim.TDCC_ClaimID;
                        if (string.IsNullOrEmpty(objDCClaim.TDCC_ClaimClient))
                        {
                            getDatatable();
                            dt.Rows[0]["code"] = "-500"; dt.Rows[0]["Message"] = "Please Provide Client Id";
                            return dt;
                        }
                        else if (GetClientCode(objDCClaim.TDCC_PolicyNumber) == objDCClaim.TDCC_ClaimClient)
                        {
                            objBLLDCClaim.TDCC_ClaimClient = objDCClaim.TDCC_ClaimClient;
                        }
                        else
                        {
                            getDatatable();
                            dt.Rows[0]["code"] = "-500"; dt.Rows[0]["Message"] = "Invalid ClientId";
                            return dt;
                        }
                        objBLLDCClaim.TDCC_PolicyNumber = objDCClaim.TDCC_PolicyNumber;
                        objBLLDCClaim.TDCC_Document = objDCClaim.TDCC_Document;
                        
                        if (string.IsNullOrEmpty(objDCClaim.TDCC_PatientName))
                        {
                            getDatatable();
                            dt.Rows[0]["code"] = "-500"; dt.Rows[0]["Message"] = "Please Provide Patient Name";
                            return dt;
                        }
                        else
                        {
                            objBLLDCClaim.TDCC_PatientName = objDCClaim.TDCC_PatientName;
                        }
                        objBLLDCClaim.TDCC_MemberCode = objDCClaim.TDCC_MemberCode;
                        if (string.IsNullOrEmpty(objDCClaim.TDCC_PatientAge))
                        {
                            getDatatable();
                            dt.Rows[0]["code"] = "-500"; dt.Rows[0]["Message"] = "Please Provide Patient Age";
                            return dt;
                        }
                        else if (Convert.ToInt32(objDCClaim.TDCC_PatientAge) > 150)
                        {
                            getDatatable();
                            dt.Rows[0]["code"] = "-500"; dt.Rows[0]["Message"] = "Age cannot be greater than 150";
                            return dt;
                        }
                        else
                        {
                            objBLLDCClaim.TDCC_PatientAge = objDCClaim.TDCC_PatientAge;
                        }
                        if (string.IsNullOrEmpty(objDCClaim.TDCC_PatientGen))
                        {
                            getDatatable();
                            dt.Rows[0]["code"] = "-500"; dt.Rows[0]["Message"] = "Please Provide Patient Gender";
                            return dt;
                        }
                        else
                        {
                            objBLLDCClaim.TDCC_PatientGen = objDCClaim.TDCC_PatientGen;
                        }
                        
                            objBLLDCClaim.TDCC_PatientAddress = objDCClaim.TDCC_PatientAddress;
                        
                       
                            objBLLDCClaim.TDCC_PatientMobile = objDCClaim.TDCC_PatientMobile;
                        
                        if (string.IsNullOrEmpty(objDCClaim.TDCC_AppointmentDate))
                        {
                            getDatatable();
                            dt.Rows[0]["code"] = "-500"; dt.Rows[0]["Message"] = "Please Provide AppointmentDate";
                            return dt;
                        }
                        else
                        {
                            objBLLDCClaim.TDCC_AppointmentDate = Convert.ToDateTime(objDCClaim.TDCC_AppointmentDate).ToString();
                        }
                        if (string.IsNullOrEmpty(objDCClaim.TDCC_DCID))
                        {
                            getDatatable();
                            dt.Rows[0]["code"] = "-500"; dt.Rows[0]["Message"] = "Please Provide DCID";
                            return dt;
                        }
                        else
                        {
                            objBLLDCClaim.TDCC_DCID = objDCClaim.TDCC_DCID;
                        }
                        if (string.IsNullOrEmpty(objDCClaim.TDCC_DCName))
                        {
                            getDatatable();
                            dt.Rows[0]["code"] = "-500"; dt.Rows[0]["Message"] = "Please Provide DC_Name";
                            return dt;
                        }
                        else
                        {
                            objBLLDCClaim.TDCC_DCName = objDCClaim.TDCC_DCName;
                        }

                        objBLLDCClaim.TDCC_PatientPic = objDCClaim.TDCC_PatientPic;
                        objBLLDCClaim.TDCC_DCDocument = objDCClaim.TDCC_DCDocument;
                        objBLLDCClaim.TDCC_PharmacyDocument = objDCClaim.TDCC_PharmacyDocument;
                        objBLLDCClaim.AddUser = objDCClaim.AddUser;
                        objBLLDCClaim.AddDate = objDCClaim.AddDate;
                        objBLLDCClaim.ModUser = objDCClaim.ModUser;
                        objBLLDCClaim.ModDate = objDCClaim.ModDate;
                        objBLLDCClaim.IsActive = objDCClaim.IsActive;
                        objBLLDCClaim.IsDeleted = objDCClaim.IsDeleted;
                        objBLLDCClaim.IP = objDCClaim.IP;
                        //if (string.IsNullOrEmpty(objDCClaim.DC_Diagnosis))
                        //{
                        //    getDatatable();
                        //    dt.Rows[0]["code"] = "-500"; dt.Rows[0]["Message"] = "Please Provide Diagnosis";
                        //    return dt;
                        //}
                        //else
                        //{
                            objBLLDCClaim.DC_Diagnosis = objDCClaim.DC_Diagnosis;
                        //}
                        if (string.IsNullOrEmpty(objDCClaim.DC_ClaimedAmount))
                        {
                            getDatatable();
                            dt.Rows[0]["code"] = "-500"; dt.Rows[0]["Message"] = "Please Provide Claimed Amount";
                            return dt;
                        }
                        else if (objDCClaim.DC_ClaimedAmount == "0")
                        {
                            getDatatable();
                            dt.Rows[0]["code"] = "-500"; dt.Rows[0]["Message"] = "Claimed Amount Cannot Be 0";
                            return dt;
                        }
                        else
                        {
                            objBLLDCClaim.DC_ClaimedAmount = objDCClaim.DC_ClaimedAmount;
                        }
                        
                            objBLLDCClaim.DC_ARRemarks = objDCClaim.DC_ARRemarks;
                        

                        objBLLDCClaim.DC_ARRemarks = objDCClaim.DC_ARRemarks;
                        objBLLDCClaim.DC_ARBY = objDCClaim.DC_ARBY;
                        objBLLDCClaim.DC_ARDATETIME = objDCClaim.DC_ARDATETIME;
                        objBLLDCClaim.DC_ARStatus = objDCClaim.DC_ARStatus;

                        DataSet objds = objBLLDCClaim.ExecuteDataset(objBLLDCClaim);

                        try
                        {
                            objDCService.SaveReport();
                        }
                        catch (Exception)
                        {

                           
                        }
                        return objds.Tables[0];
                    }
                    else
                    {
                        getDatatable();
                        dt.Rows[0]["code"] = "-107"; dt.Rows[0]["Message"] = "Invalid Member Code";
                        return dt;
                    }
                }
                else
                {
                    getDatatable();
                    dt.Rows[0]["code"] = "-100"; dt.Rows[0]["Message"] = "Invalid Policy";
                    return dt;
                }



            }
            catch (Exception ex)
            {
                getDatatable();
                dt.Rows[0]["code"] = "-500"; dt.Rows[0]["Message"] = ex.Message;
                return dt;
            }
        }
        public bool CheckIsPolicyValid(string PolicyNumber)
        {
            bool isValid = false;
            try
            {
                BLLPolicyInfo objBLLPolicyInfo = new BLLPolicyInfo();
                objBLLPolicyInfo.Sptype = 1;
                objBLLPolicyInfo.PolicyNumber = PolicyNumber;
                DataSet objDs = objBLLPolicyInfo.ExecuteDataset(objBLLPolicyInfo);
                if (objDs.Tables[0].Rows.Count > 0)
                {
                    isValid = true;
                }
                
                    return isValid;
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

        public bool phone(string no)
        {
            Regex expr = new Regex(@"^((\+){0,1}91(\s){0,1}(\-){0,1}(\s){0,1}){0,1}9[0-9](\s){0,1}(\-){0,1}(\s){0,1}[1-9]{1}[0-9]{7}$");
            if (expr.IsMatch(no))
            {
                return true;
            }
            else return false;
        }

    }
}