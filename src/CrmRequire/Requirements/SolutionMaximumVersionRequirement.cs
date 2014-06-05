using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Semver;

namespace CrmRequire
{
    public class SolutionMaximumVersionRequirement : Requirement
    {

        internal SolutionExistsRequirement SolutionExistsRequirement { get; set; }

        internal SolutionMaximumVersionRequirement(SolutionExistsRequirement solutionRequirement, string versionNumber)
        {
            this.SolutionExistsRequirement = solutionRequirement;
            this.VersionNumber = versionNumber;
        }

        protected string VersionNumber { get; set; }

        internal override bool Check(Dynamics.ICrmServiceProvider crmServiceProvider, out string failureMessage)
        {
            // Check to make sure the solution exists.
            using (var service = crmServiceProvider.GetOrganisationService() as OrganizationServiceContext)
            {
                if (service == null)
                {
                    Fail("Org service cannot be null");
                }
                var solutions = (from a in service.CreateQuery("solution")
                                 where ((string)a["uniquename"] == SolutionExistsRequirement.Name && a["version"] != null)
                                 select new { Name = (string)a["uniquename"], VersionNumber = (string)a["version"] }).ToList();

                var versions =
                    solutions.Select(
                        a =>
                        new CrmSolution()
                        {
                            Name = a.Name,
                            VersionNumber = a.VersionNumber,
                            Version = Version.Parse(a.VersionNumber)
                        }).ToList();


                // need to get the latest solution by comapring the version numbers (can't use standard alphabetical - need to parse each segment as an int and compare.
                //   var versions = new List<KeyValuePair<int, Entity>>();
                //  var semversions = solutions.Select(a => new { Entity = a, Version = SemVersion.Parse((string)a["versionnumber"]) });

                var latestVersion =
                    versions.OrderByDescending(a => a.Version.Major)
                               .ThenByDescending(a => a.Version.Minor)
                               .ThenByDescending(a => a.Version.Build)
                               .ThenByDescending(a => a.Version.Revision).First();

              //  var maxVersionConstraint = SemVersion.Parse(VersionNumber);
                if (latestVersion.Version > new Version(VersionNumber))
                {
                    failureMessage = "The max supported solution version number has been exceeded.";
                    Fail(failureMessage);
                    return false;
                }
                else
                {
                    Success("Latest solution does not exceed max version.");
                    failureMessage = string.Empty;
                    return true;
                }
            }
        }
    }
}