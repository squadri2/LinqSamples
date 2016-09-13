<Query Kind="Expression">
  <Connection>
    <ID>b817c69a-976b-46f9-9d8b-03045d06bc21</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>



from x in Items
where x.CurrentPrice > 5
select new {
		x.Description,
		x.Calories
}