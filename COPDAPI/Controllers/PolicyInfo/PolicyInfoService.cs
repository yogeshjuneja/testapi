using System;
using System.Data;
using BLLCOPD;
using Newtonsoft.Json;
namespace COPDAPI.Controllers
{
    public class PolicyInfoService : IPolicyInfoService
    {
        BLLPolicyInfo objBLLPolicyInfo = new BLLPolicyInfo();
        BLLDoctorClaim objBLLDoctorClaim = new BLLDoctorClaim();
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
        /// Created by : ASHISH SRIVASTAVA
        /// Check Valid Policy  
        /// </summary>
        /// <param name="PolicyNumber"></param>
        /// <returns></returns>
        public DataTable PolicyDetails(string PolicyNumber)
        {
            try
            {
                objBLLPolicyInfo.Sptype = 1;
                objBLLPolicyInfo.PolicyNumber = PolicyNumber;
                DataSet objds = objBLLPolicyInfo.ExecuteDataset(objBLLPolicyInfo);
                if (objds.Tables[0].Rows.Count > 0)
                {
                    return objds.Tables[0];
                }
                else
                {
                    getDatatable();
                    dt.Rows[0]["code"] = "-100"; dt.Rows[0]["Message"] = "InValid Policy";
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
        /// <summary>
        /// Created by : ASHISH SRIVASTAVA
        /// Member Details By PolicyNumber
        /// </summary>
        /// <param name="PolicyNumber"></param>
        /// <returns></returns>
        public DataTable MemberDetails(string PolicyNumber)
        {
            try
            {
                objBLLPolicyInfo.Sptype = 2;
                objBLLPolicyInfo.PolicyNumber = PolicyNumber;
                DataSet objds = objBLLPolicyInfo.ExecuteDataset(objBLLPolicyInfo);
                if (objds.Tables[0].Rows.Count > 0)
                {
                    return objds.Tables[0];
                }
                else
                {
                    getDatatable();
                    dt.Rows[0]["code"] = "-100"; dt.Rows[0]["Message"] = "InValid Policy";
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
        /// <summary>
        /// Created by : ASHISH SRIVASTAVA
        /// Member Benefit Details By PolicyNumber , MemberCode
        /// </summary>
        /// <param name="PolicyNumber"></param>
        /// <param name="MemberCode"></param>
        /// <returns></returns>
        public DataTable MemberBenefitDetails(string PolicyNumber, string MemberCode)
        {
            try
            {
                objBLLPolicyInfo.Sptype = 3;
                objBLLPolicyInfo.PolicyNumber = PolicyNumber;
                objBLLPolicyInfo.vchMemberCode = MemberCode;
                DataSet objds = objBLLPolicyInfo.ExecuteDataset(objBLLPolicyInfo);
                if (objds.Tables[0].Rows.Count > 0)
                {
                    return objds.Tables[0];
                }
                else
                {
                    getDatatable();
                    dt.Rows[0]["code"] = "-100"; dt.Rows[0]["Message"] = "InValid Policy";
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
        public DataTable ValidatePolicyDetail(string ContactMobile)
        {
            try
            {
                objBLLPolicyInfo.Sptype = 4;
                objBLLPolicyInfo.ContactMobile = ContactMobile;
                DataSet objds = objBLLPolicyInfo.ExecuteDataset(objBLLPolicyInfo);
                if (objds.Tables[0].Rows.Count > 0)
                {
                    return objds.Tables[0];
                }
                else
                {
                    getDatatable();
                    dt.Rows[0]["code"] = "-100"; dt.Rows[0]["Message"] = "InValid Policy";
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

        public DataTable DCCoveredinfo(string PolicyNumber, string MemberCode)
        {
            try
            {
                objBLLPolicyInfo.Sptype = 5;
                objBLLPolicyInfo.PolicyNumber = PolicyNumber;
                objBLLPolicyInfo.vchMemberCode = MemberCode;
                DataSet objds = objBLLPolicyInfo.ExecuteDataset(objBLLPolicyInfo);
                if (objds.Tables[0].Rows.Count > 0)
                {
                    return objds.Tables[0];
                }
                else
                {
                    getDatatable();
                    dt.Rows[0]["code"] = "-100"; dt.Rows[0]["Message"] = "InValid Policy/ OPD Not Covered";
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

        public DataSet DCPolicyDetails(string PolicyNumber, string FirstName, string DC_ID, string Insurance = "", string TPAName = "")
        {
            try
            {
                objBLLPolicyInfo.Sptype = 7;
                objBLLPolicyInfo.PolicyNumber = PolicyNumber;
                objBLLPolicyInfo.FirstName = FirstName;
                DataSet objds = objBLLPolicyInfo.ExecuteDataset(objBLLPolicyInfo);
                if (objds.Tables[0].Rows.Count > 0)
                {
                    objBLLDoctorClaim.SpType = 4;
                    objBLLDoctorClaim.PolicyNumber = PolicyNumber;
                    if (objds.Tables[0].Rows[0]["vchClientCode"].ToString() != "")
                        objBLLDoctorClaim.ClientId = objds.Tables[0].Rows[0]["vchClientCode"].ToString();
                    else
                        objBLLDoctorClaim.ClientId = "";
                    if (objds.Tables[1].Rows.Count > 0)
                        objBLLDoctorClaim.MemberCode = objds.Tables[1].Rows[0]["vchMemberCode"].ToString();
                    else
                        objBLLDoctorClaim.MemberCode = "";

                    DataSet objDsDoctorClaim = objBLLDoctorClaim.ExecuteDataset(objBLLDoctorClaim);
                    if (objDsDoctorClaim.Tables[0].Rows.Count > 0)
                    {
                        DataTable claimData = objDsDoctorClaim.Tables[0].Copy();
                        claimData.TableName = "Prescription";
                        objds.Tables.Add(claimData);
                    }
                    return objds;
                }
                else
                {
                    getDatatable();
                    dt.Rows[0]["code"] = "-100"; dt.Rows[0]["Message"] = "InValid Policy";
                    DataSet objds1 = new DataSet();
                    objds1.Tables.Add(dt);
                    return objds1;
                }
            }
            catch (Exception ex)
            {
                getDatatable();
                dt.Rows[0]["code"] = "-500"; dt.Rows[0]["Message"] = ex.Message;
                DataSet objds1 = new DataSet();
                objds1.Tables.Add(dt);
                return objds1;
            }
        }

        public DataSet DocPolicyDetails(string PolicyNumber, string FirstName, string doctorID, string Insurance, string TPAName)
        {
            try
            {
                objBLLPolicyInfo.Sptype = 8;
                objBLLPolicyInfo.PolicyNumber = PolicyNumber;
                objBLLPolicyInfo.FirstName = FirstName;
                DataSet objds = objBLLPolicyInfo.ExecuteDataset(objBLLPolicyInfo);
                return objds;
                //if (objds.Tables[0].Rows.Count > 0)
                //{


                //}
                //else
                //{
                //    getDatatable();
                //    dt.Rows[0]["code"] = "-100"; dt.Rows[0]["Message"] = "InValid Policy";
                //    DataSet objds1 = new DataSet();                    
                //    objds1.Tables.Add(dt);
                //    return objds1;
                //}
            }
            catch (Exception ex)
            {
                getDatatable();
                dt.Rows[0]["code"] = "-500"; dt.Rows[0]["Message"] = ex.Message;
                DataSet objds1 = new DataSet();
                objds1.Tables.Add(dt);
                return objds1;
            }
        }

        public DataSet DocPolicyDetailsMemberCode(string PolicyNumber, string FirstName, string doctorID, string Insurance, string TPAName)
        {
            try
            {

                objBLLDoctorClaim.SpType = 9;
                objBLLDoctorClaim.PatientName = PolicyNumber;
                DataSet objdsT = objBLLDoctorClaim.ExecuteDataset(objBLLDoctorClaim);
                if (objdsT.Tables[0].Rows.Count > 0)
                {
                    objBLLPolicyInfo.Sptype = 11;
                    objBLLPolicyInfo.PolicyNumber = objdsT.Tables[0].Rows[0]["VCHPOlicyNumber"].ToString();
                    objBLLPolicyInfo.vchMemberCode = objdsT.Tables[0].Rows[0]["vchMemberCode"].ToString();
                    DataSet objds = objBLLPolicyInfo.ExecuteDataset(objBLLPolicyInfo);
                    return objds;
                }
                else
                {
                    objBLLPolicyInfo.Sptype = 11;
                    objBLLPolicyInfo.PolicyNumber = "A";
                    objBLLPolicyInfo.vchMemberCode = "A";
                    DataSet objds = objBLLPolicyInfo.ExecuteDataset(objBLLPolicyInfo);
                    return objds;
                }
            }
            catch (Exception ex)
            {
                getDatatable();
                dt.Rows[0]["code"] = "-500"; dt.Rows[0]["Message"] = ex.Message;
                DataSet objds1 = new DataSet();
                objds1.Tables.Add(dt);
                return objds1;
            }
        }

        public DataSet DCPolicyDetailsMemberCode(string PolicyNumber, string FirstName, string DC_ID, string Insurance = "", string TPAName = "")
        {
            try
            {
                DataSet objds = new DataSet();
                objBLLDoctorClaim.SpType = 9;
                objBLLDoctorClaim.PatientName = PolicyNumber;
                DataSet objdsT = objBLLDoctorClaim.ExecuteDataset(objBLLDoctorClaim);
                if (objdsT.Tables[0].Rows.Count > 0)
                {
                    objBLLPolicyInfo.Sptype = 12;
                    objBLLPolicyInfo.PolicyNumber = objdsT.Tables[0].Rows[0]["VCHPOlicyNumber"].ToString();
                    objBLLPolicyInfo.vchMemberCode = objdsT.Tables[0].Rows[0]["vchMemberCode"].ToString();
                    objds = objBLLPolicyInfo.ExecuteDataset(objBLLPolicyInfo);
                }
                else
                {
                    objBLLPolicyInfo.Sptype = 12;
                    objBLLPolicyInfo.PolicyNumber = "A";
                    objBLLPolicyInfo.vchMemberCode = "A";
                    objds = objBLLPolicyInfo.ExecuteDataset(objBLLPolicyInfo);
                }                 
                if (objds.Tables[0].Rows.Count > 0)
                {
                    objBLLDoctorClaim.SpType = 4;
                    objBLLDoctorClaim.PolicyNumber = PolicyNumber;
                    if (objds.Tables[0].Rows[0]["vchClientCode"].ToString() != "")
                        objBLLDoctorClaim.ClientId = objds.Tables[0].Rows[0]["vchClientCode"].ToString();
                    else
                        objBLLDoctorClaim.ClientId = "";
                    if (objds.Tables[1].Rows.Count > 0)
                        objBLLDoctorClaim.MemberCode = objds.Tables[1].Rows[0]["vchMemberCode"].ToString();
                    else
                        objBLLDoctorClaim.MemberCode = "";

                    DataSet objDsDoctorClaim = objBLLDoctorClaim.ExecuteDataset(objBLLDoctorClaim);
                    if (objDsDoctorClaim.Tables[0].Rows.Count > 0)
                    {
                        DataTable claimData = objDsDoctorClaim.Tables[0].Copy();
                        claimData.TableName = "Prescription";
                        objds.Tables.Add(claimData);
                    }
                    return objds;
                }
                else
                {
                    getDatatable();
                    dt.Rows[0]["code"] = "-100"; dt.Rows[0]["Message"] = "InValid Policy";
                    DataSet objds1 = new DataSet();
                    objds1.Tables.Add(dt);
                    return objds1;
                }
            }
            catch (Exception ex)
            {
                getDatatable();
                dt.Rows[0]["code"] = "-500"; dt.Rows[0]["Message"] = ex.Message;
                DataSet objds1 = new DataSet();
                objds1.Tables.Add(dt);
                return objds1;
            }
        }
    }
}