CrmRequire
==========

A library that helps you easily check for and establish runtime dependencies on Dynamics CRM


Problem
Imagine you write an application that queries a custom entity in Dynamics CRM.

You deploy your application to a UAT environment andd it all works swimmingly.

However, when you deploy your application to the LIVE environment - it all falls over - because someone forgot to create the custom entity in the LIVE CRM.

What's happening?
Your application has a runtime dependency on that entity being in Dynamics CRM. However your application has not done any intelligent checking of this dependency and therefore it ends up failing whilst its halfway through processing that invoice, or adjusting that exchange rate. This is bad!

How does this help me?
CrmRequire will help you be more explicit about what your runtime dependencies on CRM are, and it will enable you to identify early if there is a problem. This allows your application to intelligently disable functionality if the CRM dependencies are not met. This is better!
