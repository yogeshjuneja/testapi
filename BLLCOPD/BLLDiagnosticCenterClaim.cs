using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DLLCOPD;
using System.Data;

namespace BLLCOPD
{
   public  class BLLDiagnosticCenterClaim
    {
        #region Variable      
        public Int64 Id { get; set; }
        public string TDCC_ClaimClient { get; set; }
        public string TDCC_ClaimID { get; set; }
        public string TDCC_PolicyNumber { get; set; }
        public string TDCC_PatientName { get; set; }
        public string TDCC_MemberCode { get; set; }
        public string TDCC_PatientAge { get; set; }
        public string TDCC_PatientGen { get; set; }
        public string TDCC_PatientAddress { get; set; }
        public string TDCC_PatientMobile { get; set; }
        public string TDCC_AppointmentDate { get; set; }
        public string TDCC_DCID { get; set; }
        public string TDCC_DCName { get; set; }
        public string TDCC_PatientPic { get; set; }
        public string TDCC_Document { get; set; }
        public string TDCC_DCDocument { get; set; }
        public string TDCC_PharmacyDocument { get; set; }
        public Int64 AddUser { get; set; }
        public DateTimeOffset AddDate { get; set; }
        public Int64 ModUser { get; set; }
        public DateTimeOffset ModDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string IP { get; set; }
        public string DC_Diagnosis { get; set; }
        public string DC_ClaimedAmount { get; set; }
        public string DC_ARRemarks { get; set; }
        public Int64 DC_ARBY { get; set; }
        public string DC_ARDATETIME { get; set; }
        public int DC_ARStatus { get; set; }
        public Int32 SpType { get; set; }
        public string Token { get; set; }


        #endregion
        #region Methods
        public DataSet ExecuteDataset(BLLDiagnosticCenterClaim objBLLDC)
        {
            using (SqlConnection ConnectionString = new SqlConnection(Configuration.ConnectionStringsMaster))
            {
                SqlParameter[] _parameters = {
                            new SqlParameter("@Sptype",objBLLDC.SpType),
                            new SqlParameter("@Token",objBLLDC.Token),
                            new SqlParameter("@ClaimClient",objBLLDC.TDCC_ClaimClient),
                            new SqlParameter("@PolicyNumber",objBLLDC.TDCC_PolicyNumber),
                            new SqlParameter("@PatientName",objBLLDC.TDCC_PatientName),
                            new SqlParameter("@MemberCode",objBLLDC.TDCC_MemberCode),
                            new SqlParameter("@PatientAge",objBLLDC.TDCC_PatientAge),
                            new SqlParameter("@PatientGen",objBLLDC.TDCC_PatientGen),
                            new SqlParameter("@PatientAddress",objBLLDC.TDCC_PatientAddress),
                            new SqlParameter("@PatientMobile",objBLLDC.TDCC_PatientMobile),
                            new SqlParameter("@AppointmentDate",objBLLDC.TDCC_AppointmentDate),
                            new SqlParameter("@DC_ID",objBLLDC.TDCC_DCID),
                            new SqlParameter("@DC_Name",objBLLDC.TDCC_DCName),
                            new SqlParameter("@PatientPic",objBLLDC.TDCC_PatientPic),
                            new SqlParameter("@Document",objBLLDC.TDCC_Document),
                            new SqlParameter("@DCDocument",objBLLDC.TDCC_DCDocument),
                            new SqlParameter("@PharmacyDocument",objBLLDC.TDCC_PharmacyDocument),
                            new SqlParameter("@IP",objBLLDC.IP),
                            new SqlParameter("@DC_Diagnosis",objBLLDC.DC_Diagnosis),
                            new SqlParameter("@DC_ClaimedAmount",objBLLDC.DC_ClaimedAmount),

                                    };
                return SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "PROC_DiagnosticCenterClaim", _parameters);
            }
        }
        #endregion
    }
}
