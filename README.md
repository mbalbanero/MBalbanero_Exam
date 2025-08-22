# Project Overview

This is a simple project demonstrating a basic integration of ASP.NET Core MVC with Web API and Web3 wallet connectivity.

## Frontend

- Built using **ASP.NET Core MVC**.
- The frontend is simple and functional: clicking the **Connect Wallet** button automatically connects to **MetaMask** or any compatible Web3 wallet.

## Backend

- Built using **ASP.NET Core Web API**.
- **Swagger** has been integrated for easier testing and interaction with the API endpoints from the frontend.

## Dependencies

The following NuGet packages are used in this project:

- [Swashbuckle.AspNetCore](https://www.nuget.org/packages/Swashbuckle.AspNetCore/) – for Swagger integration
- [Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json/) – for JSON serialization/deserialization

## Prerequisites

Before running the project, make sure you have installed:

- [.NET 7 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)
- MetaMask or any Web3-compatible wallet browser extension


## Setup & Run Locally

1. **Clone the repository or open directly in Visual Studio**
   - Go to your GitHub repository and click **Code** → **Local** → **Open with Visual Studio**  
     This will automatically clone the repo and open the solution in Visual Studio.  
   - Alternatively, you can clone via command line:
     ```bash
     git clone https://github.com/your-username/your-repo.git
     cd your-repo
     ```
2. **appsettings.json**
   - Open `appsettings.json`.
   - Locate the section for your API key and **replace the value with your actual API key** from [Etherscan](https://etherscan.io):
     ```json
     {
       "YourApiService": {
         "ApiKey": "YOUR_ACTUAL_API_KEY_HERE"
       }
     }
     ```

4. **Run the program**
   click run or f5
