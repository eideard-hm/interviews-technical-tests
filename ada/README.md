# Prueba Técnica ADA SAS

## Recomendaciones de versiones usadas en el desarrollo

Estas son las versiones utilizadas para el desarrollo del sistema de facturación

- Versión de angular -> Angular CLI: 16.2.0
- Versión de Node.Js -> 18.\*
- Versión de .NET -> 6.0.203
- Si se van hacer pruebas se debe de cambiar la cadena de conexión hacia la base de datos; asegurándose de colocar sus credenciales en el motor de base de datos SQL Server.

### Pasos a seguir para ejecutar los proyectos:
#### Proyecto de BackEnd:
* Se debe de crear la base de datos con el script SQL adjunto.
* Se debe de cambiar la cadena de conexión en el archivo __appsettings.json__
* Se debe de correr las migraciones para tener las tablas de base de datos, code-first
````
Update-Database -P UserManagement.Infrastructure
````

#### Proyecto de Front-End:
* Se debe de tener Node.js v.18.*
* Utilizar un node package manager (pnpm, yarn, bun, npm)

### Links:
- GitHub(repositorio): https://github.com/eideard-hm/ada-interview-.net
- Video Explicativo: https://drive.google.com/file/d/1GCrE70BNtUYNEobr295LzJIs4h1YyW39/view?usp=drive_link

![image](https://github.com/eideard-hm/ada-interview-.net/assets/82130680/87191fc8-0565-4b62-8c1b-1fde34b29726)

