use InventoryDB;

-- Obtener la lista de precios de todos los productos
SELECT ProductId, Name, Description, Cost, Price, Stock
FROM Products;

/*
Obtener la lista de productos cuya existencia en el inventario haya llegado al m�nimo
permitido (5 unidades) 
FROM Products
1 de febrero de 2000 y el 25 de mayo de 2000
en qu� fecha podr�a volver a comprar.