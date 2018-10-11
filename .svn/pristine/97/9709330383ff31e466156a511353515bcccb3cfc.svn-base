#region
using BLLCOPD;
using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Controllers;
#endregion

namespace COPDAPI.Filters
{
    public class AuthenticateFilter:AuthorizeAttribute
    {
        BLLMApiUser objBLLMApiUser = new BLLMApiUser();
        public override void OnAuthorization(HttpActionContext filterContext)
      {
            if (AuthorizeToken(filterContext))
            {
                return;
            }
            HandleUnauthorizedRequest(filterContext);
        }

        protected override void HandleUnauthorizedRequest(HttpActionContext filterContext)
        {
            base.HandleUnauthorizedRequest(filterContext);
        }

        private bool AuthorizeToken(HttpActionContext actionContext)
        {
            try
            {
                var encodedString = actionContext.Request.Headers.GetValues("Token").First();

                bool validFlag = false;

                if (!string.IsNullOrEmpty(encodedString))
                {
                    objBLLMApiUser.Token=encodedString;
                    objBLLMApiUser.Sptype = 1;
                    int UserCount = objBLLMApiUser.ExecuteNonQuery(objBLLMApiUser);
                    
                    if (UserCount>0)
                    {
                        validFlag = true;
                    }
                }
                return validFlag;
            }
            catch (Exception )
            {
                return false;
            }
        }
    }
}