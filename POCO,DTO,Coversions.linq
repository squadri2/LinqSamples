<Query Kind="Program">
  <Connection>
    <ID>b817c69a-976b-46f9-9d8b-03045d06bc21</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

void Main()
{
	// a list of bill counts for all waiters
	//This query will create a flat dataset 
	//The colums are native data types (ie int, string,....)
	//One is not concern with a repeated data in a column 
	//Instead of using an anonymous data type (new{...})
	// we wish to use a defined class definition 

	
	var BestWaiter = from x in Waiters
				
				select new waiterBillsCounts {
				
						Name = x.FirstName + " " + x.LastName,
						TCount = x.Bills.Count()
						
						};
    BestWaiter.Dump();

	var paramMonth = 4;
	var paramYear = 2016;
	
	var WaiterBills = from x in Waiters
			where x.LastName.Contains("K")
			orderby x.LastName, x.FirstName
			select new WaiterBills {
						Name = x.LastName + ","+ x.FirstName,
						TotalBillCount = x.Bills.Count(),
						BillInfo = (from y in x.Bills
									where y.BillItems.Count () > 0
									&& y.BillDate.Month == DateTime.Today.Month - paramMonth
									&& y.BillDate.Year == paramYear
						select new BillItemSummary{
						     BillID = y.BillID,
							 BillDate = y.BillDate,
							 TableID = y.TableID,
							 Total = y.BillItems.Sum(b => b.SalePrice * b.Quantity)
						     }	
						).ToList()
			
			};
    WaiterBills.Dump();






}

// Define other methods and classes here
// An example of a POCO Class (flat)


public class  waiterBillsCounts
{

     //Whatever recieving field in your query in your select 
	 //Appears as a property in this class
	 public string Name{get;set;}
	 public int TCount{get;set;}
	 
}



public class BillItemSummary
{

		public int BillID{get;set;}
		public DateTime BillDate{get;set;}
		public int? TableID{get;set;}
		public decimal Total{get;set;}
}

//An Example of A DTO class (structured)


public class WaiterBills
{
	public string Name{get;set;}
	public int TotalBillCount{get;set;}
	public List<BillItemSummary> BillInfo{get;set;}

}