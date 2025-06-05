## CRUD de Productos en ASP.NET Core con SQL Server

Este proyecto es una aplicación ASP.NET Core MVC desde cero para gestionar productos con las operaciones básicas de CRUD (Crear, Leer, Actualizar, Eliminar), usando SQL Server y Entity Framework Core.

### 🧱 Tecnologías utilizadas

* ASP.NET Core Web App (MVC)
* Entity Framework Core
* SQL Server

---

## ✅ Paso 1: Crear el proyecto

1. Abrir Visual Studio.
2. Seleccionar **Crear un nuevo proyecto**.
3. Escoger **ASP.NET Core Web App (Model-View-Controller)**.
4. Asignar nombre, por ejemplo: `CrudProductosApp`.
5. Seleccionar el framework **.NET 6** o superior.
6. Clic en **Crear**.

---

## ✅ Paso 2: Instalar Entity Framework Core SQL Server

Abrir la **Consola del Administrador de Paquetes NuGet** y ejecutar:

```bash
Install-Package Microsoft.EntityFrameworkCore.SqlServer
Install-Package Microsoft.EntityFrameworkCore.Tools
```

---

## ✅ Paso 3: Crear el modelo `Producto`

En la carpeta `Models`, crear el archivo `Producto.cs`:

```csharp
using System.ComponentModel.DataAnnotations;

namespace CrudProductosApp.Models
{
    public class Producto
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required]
        public decimal Precio { get; set; }
    }
}
```

---

## ✅ Paso 4: Crear el DbContext

En la carpeta `Data`, crear el archivo `AppDbContext.cs`:

```csharp
using Microsoft.EntityFrameworkCore;
using CrudProductosApp.Models;

namespace CrudProductosApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Producto> Productos { get; set; }
    }
}
```

---

## ✅ Paso 5: Configurar la cadena de conexión

En `appsettings.json`, agregar la cadena de conexión:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=TU_SERVIDOR_SQL;Database=CrudProductosDB;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

---

## ✅ Paso 6: Configurar el contexto en `Program.cs`

Agregar en `builder.Services`:

```csharp
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
```

---

## ✅ Paso 7: Crear la base de datos

Ejecutar en la consola del administrador de paquetes:

```bash
Add-Migration InitialCreate
Update-Database
```

Esto generará la tabla `Productos` en la base de datos.

---

## ✅ Paso 8: Crear el controlador `ProductosController`

1. Clic derecho en **Controllers > Agregar > Controlador…**
2. Seleccionar **Controlador MVC con vistas, usando Entity Framework**
3. Modelo: `Producto`
4. Contexto: `AppDbContext`
5. Clic en **Agregar**

Esto generará automáticamente:

* Controlador `ProductosController`
* Vistas: `Create`, `Edit`, `Details`, `Delete`, `Index`

---

## ✅ Paso 9: Agregar enlace al menú

En `Views/Shared/_Layout.cshtml`, agregar:

```html
<li class="nav-item">
    <a class="nav-link text-dark" asp-controller="Productos" asp-action="Index">Productos</a>
</li>
```

---

## ✅ Paso 10: Ejecutar

Presionar **F5** para ejecutar la aplicación. Se podrá:

* Ver el listado de productos
* Crear un nuevo producto
* Editar producto existente
* Ver detalles
* Eliminar producto

---

¿Deseas una versión mejorada con Bootstrap o una API REST también?
