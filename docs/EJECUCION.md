# Ejecución local de LibroExpress

## Requisitos

- Windows y Visual Studio con las herramientas de **ASP.NET y desarrollo web para .NET Framework**.
- Paquete de desarrollo o targeting pack de **.NET Framework 4.7.2**.
- SQL Server o SQL Server Express LocalDB, y una herramienta para ejecutar scripts T-SQL, como SQL Server Management Studio o SQL Server Object Explorer de Visual Studio.
- IIS Express para servir la aplicación durante el desarrollo.

El SDK de .NET utilizado por ASP.NET Core no sustituye las herramientas de Web Forms necesarias para esta solución.

## 1. Preparar una base de datos propia

Crea una base **nueva y vacía**, por ejemplo `LibroExpressDemo`, en tu instancia local de SQL Server.

Ejecuta sobre ella, en este orden:

1. `database/01-schema.sql`: tablas, claves y relaciones del modelo original.
2. `database/02-catalogo.sql`: catálogo de libros, categorías, paquetes y sus relaciones.

Los scripts no crean usuarios ni incluyen contraseñas o datos de clientes. El catálogo usa los identificadores generados al insertar en una base vacía; no lo ejecutes sobre una base existente de producción. Los datos de ventas y cuentas se generan al utilizar la aplicación, por lo que las métricas dependen del contenido disponible.

## 2. Configurar la conexión

Copia `proWeb/ConnectionStrings.example.config` con el nombre `proWeb/ConnectionStrings.config`. Este último archivo es local y está excluido de nuevas incorporaciones a Git.

El ejemplo utiliza autenticación integrada de Windows:

```xml
<connectionStrings>
  <add name="database"
       connectionString="Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LibroExpressDemo;Integrated Security=True;Connect Timeout=5;"
       providerName="System.Data.SqlClient" />
</connectionStrings>
```

Si tu instancia es distinta, adapta `Data Source` y `Initial Catalog`. `Web.config` carga la conexión mediante `configSource`; conserva el nombre `database`, que utilizan las clases CAD.

## 3. Abrir y compilar

1. Abre `libroExpress.sln` en Visual Studio.
2. Selecciona `proWeb` como proyecto de inicio.
3. Comprueba que ambos proyectos tienen como destino .NET Framework 4.7.2.
4. Compila la solución y ejecuta con IIS Express.
5. Abre `mainPage.aspx`; desde su navegación puedes acceder al catálogo, los paquetes y las pantallas de registro y acceso.

## Pantallas principales

| Página | Contenido |
| --- | --- |
| `mainPage.aspx` | Portada, novedades y selección de productos. |
| `catalogo.aspx` | Búsqueda y filtros de libros y paquetes. |
| `producto.aspx` | Ficha de un libro. |
| `paquete.aspx` | Ficha de un paquete de libros. |
| `carrito.aspx` | Carrito de compra. |
| `LogIn.aspx`, `register.aspx` | Acceso y registro. |
| `usuario.aspx`, `mispedidos.aspx` | Perfil y pedidos del cliente. |
| `admin*.aspx`, `metricas.aspx` | Gestión y métricas de la tienda. |

## Diagnóstico

- **No se encuentra Microsoft.WebApplication.targets:** comprueba que tienes las herramientas de desarrollo web de Visual Studio.
- **No se encuentran referencias de .NET 4.7.2:** instala su paquete de desarrollo o targeting pack.
- **Error de conexión SQL:** revisa que la instancia esté arrancada, la base exista y el archivo local contenga la conexión correcta.
- **La portada falla con una base vacía:** carga el catálogo y comprueba las consultas de novedades y ventas; la versión académica contiene suposiciones sobre el número de resultados.
- **Imágenes externas o estilos incompletos:** la interfaz usa algunas bibliotecas y recursos alojados en CDN y requiere acceso a ellos.

## Documentación de las herramientas

- [ASP.NET Web Forms](https://learn.microsoft.com/en-us/aspnet/web-forms/).
- [SQL Server Express LocalDB](https://learn.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb).
