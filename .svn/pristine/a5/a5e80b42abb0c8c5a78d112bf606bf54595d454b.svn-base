using DLLCOPD;
using System;
using System.Data;
using System.Data.SqlClient;
namespace BLLCOPD
{
    public class BLLPolicyInfo
    {
        #region Variable
        public Int32 Sptype { get; set; }
        public string PolicyNumber { get; set; }
        public string vchMemberCode { get; set; }
        public Int32 intPolicyInfoId { get; set; }
        public string ContactMobile { get; set; }
        public string FirstName { get; set; }
        public string DCID { get; set; }
        #endregion

        #region Method
        public DataSet ExecuteDataset(BLLPolicyInfo objBLLPolicyInfo)
        {
            using (SqlConnection ConnectionString = new SqlConnection(Configuration.ConnectionStrings))
            {
                SqlParameter[] _parameters = {
                        new SqlParameter("@Sptype",objBLLPolicyInfo.Sptype),
                        new SqlParameter("@POlicyNumber",objBLLPolicyInfo.PolicyNumber),
                        new SqlParameter("@vchMemberCode",objBLLPolicyInfo.vchMemberCode),
                        new SqlParameter("@intPolicyInfoId",objBLLPolicyInfo.intPolicyInfoId),
                        new SqlParameter("@ContactMobile",objBLLPolicyInfo.ContactMobile),
                        new SqlParameter("@FirstName",objBLLPolicyInfo.FirstName),
                        new SqlParameter("@DCID",objBLLPolicyInfo.DCID)
                                    };
                return SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "PROC_PolicyInfo", _parameters);
            }
        }
        #endregion
    }
}
