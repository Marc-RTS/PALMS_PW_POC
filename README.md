# Introduction

## PALMS E2E Playwright Test Automation

    An end-to- end test verifies that a system meets external requirements and achieves its goals testing the entire system from end to end.
    This documentation contains the E2E UI and API Test Automation of the PALMS application.

## Approach

    The approach developed is derived based on a good characteristic of a Test Automation Framework which are Fast, Reliable, Traceable and Low Maintenance framework.

    Playwright is an open-source tool developed by Microsoft to address pain points in the UI Test Automation space such as Flaky tests, executing multiple, concurrent and isolated tests and detecting objects from modern rendering engines.
    As the recommended scripting language in Rio Tinto is .Net, this automation framework used the Microsoft Playwright NUnit base classes to setup create and execute the tests.
    This contains all necessary classes to enable the test automation such as browser instances, actions and assertions.

    In creation of this automation framework, a Base test class is introduced to that comprises all necessary setup and configuration of each of the browser instance in order to achieve a smooth execution of multiple concurrent tests with respect to the application current requirements such as the login.
    To support the above requirement,  the framework have leveraged playwright�s Authentication feature which saves current browser state and then load it in every tests it needs to thus eliminate the needs to login in every test which makes the test suite faster.

    The Page Object component model is the structure used in this framework to optimize the pages thus increasing reusability and lessen the maintenance in the application test. The pages simply represent part of the application under test which contains all elements needed to steer the application.
    By putting these in one place, it increases reusability of the code and avoid duplication.

    As most of the tests should have an independent and reusable test data across the framework, the Fixtures have been developed in this framework.
    The fixtures contain all the necessary test data preparation and implementation needed for a test to enable verification of the application under test. By using this fixtures, the test automation framework is also independent of any other test data configuration such as Database.

# Getting Started

## Requirements

- NodeJs : Version uses 20.11.0 Node Doc
- Playwright : Created specifically to accommodate the needs of end to end testing. Supports modern rendering engines incl. Chronium, FireFox and Webkit Playwright Doc
- Allure NUnit Allure is a reporting tool framework which is flexible lightweight multi language test report tool that shows concise representation of what have been tested in neat web report form Allure Doc

## Installation process

1. Login to Rio Tinto artifactory to be able to download libraries needed. Make sure you are a member of the RT-Analytics-Artifactory-Users active directory group. If not , kindly request to ServiceNow ticket then follow the steps below in your vs project directory

```powershell
npm config set registry https://artifactory.riotinto.com/artifactory/api/npm/npmjs/
```

```powershell
npm login
```

Follow the instructions and wait for the browser confirmation showing user have successfully logged in

2. Set your certificate file

```powershell
$Env:NODE_EXTRA_CA_CERTS="<path-to-cert-file>\ca-bundle.crt"
```

3. Run below to add Playwirght into your project directory

```powershell
dotnet add package Microsoft.Playwright.NUnit into your project directory
```

4. Build project
5. Run install

```powershell
pwsh bin/Debug/net8.0/playwright.ps1 install
```

6. Run below to add Allure report into your project directory

```powershell
Run dotnet add package Allure.NUnit into your project directory
```

## Project Setup

### Fixtures

- Contains all the data preparation artifacts needed for test automation suite to be self sufficient when executing its tests

### Data Fixtures

- contains template JSON file data source

### FxInterfaces

– contains interfaces of the JSON data fixture files

#### Implementation - contains all the implementations/manipulations methods of the data fixture to meet the data requirements

- Model – contains Classes which are converted from the JSON file data fixtures
- Pages – contains all the pages and components needed to steer the application under test
- Support - contains all the files needed to support the test automation framework. Sample are mock and helpers to serialize- deserialize the JSON data fixtures
- Tests – contains all the test classes to verify/validate the application under test
  • UI - contains all UI tests
  • API - contains all API tests
- Base Test – contains pre-test configurations below needed for each test to run in isolation and parallel; can setup headless/headed mode as well
  • [OneTmeSetUp], [OneTimeTearDown] for all tests
  • [SetUp] and [TearDown] of each tests
  • Assertions
- Utils – contains all rarely maintained utility files needed by the application under test
- Runsettings – contains all test run configurations for all the test in the project

# Build and Test

## Writing Test

Once all the packages are installed, automation engineer can start writing a test by adding the C# test file and then inherit it to the Base Test class. Once created, it can start calling the pages or components needed for the test to succeed.
See sample test structure below:

## Executing Test

### Running via CLI

• Run in your command line

- this will run all the tests

```powershell
dotnet test -s Test.runsettings
```

- this will run single test

```powershell
dotnet test -- filter “class name”
```

### Running via Test Explorer

Assuming you are using Visual Studio
a. Select run settings by navigating to Test -> Configure Run Settings -> Select solution wide runsettings file
b. Locate and select the runsettings file
b. Open Test Explorer by navigating to Test -> Test Explorer
c. Right click on the desired test or set of tests and click Run

# Tracing

## Viewing trace locally

- Run in your command line

```powershell
pwsh bin/Debug/netX/playwright.ps1 show-trace <path-and-filename>.zip
```

## Viewing trace via Playwright trace viewer

1. Navigate to Playwright Trace Viewer <https://trace.playwright.dev/>
2. Locate you trace files and dump it into the browser page

# Reporting

Once all reports have been executed, all artifacts of the execution run will be saved in allure-results folder. By default it will be in "<project-path> \bin\Debug\netX\allure-results". Use below commands to generate report and open it

## Generate Report

```powershell
 allure generate <path-to-allure-results> --clean
```

## Open generated file

```powershell
allure open
```

# References

Playwright: https://playwright.dev/
Allure Report: https://allurereport.org/
