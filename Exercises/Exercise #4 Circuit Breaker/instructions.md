# Exercise #4

## Goal

Explore fault and latency tolerance along with service health monitoring.

## Expected Results

Change the UI service so that external calls are wrapped in a Hystrix Command to provide fault and latency tolerance.  Bind existing UI application with an instance of Hystrix Service to allow monitoring of the external calls.

## Introduction

This exercise helps us understand how to wrap our external calls in Hystrix Commands and allows us to view metrics on the health of those calls.

1. If you have not already done so in previous steps clone the repository located at <https://github.com/tezizzm/MicronWorkshop>.  Navigate to the Exercise Files > Exercise #4 Circuit Breaker folder.

2. From powershell run the create-service.bat file.  This will create an instance of Circuit Breaker service.  *Note the actual name of the service registry in your Pivotal Cloud Foundry installation may be different.  To see the name of the installed services in your installation run the following command `cf marketplace`.  If it is different take note of the name and update the create-service.bat file accordingly*

3. We will once again push the UI application.  Navigate to the bootcamp-store folder and take note of the manifest.yml.  Notice that in addition to the discovery service we now have added the circuit breaker to our list of services bound to this application.  Run the `cf push` command to update the UI application.

4. Go "manage" the `Circuit Breaker` instance from within Apps Manager. Notice the dashboard listings.  At this point you may see a generic "loading..." message. Once the UI application has finished updating navigate to it and refresh the page a couple of times.  In the Circuit Breaker instance you should start seeing activity being monitored.

*Optional: Explore advanced features of the Circuit Breaker:*

1. From Apps Manager stop the API application.  Once the API application has been stopped navigate to the UI application and refresh the page a couple of times.  Notice that the product listing has changed (the products are being loaded from the fallback method).  Also go back to the Circuit Breaker service and click Manage to see the circuit health.  

2. Things to note: all calls should now be failing.  Note that once the threshold has been hit calls completely bypass the initial call and immediately go to the fallback method.

3. Restart the API application.

4. Navigate to the Service folder inside the bootcamp-store folder.  Take note of the ProductService.cs file, within it you will find the definition of the ProductService which is a HystixCommand.  There are two protected methods RunAsync and RunFallbackAsync that implement the external call and fallback call respectively.

5. In the ProductService class add logic to raise an exception (ie. new Exception()) in the RunAsync method every fifth call prior to the code that calls the external service.  Once complete re-push the application.

6. Once the UI application has been updated use a tool (Postman, curl, etc) to hit the UI URL a large number of times.  You should notice over the course of monitoring that the Circuit should go between closed and opened as the health changes overtime.