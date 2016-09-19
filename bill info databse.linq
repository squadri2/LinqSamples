<Query Kind="Statements">
  <Connection>
    <ID>b817c69a-976b-46f9-9d8b-03045d06bc21</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

var maxBills = (from x in Waiters
		select x.Bills.Count()).Max();
		


var BestWaiter = from x in Waiters
				//where x.Bills.Count ( ) == maxBills
				select new {
						Name = x.FirstName + " " + x.LastName,
						tbills = x.Bills.Count()};
BestWaiter.Dump();

//create a Dataset which contains the summary bill info  by waiter
var WaiterBills = from x in Waiters
			orderby x.LastName, x.FirstName
			select new {
						Name = x.LastName + ","+ x.FirstName,
						BillInfo = (from y in x.Bills
									where y.BillItems.Count () > 0
						select new {
						     BillID = y.BillID,
							 BillDate = y.BillDate,
							 TableID = y.TableID,
							 Total = y.BillItems.Sum(b => b.SalePrice * b.Quantity)
						     }	
						)
			
			};
WaiterBills.Dump();
