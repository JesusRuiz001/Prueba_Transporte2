CREATE DATABASE Base_Pruebas
CREATE TABLE Cliente (
    ClienteID INT PRIMARY KEY,
    Nombre varchar(100),
    Direccion varchar(200)
 
);
CREATE TABLE Producto (
    ProductoID INT PRIMARY KEY,
    Nombre varchar(100),
	Stock int,
	valorUnit float
   
);
CREATE TABLE Vehiculo (
    Placa varchar(10) PRIMARY KEY,
    TipoVehiculo varchar(20)
  
);
CREATE TABLE Bodega (
    BodegaID INT PRIMARY KEY,
    Nombre varchar(50),
    Ubicacion varchar(50)   
);
CREATE TABLE Envio (
    EnvioID INT PRIMARY KEY,    
    ClienteID INT,
	ProductoID INT,  
    Cantidad INT,
	Placa varchar(10),
	PrecioEnvio DECIMAL(10, 2),
	PrecioEnvioNeto DECIMAL(10, 2),
    FechaRegistro DATE,
    FechaEntrega DATE,    
    NumeroGuia varchar(10),
	BodegaID int
    -- Otros campos relacionados con el envío
);

ALTER TABLE Envio
ADD CONSTRAINT FK_Envio_Producto
FOREIGN KEY (ProductoID) REFERENCES Producto(ProductoID);

ALTER TABLE Envio
ADD CONSTRAINT FK_Envio_Cliente
FOREIGN KEY (ClienteID) REFERENCES Cliente(ClienteID);

ALTER TABLE Envio
ADD CONSTRAINT FK_Envio_Vehiculo
FOREIGN KEY (Placa) REFERENCES Vehiculo(Placa);

ALTER TABLE Envio
ADD CONSTRAINT FK_Envio_Bodega
FOREIGN KEY (BodegaID) REFERENCES Bodega(BodegaID);

