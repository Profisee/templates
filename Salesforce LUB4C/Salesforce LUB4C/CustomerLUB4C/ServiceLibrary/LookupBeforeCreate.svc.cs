//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the Maestro SDK Web Services Generator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mdm.Profisee_Customer360Service.ServiceLibrary
{
    using Mdm.Profisee_Customer360Service.Contracts;
    using Profisee.Services.Sdk.AcceleratorFramework;
    using System;
    using System.Configuration;
    using System.ServiceModel;
    
    /// <remarks>
    /// This class provides the implementation of the service contract associated with the MDS model.  Note that this
    /// class is defined as 'partial'. The bulk of the implementation is generated and contained in the
    /// entity-specific files within the 'Services' subdirectory.
    ///  
    /// This file should not be edited. If any user-defined customization must be added to this service, these
    /// methods should be added to the LookupBeforeCreateExtensions file and its associated <see cref="ILookupBeforeCreateExtensions"/> interface.
    /// </remarks>
    [System.ServiceModel.ServiceBehavior(InstanceContextMode=InstanceContextMode.PerSession, ConcurrencyMode=ConcurrencyMode.Multiple)]
    public partial class LookupBeforeCreate : BaseModelService, ILookupBeforeCreate
    {
        public string versionName = "Current Data";
        public LookupBeforeCreate() : 
                base()
        {
            this.ModelName = ConfigurationManager.AppSettings.Get("ModelName");
            String url;
            String spn;
            url = ConfigurationManager.AppSettings.Get("MaestroURI");
            try
            {
                spn = ConfigurationManager.AppSettings.Get("ServicePrincipalName");
            }
            catch (ConfigurationErrorsException ex)
            {
                // Handle exceptions when SPN isn't defined.
                spn = string.Empty;
            }
            base.ConnectToMasterDataServer(url, spn);
        }
    }
}