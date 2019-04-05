# Api Rest de cervezas

## Descripcion


Con esta API Rest podras consultar informacion basica sobre la cerveza tal como:

* Nombre comercial
* Tipo de cerveza
* Fabricante
* Porcentaje de alcohol
* Presentacion en mililitros

## Arquitectura

Nuestra API utiliza la arquitectura MVC de ASPNet Core.

![Arquitectura de la aplicacion](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api/_static/architecture.png?view=aspnetcore-2.2)

## Metodos HTTP soportados
- GET
- POST 
- PUT
- DELETE




## Requerimientos

|   Dependencia      | Version     |
|--------------------|:-----------:|
| Visual Studio Code  |Cualquiera  |
| .NET Core SDK       |2.2 o >     |
| C# para Visual Code |1.17.1 o >  |



## Ejecutar el proyecto.

1. Ubicate en la carpeta donde clonaste el proyecto
2. Accede a la carpeta cervezaApi/
3. En la consola (preferiblemente powershell o cmd ejectuta) ``` dotnet build ```
4. Una vez compilado el proyecto ejectuta ``` dotnet run ```


## Trabajar con la API

Si la compilacion y ejecucion fue exitosa accede a: ```  http://localhost:5000/api/cervezas ```


