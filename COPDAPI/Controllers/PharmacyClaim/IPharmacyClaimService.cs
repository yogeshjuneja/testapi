using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COPDAPI.Models;
using System.Data;

namespace COPDAPI.Controllers.PharmacyClaim
{
    public interface IPharmacyClaimService
    {
        DataTable SavePCClaim(PharmacyClaimRequest objPClaim);
    }
}