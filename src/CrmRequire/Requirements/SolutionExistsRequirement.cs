using System;
using System.Linq;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;

namespace CrmRequire
{
    public class SolutionExistsRequirement : Requirement
    {
        internal SolutionExistsRequirement(OrganisationRequirement orgRequirement, string name)
        {
            this.Name = name;
            OrgRequirement = orgRequirement;
        }

        internal string Name { get; set; }

        //internal Entity SolutionEntity { get; set; }

        internal OrganisationRequirement OrgRequirement { get; set; }

        internal override bool Check(Dynamics.ICrmServiceProvider crmServiceProvider, out string failureMessage)
        {
            // Check to make sure the solution exists.
            using (var service = crmServiceProvider.GetOrganisationService() as OrganizationServiceContext)
            {
                if (service == null)
                {
                    Fail("Org service cannot be null");
                }
                var solution = (from a in service.CreateQuery("solution")
                                where (string)a["uniquename"] == Name
                                select a)
                                .FirstOrDefault();

                if (solution == null)
                {
                    Fail("Solution named: " + Name + " was not found.");
                }
                else
                {
                    Success("Solution named: " + Name + " was found.");
                }
            }

            return base.Check(crmServiceProvider, out failureMessage);
        }

    }
}