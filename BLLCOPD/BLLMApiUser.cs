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
    /// <summary>
    /// 
    /// </summary>
    public class BLLMApiUser
    {

        #region Variable
        public string Token{ get; set; }
        public string ActionMethod { get; set; }
        public string Controller { get; set; }
        public  string IP { get; set; }
        public  string RequestUrl { get; set; }
        public string RequestObject { get; set; }
        public string ResponseObject { get; set; }
        public Int32 Sptype { get; set; }
        #endregion

        #region Method
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objBLLApiUser"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(BLLMApiUser objBLLApiUser)
        {
            using (SqlConnection ConnectionString = new SqlConnection(Configuration.ConnectionStringsMaster))
            {
                SqlParameter[] _parameters = {
                    new SqlParameter("@Sptype",objBLLApiUser.Sptype),
                    new SqlParameter("@Token",objBLLApiUser.Token),
                    new SqlParameter("@ActionMethod",objBLLApiUser.ActionMethod),
                    new SqlParameter("@Controller",objBLLApiUser.Controller),
                    new SqlParameter("@Ip",objBLLApiUser.IP),
                    new SqlParameter("@RequestedUrl",objBLLApiUser.RequestUrl),
                    new SqlParameter("@RequestedObject",objBLLApiUser.RequestObject),
                    new SqlParameter("@ResponseObject",objBLLApiUser.ResponseObject)
                                };
                return Convert.ToInt32(SqlHelper.ExecuteScalar(ConnectionString,CommandType.StoredProcedure, "PROC_ApiUser", _parameters));
            }
        }
        #endregion
    }
}
