using BLLCOPD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace COPDAPI.Controllers.Pharmacy
{
    public class PharmacyService : IPharmacy
    {
        BLLPolicyInfo policyInfo = new BLLPolicyInfo();
        BLLDoctorClaim doctorClaim = new BLLDoctorClaim();

        DataSet objds = new DataSet();

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

        public DataSet GetPharmacyPolicyInfo(string PolicyNumber, string FirstName)
        {
            try
            {

                policyInfo.PolicyNumber = PolicyNumber;
                policyInfo.FirstName = FirstName;
                policyInfo.Sptype = 10;
                DataSet objDsPolicyInfo = policyInfo.ExecuteDataset(policyInfo);
                objDsPolicyInfo.Tables[0].TableName = "PolicyInfo";                
                if (objDsPolicyInfo.Tables.Count > 1)
                    objDsPolicyInfo.Tables[1].TableName = "Members";
                if (objDsPolicyInfo.Tables.Count > 2)
                    objDsPolicyInfo.Tables[2].TableName = "Covered";

                doctorClaim.SpType = 4;
                doctorClaim.PolicyNumber = PolicyNumber;
                if (objDsPolicyInfo.Tables[0].Rows[0]["vchClientCode"].ToString() != "")
                    doctorClaim.ClientId = objDsPolicyInfo.Tables[0].Rows[0]["vchClientCode"].ToString();
                else
                    doctorClaim.ClientId = "";
                if (objDsPolicyInfo.Tables[1].Rows.Count > 0)
                    doctorClaim.MemberCode = objDsPolicyInfo.Tables[1].Rows[0]["vchMemberCode"].ToString();
                else
                {
                    doctorClaim.MemberCode = "";
                }
                DataSet objDsDoctorClaim = doctorClaim.ExecuteDataset(doctorClaim);
                DataTable claimData = objDsDoctorClaim.Tables[0].Copy();
                claimData.TableName = "Prescription";
                objDsPolicyInfo.Tables.Add(claimData);
                return objDsPolicyInfo;
                //}
                //else
                //{
                //    getDatatable();
                //    dt.Rows[0]["code"] = "-100"; dt.Rows[0]["Message"] = "Invalid Policy Number";
                //    DataTable logData = dt.Copy();
                //    logData.TableName = "Table4";
                //    objds.Tables.Add(logData);
                //    return objds;
                //}
            }
            catch (Exception ex)
            {
                getDatatable();
                dt.Rows[0]["code"] = "-100"; dt.Rows[0]["Message"] = ex.Message;
                DataTable logData = dt.Copy();
                logData.TableName = "Table4";
                objds.Tables.Add(logData);
                return objds;
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
            }
            catch (Exception ex)
            {

                string error = ex.Message;
            }
            return isValid;
        }
    }
}