# ReadingIsGood
Getir - Reading is good - ecommerce - .Net Core microservices, Ocelot, RabbitMQ, Elastic Search, Kibana, Sql Server

## Architecture
![enter image description here](https://user-images.githubusercontent.com/11176913/113098468-2b0fa400-9201-11eb-8b99-07faa71bd9d0.png)


## Features

User can add, check/uncheck, list and delete catalog
User can add/delete products to basket and can checkout the basket after the checkout products will order as automatic with rabbitmq event sourcing.

## Installing and Running
**Requirements;** 
- Docker Desktop
- Git

**Clone or download project**, then build and run with commands below;

    docker-compose -f docker-compose.yml -f docker-compose.override.yml up –d
**launch microservices** as below urls:
-   **Catalog API ->  [http://host.docker.internal:8000/swagger/index.html](http://host.docker.internal:8000/swagger/index.html)**
    
-   **Basket API ->  [http://host.docker.internal:8001/swagger/index.html](http://host.docker.internal:8001/swagger/index.html)**
       
-   **Ordering API ->  [http://host.docker.internal:8002/swagger/index.html](http://host.docker.internal:8004/swagger/index.html)**
-   **Customer API ->  [http://host.docker.internal:8003/swagger/index.html](http://host.docker.internal:8010/Catalog)**
-   **Auth API ->  [http://host.docker.internal:8004/swagger/index.html](http://host.docker.internal:8010/Catalog)**  -- hamit/12345
-   **API Gateway ->  [http://host.docker.internal:7000/Catalog](http://host.docker.internal:8010/Catalog)**
    
-   **Rabbit Management Dashboard ->  [http://host.docker.internal:15672](http://host.docker.internal:15672/)**  -- guest/guest

-   **Elasticsearch ->  [http://host.docker.internal:9200](http://host.docker.internal:9200/)**
    
-   **Kibana ->  [http://host.docker.internal:5601](http://host.docker.internal:5601/)**
    
-   **Web Status ->  [http://host.docker.internal:8007](http://host.docker.internal:8007/)**

## Developers

 - Hamit Doğan (hamitdogan17@gmail.com)
