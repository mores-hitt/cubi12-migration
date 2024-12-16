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

## Prerequisitos para correr el projecto

Antes de correr el projecto, asegurate de tener las siguientes cosas instaladas:

- .NET 8
- Docker Desktop
- repositorio en ejecucion de cubi12-api

Tambien, asegurate de tener una conexión de internet estable. Este proyecto utiliza filess para hostear la base de datos mongodb, por lo que es requerido una conexión estable

## Instalación

1. Clona el repositorio:

```bash
git clone https://github.com/mores-hitt/cubi12-migration.git
```

2. Crea un archivo .env dentro de la carpeta UserMicroservice con las siguientes variables

```dotenv

JWT_SECRET=//poner secreto jwt aqui

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

9. Para correr el proyecto entero, se debe abrir 4 terminales distintas, cada una debe estar en una de las siguientes carpetas:ApiGateway, AuthMicroservice, CareerMicroservice y UserMicroservice. En cada terminal, ejecutar el siguiente comando para levantar el proyecto correspondiente

```bash
dotnet run
```

Asegurate de tener los puertos 5235, 5275, 5375 y el puerto 5000 habilitados, junto a los puertos 5672 y 15672 para rabbitmq, 5632 y 1433 para MSSQL y 5432 para PostgreSQL

10. Para utilizar el proyecto, navega a la URl http://localhost:5000/swagger/ para interactuar con los endpoints de la api gateway
