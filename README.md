# animal shelter api

#### By _**Jacob Palaoro**_  

#### _an api to hold animal details for an animal shelter._  

---

## Table of Contents

**[Technologies Used](#technologies-used)  
[Description](#description)  
[Setup/Installation Requirements](#setup-and-installation-requirements)  
[Known Bugs](#known-bugs)  
[License](#license)**

---

## Technologies Used

* _C#_
* _.NET_
* _HTML_
* _CSS_
* _SQL Workbench_
* _Entity Framework_
* _MVC_
* _Postman_

---
## Description

_This is an API made to display animals contained in an animal shelter. its my first independent project creating an api_

---
## Setup and Installation Requirements

<details>
<summary><strong>Initial Setup</strong></summary>
<ol>
<li>Copy the git repository url
<li>Open a shell program and navigate to your desktop.
<li>Clone the repository for this project using the "git clone" command and including the copied URL.
<li>While still in the shell program, navigate to the root directory of the newly created file named "treat.Solution".
<li>From the root directory, navigate to the "AnimalShelter" directory.

<br>
</details>

<details>
<summary><strong>SQL Workbench Configuration</strong></summary>
<ol>
<li>Create an appsetting.json file in the "AnimalShelter" directory of the project*  
   <pre>AnimalShelterAPI.Solution
   └── AnimalShelter
    └── appsetting.json</pre>
<li> Insert the following code** : <br>

<pre>{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=jacob_palaoro;uid=root;pwd=[YOUR-PASSWORD-HERE];"
  }
}</pre>
<small>*note: you must include your password in the code block section labeled "YOUR-PASSWORD-HERE".</small><br>
<small>**note: if you plan to push this cloned project to a public-facing repository, remember to add the appsettings.json file to your .gitignore before doing so.</small>
 project.<br><br>
How to Import a Database:
<ol> 
  <li>Open your terminal 
  <li>Move to AnimalShelter folder in the project
  <li>run dotnet ef migrations add Initial
  <li> dotnet ef database update
  
</details>

<details>
<summary><strong>To Run</strong></summary>
Navigate to:  
   <pre>AnimalShelterAPI.Solution
   └── <strong>AnimalShelter</strong></pre>

Run ```$ dotnet restore``` in the console.<br>
Run ```$ dotnet run``` in the console
The endpoints for this app can be reached through a web browser or an API platform like Postman.

After launching the app, as described below, navigate to http://localhost:5000/api/Animals/ in your browser or send the URL as a GET request in Postman to receive a list of all animals currently in the shelter.


</details>
<br>
### Endpoints

Base URL: `https://localhost:5000/Animals`

#### HTTP Request Structure

```Shell
GET /api/Animals
POST /api/Animals
GET /api/Animals/{id}
PUT /api/Animals/{id}
DELETE /api/Animals/{id}
```

#### Example Query

```Shell
https://localhost:5000/api/Animals/2
```

#### Example JSON Response

```JSON
{
  "animalId": 2,
  "name": "Bob",
  "species": "Panda",
  "age": 8,
  "gender": "Unknown"
}
```


This program was built using *`Microsoft .NET SDK 5.0.401`*, and may not be compatible with other versions. Your milage may vary.

---
## Known Bugs

* _No known issues_

## License

_[MIT License](license)_

Copyright (c) August 13th, 2022 Jacob Palaoro