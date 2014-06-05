CrmRequire
==========

A .NET library that helps you easily check a Dynamics Crm for required runtime dependencies.

## Code Example

```csharp
            var crmConnectionString = "Url=http://somecrm:5555/orgname;Domain=domainname; UserName=admin; Password=password;" 

            var requirements = RequireThat.CrmOrganisation(crmConnectionString)
                       .HasSolution("MySolution")
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
```

You can use NuGet to adopt this library: https://www.nuget.org/packages/CrmRequire/

# Explaination of the problem
Imagine you write an application that part way through processing, queries a custom entity in Dynamics CRM 

You deploy your application to a UAT environment and it all works swimmingly.

You later deploy your application to the LIVE environment. It all falls over part way through processing. You look through the logs - oops - someone has forgotton to create that custom entity your application requires, in the LIVE CRM.

## What's happening?
Your application has a runtime dependency on that entity being in Dynamics CRM. However your application has not done any intelligent checking of this dependency and therefore it ends up failing whilst its halfway through processing that invoice, or adjusting that exchange rate. This is bad!

# How does this help me?
CrmRequire will enable your application to be explicit about what Crm runtime dependencies it requires in order to operate. It will enable your application to detect early if there missing CRM dependencies. This allows you to intelligently disable functionality or present a warning message etc if runtime CRM dependencies are not met - with clear indicators as to what the problem is. This is better than falling over halfway through processing that invoice!
