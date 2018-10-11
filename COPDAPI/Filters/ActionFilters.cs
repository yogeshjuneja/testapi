using BLLCOPD;
using COPDAPI.Models;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.Xml;

namespace COPDAPI.Filters
{
    public class ActionFilters: ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            BLLMApiUser objBLLMApiUser = new BLLMApiUser();
            objBLLMApiUser.Sptype = 3;
            objBLLMApiUser.IP = GetClientIpString(actionExecutedContext);
            objBLLMApiUser.Token = actionExecutedContext.Request.Headers.GetValues("Token").First();
            objBLLMApiUser.ResponseObject = actionExecutedContext.Response.Content.ReadAsStringAsync().Result;
            objBLLMApiUser.RequestObject = actionExecutedContext.Request.RequestUri.Query.ToString();
            objBLLMApiUser.RequestUrl = actionExecutedContext.Request.RequestUri.ToString();
            objBLLMApiUser.ExecuteNonQuery(objBLLMApiUser);
            
        }

        //This method is used to find ip Address of client
        public string GetClientIpString(HttpActionExecutedContext filterContext)
        {
            string HttpContext = "MS_HttpContext";
            string RemoteEndpointMessage = "System.ServiceModel.Channels.RemoteEndpointMessageProperty";

            string IP = "";
            if (filterContext.Request.Properties.ContainsKey(HttpContext))
            {
                dynamic ctx = filterContext.Request.Properties[HttpContext];
                if (ctx != null)
                {
                    IP = ctx.Request.UserHostAddress;
                }
            }

            if (filterContext.Request.Properties.ContainsKey(RemoteEndpointMessage))
            {
                dynamic remoteEndpoint = filterContext.Request.Properties[RemoteEndpointMessage];
                if (remoteEndpoint != null)
                {
                    IP = remoteEndpoint.Address;
                }
            }
            return IP;

        }

        //This method is used to find reqested body of client
        private string GetBodyFromRequest(HttpActionExecutedContext context)
        {   
           
            string data;
            using (var stream = context.Request.Content.ReadAsStreamAsync().Result)
            {
                if (stream.CanSeek)
                {
                    stream.Position = 0;
                }
                data = context.Request.Content.ReadAsStringAsync().Result;
            }
            return data;
        }

    }
}