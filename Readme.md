# Risk Center Store

Risk Center Store

**Levantar proyecto Api y Crear BD del proyecto (desarrollo):**

- Cambiar el connection string del appsettings.json, ubicado en "**RiskCenterStore/src/Api/appsettings.json**"

> ![".\\src\WebUI\assets\appsettingsjson.png"](.\\src\WebUI\assets\appsettingsjson.png)

- Ingresar a la carpeta del proyecto, luego ir a la carpeta del proyecto Api ubicada en "**RiskCenterStore/src/Api**"

> ![".\\src\WebUI\assets\proyectApi.png"](.\\src\WebUI\assets\proyectApi.png)

- Luego se debe crear la migración con la directiva "**dotnet ef migrations add InitialCreate**", obtenemos el siguiente mensaje si la conexión está configurada correctamente.

> ![".\\src\WebUI\assets\migration.png"](.\\src\WebUI\assets\migration.png)

- Seguidamente utilizamos el comando para crear la BD "**dotnet ef database update**", podremos observar la creación de las tablas a traves de los mensajes tipo info.

> ![".\\src\WebUI\assets\updateDB.png"](.\\src\WebUI\assets\updateDB.png)

- En nuestro Microsoft SQL Server Management Studio podremos observar la creación de las tablas sin datos


> ![".\\src\WebUI\assets\updateDB.png"](.\\src\WebUI\assets\DBInitialized.png)

- Para crear datos debemos levantar el server del proyecto Api e ir a [https://localhost:7053/swagger/index.html](https://localhost:7053/swagger/index.html).


> ![".\\src\WebUI\assets\seed.png"](.\\src\WebUI\assets\seed.png)

- Luego en el apartado Seed, ejecutar el endpoint "**/api/Seed**", para que automaticamente se genere la data necesaria.

> ![".\\src\WebUI\assets\DBWithData.png"](.\\src\WebUI\assets\DBWithData.png)


**Levantar proyecto angular (desarrollo):**

- Ingresar a la carpeta del proyecto, luego ir a la carpeta del proyecto clientApp ubicada en "**RiskCenterStore/src/WebUI/ClientApp**"

> ![".\\src\WebUI\assets\proyectApi.png"](.\\src\WebUI\assets\webUi.png)
- Instalar dependencias con "**npm i**".


- Levantar el proyecto con el comando "**ng serve**", y verificar en la ruta [http://localhost:4200](http://localhost:4200/)


> ![".\\src\WebUI\assets\app.png"](.\\src\WebUI\assets\app.png)


