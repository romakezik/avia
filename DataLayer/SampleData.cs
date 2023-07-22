using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public static class SampleData
    {
        public static void InitData(EFDBContext context)
        {
            if (!context.Airlines.Any())
            {
                context.Airlines.Add(new Airlines
                {
                    AirlinesID = 1,
                    Name = "Avia1",
                    IATACode = "1111"
                });
                context.Airlines.Add(new Airlines
                {
                    AirlinesID = 2,
                    Name = "Avia2",
                    IATACode = "2222"
                });
                context.Airlines.Add(new Airlines
                {
                    AirlinesID = 3,
                    Name = "Avia3",
                    IATACode = "3333"
                });



                context.Destinations.Add(new Destinations
                {
                    DestinationsID = 1,
                    CityName = "Minsk",
                    IATACode = "Minsk"
                }); 
                context.Destinations.Add(new Destinations
                {
                    DestinationsID = 2,
                    CityName = "Moscow",
                    IATACode = "Moscow"
                });
                context.Destinations.Add(new Destinations
                {
                    DestinationsID = 3,
                    CityName = "China",
                    IATACode = "China"
                });
                context.Destinations.Add(new Destinations
                {
                    DestinationsID = 4,
                    CityName = "Japan",
                    IATACode = "Japan"
                });
                context.Destinations.Add(new Destinations
                {
                    DestinationsID = 5,
                    CityName = "USA",
                    IATACode = "USA"
                });



                context.Flights.Add(new Flights
                {
                    FlightsID = 1,
                    AirlineID = 1,
                    FlightNumber = "123",
                    DepartureDate = new DateTime(2023, 5, 1, 8, 30, 52),
                    DepartureCityID = 1,
                    ArrivalCityID = 2
                });
                context.Flights.Add(new Flights
                {
                    FlightsID = 2,
                    AirlineID = 2,
                    FlightNumber = "322",
                    DepartureDate = new DateTime(2023, 6, 2, 7, 20, 2),
                    DepartureCityID = 4,
                    ArrivalCityID = 2
                });
                context.Flights.Add(new Flights
                {
                    FlightsID = 3,
                    AirlineID = 3,
                    FlightNumber = "32-21213372",
                    DepartureDate = new DateTime(2023, 5, 4, 3, 20, 10),
                    DepartureCityID = 3,
                    ArrivalCityID = 5
                });




                context.Tickets.Add(new Tickets
                {
                    TicketsID = 1,
                    FlightID = 1,
                    Price = 1000,
                    Status = "Available"
                });
                context.Tickets.Add(new Tickets
                {
                    TicketsID = 2,
                    FlightID = 2,
                    Price = 1030,
                    Status = "Available"
                });
                context.Tickets.Add(new Tickets
                {
                    TicketsID = 3,
                    FlightID = 2,
                    Price = 1020,
                    Status = "Available"
                });

                context.Tickets.Add(new Tickets
                {
                    TicketsID = 4,
                    FlightID = 2,
                    Price = 1001,
                    Status = "Available"
                });
                context.Tickets.Add(new Tickets
                {
                    TicketsID = 5,
                    FlightID = 3,
                    Price = 10002,
                    Status = "Available"
                });
                context.Tickets.Add(new Tickets
                {
                    TicketsID = 6,
                    FlightID = 3,
                    Price = 10222,
                    Status = "Available"
                });

                context.Tickets.Add(new Tickets
                {
                    TicketsID = 7,
                    FlightID = 3,
                    Price = 10003,
                    Status = "Available"
                });
                context.Tickets.Add(new Tickets
                {
                    TicketsID = 8,
                    FlightID = 3,
                    Price = 10004,
                    Status = "Available"
                });
                context.Tickets.Add(new Tickets
                {
                    TicketsID = 9,
                    FlightID = 1,
                    Price = 900,
                    Status = "Available"
                });


                context.SaveChanges();

            }
        }
    }
}
