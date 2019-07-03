# CarSaleApi
## Compromise (for the sake of the test but needed in production)
1. Health check: apis on production need health checks behind ELB
2. SpecFlow: in integration (or acceptance) test it can be used
3. Validation: in this test, models do not have validation (otherwise tools like FluentApi, ...)
4. Build and package script: ci/cds need them to build/deploy the code
5. Aws resource file: ASG, security groups, elbs, ... are normally required
6. StatsD: appart from normall log
7. Security: Auth/Security groups/Vpc are normally required
8. Unit test for carService and controllers skipped
11. Integration Test written for just the Discount endpoint
12. Repositories are created as static. In real world they are usually async and thread safe

