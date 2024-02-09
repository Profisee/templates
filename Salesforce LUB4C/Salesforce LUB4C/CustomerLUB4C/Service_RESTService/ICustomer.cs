using Profisee.MasterDataMaestro.Services.DataContracts; 
using Profisee.MasterDataMaestro.Services.DataContracts.MasterDataServices;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Mdm.Profisee_Customer360Service.Contracts.EntityServiceContracts;
using Mdm.Profisee_Customer360Service.Contracts.MemberDataContracts;

namespace Mdm.Profisee_Customer360Service.ServiceREST
{
    [ServiceContract()]
    public interface ICustomer : ICustomerExtensions
    {

		//ServiceREST GetMember
        [SwaggerWcf.Attributes.SwaggerWcfPath("GetCustomerMember", "Get Customer member by code.")]
        [WebInvoke(Method = "GET", UriTemplate = "/GetCustomerMember/{code}")]
        [OperationContract]
        CustomerMember GetCustomerMember(string code);
		
		//ServiceREST GetMember(s) by BrowseEntityContext at its default parameters
        [SwaggerWcf.Attributes.SwaggerWcfPath("GetCustomerMemberList", "Get Customer members.")]
        [WebInvoke(Method = "GET", UriTemplate = "/GetCustomerMembers")]
        [OperationContract]
        CustomerMemberList GetCustomerMemberList();

		//ServiceREST GetMember(s) by BrowseEntityContext with filter
        [SwaggerWcf.Attributes.SwaggerWcfPath("GetCustomerMemberList_Filter", "Get Customer members with filtering.")]
        [WebInvoke(Method = "GET", UriTemplate = "/GetCustomerMembers/filter={filter}")]
        [OperationContract]
        CustomerMemberList GetCustomerMemberList_Filter(string filter);

		//ServiceREST GetMember(s) by BrowseEntityContext PageSize and PageNumber
        [SwaggerWcf.Attributes.SwaggerWcfPath("GetCustomerMemberList_PageNumberPageSize", "Get Customer members with paging.")]
        [WebInvoke(Method = "GET", UriTemplate = "/GetCustomerMembers/pagenumber={pagenumber};pagesize={pagesize}")]
        [OperationContract]
        CustomerMemberList GetCustomerMemberList_PageNumberPageSize(string pagenumber, string pagesize);

		//ServiceREST GetMember(s) by BrowseEntityContext Filter, PageSize, and PageNumber
        [SwaggerWcf.Attributes.SwaggerWcfPath("GetFilteredCustomerMemberList", "Get Customer members with filtering and paging.")]
		[WebInvoke(Method = "GET", UriTemplate = "/GetCustomerMembers/filter={filter};pagenumber={pagenumber};pagesize={pagesize}")]
        [OperationContract]
        CustomerMemberList GetFilteredCustomerMemberList(string filter, string pagenumber, string pagesize);
	
		//ServiceREST AddMember
        [SwaggerWcf.Attributes.SwaggerWcfPath("AddCustomerMember", "Add Customer member.")]
        [WebInvoke(Method = "POST", UriTemplate = "/AddCustomerMember")]
        [OperationContract]
        MemberIdentifier AddCustomerMember(CustomerMember member);
		
		//ServiceREST AddMembers
        [SwaggerWcf.Attributes.SwaggerWcfPath("AddCustomerMembers", "Add Customer members.")]
        [WebInvoke(Method = "POST", UriTemplate = "/AddCustomerMembers")]
        [OperationContract]
        Collection<MemberIdentifier> AddCustomerMembers(Collection<CustomerMember> members);

		//ServiceREST MergeMember
        [SwaggerWcf.Attributes.SwaggerWcfPath("MergeCustomerMember", "Merge Customer member.")]
        [WebInvoke(Method = "POST", UriTemplate = "/MergeCustomerMember")]
        [OperationContract]
        Collection<Error> MergeCustomerMember(CustomerMember member);

		//ServiceREST MergeMembers
        [SwaggerWcf.Attributes.SwaggerWcfPath("MergeCustomerMembers", "Merge Customer members.")]
        [WebInvoke(Method = "POST", UriTemplate = "/MergeCustomerMembers")]
        [OperationContract]
        Collection<Error> MergeCustomerMembers(Collection<CustomerMember> members);

		//ServiceREST UpdateMember
        [SwaggerWcf.Attributes.SwaggerWcfPath("UpdateCustomerMember", "Update Customer member.")]
        [WebInvoke(Method = "POST", UriTemplate = "/UpdateCustomerMember")]
        [OperationContract]
        Collection<Error> UpdateCustomerMember(CustomerMember member);

		//ServiceREST UpdateMembers
        [SwaggerWcf.Attributes.SwaggerWcfPath("UpdateCustomerMembers", "Update Customer members.")]
        [WebInvoke(Method = "POST", UriTemplate = "/UpdateCustomerMembers")]
        [OperationContract]
        Collection<Error> UpdateCustomerMembers(Collection<CustomerMember> members);

		//ServiceREST DeleteMember
        [SwaggerWcf.Attributes.SwaggerWcfPath("DeleteCustomerMember", "Delete Customer member.")]
        [WebInvoke(Method = "POST", UriTemplate = "/DeleteCustomerMember/{code}")]
        [OperationContract]
        Collection<Error> DeleteCustomerMember(string code);

		//ServiceREST DeleteMembers
        [SwaggerWcf.Attributes.SwaggerWcfPath("DeleteCustomerMembers", "Delete Customer members.")]
        [WebInvoke(Method = "POST", UriTemplate = "/DeleteCustomerMembers")]
        [OperationContract]
        Collection<Error> DeleteCustomerMembers(Collection<string> membersCodes);
    }
}
