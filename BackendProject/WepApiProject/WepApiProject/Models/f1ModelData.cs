namespace WepApiProject.Models;

public class Rootobject
{
    public Mrdata MRData { get; set; }
}

public class Mrdata
{
    public string? Xmlns { get; set; }
    public string? Series { get; set; }
    public string? Url { get; set; }
    public string? Limit { get; set; }
    public string? Offset { get; set; }
    public string? Total { get; set; }
    public Standingstable StandingsTable { get; set; }
}

public class Standingstable
{
    public string? Season { get; set; }
    public Standingslist[] StandingsLists { get; set; }
}

public class Standingslist
{
    public string? Season { get; set; }
    public string? Round { get; set; }
    public Driverstanding[] DriverStandings { get; set; }
}

public class Driverstanding
{
    public string? position { get; set; }
    public string? positionText { get; set; }
    public string? points { get; set; }
    public string? wins { get; set; }
    public Driver Driver { get; set; }
    public Constructor[] Constructors { get; set; }
}

public class Driver
{
    public string? driverId { get; set; }
    public string? url { get; set; }
    public string? givenName { get; set; }
    public string? familyName { get; set; }
    public string? dateOfBirth { get; set; }
    public string? nationality { get; set; }
}

public class Constructor
{
    public string? constructorId { get; set; }
    public string? url { get; set; }
    public string? name { get; set; }
    public string? nationality { get; set; }
}
