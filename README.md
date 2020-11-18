# Easypeasy.Api

## Introduction
This is the application layer of the overall DDD and Microservices design pattern. It is responsible for routing requests from the UI to the underlying services.
We are using GraphQL here to expose endpoints. Clients will be able to deduce their own domain from the result Api domains. This api will be tightly coupled with the UI.

## Dvelopment
Api project needs no modification as it only exposes the endpoints (apart from injecting classes). The project infrastructure contains the types, query, mutation and the services.
Services folder can be extended with the different Ui requirements. Extension should be done using the design pattern in place.

## Technicalities
This api uses asp net core 3.0, serilog for logging, XUnit for Unit Tests, GRaphQL. We are using Docker to containerize application. We donot want any dependencies to any cloud components, hence we containerize and deploy. 
This also gives us the opportunity to deploy any cloud platform like Azure, AWS, GCP, Kubernetes & Docker Swarm.

## Contribution-Guidelines
We use feature branching guidelines. New feature development should be developed in branch "feature/*". All methods should be covered by unit tests.
All the merging to master should be through PR review.

## Sample
When container is running
/graphql [graphql endpoint for clients]
/ui/playground [graphql ui for testing]

Requet
{host}/graphql

`query {
      login (userid: "udita@gmail.com", password: "password1") {
        userid
      }
    }

    {
      "data": {
        "login": {
          "userid": "udita@gmail.com"
        }
      },
      "extensions": {}
    }`





