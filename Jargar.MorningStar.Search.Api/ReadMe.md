# Full-Text Search API
This is the API component of a .NET 7 ASP.NET Core application that allows users to perform a full-text search on a provided dataset and retrieve matching records.

## Description
The API serves as the data source and search engine for the application. 
It accepts a search parameter and returns records that match the given search criteria from the provided JSON dataset. 
The API part of the application meets the acceptance criteria specified in the project requirements.

## Table of Contents
- [Prerequisites](#prerequisites)
- [Getting Started](#getting-started)
- [Configuration](#configuration)
- [Contributing](#contributing)
- [License](#license)

## Prerequisites

List any prerequisites or dependencies required to run your project. Include software, libraries, or services that the user needs to have installed or set up before using your application.

- [ASP.NET Core SDK](https://dotnet.microsoft.com/download)
- [Visual Studio](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/) (optional, but recommended)
- Other dependencies specific to your project

## Getting Started
Clone the Repository:

Open Visual Studio and go to "File" > "Open" > "Clone Repository." Enter the repository URL, which is https://github.com/yourusername/full-text-search-app.git, and click "Clone."

Open the API Project:

In Visual Studio's Solution Explorer, you will see the cloned repository. Expand it and locate the "api" project. Right-click on the "api" project and select "Set as StartUp Project."

Restore Dependencies:

Build the project by right-clicking on the "api" project in Solution Explorer and selecting "Build." Alternatively, you can open the "Package Manager Console" and run:

shell
Copy code
dotnet restore
Run the API:

Now, you can run the API. Press F5 or click the "Start" button in Visual Studio. The API should start, and you'll see output in the console, indicating that it's running. The API should be accessible at http://localhost:5000.

Note: You can adjust the port and launch settings by right-clicking on the project in Solution Explorer, selecting "Properties," and going to the "Debug" tab.

Test the API:

You can test the API by sending HTTP requests to its endpoints. The API exposes a search endpoint, as described in the API Endpoints section in the README.

Customize and Extend:

Now that you have the API running in Visual Studio, you can start customizing and extending it to meet your specific project requirements. Add your full-text search logic and any additional functionality to complete the API part of your project.


## Usage

Explain how to use your application or project. Provide examples or code snippets if necessary. Describe any user interfaces or API endpoints and how they can be accessed.

## Configuration
You might need to ensure ports are matching with the ports on the react part of the application