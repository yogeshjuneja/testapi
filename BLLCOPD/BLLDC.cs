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
     public class BLLDC
    {
        #region Variable      
        public string DC_Id { get; set; }
        public string DC_Name { get; set; }
        public string DC_CAreaId { get; set; }
        public string AreaId { get; set; }
        public string AreaName { get; set; }
        public int DC_CCityId { get; set; }
        public int CityId { get; set; }
        public string City { get; set; }
        public int DC_CStateId { get; set; }
        public int StateId { get; set; }
        public string State { get; set; }
        public int DC_CCountryId { get; set; }
        public int CountryId { get; set; }
        public string Country { get; set; }
        public string Pincode { get; set; }
        public Int64 AddUser { get; set; }
        public DateTimeOffset AddDate { get; set; }
        public Int64 ModUser { get; set; }
        public DateTimeOffset ModDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string IP { get; set; }
        public Int32 SpType { get; set; }
        public string Token { get; set; }

        public Int64 Id { get; set; }


        #endregion

        #region Methods
        public DataSet ExecuteDataset(BLLDC objBLLDc)
        {
            using (SqlConnection ConnectionString = new SqlConnection(Configuration.ConnectionStringsMaster))
            {
                SqlParameter[] _parameters = {
                    new SqlParameter("@Sptype",objBLLDc.SpType),
                    new SqlParameter("@Token",objBLLDc.Token),
                    new SqlParameter("@DC_Id",objBLLDc.DC_Id),
                    new SqlParameter("@DC_AreaId",objBLLDc.AreaId),
                    new SqlParameter("@DC_CAreaId",objBLLDc.DC_CAreaId),
                    new SqlParameter("@DC_AreaName",objBLLDc.AreaName),
                    new SqlParameter("@DC_CCityId",objBLLDc.DC_CCityId),
                    new SqlParameter("@DC_CityId",objBLLDc.CityId),
                    new SqlParameter("@DC_City",objBLLDc.City),
                    new SqlParameter("@DC_CStateId",objBLLDc.DC_CStateId),
                    new SqlParameter("@DC_StateId",objBLLDc.StateId),
                    new SqlParameter("@DC_State",objBLLDc.State),
                    new SqlParameter("@DC_CCountryId",objBLLDc.DC_CCountryId),
                    new SqlParameter("@DC_CountryId",objBLLDc.CountryId),
                    new SqlParameter("@DC_Country",objBLLDc.Country),
                    new SqlParameter("@DC_Name",objBLLDc.DC_Name),
                    new SqlParameter("@DC_Pincode",objBLLDc.Pincode),
                    new SqlParameter("@IP",objBLLDc.IP),
                    new SqlParameter("@IsActive",objBLLDc.IsActive),
                    new SqlParameter("@IsDeleted",objBLLDc.IsDeleted),
                    //new SqlParameter("@AddUser",objBLLDc.AddUser),
                    new SqlParameter("@AddDate",objBLLDc.AddDate),
                    new SqlParameter("@ModDate",objBLLDc.ModDate),
                    new SqlParameter("@ModUser",objBLLDc.ModUser)
                    
                    

                                    };
                return SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "PROC_DiagnosticCenter", _parameters);
            }
        }

        public int ExecuteNonQuery(BLLDC objBLLDc)
        {
            using (SqlConnection ConnectionString = new SqlConnection(Configuration.ConnectionStringsMaster))
            {
                SqlParameter[] _parameters = {
                    new SqlParameter("@Sptype",objBLLDc.SpType),
                    new SqlParameter("@Token",objBLLDc.Token),
                    new SqlParameter("@DC_Id",objBLLDc.DC_Id),
                    new SqlParameter("@DC_AreaId",objBLLDc.AreaId),
                    new SqlParameter("@DC_CAreaId",objBLLDc.DC_CAreaId),
                    new SqlParameter("@DC_AreaName",objBLLDc.AreaName),
                    new SqlParameter("@DC_CCityId",objBLLDc.DC_CCityId),
                    new SqlParameter("@DC_CityId",objBLLDc.CityId),
                    new SqlParameter("@DC_City",objBLLDc.City),
                    new SqlParameter("@DC_CStateId",objBLLDc.DC_CStateId),
                    new SqlParameter("@DC_StateId",objBLLDc.StateId),
                    new SqlParameter("@DC_State",objBLLDc.State),
                    new SqlParameter("@DC_CCountryId",objBLLDc.DC_CCountryId),
                    new SqlParameter("@DC_CountryId",objBLLDc.CountryId),
                    new SqlParameter("@DC_Country",objBLLDc.Country),
                    new SqlParameter("@DC_Name",objBLLDc.DC_Name),
                    new SqlParameter("@DC_Pincode",objBLLDc.Pincode),
                    new SqlParameter("@IP",objBLLDc.IP),
                    new SqlParameter("@IsActive",objBLLDc.IsActive),
                    new SqlParameter("@IsDeleted",objBLLDc.IsDeleted),
                    //new SqlParameter("@AddUser",objBLLDc.AddUser),
                    new SqlParameter("@AddDate",objBLLDc.AddDate),
                    new SqlParameter("@ModDate",objBLLDc.ModDate),
                    new SqlParameter("@ModUser",objBLLDc.ModUser),
                     new SqlParameter("@DcId",objBLLDc.Id)

                                    };
                return SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "PROC_DiagnosticCenter", _parameters);
            }
        }

        #endregion

    }
}
