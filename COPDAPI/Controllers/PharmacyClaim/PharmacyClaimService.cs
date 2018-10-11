using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLLCOPD;
using COPDAPI.Models;
using System.Data;
using System;
using System.ComponentModel;

namespace COPDAPI.Controllers.PharmacyClaim
{
    public class PharmacyClaimService:IPharmacyClaimService
    {
        BLLPharmacyClaim objBLLPClaim = new BLLPharmacyClaim();
        DataTable dt = new DataTable();
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
        /// Add DC Claim Details
        /// </summary>
        /// <param name="objDCClaim"></param>
        /// <returns></returns>
        public DataTable SavePCClaim(PharmacyClaimRequest objPClaim)
        {
            
                objBLLPClaim.SpType = 1;
                objBLLPClaim.Token = objPClaim.Token;
                objBLLPClaim.TPC_ClaimClient= objPClaim.TPC_ClaimClient;
                objBLLPClaim.TPC_PolicyNumber= objPClaim.TPC_PolicyNumber;
                objBLLPClaim.TPC_Document= objPClaim.TPC_ClaimClient;
                objBLLPClaim.TPC_PatientName = objPClaim.TPC_PatientName;
                objBLLPClaim.TPC_MemberCode = objPClaim.TPC_MemberCode;
                objBLLPClaim.TPC_PatientMobile = objPClaim.TPC_PatientMobile;
                objBLLPClaim.TPC_AppointmentDate = objPClaim.TPC_AppointmentDate;
                objBLLPClaim.TPC_ID = objPClaim.TPC_ID;
                objBLLPClaim.TPC_Name = objPClaim.TPC_Name;               
                objBLLPClaim.IP = objPClaim.IP;
                objBLLPClaim.TPC_ClaimedAmount = objPClaim.TPC_ClaimedAmount;
                objBLLPClaim.TPC_ARRemarks = objPClaim.TPC_ARRemarks;
                objBLLPClaim.TPC_MedicineName = "";
                objBLLPClaim.TPC_MRP = "";
                objBLLPClaim.TPC_QTY = "";
                objBLLPClaim.TPC_SellingPrice = "";
                foreach (var item in objPClaim.PharmacyClaimDetail)
                {

                    objBLLPClaim.TPC_MedicineName += item.TPC_MedicineName + "|";
                    objBLLPClaim.TPC_QTY+= item.TPC_QTY + "|";
                    objBLLPClaim.TPC_SellingPrice += item.TPC_SellingPrice + "|";
                }
                DataSet objds = objBLLPClaim.ExecuteDataset(objBLLPClaim);
                return objds.Tables[0];            
        }

        

    }
}