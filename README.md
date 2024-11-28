# MyNunitProject

 This project contains automated tests for the JSONPlaceholder RESTful API using NUnit and RestSharp. The tests include GET, POST, PUT, and DELETE requests to validate the functionality of the API.

## Prerequisites
Before running the tests, ensure that you have the following installed:

1. Visual Studio 2022 (or later):
Download: [Visual Studio](https://visualstudio.microsoft.com/).
Ensure the .NET desktop development and NUnit Test Adapter workloads are installed.
2. .NET SDK (6.0 or later):
Download: [.NET SDK.](https://dotnet.microsoft.com/download)

3. NuGet Packages:
- The project uses the following dependencies:
- RestSharp: For making HTTP requests.
- NUnit: For test framework.
- Newtonsoft.Json: For JSON parsing.

# Setup Instructions
1. Clone the Repository: Clone this repository to your local machine:
- git clone https://github.com/niketsathe1997/MyNunitProject.git
2. Open the Project: Open the solution file (MyNunitProject.sln) in Visual Studio.

3. Restore Dependencies: Restore the required NuGet packages:
   dotnet restore
## Running the Tests
### Option 1: Using Visual Studio Test Explorer
- Open Visual Studio.
- Go to Test > Test Explorer in the menu.
- Build the solution (shortcut: Ctrl + Shift + B).
- Run all tests or individual tests by clicking the Run All button or selecting specific tests.

### Option 2: Using the Command Line
- Open a terminal in the project directory.
- Run the following command to execute the tests    
--> dotnet test

  This will run all the tests and display the results in the terminal


## Test Report
### Generating HTML Reports
The test results can be saved as HTML reports for easier review. To generate reports:
1. Run the tests using the dotnet test command with a results file output:
# To be tested 
Open the generated TestReport.html file in a browser to view the test results.

## Logs
Each test logs the following details:

- Request: The HTTP method, endpoint, headers, and body.
- Response: The status code and response body.
Logs can be found in the output of the test run.


