//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the Maestro SDK Web Services Generator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mdm.Profisee_Customer360Service.Contracts
{
    using System;
    using System.ServiceModel;
    
    /// <remarks>
    /// This interface contains custom operations defined for the <see cref="LookupBeforeCreate"/>. This interface
    /// is combined with other entity-specific interfaces to form the main <see cref="ILookupBeforeCreate"/>
    /// interface. The implementation of this interface should be created in the LookupBeforeCreateExtensions file
    /// in the same directory as this file.
    /// </remarks>
    [System.ServiceModel.ServiceContract(SessionMode=SessionMode.Allowed)]
    public interface ILookupBeforeCreateExtensions
    {
        // TODO: Add any custom service operation you need here. Here's a sample!
        [System.ServiceModel.OperationContract()]
        String CustomOperation(String yourName);       
    }
}

