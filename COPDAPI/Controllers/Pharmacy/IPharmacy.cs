using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COPDAPI.Controllers.Pharmacy
{
    public interface IPharmacy
    {
        DataSet GetPharmacyPolicyInfo(string PolicyNumber, string FirstName);
    }
}
