using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace AccountLookupClient
{
	class Program
	{
		static void Main(string[] args)
		{
			//var restfulUri = " http://localhost/SalesforceLUB4C/Account.svc/AccountLookup";
			var restfulUri = " http://corpmdm02.corp.profisee.com/SalesforceLUB4C/Account.svc/LookupBeforeCreate";

			var request = WebRequest.CreateHttp(restfulUri);
			request.Credentials = CredentialCache.DefaultCredentials;
			request.Method = "POST";
			request.ContentType = "application/json";

			var lub4cRequest = new Mdm.Profisee_Customer360Service.Contracts.AccountLUB4CRequest();
			lub4cRequest.AttributeValues = new Dictionary<string, string>
			{
				{"account-Name", "First Financial"},
				{"account-BillingStreet", "255 East Fifth Street"},
				{"account-BillingZipPostalCode", "45202"}
			};
			var jsonSerializer = new JavaScriptSerializer();
			var serializedData = jsonSerializer.Serialize(lub4cRequest);

			using (var sw = new StreamWriter(request.GetRequestStream(), System.Text.Encoding.ASCII))
			{
				sw.Write(serializedData);
				sw.Flush();
				sw.Close();
			}

			try
			{
				var response = request.GetResponse();
				using (var sr = new StreamReader(response.GetResponseStream()))
				{
					string responseText = sr.ReadToEnd();
					sr.Close();

					Console.WriteLine("-----------------------");
					Console.WriteLine(responseText);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("-------------------------");
				Console.WriteLine(ex.ToString());
			}
			Console.WriteLine();
			Console.Write("All Done...press <ENTER>");
			Console.ReadLine();
		}
	}
}
