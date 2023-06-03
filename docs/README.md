# EXSM 3943: C# Project - Project MACK

---

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;This is a dotnet core MVC web project that allows users to manage vehicles for a corporation. It utilizes Entity Framework for data access and provides various functionalities such as creating, editing, viewing, and deleting vehicles. Additionally, users can upload a .csv file to mass create vehicle objects along with their related model and manufacturer information. The project also incorporates built-in dotnet Identity for user authentication, logins, and registration validation.

## Prerequisites

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Before running this project, make sure you have the following prerequisites installed:

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[.NET Core SDK](https://dotnet.microsoft.com/en-us/download)
  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/)
  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[dotnet Identity](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-7.0&tabs=visual-studio)

## Getting Started
Follow the steps below to get started with the project:

  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1. Clone the repository:

  ```bash
  git clone https://github.com/Web-Development-UAlberta/c-project-mack
  ```

  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;2. Navigate to the project directory:

  ```bash
  cd ~(LocalDirectory)/src/MACK
  ```

  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;3. Restore the dependencies:

  ```bash
  dotnet restore
  ```

  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;4. Apply the database migrations:

  ```bash
  dotnet ef database update
  ```
  
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;5. Build and run the project:

  ```bash
  dotnet run
  ```
  
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;6. Access the website in your browser by visiting https://localhost:5001.

## Usage
### Registration and Login

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;To access the full functionality of the website, users need to register and log in. Click on the "Register" link on the homepage to create a new account. Once registered, you can use the login form to sign in.

### Vehicle Management:

    - Create Vehicle: Logged-in users can create new vehicles by providing details such as the vehicle's model, manufacturer, and other relevant information.
    
    - Edit Vehicle: Users can edit the details of existing vehicles, making changes to any field as needed.
    
    - View Vehicle List: The website provides a list view of all vehicles, displaying essential information such as the vehicle's make, model, and other relevant details.
    
    - Delete Vehicle: Users can delete a vehicle from the system, removing it permanently.

## Mass Vehicle Creation from .csv File

To mass create vehicles from a .csv file, follow these steps:

    1. Prepare a .csv file with the necessary columns and data. The file should include fields such as make, model, and other relevant vehicle details.

    2. Log in to the website.

    3. Navigate to the "Vehicles/FileUpload" page.

    4. Choose the .csv file using the provided file input field.

    5. Click on the "Upload" button to initiate the upload process.
        
The system will read the .csv file and create vehicle objects for each row, associating them with their respective models and manufacturers.

Once the upload is complete, the newly created vehicles will be available in the system and can be managed accordingly.
    
## License

### MIT License

### Copyright (c) 2023 MACK

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION

## ✍️ Author(s)
- [Minh Hoang](https://github.com/mintiefresh) (CCID: minhtuan)
- [Kevin Larner](https://github.com/Larnerk) (CCID: larnerk)
- [Andrew Potter](https://github.com/SaskatchewanPython) (CCID: rapotter)
- [Caelan Ross](https://github.com/Caelan-Ross) (CCID: cjross1)
