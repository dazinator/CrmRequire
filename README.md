CrmRequire
==========

A library that helps you easily check for required runtime dependencies on Dynamics CRM


# The problem
Imagine you write an application that part way through processing, queries a custom entity in Dynamics CRM 

You deploy your application to a UAT environment and it all works swimmingly.

You later deploy your application to the LIVE environment. It all falls over part way through processing. You look through the logs - oops - someone has forgotton to create that custom entity your application requires, in the LIVE CRM.

## What's happening?
Your application has a runtime dependency on that entity being in Dynamics CRM. However your application has not done any intelligent checking of this dependency and therefore it ends up failing whilst its halfway through processing that invoice, or adjusting that exchange rate. This is bad!

# How does this help me?
CrmRequire will enable your application to be explicit about what Crm runtime dependencies it requires. It will be able to detect early if there are any missing dependencies. This allows your application to intelligently disable functionality if runtime CRM dependencies are not met - with clear indicators as to what the problem is. This is better!
