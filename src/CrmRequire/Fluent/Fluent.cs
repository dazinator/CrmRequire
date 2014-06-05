using CrmRequire.Requirements;

// ReSharper disable CheckNamespace 
// Do not change the namespace as we want anyone impprting the dynamics Sdk to get these handy utility extension methods without having
// to set up additional Using / Imports statements.
namespace CrmRequire.Fluent
// ReSharper restore CheckNamespace
{
    public static class Fluent
    {
        public static SolutionExistsRequirement HasSolution(this OrganisationRequirement orgRequirment, string name)
        {
            var solReq = new SolutionExistsRequirement(orgRequirment, name);
            orgRequirment.Requirements.Add(solReq);
            return solReq;
        }

        public static SolutionExistsRequirement MinimumVersion(this SolutionExistsRequirement requirment, string versionNumber)
        {
            var req = new SolutionMinimumVersionRequirement(requirment, versionNumber);
            requirment.Requirements.Add(req);
            return requirment;
        }

        public static SolutionExistsRequirement MaximumVersion(this SolutionExistsRequirement requirment, string versionNumber)
        {
            var req = new SolutionMaximumVersionRequirement(requirment, versionNumber);
            requirment.Requirements.Add(req);
            return requirment;
        }

        public static RequirementsList Gather(this SolutionExistsRequirement requirment)
        {
            var reqList = new RequirementsList();
            reqList.Requirements.Add(requirment.OrgRequirement);
            return reqList;
        }
    }
}

