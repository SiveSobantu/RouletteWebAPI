USE [NORTHWND]
GO

/****** Object:  StoredProcedure [dbo].[CustOrdersDetail]    Script Date: 19/03/2022 23:39:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
----------------------------------
--Author :Sive Sobantu
--Created Date:
--Description: to return a summary of orders 
----------------------------------
--========================================================test scenarios

--exec pr_GetOrderSummary @StartDate='1 Jan 1996', @EndDate='31 Aug 1996', @EmployeeID=NULL , @CustomerID=NULL

--exec pr_GetOrderSummary @StartDate='1 Jan 1996', @EndDate='31 Aug 1996', @EmployeeID=5 , @CustomerID=NULL

--exec pr_GetOrderSummary @StartDate='1 Jan 1996', @EndDate='31 Aug 1996', @EmployeeID=NULL , @CustomerID='VINET'

--exec pr_GetOrderSummary @StartDate='1 Jan 1996', @EndDate='31 Aug 1996', @EmployeeID=5 , @CustomerID='VINET'

--==========================================================

ALTER PROCEDURE pr_GetOrderSummary

@StartDate  DATETIME = NULL,
@EndDate DATETIME = NULL,
@EmployeeID INT = NULL,
@CustomerID NCHAR(5) = NULL 

AS

SELECT											
                                               
											  
											    CONCAT(e.TitleOfCourtesy,' ', e.FirstName,' ',e.LastName)    AS  EmployeeFullName 
                                               ,s.CompanyName                                                AS [Shipper CompanyName]
                                               ,c.CompanyName                                                AS [Customer CompanyName]
                                               ,SUM(od.Quantity)                                             AS  NumberOfOders                                                                                        
                                               ,o.OrderDate                                                  AS  [Date]	                                             
                                               ,SUM(Freight)	                                             AS  TotalFreightCost                                                                                        
                                               ,COUNT(p.QuantityPerUnit)                                     AS  NumberOfDifferentProducts
                                               ,SUM(od.Quantity)                                             AS  TotalOrderValue 
                                            

FROM											[NORTHWND].[dbo].[Orders] o

LEFT JOIN                                      [dbo].[Shippers] s on o.ShipVia = s.ShipperID

INNER JOIN						               [dbo].[Employees] e on o.EmployeeID = e.EmployeeID

INNER JOIN						               [dbo].[Customers] c on o.CustomerID = c.CustomerID

LEFT JOIN						               [dbo].[Order Details] od on o.OrderID = od.OrderID

LEFT JOIN						               [dbo].[Products] p on od.ProductID = p.ProductID

WHERE                                         
											  ((o.OrderDate BETWEEN @StartDate AND @EndDate) OR (@StartDate IS NULL AND @EndDate IS NULL))

AND                                           (o.EmployeeID = @EmployeeID OR  @EmployeeID IS NULL)

AND                                           (o.CustomerID = @CustomerID OR  @CustomerID IS NULL)

GROUP BY o.OrderDate , CONCAT(e.TitleOfCourtesy,' ', e.FirstName,' ',e.LastName), c.CompanyName,s.CompanyName


GO


