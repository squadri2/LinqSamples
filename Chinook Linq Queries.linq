<Query Kind="Expression">
  <Connection>
    <ID>af151016-89d1-4817-b7da-9c4c2030909e</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

from x in Customers
where x.SupportRepIdEmployee.FirstName.Equals("Jane") &&
x.SupportRepIdEmployee.LastName.Equals("Peacock") 
select new {
		Name = x.LastName + "," + x.FirstName,
		City = x.City,
		state = x.State,
		Phone = x.Phone ,
		Email = x.Email
}


from x in Albums
orderby x.Title 
where x.Tracks.Count() > 0
select new
{
     Title = x.Title,
	 Price= x.Tracks.Sum(y => y.UnitPrice),
     NumberOfAlbumTracks= x.Tracks.Count(),
	 AverageLengthOfAlbuminSecondsA = (x.Tracks.Average(y => y.Milliseconds))/1000,
	  AverageLengthOfAlbuminSecondsB = x.Tracks.Average(y => y.Milliseconds/1000)
}


from x in MediaTypes
select new
{
     MediaType = x.Name,
	 MediaWithMaxTrack= x.Tracks.Max(y => y.TrackId)
}





