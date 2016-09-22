<Query Kind="Expression">
  <Connection>
    <ID>5d527546-85fd-4693-bc44-f7cb8c09d22b</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

//multiple column group
//grouping data placed in a local temp data set for further processing
//.Key allows you to have access to value(s) in you r group key(s)
//If you have multiple group colums they Must be in an anonymous datatype
//to create a DTO type collection you can use .ToList() on the temp data set
// you can have a custom anonymous data collection by using a nested query 


//Step A

from food in Items
	group food by new {food.MenuCategoryID, food.CurrentPrice} 
	
//Step B DTO looking dataset
from food in Items
	group food by new {food.MenuCategoryID, food.CurrentPrice} into tempdataset
	
	
	select new{
				MenuCategoryID = tempdataset.Key.MenuCategoryID,
				CurrentPrice = tempdataset.Key.CurrentPrice,
				FoodItems = tempdataset.ToList()
	}



//step C DTO custom style dataset
from food in Items
	group food by new {food.MenuCategoryID, food.CurrentPrice} into tempdataset
	
	
	select new{
				MenuCategoryID = tempdataset.Key.MenuCategoryID,
				CurrentPrice = tempdataset.Key.CurrentPrice,
				FoodItems = from x in tempdataset
						select new {
								 ItemID = x.ItemID,
								 FoodDescription = x.Description,
								 TimesServed = x.BillItems.Count()
						}
	}