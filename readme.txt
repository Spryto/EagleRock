EagleRock™
• The EagleRock is a charging and maintenance hub for a group of EagleBots. The EagleRock 
also serves as an operations control centre.


Task 1: EagleRock Service and APIs (mandatory)

Develop a simple back-end service (ideally a containerized C#/.NET Core app) that provides the 
capability for EagleBots to send data to EagleRock, composed of:

1. a REST API that EagleBots may periodically call to transfer traffic data to the EagleRock

2. a Redis (or equivalent) in-memory data store that the received traffic data is cached into
3. a second (aggregate) REST API that a web application might use to get the current 
location, status and latest traffic data from all active EagleBots via the Redis cache
4. appropriate unit tests to validate that each component operates as expected



Task 2: EagleRock Data Stream (for bonus points)
Extend the EagleRock service to offer an event-driven data stream for an additional type of 
consumer, by means of:
1. received EagleBot data also being written to a RabbitMQ topic (or similar 
publish/subscribe-based queue) that external applications can read from


In Conclusion
Think of this like a MasterChef challenge: get as close as you can with the time and tools you 
have available, but if you don’t complete it perfectly we still want to see how close you got and 
what your code looks like. We are looking for the following:
• Skills in C#/,NET Core application design and implementation
• Skills in utilizing cloud service components such as in-memory caches and queues
• Skills in defining and implementing data payloads, and APIs such as REST
• Skills in writing unit tests