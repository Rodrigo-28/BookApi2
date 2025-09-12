# 📚 bookApi

**bookApi** es una API RESTful desarrollada en **.NET 8** utilizando principios de **Clean Architecture**, cuyo objetivo es replicar funcionalmente una plataforma de libros similar a *Goodreads*. Este proyecto me permitió practicar relaciones complejas entre entidades, aplicar buenas prácticas de diseño, seguridad y testing, y construir una base escalable para una aplicación realista.

---

### 📊 Descripción del sistema

El sistema permite:

- Registrar usuarios y autenticar con JWT.
- Explorar libros con sus datos completos.
- Asignar libros a estanterías personales (`UserBook`).
- Agregar calificación y estado de lectura.
- Consultar detalles y lista de libros según el usuario.

Fue un verdadero desafío construir una versión inspirada en Goodreads, ya que involucra muchas relaciones entre entidades y reglas de negocio realistas.

---

### 🚧 Arquitectura y estructura

El proyecto sigue una implementación completa de **Clean Architecture**, distribuyendo responsabilidades de forma clara:

- **Domain**: modelos de negocio como `Book`, `User`, `UserBook`, `Genre`, etc.
- **Application**: servicios, DTOs, validaciones, interfaces, excepciones personalizadas.
- **Infrastructure**: `Entity Framework Core` con PostgreSQL, servicios JWT, cifrado, herramientas de acceso a datos.
- **bookApi**: capa de presentación (`WebAPI`) con controladores y endpoints.
- **bookApiTests**: proyecto de testing unitario con `xUnit`, `FakeItEasy` y `FluentAssertions`.

🔗 Más sobre Clean Architecture: [The Clean Architecture - Uncle Bob](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)

---

### 🔒 Seguridad y autenticación

El sistema implementa autenticación mediante **JWT (JSON Web Tokens)**:

- Los usuarios obtienen un token al iniciar sesión.
- El token contiene `claims` como `userId`, `email`, y `role`.
- Los endpoints sensibles están protegidos con `[Authorize]`.

Ejemplo de restricción por rol:

```csharp
[Authorize(Roles = "Admin")]
[HttpPost("genres")]
public async Task<IActionResult> CreateGenre(...) { ... }
```

---

### 📄 Entidades principales

- **User**: usuario registrado (email, contraseña cifrada, rol).
- **Book**: datos del libro (título, autor, descripción, géneros, etc.).
- **Genre**: género literario.
- **UserBook**: relación entre usuario y libro (estado de lectura, calificación, fecha de modificación).

---

### 🕵️ Roles de usuario

- **Usuario (User)**: puede agregar libros a su estantería, calificarlos y cambiar su estado.
- **Administrador (Admin)**: además de lo anterior, puede crear géneros y realizar acciones restringidas.

El rol se establece mediante `Claims` en el JWT.

---

### 🔮 Testing

Los tests unitarios cubren tanto servicios como controladores. Las tecnologías utilizadas incluyen:

- **xUnit**: definición y ejecución de tests.
- **FakeItEasy**: mocks de dependencias.
- **FluentAssertions**: validaciones expresivas.

Ejemplo de aserción:

```csharp
okResult!.Value.Should().BeEquivalentTo(expectedDto);
```

Estos tests permiten validar la lógica de negocio sin necesidad de acceder a la base de datos real.

---

### 🛠️ Middleware personalizado

Se desarrolló un **ExceptionMiddleware** para capturar errores de forma global y devolver respuestas consistentes:

- Manejo de excepciones como `BadRequestException`, `NotFoundException`, `UnauthorizedException`, `ForbiddenException`.
- El middleware genera un `ErrorResponse` con `ErrorCode` y mensaje específico, facilitando el debugging y control del frontend.

---

### 🧱 Abstracción de Repositorios y Servicios

Para evitar la repetición de lógica y fomentar un diseño escalable, implementé una capa de **repositorios y servicios genéricos reutilizables**, disponible en la rama `abstraction`.

#### 🧩 `BaseRepository<TEntity>`

Encapsula operaciones básicas (`CRUD`) para cualquier entidad que herede de `BaseModel`. Soporta:

- Soft delete (`ISoftDeletable`)
- Carga de relaciones (`IncludeDelegate<TEntity>`)
- Reutilización total desde repositorios concretos como `BookRepository`.

#### 💼 `BaseService<TEntity, TResponseDto, TResponseDetail, TCreateDto, TUpdateDto>`

Define la lógica de negocio común a todas las entidades:

- `GetAll()`, `GetOne()`, `Create()`, `Update()`, `Delete()`
- Mapeo automático con `AutoMapper`
- Manejo de soft deletes y timestamps (`ITimestampedModel`)

#### 📘 Ejemplo: `BookService` y `BookRepository`

Ambas clases heredan de sus versiones base e implementan lógica específica como:

- Asignación de géneros al crear un libro.
- Inclusión de datos relacionados como `ReadingStatus`.
- Filtros dinámicos, ordenamiento y paginación personalizados.

#### 🧠 Beneficios

- ✅ Reutilización de lógica compartida
- ✅ Separación clara de responsabilidades
- ✅ Menor acoplamiento, mayor testabilidad
- ✅ Código más limpio y mantenible

---

### 🔍 Búsqueda y filtrado dinámico

Para potenciar la experiencia del usuario y permitir consultas avanzadas desde el frontend, desarrollé un sistema de **búsqueda, filtrado y ordenamiento dinámico**, utilizando `System.Linq.Expressions` para construir árboles de expresión en tiempo de ejecución.

Desde el frontend, se pueden enviar consultas codificadas en base64 que incluyen:

- 🔎 Texto de búsqueda general (`title`, `author`, `description`)
- 🧮 Filtros avanzados: `eq`, `neq`, `gt`, `lte`, `between`, `contains`, etc. (ver clase `FilterTypes`)
- 📐 Ordenamiento: ascendente o descendente por propiedades como `PublishYear`
- 📄 Paginación integrada para mejorar el rendimiento

Toda esta lógica está encapsulada en `QueryHelpers`, que construye expresiones dinámicamente según los parámetros recibidos.

Utilicé como herramienta de apoyo el generador visual de queries:  
🔗 [https://query-builder-bay.vercel.app](https://query-builder-bay.vercel.app), donde se puede armar visualmente la búsqueda y copiar el string listo para usar.

---

### ⚙️ Instrucciones para correr el proyecto

1. **Clonar el repositorio**:

```bash
git clone https://github.com/tu-usuario/bookApi.git
```

2. **Configurar la conexión en `appsettings.json`**:

```json
"ConnectionStrings": {
  "DefaultConnection": "***"
},
"Jwt": {
  "Key": "TuClaveJwtSegura",
  "Issuer": "bookApiIssuer",
  "Audience": "bookApiAudience"
}
```

3. **Aplicar migraciones**:

```bash
dotnet ef database update --project bookApi.infrastructure --startup-project bookApi
```

4. **Ejecutar la API**:

```bash
dotnet run --project bookApi
```

5. **Explorar con Swagger**:  
[https://{tu puerto}/swagger/index.html]

---

### 🚀 Ideas para escalar

- Crear microservicio para recomendaciones personalizadas.
- Integrar sistema de comentarios y reseñas.
- Implementar notificaciones por email.
- Desarrollar frontend con Angular o React.
- Exponer una API pública para integraciones externas.

---

### 🧠 Lecciones aprendidas y desafíos

- Fue desafiante modelar las relaciones entre `Book`, `User`, `Genre`, `UserBook`, etc.
- Intentar imitar la estructura de Goodreads me obligó a pensar como usuario y como desarrollador.
- Aprendí a aplicar Clean Architecture en un contexto realista y complejo.
- Profundicé en testing profesional con `xUnit`, `FakeItEasy`, y `FluentAssertions`.
- Desarrollé un middleware de errores claro y reutilizable para el manejo unificado de excepciones.
- Implementé lógica de filtros dinámicos con expresiones LINQ y consultas base64.

---

### 📈 Tecnologías utilizadas

- ✅ **.NET 8**
- ✅ **Entity Framework Core**
- ✅ **PostgreSQL**
- ✅ **JWT**
- ✅ **AutoMapper**
- ✅ **xUnit**
- ✅ **FakeItEasy**
- ✅ **FluentAssertions**
- ✅ **Swagger (Swashbuckle)**

---

### 🧾 Resumen del proyecto

Este proyecto fue una experiencia muy completa y desafiante para mí. No solo me permitió aplicar todos los conocimientos que fui incorporando como backend developer, sino que también me hizo enfrentar problemas reales: modelado complejo de datos, diseño escalable de servicios, autenticación segura, testing, abstracciones reutilizables, filtros dinámicos, y más.

Intenté llevar adelante este desarrollo como lo haría en un entorno profesional, priorizando la calidad del código, la claridad en las responsabilidades de cada capa, y un enfoque orientado a escalabilidad y mantenibilidad.

Además de crecer como programador, disfruté mucho el proceso de armar un sistema funcional basado en una plataforma que uso a diario como Goodreads. Mi objetivo no fue simplemente que funcione, sino que esté bien construido por dentro. Este proyecto representa mi compromiso con el aprendizaje serio y mi deseo de construir software profesional y útil.
