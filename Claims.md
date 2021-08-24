# Claims

This is a console Application for processing  Insurance claim. It utilizes Queues as the Database for storing data
and all the data dissapers at runtime excexpt the seeded data.It hads a class class Called **Claim** and an Enum that 
clasify insurance claims to diffrent categories.
The folowing are the properties of the **Claim** class


- CaimID
-  ClaimType
-  Description
- ClaimAmount
- DateOfIncident
- DateOfClaim
- IsValid


The application utilizes [POCO](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/object-oriented/objects) Repository pattern with the claim Repository abstracting all the Methods (CRUD)
The Agent /user can 
 1. see all claims
 2. Take care of next claim 
 3. Enter a new Claim
 

