Conexión a Base de datos y lectura de registros

Cómo ejecutarlo

Abre el proyecto en Visual Studio Community y presiona F5.
O utiliza el comando dotnet run desde la terminal.


![Caso 1](img/img-1.png)


![Caso 2](img/img-2.png)


![Caso 3](img/img-3.png)


![Caso 4](img/img-4.png)

El programa da error porque al cambiar el nombre de la base de datos en el código, le estamos pidiendo al programa que se conecte a una que no existe, 
como el programa todavía no está preparado para manejar este tipo de fallos, la aplicación se cae.



