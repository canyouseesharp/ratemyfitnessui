# Rate My Fitness - Fitness Standards
Demo Project, Work in Progress. Please read the specification document for further details.

## Tech Stack & Packages
 - .NET 6
 - Blazor Server
 - nUnit
 - bUnit
 - Moq
 - SQLite
 - EF Core
 
## Roadmap & Current Development State
This project is still in it's infancy and is undergoing constant refactor. 

As of today, the project consists of 2 distinct areas separated by their responsibility:
 - RateMyFitness.Core: Core model and database access
 - RateMyFitness.UI: Blazor frontend 

Both these also have their own test projects which will be developed alongside the main codebases (TDD).

The next phase of development is to further separate the projects above with an API project sitting inbetween, and will be renamed as follows:
 - FitnessStandards.Core: Core model and database access
 - FitnessStandards.API: API to the core model - swagger and possibly graphQL. This will enable further use aside from the Blazor UI frontend.
 - RateMyFitness.UI: Blazor frontend for user interaction with the fitness standards using their own data.

Beyond this, other areas of fitness standard will be added for consumption through either the API or the frontend. Currently, standards for vertical jumps are in development only.

