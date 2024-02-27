# Garden 
by Chris Ross Davila, Gabriel Tucker, Kim Robinson, Nikkita Torres

### Description

An application where a user can:
- register and sign in
- create, read, update and delete their garden information (Garden Beds, divided into grids with plants allocated into each grid)
- track their planting and results
- see a graph of the results over time
- Data Visualization of planted garden grid
- OpenWeatherApi to track weather at time of planting? User location?

![mysql relationship](./GardenAPI.Solution/GardenApi/wwwroot/img/models.png)

### Built With
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white)
![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![MySQL](https://img.shields.io/badge/mysql-%2300f.svg?style=for-the-badge&logo=mysql&logoColor=white)
![Git](https://img.shields.io/badge/git-%23F05033.svg?style=for-the-badge&logo=git&logoColor=white)
![Visual Studio Code](https://img.shields.io/badge/Visual%20Studio%20Code-0078d7.svg?style=for-the-badge&logo=visual-studio-code&logoColor=white)
![Swagger](https://img.shields.io/badge/-Swagger-%23Clojure?style=for-the-badge&logo=swagger&logoColor=white)
![Postman](https://img.shields.io/badge/Postman-FF6C37?style=for-the-badge&logo=postman&logoColor=white)
![Chart.js](https://img.shields.io/badge/Chart%20js-FF6384?style=for-the-badge&logo=chartdotjs&logoColor=white)
![Markdown](https://img.shields.io/badge/Markdown-000000?style=for-the-badge&logo=markdown&logoColor=white)
![Next.js](https://img.shields.io/badge/next%20js-000000?style=for-the-badge&logo=nextdotjs&logoColor=white)
![npm](https://img.shields.io/badge/npm-CB3837?style=for-the-badge&logo=npm&logoColor=white)
![react](https://img.shields.io/badge/React-20232A?style=for-the-badge&logo=react&logoColor=61DAFB)
![Tailwind CSS](https://img.shields.io/badge/Tailwind_CSS-38B2AC?style=for-the-badge&logo=tailwind-css&logoColor=white)
[ASP.NET Core MVC](https://docs.microsoft.com/en-us/aspnet/core/mvc/overview?view=aspnetcore-3.1)
[Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)


### API Endpoints
`GET http://localhost:5000/api/seeds` that will return all seed objects.
`GET http://localhost:5000/api/seeds/{id}` that will return one seed object based on its SeedId property.
`POST http://localhost:5000/api/seeds` that will add a new seed to our database and requires a request body with an object literal of an seed.
`DELETE http://localhost:5000/api/animals/{id}` will delete seed object by SeedId

kim todo: (seed)
-Patch method for seeds?
-add seed relationship with *Tags and * Grid (Join Entities)
-DateTime fix for DatePlanted property?
