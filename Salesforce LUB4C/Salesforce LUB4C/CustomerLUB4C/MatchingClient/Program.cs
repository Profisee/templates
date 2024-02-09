using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using Profisee.Services.Sdk.AcceleratorFramework;
using Profisee.MasterDataMaestro.Services.DataContracts.MasterDataServices;
using Profisee.MasterDataMaestro.Services.MessageContracts;

namespace MatchingClient
{
	class Program
	{
		static void Main(string[] args)
		{
			//string maestroUri = "http://localhost/MaestroV512/service.svc";
			string maestroUri = "http://corpmdm02/Maestro/service.svc";
			string modelName = "Profisee_Customer360";
			string entityName = "Account";
			string versionName = "Version_1";
			string matchingStrategy = "P360 - Account";
			string logFilename = $"C:\\temp\\MatchingClient\\MatchingClient-{DateTime.Now.ToString("yyyyMMdd-hhmmss")}.txt";

			if (!Directory.Exists(Path.GetDirectoryName(logFilename)))
				Directory.CreateDirectory(Path.GetDirectoryName(logFilename));

			using (var logFile = new StreamWriter(logFilename))
			{
				try
				{
					// connect to the MDM Source and get the model
					var mdmSource = new MdmSource();
					mdmSource.Connect(maestroUri);
					logFile.WriteLine($"Connected to source...");
					var mdmModel = mdmSource.GetModel(modelName);
					logFile.WriteLine($"Found Model: {mdmModel.Identifier.Name} ({mdmModel.Identifier.Id})");
					var mdmEntity = mdmModel.GetEntity(entityName);
					logFile.WriteLine($"Found Entity: {mdmEntity.Identifier.Name} ({mdmEntity.Identifier.Id})");

					// get the matching strategy from the model
					var mdmMatching = mdmModel.GetMatchingStrategy(matchingStrategy);
					logFile.WriteLine($"Found Matching Strategy: {mdmMatching.Identifier.Name} ({mdmMatching.Identifier.Id})");

					// create the member with the Name, Billing Street Address, and Billing Postal Code
					var member = mdmEntity.GetNewMdmMemberTemplate(versionName, MemberType.Leaf);
					member.SetMemberValue("Name", "First Financial");
					member.SetMemberValue("BillingStreet", "255 East Fifth Street");
					member.SetMemberValue("BillingZipPostalCode", "45202");
					member.SetMemberValue("Phone", "(877) 322-9530");
					member.SetMemberValue("Website", "https://www.bankatfirst.com/content/first-financial-bank/home.html");
					logFile.Write($"New MDM Member created with Name, BillingStreet, and BillingZipPostalCode, Phone and Website attributes");

					// execute the matching strategy
					var results = mdmModel.GetMemberMatches(mdmMatching.Identifier, new Collection<Member> { member.Member }, false, true);
					if (results.OperationResult.Errors.Count > 0)
					{
						logFile.WriteLine("");
						logFile.WriteLine("------------------------------------------");
						logFile.WriteLine($"OperationResults.Errors: {results.OperationResult.Errors.Count}");
						foreach (var error in results.OperationResult.Errors)
						{
							logFile.WriteLine($"Code: {error.Code}");
							logFile.WriteLine($"Context: {error.Context}");
							logFile.WriteLine($"Error Type: {error.ErrorType}");
							logFile.WriteLine($"Description{Environment.NewLine}: {error.Description}");
							logFile.WriteLine();
						}
					}

					if (results.Members.Count > 0)
					{
						logFile.WriteLine();
						logFile.WriteLine("-------------------------------");
						logFile.WriteLine($"Match Count: {results.Members.Count}");
						logFile.WriteLine("");
						foreach (var matched in results.Members)
						{
							foreach (var matchedMember in matched.MatchedMembers)
							logFile.WriteLine($"Matched Item: Score: {matchedMember.Score} Code: {matchedMember.Code}; Name: {matchedMember.Name}");

						}
					}
				}
				catch (Exception ex)
				{
					logFile.WriteLine();
					logFile.WriteLine("-------------------------------");
					logFile.WriteLine(ex.ToString());
				}
			}
			Console.WriteLine($"Log File written to: {logFilename}");
			Console.WriteLine("All Done...press <ENTER> to exit.");
			Console.ReadLine();
		}
	}
}
