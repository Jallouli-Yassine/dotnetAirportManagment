// See https://aka.ms/new-console-template for more information
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.services;

Console.WriteLine("Hello, World!");
/*
Flight f1 = new Flight();
Flight f2 = new ();
Flight f3 = new Flight(1,DateTime.Now,5);
f1.Destination = "dehe";
Console.WriteLine("dest : "+f1.Destination);
*/

FlightMethodes flightMethodes = new ();

Flight f4 = new()
{
    FlightDate = DateTime.Now,
    Destination = "sfax", 
    Dparture = "dehe",

};

Console.WriteLine(f4.Destination);