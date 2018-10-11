using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLLCOPD;
using COPDAPI.Models;
using System.Data;
using System.Web.Script.Serialization;
using System.IO;
using Newtonsoft.Json;
using System.Web.Helpers;
using System.Web.UI.WebControls;

namespace COPDAPI.Controllers.DC
{
    public class DCServices:IDCService
    {
        BLLDC objBLLDC = new BLLDC();
        BLLTestReport ObjBLLTestReport = new BLLTestReport();
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
        /// Add Diagnostic Center
        /// </summary>
        /// <param name="objDCClaim"></param>
        /// <returns></returns>

        public DataTable SaveDiagnosticCenter(DCClaimRequest objDCClaim)
        { 
            try
            {
                objBLLDC.SpType = 1;
                objBLLDC.DC_Id =objDCClaim.DC_Id;
                objBLLDC.DC_Name = objDCClaim.DC_Name;
                objBLLDC.AreaId = objDCClaim.AreaId;
                objBLLDC.DC_CAreaId = objDCClaim.AreaId;
                objBLLDC.AreaName = objDCClaim.AreaName;
                objBLLDC.DC_CCityId = objDCClaim.DC_CCityId;
                objBLLDC.CityId = objDCClaim.CityId;
                objBLLDC.City = objDCClaim.City;
                objBLLDC.Token = objDCClaim.Token;
                objBLLDC.IP = objDCClaim.IP;
                objBLLDC.DC_CCountryId = objDCClaim.DC_CCountryId;
                objBLLDC.CountryId = objDCClaim.CountryId;
                objBLLDC.Country = objDCClaim.Country;
                objBLLDC.DC_CStateId = objDCClaim.DC_CStateId;
                objBLLDC.StateId = objDCClaim.StateId;
                objBLLDC.State = objDCClaim.State;
                objBLLDC.Pincode = objDCClaim.Pincode;
                objBLLDC.ModUser = objDCClaim.ModUser;
                objBLLDC.ModDate = objDCClaim.ModDate;
                objBLLDC.AddDate = objDCClaim.AddDate;                     
                DataSet objds = objBLLDC.ExecuteDataset(objBLLDC);
                SaveReport();
                return objds.Tables[0];
            }
            catch (Exception ex)
            {
                getDatatable();
                dt.Rows[0]["code"] = "-500"; dt.Rows[0]["Message"] = ex.Message;
                return dt;
            }
        }
        [MTAThread]
        public void SaveReport()
        {
            List<Table> tableList = new List<Table>();
            try
            {
                objBLLDC.SpType = 2;
                DataSet objds = objBLLDC.ExecuteDataset(objBLLDC);
                var result= objds.Tables[0];
                if(result.Rows.Count > 0)
                {
                    for (int i = 0; i < result.Rows.Count; i++)
                    {
                        Int64 claimId = Convert.ToInt64(result.Rows[i]["Id"].ToString());
                        objBLLDC.Id = claimId;
                        if (!string.IsNullOrEmpty(result.Rows[i]["DC_Diagnosis"].ToString()))
                        {
                            
                            string jsonString = result.Rows[i]["DC_Diagnosis"].ToString();
                           
                            DataSet objDataSet = JsonConvert.DeserializeObject<DataSet>(jsonString);
                            if (objDataSet.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow DR in objDataSet.Tables[0].Rows)
                                {
                                    ObjBLLTestReport.SpType = 1;
                                    ObjBLLTestReport.TestName = DR["TestName"].ToString();
                                    ObjBLLTestReport.ProfileName = DR["ProfileName"].ToString();
                                    ObjBLLTestReport.IsTestCompleted = Convert.ToBoolean(DR["IsTestCompleted"].ToString());
                                    ObjBLLTestReport.CaseId = DR["CaseId"].ToString();
                                    ObjBLLTestReport.Advise_SNo = Convert.ToInt64(DR["Advise_SNO"].ToString());
                                    ObjBLLTestReport.CaseCode = DR["CaseCode"].ToString();
                                    ObjBLLTestReport.CaseBarCode = DR["CaseBarCode"].ToString();
                                    ObjBLLTestReport.PatientCode = DR["PatientCode"].ToString();
                                    ObjBLLTestReport.ContactNo = DR["ContactNo"].ToString();
                                    ObjBLLTestReport.PatientName = DR["PatientName"].ToString();
                                    ObjBLLTestReport.PatientId = DR["PatientId"].ToString();
                                    ObjBLLTestReport.Sex = DR["Sex"].ToString();
                                    ObjBLLTestReport.Age = DR["Age"].ToString();
                                    ObjBLLTestReport.LabNo = DR["LabNo"].ToString();
                                    ObjBLLTestReport.AdvisedDoctor = DR["AdvisedDoctor"].ToString();
                                    ObjBLLTestReport.AdviseDate = DR["AdviseDate"].ToString();
                                    ObjBLLTestReport.ReportNo = DR["ReportNo"].ToString();
                                    ObjBLLTestReport.Specimen = DR["Specimen"].ToString();
                                    ObjBLLTestReport.SampleCollectedDate = DR["SampleCollectedDate"].ToString();
                                    ObjBLLTestReport.SecondryCategory = DR["SecondryCategory"].ToString();
                                    ObjBLLTestReport.InvestigationId = DR["InvestigationId"].ToString();
                                    ObjBLLTestReport.RangeValue = DR["RangeValue"].ToString();
                                    ObjBLLTestReport.ResultValue = DR["ResultValue"].ToString();
                                    ObjBLLTestReport.ResultType = DR["ResultType"].ToString();
                                    ObjBLLTestReport.CriticalLow = DR["CriticalLow"].ToString();
                                    ObjBLLTestReport.CriticalHigh = DR["CriticalHigh"].ToString();
                                    ObjBLLTestReport.TestId = DR["TestId"].ToString();
                                    ObjBLLTestReport.DateOfReport = DR["DateOfReport"].ToString();
                                    ObjBLLTestReport.ReportStatus = DR["ReportStatus"].ToString();
                                    ObjBLLTestReport.AreaName = DR["AreaName"].ToString();
                                    ObjBLLTestReport.Remarks = DR["Remarks"].ToString();
                                    ObjBLLTestReport.RangeFrom = DR["RangeFrom"].ToString();
                                    ObjBLLTestReport.RangeTo = DR["RangeTo"].ToString();
                                    ObjBLLTestReport.Comments = DR["Comments"].ToString();
                                    ObjBLLTestReport.UnitCode = DR["UnitCode"].ToString();
                                    ObjBLLTestReport.InvestigationType = DR["InvestigationType"].ToString();
                                    ObjBLLTestReport.PrimaryCategoryName = DR["PrimaryCategoryName"].ToString();
                                    ObjBLLTestReport.IsChecked = Convert.ToBoolean(DR["IsChecked"].ToString());
                                    ObjBLLTestReport.IsPublish = Convert.ToBoolean(DR["IsPublish"].ToString());
                                    ObjBLLTestReport.LocationId = DR["LocationId"].ToString();
                                    ObjBLLTestReport.CaseBookedAt = DR["CaseBookedAt"].ToString();
                                    ObjBLLTestReport.CaseProcessedAt = DR["CaseProcessedAt"].ToString();
                                    ObjBLLTestReport.IsCultureReport = DR["IsCultureReport"].ToString();
                                    ObjBLLTestReport.AntiobioticLevel = DR["AntiobioticLevel"].ToString();
                                    ObjBLLTestReport.ReceiptPrefix = DR["ReceiptPrefix"].ToString();
                                    ObjBLLTestReport.PanelNo = DR["PanelNo"].ToString();
                                    ObjBLLTestReport.IsNABL = Convert.ToBoolean(DR["IsNABL"].ToString());
                                    ObjBLLTestReport.FullAge = DR["FullAge"].ToString();
                                    ObjBLLTestReport.Balance = Convert.ToDecimal(DR["Balance"].ToString());
                                    ObjBLLTestReport.PrintRangeName = Convert.ToBoolean(DR["PrintRangeName"].ToString());
                                    ObjBLLTestReport.ResultRange = DR["ResultRange"].ToString();
                                    ObjBLLTestReport.ClinicalHistory = DR["ClinicalHistory"].ToString();
                                    ObjBLLTestReport.AntiobioticRank = Convert.ToInt64(DR["AntiobioticRank"].ToString());
                                   // ObjBLLTestReport.ClaimId = claimId;
                                    int insertResult = ObjBLLTestReport.ExecuteNonQuery(ObjBLLTestReport);
                                    
                                }
                            }

                        }
                        objBLLDC.SpType = 3;
                        int UpdateResult = objBLLDC.ExecuteNonQuery(objBLLDC);
                    }
                }
                
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }

    }
}