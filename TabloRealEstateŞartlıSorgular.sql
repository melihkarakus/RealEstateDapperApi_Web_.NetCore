--select count(*) from Product where Title like '%Yazl�k%'
--select count(*) from Product where type = 'Sat�l�k'
--select avg(price) from Product where type = 'Sat�l�k'
--select avg(price) from Product where type = 'Kiral�k'
--select avg(RoomCount) from ProductDetails
--select count(*) from Category
--select Top(1) CategoryName,Count(*) from Product inner join Category on Product.ProductCategory=Category.CategoryID Group by CategoryName order by Count(*) desc
--select top(1) City,Count(*) as 'ilanSay�s�' from Product Group by City order by ilanSay�s� desc
--select count(distinct(City)) from Product 
--select Name,Count(*) 'productcount' from Product Inner join Employee on Product.EmployeeID = Employee.EmployeeID Group by Name order by productcount desc
--select top(1) Price from Product order by  ProductID desc 
--select top(1) BuildYear from ProductDetails order by  BuildYear desc  
--select top(1) BuildYear from ProductDetails order by  BuildYear asc 
--select count(*) from Product 



