<p align="center"><img width=6.5% src="/Images/logo.png"></p>
<h1 align="center">Search Capture</h1>

<div align="center">

[![Status](https://img.shields.io/badge/status-new-blue.svg)]()
[![Build](https://img.shields.io/badge/build-pending-orange.svg)]()
[![Test](https://img.shields.io/badge/test-pending-orange.svg)]()
[![Swagger](https://img.shields.io/badge/swagger-valid-blue.svg)]()
[![License](https://img.shields.io/badge/license-boeing-blue.svg)]()

</div>

<div align="center">
  A <code>domain driven</code> micro service architecture
</div>

## Table of Contents
- [Basic Overview](#Overview)
- [Getting Started](#Started)
- [Built With](#BuiltWith)
- [Design Strategies](#Strategies)
- [Deployment](#Deployment)
- [Support](#support)

## Basic Overview
Microservice architectural style is an approach to developing a single application as a suite of small services, each running in its own process and communicating with lightweight mechanisms, often an HTTP resource API.
These services are built around business capabilities and independently deployable by fully automated deployment process. These may be written in different programming languages and use different data storage technologies.

## Getting Started
These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. See deployment for notes on how to deploy the project on a live system.

### Prerequisites
Things you need to install the software and how to install them are as follows:

- __Visual Studio 2017:__ Install Visual Studio 2017 from Software Asset Management (SAM) - https://bars-am-prd.web.boeing.com/ProcessPortal
- __Neo4j:__ Install neo4j from SRES - https://sres.web.boeing.com/artifactory/webapp/#/home
- __Docker:__ Install Docker from SRES - https://sres.web.boeing.com/artifactory/webapp/#/home

## Built With
### System Overview

<p align="left"><img width=80% src="/Images/SaTRN_Architecture.png"></p>

### Goals
The major goal of developing this service is to capture the user search keywords. This service stores user search data. Using historical data, train a supervised learning algorithm to predicate & analyse searched keywords of a user.

### Overview
Service will be responsible to save user search keywords along with user details. With these details, it should be able to retreive required informations for any data analysis.
Data will be stored in a graph database (Neo4j). Service will be built upon .Net Core Web Api.

### Use Cases
Below are the Use Cases:
- Save Search keywords
- Get Search Keywords
- Analyse Search Keywords
<p align="left"><img width=80% src="/Images/SaTRNUseCase.png"></p>

### Components
#### Server Side
- __.NET Core:__ .NET Core supports the dependency injection (DI) software design pattern, which is a technique for achieving Inversion of Control (IoC) between classes and their dependencies.
- __NLog:__ NLog is a flexible and free logging platform for various .NET platforms, including .NET standard.NLog makes it easy to write to several targets. (database, file, console) and change the logging configuration on-the-fly.
- __NUnit:__ NUnit is a unit-testing framework for all .Net languages.
- __Moq:__ Moq takes full advantage of .NET Linq expression trees and lambda expressions, which makes it the most productive, type-safe and refactoring-friendly mocking library available. And it supports mocking interfaces as well as classes. 
- __Swashbuckle.AspNetCore:__ Swagger tooling for API's built with ASP.NET Core. Generate beautiful API documentation, including a UI to explore and test operations, directly from your routes, controllers and models.

#### Package & Versions
- __.NET Core:__ ver 2.2
- __NLog:__ ver 4.8
- __NUnit:__ ver 3.11
- __Moq:__ ver 4.11
- __Swashbuckle.AspNetCore:__ ver 4.0

## Design Strategies
Architecturally, this application will be logically built to follow the principle “Separation of Concerns” by separating core business behavior from infrastructure and user interface logic.
This helps ensure that the business model is easy to test and can evolve without being tightly coupled to low-level implementation details. By organizing code into layers, common low-level functionality can be reused throughout the application. 
Below are the key points:
- Testable. The business rules can be tested without the UI, Database, Web Server, or any other external element.
- Independent of UI. The UI can change easily, without changing the rest of the system. A Web UI could be replaced with a console UI, for example, without changing the business rules.
- Independent of Database. Persistent Data can be swapped with Oracle, SQL Server, Mongo or something else. Business rules are not bound to the database.

### Architecture
This application will follow the Dependency Inversion Principle as well as Domain-Driven Design (DDD) principles architecture.Clean architecture puts the business logic and application model at the center of the application. Instead of having business logic depend on data access or other infrastructure concerns, this dependency is inverted: infrastructure and implementation details depend on the Application Core. This is achieved by defining abstractions, or interfaces, in the Application Core, which are then implemented by types defined in the Infrastructure layer. A common way of visualizing this architecture is to use a series of concentric circles, similar to an onion.
<p align="left"><img src="/Images/DDA.png"></p>

#### Domain/Entities :
 Holds the core business models/ domain objects.

#### Service:
 Holds the business logic & interfaces. These interfaces include abstractions for operations that will be performed using Infrastructure, such as data access, file system access, network calls, etc.

#### Persistence/ Infrastructure:
 This will include data access implementations. The most common way to abstract data access implementation code is with the Repository design pattern. It’s the only layer responsible to communicate with the database. 
  <p align="left"><img width=85% src="/Images/Sequence.png"></p>
  
#### Api:
 ASP.NET Web API can automatically serialize your model to JSON, XML, or some other format, and then write the serialized data into the body of the HTTP response message. As long as a client can read the serialization format, it can deserialize the object. Most clients can parse either XML or JSON. Moreover, the client can indicate which format it wants by setting the Accept header in the HTTP request message.
 The Startup class is responsible for configuring the application and for wiring up implementation types to interfaces, allowing dependency injection to work properly at run time.
  <p align="left"><img width=70% src="/Images/ClassDiagram.png"></p>
 
#### Unit Testing:
 Unit Test will be executed for all the classes. “Moq” framework will be used to mock external interfaces like database and files.	In memory database will be used for the test executions.




## Support

