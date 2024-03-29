//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the Profisee SDK Web Services Generator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mdm.AccountService.ServiceLibrary
{
    using Mdm.AccountService.Contracts;
    using Profisee.Services.Sdk.AcceleratorFramework;
    using System;
    
    /// <remarks>
    /// This class provides the implementation of service contract associated with the model.  Note that this
    /// class is defined as 'partial'. The generated implementation is contained in the entity-specific files within
    /// the 'Services' subdirectory. Custom operations should be defined in the <see cref="IAccount"/>
    /// class file located in this same directory.
    ///  
    /// This file is generated initially but it is generated only once. The Service Builder will not overwrite this
    /// file if it exists because it is intended to house any custom operations that you may need to add to
    /// the service contract. If you remove or rename this class before running the Service Builder it will generate
    /// an updated class definition. You may then reapply any custom service operations from your prior version.
    /// </remarks>
    public partial class Account : BaseModelService, IAccount
    {
		// TODO: Add any custom service operation you need here. Here's a sample!
        public String CustomOperation(String yourName)
        {
            return String.Format("Hello {0}, you\'ve reached the {1} service.", yourName, this.ModelName);
        }
    }
}

