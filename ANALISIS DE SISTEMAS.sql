-- Crear base de datos
CREATE DATABASE SistemaGestionVentas;
GO

-- Usar la base de datos recién creada
USE SistemaGestionVentas;
GO

-- Tabla para almacenar las categorías de los productos (CCTV o fibra óptica)
CREATE TABLE Categoria (
    CategoriaID INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(50) NOT NULL
);

-- Tabla de productos, con una relación a la categoría
CREATE TABLE Producto (
    ProductoID INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(255),
    Precio DECIMAL(10,2) NOT NULL,
    CategoriaID INT NOT NULL,
    FOREIGN KEY (CategoriaID) REFERENCES Categoria(CategoriaID)
);

-- Tabla de usuarios (clientes y administradores)
CREATE TABLE Usuario (
    UsuarioID INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    Direccion NVARCHAR(255),
    TipoUsuario NVARCHAR(50) NOT NULL -- 'Final' o 'Administrador'
);

-- Tabla de direcciones adicionales de los usuarios
CREATE TABLE Direccion (
    DireccionID INT PRIMARY KEY IDENTITY(1,1),
    UsuarioID INT NOT NULL,
    Direccion NVARCHAR(255) NOT NULL,
    FOREIGN KEY (UsuarioID) REFERENCES Usuario(UsuarioID)
);

-- Tabla de pedidos, con una relación a los usuarios
CREATE TABLE Pedido (
    PedidoID INT PRIMARY KEY IDENTITY(1,1),
    UsuarioID INT NOT NULL,
    FechaPedido DATETIME NOT NULL DEFAULT GETDATE(),
    Estado NVARCHAR(50) NOT NULL, -- 'Pendiente', 'Enviado', 'Completado', 'Cancelado'
    FOREIGN KEY (UsuarioID) REFERENCES Usuario(UsuarioID)
);

-- Tabla de detalles de pedido, con relación a los productos y a los pedidos
CREATE TABLE DetallePedido (
    DetallePedidoID INT PRIMARY KEY IDENTITY(1,1),
    PedidoID INT NOT NULL,
    ProductoID INT NOT NULL,
    Cantidad INT NOT NULL,
    PrecioUnitario DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (PedidoID) REFERENCES Pedido(PedidoID),
    FOREIGN KEY (ProductoID) REFERENCES Producto(ProductoID)
);

-- Tabla para el sistema de pagos asociado a los pedidos
CREATE TABLE Pago (
    PagoID INT PRIMARY KEY IDENTITY(1,1),
    PedidoID INT NOT NULL,
    Monto DECIMAL(10,2) NOT NULL,
    FechaPago DATETIME NOT NULL DEFAULT GETDATE(),
    MetodoPago NVARCHAR(50) NOT NULL, -- 'Tarjeta', 'PayPal', 'Transferencia'
    EstadoPago NVARCHAR(50) NOT NULL, -- 'Pendiente', 'Pagado', 'Fallido'
    FOREIGN KEY (PedidoID) REFERENCES Pedido(PedidoID)
);

-- Tabla para reportes de ventas (usado por administradores y dueño del sistema)
CREATE TABLE ReporteVentas (
    ReporteID INT PRIMARY KEY IDENTITY(1,1),
    FechaGeneracion DATETIME NOT NULL DEFAULT GETDATE(),
    VentasTotales DECIMAL(18,2) NOT NULL,
    NumeroPedidos INT NOT NULL,
    UsuarioID INT NOT NULL, -- Quien genera el reporte (Administrador o Dueño)
    FOREIGN KEY (UsuarioID) REFERENCES Usuario(UsuarioID)
);

-- Tabla para proveedores (relacionada a los productos)
CREATE TABLE Proveedor (
    ProveedorID INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    Contacto NVARCHAR(100),
    Telefono NVARCHAR(50)
);

-- Relación entre proveedores y productos
CREATE TABLE ProductoProveedor (
    ProductoID INT NOT NULL,
    ProveedorID INT NOT NULL,
    PRIMARY KEY (ProductoID, ProveedorID),
    FOREIGN KEY (ProductoID) REFERENCES Producto(ProductoID),
    FOREIGN KEY (ProveedorID) REFERENCES Proveedor(ProveedorID)
);


-- Tabla de login de usuarios
CREATE TABLE Login (
    LoginID INT PRIMARY KEY IDENTITY(1,1),
    UsuarioID INT NOT NULL,
    NombreUsuario NVARCHAR(100) NOT NULL UNIQUE,
    ContrasenaHash NVARCHAR(255) NOT NULL,
    UltimoAcceso DATETIME NULL,
    FOREIGN KEY (UsuarioID) REFERENCES Usuario(UsuarioID)
);

-- Tabla para autenticación de doble factor
CREATE TABLE AutenticacionDobleFactor (
    AutenticacionID INT PRIMARY KEY IDENTITY(1,1),
    UsuarioID INT NOT NULL,
    Codigo NVARCHAR(10) NOT NULL,
    FechaGeneracion DATETIME NOT NULL DEFAULT GETDATE(),
    FechaExpiracion DATETIME NOT NULL,
    Validado BIT NOT NULL DEFAULT 0,
    Metodo NVARCHAR(50) NOT NULL, -- 'SMS', 'Email', 'App'
    FOREIGN KEY (UsuarioID) REFERENCES Usuario(UsuarioID)
);

-- Tabla para almacenar sesiones del chatbot
CREATE TABLE ChatBotSesion (
    SesionID INT PRIMARY KEY IDENTITY(1,1),
    UsuarioID INT NULL,
    FechaInicio DATETIME NOT NULL DEFAULT GETDATE(),
    FechaFin DATETIME NULL,
    Activa BIT NOT NULL DEFAULT 1
);

-- Tabla para almacenar mensajes del chatbot
CREATE TABLE ChatBotMensaje (
    MensajeID INT PRIMARY KEY IDENTITY(1,1),
    UsuarioID INT NULL,
    SesionID INT NOT NULL,
    FechaMensaje DATETIME NOT NULL DEFAULT GETDATE(),
    TipoMensaje NVARCHAR(50) NOT NULL, -- 'Usuario', 'Bot'
    ContenidoMensaje NVARCHAR(1000) NOT NULL,
    FOREIGN KEY (SesionID) REFERENCES ChatBotSesion(SesionID)
);


SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME IN ('Login', 'AutenticacionDobleFactor', 'ChatBotSesion', 'ChatBotMensaje');
