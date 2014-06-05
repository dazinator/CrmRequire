using Microsoft.Xrm.Client;

namespace CrmRequire.Dynamics
{
    /// <summary>
    /// Classes that supply CrmConnection's used for creating instances of Crm services will implement this interface.
    /// </summary>
    public interface ICrmConnectionProvider
    {
        CrmConnection GetOrganisationServiceConnection();
        CrmConnection GetDeploymentServiceConnection();
        CrmConnection GetDiscoveryServiceConnection();
    }
}