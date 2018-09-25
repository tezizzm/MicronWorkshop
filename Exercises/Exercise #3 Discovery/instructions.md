# Exercise #3

## Goal

Explore service registration and discovery practices.

## Expected Results

Register existing microservice with a service registry. Create a client application so that it discovers the microservice and uses it.

## Introduction

This exercise helps us understand how to register our microservices with the Spring Cloud Services Registry, and also discover those services at runtime.

1. If you have not already done so in previous steps clone the repository located at <https://github.com/tezizzm/MicronWorkshop>.  Navigate to the Exercise Files > Exercise #3 Discovery folder.

2. From powershell run the create-service.bat file.  This will create an instance of Service Registry.  *Note the actual name of the service registry in your Pivotal Cloud Foundry installation may be different.  To see the name of the installed services in your installation run the following command `cf marketplace`.  If it is different take note of the name and update the create-service.bat file accordingly*

3. We will once again push the API application.  Navigate to the bootcamp-webapi folder and take note of the manifest.yml.  Notice that in addition to the configuration service we now have added the service registry to our list of services bound to this application.  Run the `cf push` command to update the api.

4. Go "manage" the `Service Registry` instance from within Apps Manager. Notice our service is now listed!

We now change focus to a front end application that discovers our products API microservice.

1. Navigate to the bootcamp-store folder and run the `cf push` command.  This will push the application to Pivotal Cloud Foundry and bind it to the service registry previously created.

2. Explore the application and notice how it has discovered our backend product API microservice and displaying the products.