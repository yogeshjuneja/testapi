using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DLLCOPD;
using System.Data;

namespace BLLCOPD
{
    public class BLLDoctorClaim
    {
        #region Variable
        public string ClientId { get; set; }
        public string PolicyNumber { get; set; }
        public string PatientName { get; set; }
        public string MemberCode { get; set; }
        public string PatientAge { get; set; }
        public string PatientGender { get; set; }
        public string PatientAddress { get; set; }
        public string PatientMobile { get; set; }
        public string DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string PatientPic { get; set; }
        public string Document { get; set; }
        public string DCDocument { get; set; }
        public string PharmacyDocument { get; set; }
        public string AppointmentDate { get; set; }
        public string IP { get; set; }
        public Int32 SpType { get; set; }
        public string Token { get; set; }
        public string DC_Diagnosis { get; set; }
        public string DC_ClaimedAmount { get; set; }
        public string DC_DocumentUrl { get; set; }
        public string DC_DocumentName { get; set; }
        #endregion

        #region Methods
        public DataSet ExecuteDataset(BLLDoctorClaim objBLLDoctorClaim)
        {
            using (SqlConnection ConnectionString = new SqlConnection(Configuration.ConnectionStringsMaster))
            {
                SqlParameter[] _parameters = {
                            new SqlParameter("@Sptype",objBLLDoctorClaim.SpType),
                            new SqlParameter("@Token",objBLLDoctorClaim.Token),
                            new SqlParameter("@ClaimClient",objBLLDoctorClaim.ClientId),
                            new SqlParameter("@PolicyNumber",objBLLDoctorClaim.PolicyNumber),
                            new SqlParameter("@PatientName",objBLLDoctorClaim.PatientName),
                            new SqlParameter("@MemberCode",objBLLDoctorClaim.MemberCode),
                            new SqlParameter("@PatientAge",objBLLDoctorClaim.PatientAge),
                            new SqlParameter("@PatientGen",objBLLDoctorClaim.PatientGender),
                            new SqlParameter("@PatientAddress",objBLLDoctorClaim.PatientAddress),
                            new SqlParameter("@PatientMobile",objBLLDoctorClaim.PatientMobile),
                            new SqlParameter("@DoctorId",objBLLDoctorClaim.DoctorId),
                            new SqlParameter("@DoctorName",objBLLDoctorClaim.DoctorName),
                            new SqlParameter("@PatientPic",objBLLDoctorClaim.PatientPic),
                            new SqlParameter("@Document",objBLLDoctorClaim.Document),
                            new SqlParameter("@DCDocument",objBLLDoctorClaim.Document),
                            new SqlParameter("@DocumentUrL",objBLLDoctorClaim.DC_DocumentUrl),
                            new SqlParameter("@DocumentName",objBLLDoctorClaim.DC_DocumentName),
                            new SqlParameter("@PharmacyDocument",objBLLDoctorClaim.PharmacyDocument),
                            new SqlParameter("@IP",objBLLDoctorClaim.IP),
                            new SqlParameter("@DC_Diagnosis",objBLLDoctorClaim.DC_Diagnosis),
                            new SqlParameter("@DC_ClaimedAmount",objBLLDoctorClaim.DC_ClaimedAmount),
                            new SqlParameter("@AppointmentDate",objBLLDoctorClaim.AppointmentDate)

                                    };
                return SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "PROC_DoctorClaim", _parameters);
            }
        }
        #endregion
    }
}
