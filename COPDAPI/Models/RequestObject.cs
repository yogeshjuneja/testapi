using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace COPDAPI.Models
{
    public class PolicyRequestObject
    {
        public string PolicyNumber { get; set; }
        public string MemberCode { get; set; }
        public string MobileNo { get; set; }
    }

    public class DoctorClaimRequest
    {
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
        public string Token { get; set; }
        public string PatientPic { get; set; }
        public List<Document> DocumentUrl { get; set; }
        public string DCDocument { get; set; }
        public string PharmacyDocument { get; set; }
        public string IP { get; set; }
        public string AppointmentDate { get; set; }
        public string DC_Diagnosis { get; set; }
        public string DC_ClaimedAmount { get; set; }
    }

    public class Document
    {
        public string DocumentName { get; set; }
        public string DocumentUrl { get; set; }
    }

    public class DCClaimRequest
    {
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

    }


    public class DiagnosticCenterClaim
    {    
        public Int64 Id { get; set; }
        public string TDCC_ClaimClient { get; set; }
        public string TDCC_ClaimID { get; set; }
        public string TDCC_PolicyNumber { get; set;}
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
        public Int64  ModUser { get; set; }
        public DateTimeOffset ModDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string IP { get; set; }
        public string DC_Diagnosis { get; set; }
        public string DC_ClaimedAmount { get; set; }
        public string DC_ARRemarks { get; set; }
        public Int64 DC_ARBY { get; set; }
        public DateTime DC_ARDATETIME { get; set; }
        public int DC_ARStatus { get; set; }
        public Int32 SpType { get; set; }
        public string Token { get; set; }
    }

    public class PharmacyClaimRequest
    {
        public string TPC_ClaimClient { get; set; }
        public string TPC_PolicyNumber { get; set; }
        public string TPC_PatientName { get; set; }
        public string TPC_MemberCode { get; set; }
        public string TPC_PatientMobile { get; set; }
        public Int64 TPC_ID { get; set; }
        public string TPC_Name { get; set; }
        public string TPC_AppointmentDate { get; set; }
        public string TPC_Document { get; set; }
        public string TPC_ClaimedAmount { get; set; }
        public string TPC_ARRemarks { get; set; }
        public string Token { get; set; }
        public string IP { get; set; }
        public List<PharmacyClaimDetail> PharmacyClaimDetail { get; set; }
    }

    public class PharmacyClaimDetail
    {
        public Int64 Id { get; set; }
        public Int64 TPC_Id { get; set; }
        public string TPC_MedicineName { get; set; }
        public int TPC_QTY { get; set; }
        public string TPC_SellingPrice { get; set; }
    }
    public class PharmacyList
    {
        public List<PharmacyClaimRequest> PharmacyClaimRequest { get; set; }
        public List<PharmacyClaimDetail> PharmacyClaimDetail { get; set; }
    }
    public class PharmacyRequestObject
    {
        public string PolicyNumber { get; set; }
        public string FirstName { get; set; }
        public Int64 Pharmacy_Id { get; set; }
        public Int64 Insurance_Id { get; set; }
        public string TPA_No { get; set; }
    }
}