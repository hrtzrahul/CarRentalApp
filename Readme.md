Note: 
      - MiniProject->Backend ,
      - CarRentalUI-->Frontend

# Car Rental Application


The Car Rental Application is a web-based application that allows users to browse and rent cars  online. This README provides an overview of the application and its components, along with instructions for setting up and running the application.

## Features

The Car Rental Application offers the following features:

- User sigIn and signUp
- Product browsing and search functionality
- Renting add to cart management
- Rent Order placement 
- Admin dashboard for managing products, inventory, and orders

## Technologies Used

The Car Rental Application utilizes the following technologies:

- Angular: A popular JavaScript framework for building the frontend.
- ASP.NET: A web development framework used for building the backend.
- Database (DB) first approach: A development methodology where the database schema is designed first, and the code is generated based on the database structure.

## Prerequisites

Before setting up the Car Rental Application, make sure you have the following prerequisites installed:

- Node.js: The latest LTS version of Node.js is required to run Angular.
- .NET SDK: Install the latest .NET SDK to run the ASP.NET backend.
- Microsoft SQL Server: Set up a SQL Server instance or have access to an existing SQL Server.

## Installation

To install and set up the Car Rental Application, follow these steps:

1. Clone the repository from GitLab:

   shell
   git clone https://nagarro-my.sharepoint.com/personal/rahul_singh14_nagarro_com/_layouts/15/onedrive.aspx?id=%2Fpersonal%2Frahul%5Fsingh14%5Fnagarro%5Fcom%2FDocuments%2FDesktop%2FRahulSingh%2D2%2D01%2DMarch%2D2023%2DCarRentalApp&ct=1695195528282&or=Teams%2DHL&ga=1
2. Change into the project directory:

    shell
    cd Mini-Project-Assignment

3. Install the frontend dependencies:
    shell
    cd CarRentalUI
    npm install

4. Install the backend dependencies:
    shell
    cd ../MiniProject
    dotnet restore

## Configuration

Before running the application, you need to configure the database connection. Follow these steps:

1. Open the Tools section VS Studio -> Nuget Package Manager -> Package Manager Console.

2. Run update-database command.

## Dependencies

1. Add dependencies for UI in package.json
   - "@fortawesome/angular-fontawesome": "^0.13.0",
   - "@fortawesome/fontawesome-svg-core": "^6.4.0",
   - "@fortawesome/free-solid-svg-icons": "^6.4.0",
   - "bootstrap": "^5.3.0",

## Running the Application

To run the Car Rental App, follow these steps:

1. Start the backend server:

   shell
   cd MiniProject
   dotnet run

2. Start the frontend development server:
    shell
    cd CarRentalUI
    ng serve

The frontend development server should now be running on http://localhost:4200.

3. Go to appsettings.development. in backend solution folder json find the admin credentials

"AppSettings": {

"UserName": "admin",

"UserEmail": "myadmin@test.com",

"UserPassword": "Test@321",

"AdminUserEmail": "myadmin@test.com"

}

## Usage
To use the Grocery Application, open your web browser and navigate to http://localhost:4200. You should see the application's homepage, where you can log in to access the full features of the application.
