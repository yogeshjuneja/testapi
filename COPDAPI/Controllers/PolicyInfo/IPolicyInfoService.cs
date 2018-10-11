using System.Data;
namespace COPDAPI.Controllers
{
    public interface IPolicyInfoService
    {
        DataTable PolicyDetails(string PolicyNumber);
        DataTable MemberDetails(string PolicyNumber);
        DataTable MemberBenefitDetails(string PolicyNumber, string MemberCode);
        DataTable ValidatePolicyDetail(string ContactMobile);
        DataTable DCCoveredinfo(string PolicyNumber, string MemberCode);
        DataSet DCPolicyDetails(string PolicyNumber, string FirstName, string DC_ID, string Insurance = "", string TPAName = "");
        DataSet DCPolicyDetailsMemberCode(string PolicyNumber, string FirstName, string DC_ID, string Insurance = "", string TPAName = "");
        DataSet DocPolicyDetails(string PolicyNumber, string FirstName, string doctorID, string Insurance, string TPAName);
        DataSet DocPolicyDetailsMemberCode(string PolicyNumber, string FirstName, string doctorID, string Insurance, string TPAName);
    }
}
