--Показувати асортимент пропонованої меблів і ціну товару;

select name,
ProductType,
Price 
from Products 
where ProductType=N'Меблі для їдальні'

--Показувати кількість проданої меблів вибраного зразка за звітний період часу;
select count(ProductID) 
from Orders 
where ProductID=2 and (OrderDate between '2021-03-01' and '2025-03-20' )

--Показувати список зроблених замовлень за звітний період часу;
select count(ProductID) 
from Orders 
where DeliveryDate 
between '2021-03-01' and '2025-03-20' 

--Розраховувати вартість замовлення клієнта за індивідуальним проектом.
SELECT 
    (SELECT Name FROM Customers WHERE CustomerID = Orders.CustomerID) AS Customer_Name,
    SUM(Quantity * P.Price) AS Total
FROM 
    Orders
JOIN 
    Products P ON Orders.ProductID = P.ProductID
GROUP BY Orders.CustomerID;
