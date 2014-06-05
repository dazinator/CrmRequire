using System.Collections.Generic;

namespace CrmRequire
{
    public class RequirementsList : Requirement
    {
        public bool Check()
        {
            string outMessage;
            return base.Check(null, out outMessage);
        }

        public List<Requirement> GetRequirements()
        {
            var allRequirements = this.CollateRequirements();
            return allRequirements;
        }

        public List<Requirement> GetUnsatisfiedRequirements()
        {
            var allRequirements = this.CollateRequirements(null, false);
            return allRequirements;
        }

        public List<Requirement> GetSatisfiedRequirements()
        {
            var allRequirements = this.CollateRequirements(null, true);
            return allRequirements;
        }
    }
}