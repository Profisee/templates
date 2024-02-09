using Mdm.AccountService.Contracts.MemberDataContracts;
using Profisee.MasterDataMaestro.Services.DataContracts; 
using Profisee.MasterDataMaestro.Services.DataContracts.MasterDataServices;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Mdm.AccountService.ServiceREST
{
    [ServiceContract()]
    public interface IAccount : IAccountExtensions
    {

		////ServiceREST GetMember
  //      [SwaggerWcf.Attributes.SwaggerWcfPath("GetAccountMember", "Get Account member by code.")]
  //      [WebInvoke(Method = "GET", UriTemplate = "/GetAccountMember/{code}")]
  //      [OperationContract]
  //      AccountMember GetAccountMember(string code);
		
		////ServiceREST GetMember(s) by BrowseEntityContext at its default parameters
  //      [SwaggerWcf.Attributes.SwaggerWcfPath("GetAccountMemberList", "Get Account members.")]
  //      [WebInvoke(Method = "GET", UriTemplate = "/GetAccountMembers")]
  //      [OperationContract]
  //      AccountMemberList GetAccountMemberList();

		////ServiceREST GetMember(s) by BrowseEntityContext with filter
  //      [SwaggerWcf.Attributes.SwaggerWcfPath("GetAccountMemberList_Filter", "Get Account members with filtering.")]
  //      [WebInvoke(Method = "GET", UriTemplate = "/GetAccountMembers/filter={filter}")]
  //      [OperationContract]
  //      AccountMemberList GetAccountMemberList_Filter(string filter);

		////ServiceREST GetMember(s) by BrowseEntityContext PageSize and PageNumber
  //      [SwaggerWcf.Attributes.SwaggerWcfPath("GetAccountMemberList_PageNumberPageSize", "Get Account members with paging.")]
  //      [WebInvoke(Method = "GET", UriTemplate = "/GetAccountMembers/pagenumber={pagenumber};pagesize={pagesize}")]
  //      [OperationContract]
  //      AccountMemberList GetAccountMemberList_PageNumberPageSize(string pagenumber, string pagesize);

		////ServiceREST GetMember(s) by BrowseEntityContext Filter, PageSize, and PageNumber
  //      [SwaggerWcf.Attributes.SwaggerWcfPath("GetFilteredAccountMemberList", "Get Account members with filtering and paging.")]
		//[WebInvoke(Method = "GET", UriTemplate = "/GetAccountMembers/filter={filter};pagenumber={pagenumber};pagesize={pagesize}")]
  //      [OperationContract]
  //      AccountMemberList GetFilteredAccountMemberList(string filter, string pagenumber, string pagesize);
	
		






    }
}
