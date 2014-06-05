using CrmRequire.Dynamics;

namespace CrmRequire
{
    public class OrganisationRequirement : Requirement
    {
        public OrganisationRequirement(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public string ConnectionString { get; set; }

        internal override bool Check(Dynamics.ICrmServiceProvider crmServiceProvider, out string failureMessage)
        {
            // create connection
            var crmServiceProvder = new CrmServiceProvider(new ExplicitConnectionStringProviderWithFallbackToConfig() { OrganisationServiceConnectionString = ConnectionString }, new CrmClientCredentialsProvider());
            // Check sub requirements.
            return base.Check(crmServiceProvder, out failureMessage);
        }

    }
}