using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data.SqlClient;
using DLLCOPD;
using System.Data;

namespace BLLCOPD
{
    public class BLLPharmacyClaim
    {
        #region Variable
        public Int64 Id { get; set; }
        public string TPC_ClaimClient { get; set; }
        public string TPC_ClaimID { get; set; }
        public string TPC_PolicyNumber { get; set; }
        public string TPC_PatientName { get; set; }
        public string TPC_MemberCode { get; set; }
        public int TPC_PatientAge { get; set; }
        public string TPC_PatientGen { get; set; }
        public string TPC_PatientAddress { get; set; }
        public string TPC_PatientMobile { get; set; }
        public string TPC_AppointmentDate { get; set; }
        public Int64 TPC_ID { get; set; }
        public string TPC_Name { get; set; }
        public string TPC_PatientPic { get; set; }
        public string TPC_Document { get; set; }
        public string TPC_DCDocument { get; set; }
        public string TPC_PharmacyDocument { get; set; }
        public string TPC_Diagnosis { get; set; }
        public string TPC_ClaimedAmount { get; set; }
        public string TPC_ARRemarks { get; set; }
        public string TPC_ARBY { get; set; }
        public string TPC_ARDATETIME { get; set; }
        public string TPC_ARStatus { get; set; }
        public Int32 SpType { get; set; }
        public string Token { get; set; }
        public String IP { get; set; }

        //Pharmacy Claim Details
       
            
            public Int64 TPC_Id { get; set; }
            public string TPC_MedicineName { get; set; }
            public string TPC_QTY { get; set; }
            public string TPC_MRP { get; set; }
            public string TPC_SellingPrice { get; set; }
       public DataTable dtPharmacyClaimDetails { get; set; }
        #endregion

        #region Method
        public DataSet ExecuteDataset(BLLPharmacyClaim objBLLPC)
        {
            using (SqlConnection ConnectionString = new SqlConnection(Configuration.ConnectionStringsMaster))
            {
                SqlParameter[] _parameters = {
                            new SqlParameter("@Sptype",objBLLPC.SpType),
                            new SqlParameter("@Token",objBLLPC.Token),
                            new SqlParameter("@TPCClaimClient",objBLLPC.TPC_ClaimClient),
                            new SqlParameter("@TPCPolicyNumber",objBLLPC.TPC_PolicyNumber),
                            new SqlParameter("@TPCPatientName",objBLLPC.TPC_PatientName),
                            new SqlParameter("@TPCMemberCode",objBLLPC.TPC_MemberCode),
                            new SqlParameter("@TPCPatientMobile",objBLLPC.TPC_PatientMobile),
                            new SqlParameter("@TPCAppointmentDate",objBLLPC.TPC_AppointmentDate),
                            new SqlParameter("@TPCID",objBLLPC.TPC_ID),
                            new SqlParameter("@TPCName",objBLLPC.TPC_Name),
                            new SqlParameter("@TPCDocument",objBLLPC.TPC_Document),
                            new SqlParameter("@IP",objBLLPC.IP),
                            new SqlParameter("@TPCClaimedAmount",objBLLPC.TPC_ClaimedAmount),
                            new SqlParameter("@TPC_Medicine",objBLLPC.TPC_MedicineName),
                            new SqlParameter("@TPC_Qty",objBLLPC.TPC_QTY),
                            new SqlParameter("@TPC_Mrp",objBLLPC.TPC_MRP),
                            new SqlParameter("@TPC_SellingPrice",objBLLPC.TPC_SellingPrice)
                                    };
                return SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "PROC_PharmacyClaim", _parameters);
            }
        }
        #endregion
    }
}
