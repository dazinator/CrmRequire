using CrmRequire.Requirements;

// ReSharper disable CheckNamespace 
// Do not change the namespace as we want anyone impprting the dynamics Sdk to get these handy utility extension methods without having
// to set up additional Using / Imports statements.
namespace CrmRequire.Fluent
// ReSharper restore CheckNamespace
{
    public static class RequireThat
    {
        public static OrganisationRequirement CrmOrganisation(string connectionString)
        {
            return new OrganisationRequirement(connectionString);
        }
    }
}