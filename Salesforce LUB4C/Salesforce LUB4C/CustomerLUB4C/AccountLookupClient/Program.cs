using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Mdm.Profisee_Customer360Service.Contracts;
using Mdm.Profisee_Customer360Service.ServiceREST;

namespace AccountLookupClient
{
	class Program
	{
		static void Main(string[] args)
        {
            ////var restfulUri = " http://localhost/SalesforceLUB4C/Account.svc/AccountLookup";
            //var restfulUri = " http://ProfVM65Integr.eastus2.cloudapp.azure.com/SalesforceLUB4C/Customer/LookupBeforeCreate";
            ////var restfulUri = " http://localhost/SalesforceLUB4C/Customer.svc/LookupBeforeCreate";


            //var request = WebRequest.CreateHttp(restfulUri);
            //request.Credentials = CredentialCache.DefaultCredentials;
            //request.Method = "POST";
            //request.ContentType = "application/json";

            ////var lub4cRequest = new LookupRequest();
            ////lub4cRequest.AttributeValues = new Dictionary<string, string>();
            ////lub4cRequest.AttributeValues.Add("account-Name", "metro lawncare");
            ////lub4cRequest.AttributeValues.Add("account-Email", "Melissa.Richardson@MetroCycleShop.com");


            //var lub4cRequest = new LookupRequest
            //{
            //    AttributeValues = new Dictionary<string, string>
            //    {
            //        {"account-Name", "metro lawncare"},
            //        {"account-BillingStreet", "499 Bobby Jones Expy"},
            //        {"account-BillingZipPostalCode", "30907"}
            //    }
            //};

            //var jsonSerializer = new JavaScriptSerializer();
            //var serializedData = jsonSerializer.Serialize(lub4cRequest);

            //using (var sw = new StreamWriter(request.GetRequestStream(), System.Text.Encoding.ASCII))
            //{
            //    sw.Write(serializedData);
            //    sw.Flush();
            //    sw.Close();
            //}

            //try
            //{
            //    var response = request.GetResponse();
            //    using (var sr = new StreamReader(response.GetResponseStream()))
            //    {
            //        string responseText = sr.ReadToEnd();
            //        sr.Close();

            //        Console.WriteLine("-----------------------");
            //        Console.WriteLine(responseText);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("-------------------------");
            //    Console.WriteLine(ex.ToString());
            //}
            //Console.WriteLine();
            //Console.Write("All Done...press <ENTER>");
            //Console.ReadLine();

            var service = new Customer();
            var res = service.LookupBeforeCreate(new LookupRequest
            {
                AttributeValues = new Dictionary<string, string>
                {
                    {"account-Name", "metro lawncare"},
                    {"account-AddressLine1", "499 Bobby Jones Expy"},
                    {"account-Fax", "499"},
                {"account-WebSite", ""},
                           // {"account-PostalCode", "30907"}
                }
            });

        }

	    public static string FromDictionaryToJson(Dictionary<string, string> dictionary)
	    {
	        var kvs = dictionary.Select(kvp => string.Format("\"{0}\":\"{1}\"", kvp.Key, string.Concat(",", kvp.Value)));
	        return string.Concat("{", string.Join(",", kvs), "}");
	    }

    }
}
