DROP DATABASE IF EXISTS AdaUserManagement;
CREATE DATABASE AdaUserManagement;

USE AdaUserManagement;

INSERT INTO Products
    (Id, Name, Stock, Description, Price, imageUrl)
VALUES
    (NEWID(), 'Teclado Mecánico Rojo', 50, 'Teclado con RGBA para uso diario', 100000, 'https://imgs.search.brave.com/IMYVAKLda-fxpp5EdsK1Yv7PI8xqtvLLODr1cTRTNPQ/rs:fit:500:0:0/g:ce/aHR0cHM6Ly9tLm1l/ZGlhLWFtYXpvbi5j/b20vaW1hZ2VzL0kv/NDFSOFJxeFJsNEwu/anBn'),
    (NEWID(), 'Mouse inalambrico', 90, 'Mouse importado', 20000, 'https://imgs.search.brave.com/ZNusXP3kFkfkwyX4Nm2XdzVtWyuiTu43-tuR59ddPGo/rs:fit:500:0:0/g:ce/aHR0cHM6Ly9pLmJs/b2dzLmVzLzU2Yzkw/OS9sb2dpdGVjaC1t/b3VzZS9vcmlnaW5h/bC5qcGVn'),
    (NEWID(), 'Tablet nueva', 10, 'Tablet unicas en su marca', 1000000, 'https://imgs.search.brave.com/jzLkvJoYOKrxe2YIuKlPddeszdZ2oVmeVFnCSa3Q2Ng/rs:fit:500:0:0/g:ce/aHR0cHM6Ly9odHRw/Mi5tbHN0YXRpYy5j/b20vRF9OUF82MDE5/MjUtTUxWMjk1Nzg1/OTA0MTFfMDMyMDE5/LVEuanBn'),
    (NEWID(), 'iPhone 15', 5, 'El último iPhone 15 exclusivo', 1000000, 'https://imgs.search.brave.com/rRc70_EO3rIKGC94Nn3K4tGR4MN8i1Ji9XlGr1uKN0w/rs:fit:860:0:0/g:ce/aHR0cHM6Ly9mZG4y/LmdzbWFyZW5hLmNv/bS92di9waWNzL2Fw/cGxlL2FwcGxlLWlw/aG9uZS0xNS1wcm8t/bWF4LTEuanBn');


INSERT INTO UserProductDetails
    (productId, userId, UnitPrice, QuantitySold, Total)
VALUES('a2a6f630-1539-4425-8184-3f289ba322a4', '36f6e434-f6eb-47e1-4665-08dbcb82d29b', 500000, 2, 1000000)

