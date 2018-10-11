using DLLCOPD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLCOPD
{
    public class BLLTestReport
    {
        #region variables
        public int SpType { get; set; }
        public string TestName { get; set; }
        public string ProfileName { get; set; }
        public bool IsTestCompleted { get; set; }
        public string CaseId { get; set; }
        public Int64 Advise_SNo { get; set; }
        public string CaseCode { get; set; }
        public string CaseBarCode { get; set; }
        public string PatientCode { get; set; }
        public string ContactNo { get; set; }
        public string PatientName { get; set; }
        public string PatientId { get; set; }
        public string Sex { get; set; }
        public string Age { get; set; }
        public string LabNo { get; set; }
        public string AdvisedDoctor { get; set; }
        public string AdviseDate { get; set; }
        public string ReportNo { get; set; }
        public string Specimen { get; set; }
        public string SampleCollectedDate { get; set; }
        public string SecondryCategory { get; set; }
        public string InvestigationId { get; set; }
        public string RangeValue { get; set; }
        public string ResultValue { get; set; }
        public string ResultType { get; set; }
        public string CriticalLow { get; set; }
        public string CriticalHigh { get; set; }
        public string TestId { get; set; }
        public string DateOfReport { get; set; }
        public string ReportStatus { get; set; }
        public string AreaName { get; set; }
        public string Remarks { get; set; }
        public string RangeFrom { get; set; }
        public string RangeTo { get; set; }
        public string Comments { get; set; }
        public string UnitCode { get; set; }
        public string InvestigationType { get; set; }
        public string PrimaryCategoryName { get; set; }
        public bool IsChecked { get; set; }
        public bool IsPublish { get; set; }
        public string LocationId { get; set; }
        public string CaseBookedAt { get; set; }
        public string CaseProcessedAt { get; set; }
        public string IsCultureReport { get; set; }
        public string AntiobioticLevel { get; set; }
        public string ReceiptPrefix { get; set; }
        public string PanelNo { get; set; }
        public bool IsNABL { get; set; }
        public string FullAge { get; set; }
        public decimal Balance { get; set; }
        public bool PrintRangeName { get; set; }
        public string ResultRange { get; set; }
        public string ClinicalHistory { get; set; }
        public Int64 AntiobioticRank { get; set; }
        #endregion

        #region Methods
        public int ExecuteNonQuery(BLLTestReport objBLLTestReport)
        {
            using (SqlConnection ConnectionString = new SqlConnection(Configuration.ConnectionStringsMaster))
            {
                    SqlParameter[] _parameters = {
                        new SqlParameter("@Sptype",objBLLTestReport.SpType),
                        new SqlParameter("@TestName",objBLLTestReport.TestName),
                        new SqlParameter("@ProfileName",objBLLTestReport.ProfileName),
                        new SqlParameter("@IsTestCompleted",objBLLTestReport.IsTestCompleted),
                        new SqlParameter("@CaseId",objBLLTestReport.CaseId),
                        new SqlParameter("@Advise_SNo",objBLLTestReport.Advise_SNo),
                        new SqlParameter("@CaseCode",objBLLTestReport.CaseCode),
                        new SqlParameter("@CaseBarCode",objBLLTestReport.CaseBarCode),
                        new SqlParameter("@PatientCode",objBLLTestReport.PatientCode),
                        new SqlParameter("@ContactNo",objBLLTestReport.ContactNo),
                        new SqlParameter("@PatientName",objBLLTestReport.PatientName),
                        new SqlParameter("@PatientId",objBLLTestReport.PatientId),
                        new SqlParameter("@Sex",objBLLTestReport.Sex),
                        new SqlParameter("@Age",objBLLTestReport.Age),
                        new SqlParameter("@LabNo",objBLLTestReport.LabNo),
                        new SqlParameter("@AdvisedDoctor",objBLLTestReport.AdvisedDoctor),
                        new SqlParameter("@AdviseDate",objBLLTestReport.AdviseDate),
                        new SqlParameter("@ReportNo",objBLLTestReport.DateOfReport),
                        new SqlParameter("@Specimen",objBLLTestReport.Specimen),
                        new SqlParameter("@SampleCollectedDate",objBLLTestReport.SampleCollectedDate),
                        new SqlParameter("@SecondryCategory",objBLLTestReport.SecondryCategory),
                        new SqlParameter("@InvestigationId",objBLLTestReport.InvestigationId),
                        new SqlParameter("@RangeValue",objBLLTestReport.RangeValue),
                        new SqlParameter("@ResultValue",objBLLTestReport.ResultValue),
                        new SqlParameter("@ResultType",objBLLTestReport.ResultType),
                        new SqlParameter("@CriticalLow",objBLLTestReport.CriticalLow),
                        new SqlParameter("@CriticalHigh",objBLLTestReport.CriticalHigh),
                        new SqlParameter("@TestId",objBLLTestReport.TestId),
                        new SqlParameter("@DateOfReport",objBLLTestReport.DateOfReport),
                        new SqlParameter("@ReportStatus",objBLLTestReport.ReportStatus),
                        new SqlParameter("@AreaName",objBLLTestReport.AreaName),
                        new SqlParameter("@Remarks",objBLLTestReport.Remarks),
                        new SqlParameter("@RangeFrom",objBLLTestReport.RangeFrom),
                        new SqlParameter("@RangeTo",objBLLTestReport.RangeTo),
                        new SqlParameter("@Comments",objBLLTestReport.Comments),
                        new SqlParameter("@UnitCode",objBLLTestReport.UnitCode),
                        new SqlParameter("@InvestigationType",objBLLTestReport.InvestigationType),
                        new SqlParameter("@PrimaryCategoryName",objBLLTestReport.PrimaryCategoryName),
                        new SqlParameter("@IsChecked",objBLLTestReport.IsChecked),
                        new SqlParameter("@IsPublish",objBLLTestReport.IsPublish),
                        new SqlParameter("@LocationId",objBLLTestReport.LocationId),
                        new SqlParameter("@CaseBookedAt",objBLLTestReport.CaseBookedAt),
                        new SqlParameter("@CaseProcessedAt",objBLLTestReport.CaseProcessedAt),
                        new SqlParameter("@IsCultureReport",objBLLTestReport.IsCultureReport),
                        new SqlParameter("@AntiobioticLevel",objBLLTestReport.AntiobioticLevel),
                        new SqlParameter("@ReceiptPrefix",objBLLTestReport.ReceiptPrefix),
                        new SqlParameter("@PanelNo",objBLLTestReport.PanelNo),
                        new SqlParameter("@IsNABL",objBLLTestReport.IsNABL),
                        new SqlParameter("@FullAge",objBLLTestReport.FullAge),
                        new SqlParameter("@Balance",objBLLTestReport.Balance),
                        new SqlParameter("@PrintRangeName",objBLLTestReport.PrintRangeName),
                        new SqlParameter("@ClinicalHistory",objBLLTestReport.ClinicalHistory),
                        new SqlParameter("@AntiobioticRank",objBLLTestReport.AntiobioticRank)
                                                                                                            

                                };
                return Convert.ToInt32(SqlHelper.ExecuteScalar(ConnectionString, CommandType.StoredProcedure, "PROC_TestReport", _parameters));
            }
        }
        #endregion
    }
}
