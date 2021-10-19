# PaySpace
Test Project for PaySpace Hiring Process

In order to run the application we need to have PaySpace.Api and PaySpace.MVC as startup projects.
Once started, a migragion will take place and the database will be created.

Go to the Web Application "PaySpace Tax Tax Caculation).
Provide postal code and anual income. Click calc.

The solution is divided into four major groups:

1 - Presentation (Contains Wep App and Api Service)

2 - Services (Contais application services and related unit tests)

3 - Domain (Model and repository interfaces)

4 - Infra (With only the data access layer)

Patterns:
- DDD (with minimum implementarion) Supposed to support further project development, whith many repo functionalities that are not used at that stage of dev.
- Repository
- Strategy

Unit Tests
- Only business services are tested, but not with full coverage due to the lack of time.
- No edge cases covered due to the same reason.
- I did not start the project with TDD aproach due to the short dead-line
