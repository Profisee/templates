using Mdm.Profisee_Customer360Service.Contracts.MemberDataContracts; 
using Profisee.MasterDataMaestro.Services.DataContracts.MasterDataServices;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Mdm.Profisee_Customer360Service.ServiceREST
{
    [ServiceContract()]
    public interface IAccount : IAccountExtensions
    {

		//ServiceREST GetMember
        [WebInvoke(Method = "GET", UriTemplate = "/GetAccountMember/{code}")]
        [OperationContract]
        AccountMember GetAccountMember(string code);
		
		//ServiceREST GetMember(s) by BrowseEntityContext at its default parameters
        [WebInvoke(Method = "GET", UriTemplate = "/GetAccountMembers")]
        [OperationContract]
        AccountMemberList GetAccountMemberList();

		//ServiceREST GetMember(s) by BrowseEntityContext with filter
        [WebInvoke(Method = "GET", UriTemplate = "/GetAccountMembers/filter={filter}")]
        [OperationContract]
        AccountMemberList GetAccountMemberList_Filter(string filter);

		//ServiceREST GetMember(s) by BrowseEntityContext PageSize and PageNumber
        [WebInvoke(Method = "GET", UriTemplate = "/GetAccountMembers/pagenumber={pagenumber};pagesize={pagesize}")]
        [OperationContract]
        AccountMemberList GetAccountMemberList_PageNumberPageSize(string pagenumber, string pagesize);

		//ServiceREST GetMember(s) by BrowseEntityContext Filter, PageSize, and PageNumber
		[WebInvoke(Method = "GET", UriTemplate = "/GetAccountMembers/filter={filter};pagenumber={pagenumber};pagesize={pagesize}")]
        [OperationContract]
        AccountMemberList GetFilteredAccountMemberList(string filter, string pagenumber, string pagesize);
	
		//ServiceREST AddMember
        [WebInvoke(Method = "POST", UriTemplate = "/AddAccountMember")]
        [OperationContract]
        MemberIdentifier AddAccountMember(AccountMember member);
		
		//ServiceREST AddMembers
        [WebInvoke(Method = "POST", UriTemplate = "/AddAccountMembers")]
        [OperationContract]
        Collection<MemberIdentifier> AddAccountMembers(Collection<AccountMember> members);






    }
}
