# RabbitMQ y Netcore sample

Simple project to experiment with rabbitmq and netcore webapi projects

## Infra

- publisher.api
- subscriber.api
- rabbitmq docker image
- docker-compose composition

## Prerequisites

- [Docker](http://docker.io)
- Docker Compose
- Postman (or similar)

## Steps to run the solution

```bash
docker-compose -f docker-compose.yml build
docker-compose -f docker-compose.yml up
```

Then you need to make a post request to publisher.api:

http://localhost:8001/Evolucion