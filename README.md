# 🧠 Prueba Técnica - Jerarquía de Empleados

Este proyecto consiste en una aplicación web completa que permite mostrar y gestionar una jerarquía de empleados en base a una tabla recursiva en SQL Server.

---

## 📂 Estructura del Repositorio

/PruebaTecnicaEmpleados/

```
├── BackEnd / → Proyecto Backend (ASP.NET Core Web API)
├── FrontEnd/ → Proyecto Frontend (ASP.NET MVC)
├── script BD.sql → Script de base de datos y procedimientos almacenados
└── README.md
```

---

## ⚙️ Requisitos

- .NET 8 SDK
- SQL Server (local o en la nube)
- Visual Studio 2022 o superior (opcional, recomendado)

---

## 🛠️ Instalación

### 1. Clonar el repositorio

```bash
git clone https://github.com/tu-usuario/PruebaTecnicaEmpleados.git
```

### 2. Crear la base de datos

Abre SQL Server Management Studio y ejecuta el script ubicado en:
```
/scripts/script.sql
```
Esto creará la base de datos PruebaTecnica con su tabla Empleados y los procedimientos almacenados necesarios.

---
### 3. Configurar cadenas de conexión

En ambos proyectos (EmpleadosApi y FrontEnd), edita el archivo appsettings.json con tu conexión local:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=PruebaTecnica;Trusted_Connection=True;TrustServerCertificate=True;"
}

```
> Cambia localhost si tu servidor usa otro nombre o IP, y agrega credenciales si usas autenticación SQL.

---

## ▶️ Ejecución
### 1. Levantar la API (Backend)

```bash
cd BackEnd
dotnet run
```

La API quedará disponible en https://localhost:5001 o http://localhost:5000.

---

### 2. Levantar el Frontend

```bash
cd FrontEnd
dotnet run
```

Accede al navegador en https://localhost:puerto (el que muestre la consola).

---

## ✅ Funcionalidades

- Mostrar árbol jerárquico de empleados
- Insertar nuevo empleado (con o sin jefe)
- Editar datos de un empleado
- Eliminar empleado
- Todo usando procedimientos almacenados en SQL Server

---

## 📸 Vista previa (Ejemplo de árbol)

```
1 – Gerente – Pedro
  └ 2 – Sub Gerente – Pablo
      └ 3 – Supervisor – Juan
  └ 4 – Sub Gerente – José
      ├ 5 – Supervisor – Carlos
      └ 6 – Supervisor – Diego
```

---

## 📦 Tecnologías usadas

- ASP.NET Core 8 Web API
- ASP.NET MVC
- SQL Server
- Procedimientos almacenados (stored procedures)
- Bootstrap (para estilos básicos)

---

## 🧑‍💻 Autor

    Susel Eugenia Retana Arriola

## 📄 Licencia

Este proyecto es únicamente con fines de evaluación técnica.
