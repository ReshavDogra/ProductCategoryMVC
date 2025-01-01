# ProductCategoryMVC

Created this project using ASP.NET MVC with entity framework code first approach

The project has 
1. Category Master with CRUD operations 
2. Product Master with CRUD operations. A product belongs to a category.
3. Product list is displayed with following Columns :
   ProductId ProductName CategoryId CategoryName
4. The product list have pagination on the server side, which means extract records from DB are on page as per the page size of 10 pages per view.

Framework = .NET 6.0 (Long Term Support)

Libraries :-
1. Microsoft.EntityFrameworkCore (Version 7.0)
2. Microsoft.EntityFrameworkCore.SqlServer (Version 7.0)
3. Microsoft.EntityFrameworkCore.Tools (Version 7.0)
