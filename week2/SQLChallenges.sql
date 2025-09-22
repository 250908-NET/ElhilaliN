-- SETUP:
    -- Create a database server (docker)
        -- docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=<password>" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest
    -- Connect to the server (Azure Data Studio / Database extension)
    -- Test your connection with a simple query (like a select)
    -- Execute the Chinook database (to create Chinook resources in your db)

    

-- On the Chinook DB, practice writing queries with the following exercises

-- BASIC CHALLENGES
-- List all customers (full name, customer id, and country) who are not in the USA
SELECT customerId,FirstName,lastName, Country  FROM Customer WHERE Country <> 'USA';

-- List all customers from Brazil
SELECT customerId,FirstName,lastName, Country  FROM Customer WHERE Country = 'Brazil';

-- List all sales agents

-- Retrieve a list of all countries in billing addresses on invoices
SELECT BillingCountry FROM Invoice;

-- Retrieve how many invoices there were in 2009, and what was the sales total for that year?
SELECT SUM(Total) FROM Invoice WHERE Year(InvoiceDate) = '2009';


    -- (challenge: find the invoice count sales total for every year using one query)

-- how many line items were there for invoice #37
 SELECT Count("Quantity") As LineItems FROM "InvoiceLine" Where "InvoiceId" = 37;

-- how many invoices per country? BillingCountry  # of invoices -
 SELECT COUNT(InvoiceId) as NumberOfInvoices, "BillingCountry"
  FROM Invoice GROUP BY "BillingCountry";

-- Retrieve the total sales per country, ordered by the highest total sales first.
 SELECT "Total", "BillingCountry"
  FROM Invoice 
  GROUP BY "BillingCountry", "Total"
  ORDER BY Total DESC

-- JOINS CHALLENGES
-- Every Album by Artist
SELECT a.Title  AS Album , ar.Name AS Artist
From Album a
INNer JOIN "Artist" ar On a.ArtistId = ar.ArtistId;
-- All songs of the rock genre
SELECT t.Name as Song, g.Name as Genre
FROM Track t
INNER JOIN Genre g On t.GenreId = g.GenreId;
-- Show all invoices of customers from brazil (mailing address not billing)
SELECT I.*, C.FirstName, C.lastName
FROM Invoice I
Inner Join Customer C On I."CustomerId" = C."CustomerId"
                      AND C."Country" = 'Brazil';
-- Show all invoices together with the name of the sales agent for each one
SELECT I.*, C."FirstName", C."LastName" , S."FirstName" as SalesFirstname, S."LastName" as SalesLastName
From Invoice  I 
INNER JOIN "Customer" C On I."CustomerId"= C."CustomerId" 
INNER JOIN "Employee" S On C."SupportRepId" = S."EmployeeId";
-- Which sales agent made the most sales in 2009?
SELECT TOP 1 
    S.FirstName, 
    S.LastName, 
    SUM(I.Total) AS TotalSales
FROM Invoice I
INNER JOIN Customer C ON I.CustomerId = C.CustomerId
INNER JOIN Employee S ON C.SupportRepId = S.EmployeeId
WHERE YEAR(I.InvoiceDate) = 2009
GROUP BY S.FirstName, S.LastName
ORDER BY TotalSales DESC;

-- How many customers are assigned to each sales agent?
SELECT S.FirstName, S.LastName, Count(C."CustomerId") as NumCustomers
From  Customer C
LEFT Join "Employee" S On C."SupportRepId" = S."EmployeeId"
Group By S."FirstName", S."LastName"
ORDER BY NumCustomers DESC;

-- Which track was purchased the most ing 20010?
SELECT TOP 1 
    t.Name AS TrackName, 
    COUNT(il.TrackId) AS PurchaseCount
FROM InvoiceLine il
INNER JOIN Invoice i ON il.InvoiceId = i.InvoiceId
INNER JOIN Track t ON il.TrackId = t.TrackId
WHERE YEAR(i.InvoiceDate) = 2010
GROUP BY t.Name
ORDER BY PurchaseCount DESC;
 
-- Show the top three best selling artists.
SELECT TOP 3
    a.Name AS ArtistName, 
    SUM(il.UnitPrice * il.Quantity) AS TotalSales
FROM InvoiceLine il
INNER JOIN Invoice i ON il.InvoiceId = i.InvoiceId
INNER JOIN Track t ON il.TrackId = t.TrackId
INNER JOIN Album al On t."AlbumId" = al."AlbumId"
Inner Join "Artist" a On a."ArtistId" = al."ArtistId"
GROUP BY a.name
ORDER BY TotalSales DESC;

-- Which customers have the same initials as at least one other customer?
SELECT DISTINCT c1.CustomerId, c1.FirstName, c1.LastName
FROM Customer c1
INNER JOIN Customer c2
    ON LEFT(c1.FirstName, 1) = LEFT(c2.FirstName, 1)
    AND LEFT(c1.LastName, 1) = LEFT(c2.LastName, 1)
    AND c1.CustomerId <> c2.CustomerId
    ORDER BY c1.FirstName, c1.LastName;
;



-- ADVACED CHALLENGES
-- solve these with a mixture of joins, subqueries, CTE, and set operators.
-- solve at least one of them in two different ways, and see if the execution
-- plan for them is the same, or different.

-- 1. which artists did not make any albums at all?

-- 2. which artists did not record any tracks of the Latin genre?

-- 3. which video track has the longest length? (use media type table)

-- 4. find the names of the customers who live in the same city as the
--    boss employee (the one who reports to nobody)

-- 5. how many audio tracks were bought by German customers, and what was
--    the total price paid for them?

-- 6. list the names and countries of the customers supported by an employee
--    who was hired younger than 35.


-- DML exercises

-- 1. insert two new records into the employee table.

-- 2. insert two new records into the tracks table.

-- 3. update customer Aaron Mitchell's name to Robert Walter

-- 4. delete one of the employees you inserted.

-- 5. delete customer Robert Walter.
