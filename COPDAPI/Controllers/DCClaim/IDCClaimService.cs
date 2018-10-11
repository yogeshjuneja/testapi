using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COPDAPI.Models;
using System.Data;

namespace COPDAPI.Controllers.DCClaim
{
    public interface IDCClaimService
    {
        DataTable SaveDCClaim(DiagnosticCenterClaim objDCClaim);
       
    }
}