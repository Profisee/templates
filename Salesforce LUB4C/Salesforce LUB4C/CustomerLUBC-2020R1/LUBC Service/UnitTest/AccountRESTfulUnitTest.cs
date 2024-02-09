//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the Profisee SDK Web Services Generator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Mdm.AccountService.Contracts.MemberDataContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Profisee.MasterDataMaestro.Services.DataContracts;
using Profisee.MasterDataMaestro.Services.DataContracts.MasterDataServices;
using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.Threading;

namespace Mdm.AccountService.RESTfulUnitTest
{
    [TestClass]
    public class AccountRESTfulTests
    {
		private string DefaultCode { get { return ConfigurationManager.AppSettings["DefaultCode"]; } }


		[TestInitialize]
        public void TestInitialize()
        {
        }


        private T Get<T>(WebRequest webRequest)
        {
            DataContractSerializer dataContractSerializer = new DataContractSerializer(typeof(T));
            webRequest.Credentials = CredentialCache.DefaultCredentials;

            var httpWebResponse = webRequest.GetResponse() as HttpWebResponse;
            Assert.AreEqual(HttpStatusCode.OK, httpWebResponse.StatusCode);

            if (httpWebResponse.ContentLength > 0)
                using (Stream stream = httpWebResponse.GetResponseStream())
                    return (T)dataContractSerializer.ReadObject(stream);

            return default(T);
        }

        private void Put<T>(WebRequest webRequest, T obj)
        {
            DataContractSerializer dataContractSerializer = new DataContractSerializer(typeof(T));
            webRequest.Credentials = CredentialCache.DefaultCredentials;

            using (Stream stream = webRequest.GetRequestStream())
            {
                dataContractSerializer.WriteObject(stream, obj);
            }
        }


		//The following TestMethod will be skipped in Test Explorer. Before establishing a UnitTest, please remove: Ignore.
        [TestMethod,Ignore]
        public void RESTful_GetAccountMember()
        {
			//This is a Generated Sample Test Case for the Master Data Services Example Account Model. 
			//For further information on how to create a TestMethod please visit: https://msdn.microsoft.com/en-us/library/ms182517%28v=vs.100%29.aspx

            var webRequest = WebRequest.Create(ConfigurationManager.AppSettings["RESTfulUri"] + "Account/GetAccountMember/"+ DefaultCode);
            webRequest.Method = "GET";

            AccountMember member = Get<AccountMember>(webRequest);

            Assert.IsNotNull(member);

            //Assert.AreEqual("Adjustable Ring", member.Name);
            //Assert.AreEqual((DefaultCode, member.Code);
        }

		//The following TestMethod will be skipped in Test Explorer. Before establishing a UnitTest, please remove: Ignore.
        [TestMethod,Ignore]
        public void RESTful_GetAccountMembers()
        {
			//This is a Generated Sample Test Case for the Master Data Services Example Account Model. 
			//For further information on how to create a TestMethod please visit: https://msdn.microsoft.com/en-us/library/ms182517%28v=vs.100%29.aspx

            var webRequest = WebRequest.Create(ConfigurationManager.AppSettings["RESTfulUri"] + "Account/GetAccountMembers");
            webRequest.Method = "GET";

            AccountMemberList members = Get<AccountMemberList>(webRequest);

            Assert.IsNotNull(members);
            Assert.AreEqual(50, members.Count);
        }

		//The following TestMethod will be skipped in Test Explorer. Before establishing a UnitTest, please remove: Ignore.
        [TestMethod,Ignore]
        public void RESTful_GetAccountMembers_Filter()
        {
			//This is a Generated Sample Test Case for the Master Data Services Example Account Model. 
			//For further information on how to create a TestMethod please visit: https://msdn.microsoft.com/en-us/library/ms182517%28v=vs.100%29.aspx

            var webRequest = WebRequest.Create(ConfigurationManager.AppSettings["RESTfulUri"] + "Account/GetAccountMembers/filter=[Code] LIKE '%25AR%25'");
            webRequest.Method = "GET";

            AccountMemberList members = Get<AccountMemberList>(webRequest);

            Assert.IsNotNull(members);
            //Assert.AreEqual(50, members.Count);
        }

		//The following TestMethod will be skipped in Test Explorer. Before establishing a UnitTest, please remove: Ignore.
        [TestMethod,Ignore]
        public void RESTful_GetAccountMembers_PageNumberPageSize()
        {
			//This is a Generated Sample Test Case for the Master Data Services Example Account Model. 
			//For further information on how to create a TestMethod please visit: https://msdn.microsoft.com/en-us/library/ms182517%28v=vs.100%29.aspx

            var webRequest = WebRequest.Create(ConfigurationManager.AppSettings["RESTfulUri"] + "Account/GetAccountMembers/pagenumber=1;pagesize=50");
            webRequest.Method = "GET";

            AccountMemberList members = Get<AccountMemberList>(webRequest);

            Assert.IsNotNull(members);
            Assert.AreEqual(50, members.Count);
        }

		//The following TestMethod will be skipped in Test Explorer. Before establishing a UnitTest, please remove: Ignore.
        [TestMethod,Ignore]
        public void RESTful_GetAccountMembers_FilterPageNumberPageSize()
        {
			//This is a Generated Sample Test Case for the Master Data Services Example Account Model. 
			//For further information on how to create a TestMethod please visit: https://msdn.microsoft.com/en-us/library/ms182517%28v=vs.100%29.aspx

            var webRequest = WebRequest.Create(ConfigurationManager.AppSettings["RESTfulUri"] + "Account/GetAccountMembers/filter=[Code] LIKE '%25AR%25';pagenumber=1;pagesize=50");
            webRequest.Method = "GET";

            AccountMemberList members = Get<AccountMemberList>(webRequest);

            Assert.IsNotNull(members);
            //Assert.AreEqual(50, members.Count);
        }








    }
}

