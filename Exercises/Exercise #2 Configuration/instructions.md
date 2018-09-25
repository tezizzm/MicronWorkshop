# Exercise #2

## Goal

Explore Externalized Configuration by working with Spring Cloud Config Server

## Expected Results

Create an instance of Spring Cloud Services Configuration Server and bind our API application to that instance of the Configuration Server.

## Introduction

In this exercise we explore how Configuration Server pulls configuration from a backend repository.  Also observe how we utilize Steeltoe to connect to Configuration Server and manipulate how we retrieve configuration.

## Instantiate Spring Cloud Services instances

Spring Cloud Services wrap up key Spring Cloud projects with managed capabilities.

1. Clone the repository located at <https://github.com/tezizzm/MicronWorkshop>.  Navigate to the Exercise Files > Exercise #2 Configuration folder.

2. From powershell run the create-service.bat file.  This will create an instance of Configuration Server.  *Note the actual name of the configuration server in your Pivotal Cloud Foundry installation may be different.  To see the name of the installed services in your installation run the following command `cf marketplace`.  If it is different take note of the name and update the create-service.bat file accordingly*

3. Type `cf services` to view the service instances created in your current space.  Note that as the service instance you created in the prior step is being created you will see a "create in progress" message for the status.

4. Return to Apps Manager and navigate to your targeted organization and space, click "Service", choose Configuration Server, and click the "manage" link.  Notice the configured values which were set when the service was created and now point to a Github repository which provides the underlying configuration values.

5. From the command line navigate to the bootcamp-webapi folder using the following command `cd bootcamp-webapi`.  Push the api to Cloud Foundry using the following command: `cf push`.

6. Navigate to your application and you should see the Swagger API explorer.

7. Navigate to the `api/products` endpoint of your application and you should see an array of two products.  View the following Github repository <https://github.com/tezizzm/cloud-native-net-configs> and the appsettings.json file in the api directory and notice how configuration is loaded from the underlying repository.  In the repository note the following files application-dev.properties and application.properties.