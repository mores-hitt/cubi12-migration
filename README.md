# Taller 2 Arquitectura de Sistemas

## Autores

Fernando Javier Sanabria Ampuero
Jhon Michael Lopez Rodriguez

## Correo

fernando.sanabria@alumnos.ucn.cl
jhon.lopez@alumnos.ucn.cl

## Rut

21.011.823-3
25.415.945-K

## Prerequisitos para correr el projecto sin docker

Antes de correr el projecto, asegurate de tener las siguientes cosas instaladas:

- .NET 8
- Docker Desktop
- repositorio en ejecucion de cubi12-api

## Instalación

1. Clona el repositorio:

```bash
git clone https://github.com/mores-hitt/cubi12-migration.git
```

2. Crea un archivo .env dentro de la carpeta UserMicroservice con las siguientes variables

```dotenv

SECRET=//poner secreto jwt aqui

```

Asegurate que uses el mismo secret en todos los archivos .env

3. Crea un archivo .env dentro de la carpeta AuthMicroservice con las siguientes variables

```dotenv
JWT_SECRET=//poner secreto jwt aqui
MSSQL_SA_PASSWORD=Your_password123//asegurate que la contraseña sea valida segun MSSQL

```

Asegurate que uses el mismo secret en todos los archivos .env

4. En la carpeta raiz del proyecto, ejecuta el siguiente comando para levantar el contenedor de rabbitmq

```bash
docker-compose up -d
```

5. En la carpeta de UserMicroservice, ejecuta el siguiente comando para levantar el contenedor de la base de datos del microservicio

```bash
docker-compose up -d
```

6. En la carpeta de AuthService, ejecuta el siguiente comando para levantar el contenedor de la base de datos del microservicio

```bash
docker-compose up -d
```

7. En la carpeta raiz del proyecto, ejecuta el siguiente comando para restaurar todas las soluciones

```bash
dotnet restore
```

8. En la carpeta raiz del proyecto, ejecuta el siguiente comando para buildear todas las soluciones

```bash
dotnet build
```

9. Para correr el proyecto entero, se debe ingresar a las carpetas ApiGateway, AuthMicroservice, CareerMicroservice y UserMicroservice y ejecutar el siguiente comando

```bash
dotnet run
```

Asegurate de tener los puertos 5235, 5275, 5375 y el puerto 5000 habilitados

10. Para utilizar el proyecto, navega a la URl http://localhost:5000/swagger/ para interactuar con los endpoints de la api gateway
