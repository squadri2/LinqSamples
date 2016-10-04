<Query Kind="Expression">
  <Connection>
    <ID>d82ec0cc-32ba-4d15-8e17-23e3abf87035</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

from food in Items 
	group food by new {food.MenuCategory.Description} into tempdataset
	
	select new {
				MenuCategoryDescription = tempdataset.Key.Description,
				
				Fooditems = from x in tempdataset 
						select new {
									ItemID = x.ItemID,
									FoodDescription = x.Description,
									CurrentPrice = x.CurrentPrice,
									TimeServed = x.BillItems.Count()
						}
	}
	
	
from food in Items
 orderby food.MenuCategory.Description
 	select new{
				MenuCategoryDescription = food.MenuCategory.Description,
				ItemID - food.ItemID,
				FoodDescription = x.Description,
				CurrentPrice = x.CurrentPrice,
				TimeServed = x.BillItems.Count()
	}
				