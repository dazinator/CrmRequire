using System;
using System.Collections.Generic;
using CrmRequire.Dynamics;

namespace CrmRequire
{
    public abstract class Requirement : IRequirement
    {

        public bool Failed { get; set; }

        public string Message { get; set; }

        protected Requirement()
        {
            Failed = false;
            Requirements = new List<Requirement>();
        }

        internal List<Requirement> Requirements { get; set; }

        internal virtual bool Check(ICrmServiceProvider crmServiceProvider, out string failureMessage)
        {

            bool succeeded = true;
            failureMessage = string.Empty;

            // check sub dependencies.
            foreach (var req in Requirements)
            {
                string outMessage;
                bool success = false;
                try
                {
                    success = req.Check(crmServiceProvider, out outMessage);
                    if (!success)
                    {
                        succeeded = false;
                    }
                }
                catch (Exception e)
                {
                    succeeded = false;
                    outMessage = e.Message;
                }

                failureMessage += outMessage;
            }
            if (!succeeded)
            {
                Fail(failureMessage);
            }
            return succeeded;
        }

        protected void Fail(string message)
        {
            Failed = true;
            Message = message;
        }

        protected void Success(string message)
        {
            Failed = false;
            Message = message;
        }

        protected internal List<Requirement> CollateRequirements(List<Requirement> requirements = null, bool? successOrFailureOnly = null)
        {
            if (requirements == null)
            {
                requirements = new List<Requirement>();
            }
            if (successOrFailureOnly == null)
            {
                requirements.Add(this);
            }
            else if (successOrFailureOnly.Value == true && !this.Failed)
            {
                requirements.Add(this);
            }
            else if (successOrFailureOnly.Value == false && this.Failed)
            {
                requirements.Add(this);
            }

            foreach (var requirement in this.Requirements)
            {
                requirement.CollateRequirements(requirements, successOrFailureOnly);
            }
            return requirements;
        }
    }
}