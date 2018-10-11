
using BLLCOPD;
using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace COPDAPI.Filters
{
    public class CustomAuthenticate : AuthorizeAttribute
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
            bool IsAuthorized = false;
            try
            {
                
                objBLLMApiUser.Sptype = 2;
                objBLLMApiUser.ActionMethod = actionContext.ActionDescriptor.ActionName;
                objBLLMApiUser.Controller = actionContext.ControllerContext.ControllerDescriptor.ControllerName;
                objBLLMApiUser.Token = actionContext.Request.Headers.GetValues("Token").First();
                
                int Result = objBLLMApiUser.ExecuteNonQuery(objBLLMApiUser);
                if (Result == -200)
                {
                    IsAuthorized = true;
                }
                return IsAuthorized;
            }
            catch (Exception )
            {
                return false;
            }
                
        }

    }

}