<Query Kind="Statements">
  <Connection>
    <ID>478613ad-0cb1-47fb-93e3-321600e29630</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

//when you need to uuse multiple steps
//to solve a problem , switch your language
//choice to either statement(s) or Program

//the results of each query will now be saved in a variable
//the variable can then be used in  future queries

var maxcount = (from x in MediaTypes
		select x.Tracks.Count()).Max();
		
		
//to display the contents of a variable in LinqPad 
//you use the method .Dump()
maxcount.Dump();


//usea value in a preceeding create variable

var popularMediaType = from x in MediaTypes
				where x.Tracks.Count() == maxcount
				select new {
						Type = x.Name,
						TCount = x.Tracks.Count()
				};
				
popularMediaType.Dump();

//Can this set of statements be done as one complete query
//the answer is possibly, Current case : Yes.
//in this example maxcount could be exchanged for the query that 
// actually created the value in the first place
//this subsituded query in a subquery


var popularMediaTypeSubQuery = from x in MediaTypes
				where x.Tracks.Count() == (from y in MediaTypes
										select y.Tracks.Count()).Max()
				
				select new {
						Type = x.Name,
						TCount = x.Tracks.Count()
				};
				
popularMediaTypeSubQuery.Dump();


//using the method syntax to determine the count value for the where expression 
// this demonstrate that quesries can be constructed using both query syntax and method syntax 

var popularMediaTypeSubMethod = from x in MediaTypes
				where x.Tracks.Count() == MediaTypes.Select (mt => mt.Tracks.Count()).Max()
										
				
				select new {
						Type = x.Name,
						TCount = x.Tracks.Count()
				};
				
popularMediaTypeSubMethod.Dump();






