//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the Maestro SDK Web Services Generator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.ServiceModel.Activation;
using System.Web.Routing;

namespace Mdm.Profisee_Customer360Service.ServiceREST
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
		            RouteTable.Routes.Add(new ServiceRoute("Customer", new WebServiceHostFactory(), typeof(Customer)));
			        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}