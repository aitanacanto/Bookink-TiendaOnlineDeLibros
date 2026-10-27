-- LibroExpress: esquema original de la práctica. Ejecutar sobre una base nueva y vacía.
create table [dbo].[USUARIO]
(	
    [id] INT IDENTITY (1, 1) NOT NULL,
    [nombre] VARCHAR(255) NOT NULL,
    [apellidos] VARCHAR(255) NOT NULL,
    [contrasenya] VARCHAR(255) NOT NULL,
    [dni] NVARCHAR(20) NOT NULL,
    [email] NVARCHAR(100) NOT NULL UNIQUE,
    [telefono] NVARCHAR(20) NOT NULL,
    [puntos] INT NOT NULL,
    [admin] BIT NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
)
GO
create table [dbo].[PRODUCTO]
(	
    [id] INT IDENTITY (1, 1) NOT NULL,
    [cod_oferta] NVARCHAR(50) NULL,
    [img_producto] NVARCHAR(255) NOT NULL,
    [nombre] NVARCHAR(100) NOT NULL,
    [sinopsis] NVARCHAR(2500) NOT NULL,
    [autor] NVARCHAR(50) NOT NULL,
    [editorial] NVARCHAR(70) NOT NULL,
    [precio] DECIMAL(10, 2) NOT NULL,
    [cant_stock] INT NOT NULL,
    [precio_oferta] DECIMAL(10, 2),
    [anyo_publicacion] INT,
    [num_pag] INT,
    [popularidad] INT,
    PRIMARY KEY CLUSTERED ([id] ASC)
)
GO
create table [dbo].[CARRITO]
(	
    [id] INT IDENTITY (1, 1) NOT NULL,
    [id_usuario] INT NOT NULL,
    [pvp_total] DECIMAL (7, 2) DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [fk_CARRITO_USUARIO] FOREIGN KEY ([id_usuario]) REFERENCES [dbo].[Usuario] ([id]) ON DELETE CASCADE
)
GO
create table [dbo].[LINCARRITO]
(	
    [id_carrito] INT NOT NULL,
    [id_producto] INT NOT NULL,
    [cantidad] INT DEFAULT ((1)) NOT NULL,
    [pvp] DECIMAL (7, 2) NOT NULL,
    PRIMARY KEY (id_carrito, id_producto),
    CONSTRAINT [fk_LINCARRITO_PRODUCTO] FOREIGN KEY ([id_producto]) REFERENCES [dbo].[PRODUCTO] ([id]),
    CONSTRAINT [fk_LINCARRITO_CARRITO] FOREIGN KEY ([id_carrito]) REFERENCES [dbo].[CARRITO] ([id]) ON DELETE CASCADE
)
GO
create table [dbo].[PEDIDO]
(	
    [numped] INT IDENTITY (1, 1),
    [id_usuario] INT NOT NULL,
    [cod_carrito] INT NOT NULL,
    [dirección_envío] NVARCHAR(255) NOT NULL,
    [precio] DECIMAL(10, 2) NOT NULL,
    [estado] NVARCHAR(50) NOT NULL,
    PRIMARY KEY CLUSTERED (numped),
    [fecha] DATE NOT NULL,
    FOREIGN KEY (id_usuario) REFERENCES USUARIO(id),
    FOREIGN KEY (cod_carrito) REFERENCES CARRITO(id)
)
GO
create table [dbo].[LINPEDIDO]
(	
    [id_pedido] INT NOT NULL,
    [id_producto] INT,
    [cantidad] INT NOT NULL,
    PRIMARY KEY (id_pedido, id_producto),
    FOREIGN KEY (id_pedido) REFERENCES PEDIDO(numped),
    FOREIGN KEY (id_producto) REFERENCES PRODUCTO(id)
)
GO
create table [dbo].[DIRECCION]
(	
    [id] INT IDENTITY (1, 1),
    [cod_postal] NVARCHAR(10) NOT NULL,
    [dirección] NVARCHAR(255) NOT NULL,
    [ciudad] NVARCHAR(30) NOT NULL,
    [pais] NVARCHAR(30) NOT NULL
    PRIMARY KEY (id),
)
GO
create table [dbo].[TIENE_DIRECCION]
(	
    [id_usuario] INT,
    [id_direccion] INT,
    PRIMARY KEY (id_usuario, id_direccion),
    FOREIGN KEY (id_usuario) REFERENCES USUARIO(id) ON DELETE CASCADE,
    FOREIGN KEY (id_direccion) REFERENCES DIRECCION(id)
)
GO
create table [dbo].[RESENA]
(	
    [id_usuario] INT NOT NULL,
    [id_producto] INT NOT NULL,
    [comentario] NVARCHAR(max) NOT NULL,
    [fecha] DATE NOT NULL,
    [valoracion] DECIMAL(3, 2) NOT NULL,
    FOREIGN KEY (id_usuario) REFERENCES USUARIO(id),
    FOREIGN KEY (id_producto) REFERENCES PRODUCTO(id) ON DELETE CASCADE,
    PRIMARY KEY (id_usuario,id_producto)
)
GO
create table [dbo].[PAQUETE]
(	
    [id] INT IDENTITY (1, 1) NOT NULL,
    [nombre] NVARCHAR(100) NOT NULL,
    [precio] DECIMAL(10, 2) NOT NULL,
    [img_paquete] NVARCHAR(255) NOT NULL,
    [descripcion] NVARCHAR(500) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
)
GO
create table [dbo].[TIENE_PAQUETE]
(	
    [id_paquete] INT,
    [id_producto] INT,
    PRIMARY KEY (id_paquete, id_producto),
    FOREIGN KEY (id_paquete) REFERENCES PAQUETE(id),
    FOREIGN KEY (id_producto) REFERENCES PRODUCTO(id) ON DELETE CASCADE
)
GO
create table [dbo].[LINPEDIDO_PA]
(	
    [id_paquete] INT,
    [id_pedido] INT,
    PRIMARY KEY (id_paquete, id_pedido),
    FOREIGN KEY (id_paquete) REFERENCES PAQUETE(id),
    FOREIGN KEY (id_pedido) REFERENCES PEDIDO(numped)  
)
GO

CREATE TABLE [dbo].[CATEGORIA]
(
    [id] INT IDENTITY (1, 1) NOT NULL,
    [nombre] NVARCHAR(100) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
)
GO

-- Create/modify the TIENE_CATEGORIA table
CREATE TABLE [dbo].[TIENE_CATEGORIA]
(
    [id_categoria] INT,
    [id_producto] INT,
    PRIMARY KEY (id_categoria, id_producto),
    CONSTRAINT [fk_TIENE_CATEGORIA_CATEGORIA] FOREIGN KEY ([id_categoria]) REFERENCES CATEGORIA([id]) ON DELETE CASCADE,
    CONSTRAINT [fk_TIENE_CATEGORIA_PRODUCTO] FOREIGN KEY ([id_producto]) REFERENCES PRODUCTO([id]) ON DELETE CASCADE
)
GO

---------------------------------------------------------------------------------------------------
-- PRODUCTOS
