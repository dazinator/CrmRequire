using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace CrmRequire.Tests
{
    [TestFixture]
    public class SyntaxTests
    {

        public SyntaxTests()
        {

        }

        [Test]
        public void CanExpressRequirements()
        {

            var crmConnectionString = ConfigurationManager.ConnectionStrings["CrmOrganisationServiceConnectionString"].ConnectionString;

            var requirements = RequireThat.CrmOrganisation(crmConnectionString)
                       .HasSolution("SilverbearMembershipSolution")
                       .MinimumVersion("3.3.0.58")
                       .Gather();

            var result = requirements.Check();
            if (!result)
            {
                var unsatisfiedRequirements = requirements.GetUnsatisfiedRequirements();
                foreach (var requirement in unsatisfiedRequirements)
                {
                    Console.WriteLine(requirement.Message);
                }
            }

        }

    }
}
