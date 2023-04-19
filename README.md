# Report


First, I'd like to thanks the opportunity, I really enjoyed working on this project.

Here follows  some considerations of what I've worked:

- Completed all scopes from BE-DEV-1 to BE-DEV-6;
- Refactored the code a lot, to follow SOLID and Clean Architecture, trying to keep layers (well defined in code) with single responsibility (because of time, I couldn't do it for registration endpoint). Comparing with the original project, mine is much more complex, but in other hand is organized and can evolve easier and scale better than the old one;
- Created middleware to handle exceptions;
- Broke the contract. It is a "sin", but as the documentation said, it is not operational yet, so I did it to follow the Rest/Restull patterns. But a huge consideration in this point is that I would change the registration endpoint, to pass device serial number and framework version in body request, going further, I didn't have time to handle the jwt token, so it wouldn't be necessary to pass the serial number in url, a little far from Rest, but it is much more safe;
- Unit tests for the business layer created;
- Improved the OpenApi documentation;
- Worked with threads to parallelize the alerts processing (it is not ideal, see final considerations below);
- Modeled the data base whithout consider the rules of normalization, if I did it, I had to create auxiliar tables to register messages, and join them with ids in the principal tables. The complexity was not big, so I simplifyied using enums, is more readable and easy to work, and once there is no join, the data base is less overloading with it.
- With Regex annotation in classes of request and response to improve OpenApi documentation, I didn't want to use fluent validation, the business layer is complex, and it had to handle a lot of alternative situations.

Final considerations of how this project could be improved:

- As long as it needs to have a optimum performance, for the definitive project, the parallel processing should be done by a kafka topic, sending messages to a scalable listener for it read and process it asynchronously, this way is more efficient and has mechanism for data loss;
- To let the Api and whole system robust, should be in a container, under a Network Load Balancer, Api Gateway and have a mechanism to orchestrate and autoscale instances, like Kubernetes, or cloud. For POC, the throughput is low, but in the real world it will be huge.
- It should be considered to change SqLite for PostgreSQL, once this last has a better performance over large amount of data. Maybe even a NoSql. I separated the Repository layer, so a possible change of DB will be easy on this architecture.
- As I said earlier, the endpoint registration should be safer, hiding parameter from uri, handling the jwt token to retrieve information, and as a bonus, we ask less request data. 
- It should have more unit tests, for all layers, measuring its quality, tests coverage with a tool, Sonar for example.

Thanks,

Vinicius Terra Lino
