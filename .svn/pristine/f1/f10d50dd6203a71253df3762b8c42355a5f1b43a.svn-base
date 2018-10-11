using COPDAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COPDAPI.Controllers.DoctorClaim
{
    public interface IDoctorClaim
    {
        DataSet SaveDoctorClaim(DoctorClaimRequest objDoctorRequestClaim);
        bool CheckIsPolicyValid(string PolicyNumber);
        bool CheckIsPolicyMemberValid(string PolicyNumber, string MemberCode);
        string GetClientCode(string PolicyNumber);
        DataSet DoctorDetails(string DoctorID,string Token);
        DataSet PolicySpecializationDetails(string DoctorID, string Token, string PolicyNumber);
        DataTable OTPDetails(string PatientMobile, string strIP);
    }
}
