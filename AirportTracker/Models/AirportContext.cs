using AirportTracker.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace AirportTracker.Models
{
    public class AirportContext : IdentityDbContext<User>
    {
        public AirportContext(DbContextOptions<AirportContext> options) : base(options) { }

        public DbSet<Airport> Airports { get; set; } = null!;
        public DbSet<Employee> Employees { get; set; } = null;
        public DbSet<Aircraft> Aircrafts { get; set; } = null!;
        public DbSet<Terminal> Terminals { get; set; } = null!;
        public DbSet<Booking> Bookings { get; set; } = null!;
        public DbSet<Flight> Flights { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Airport>().HasData(
                    new Airport { AirportId = 1000, State = "California", City = "Los Angeles", Name = "Los Angeles International Airport", Shorthand = "LAX", VideoURL = "https://www.youtube.com/embed/yyVLqUCqWAw", FileName = "LAX.png", Description= "Los Angeles International Airport (LAX) is one of the busiest and most iconic airports in the world, serving as a major gateway to the United States and a hub for international travel. Located in Westchester, just 18 miles from downtown Los Angeles, it connects travelers to over 180 destinations worldwide. Known for its iconic Theme Building and futuristic design, LAX embodies the dynamic energy of Los Angeles. The airport is home to nine passenger terminals, including the state-of-the-art Tom Bradley International Terminal, which accommodates millions of passengers annually. With world-class dining, shopping, and efficient transit options, LAX offers a premier travel experience while reflecting the cultural diversity of Southern California." },
                    new Airport { AirportId = 1001, State = "Washington", City = "Seattle", Name = "Seattle International Airport", Shorthand = "SEA", VideoURL = "https://www.youtube.com/embed/9f9GJ-xSS3A", FileName = "SEA.png", Description = "Seattle-Tacoma International Airport (SEA), commonly known as Sea-Tac, is the primary airport serving the Seattle metropolitan area and the Pacific Northwest. Located about 14 miles south of downtown Seattle, it is a major hub for domestic and international travel, particularly to Asia and Alaska. Known for its stunning views of Mount Rainier and Puget Sound, the airport features modern amenities, including a wide range of dining and shopping options. Sea-Tac’s focus on sustainability is evident through initiatives like renewable energy use and eco-friendly terminal designs. With efficient public transit connections, such as the Link Light Rail, it offers convenient access for travelers while showcasing the region’s commitment to innovation and natural beauty." },
                    new Airport { AirportId = 1002, State = "Nebraska", City = "Lincoln", Name = "Lincoln Airport", Shorthand = "LNK", VideoURL = "https://www.youtube.com/embed/3w7EiX92W_E", FileName = "LNK.png", Description = "Lincoln Airport (LNK) is a regional airport located in Lincoln, Nebraska, serving as a vital gateway to the city and surrounding areas. Situated about five miles northwest of downtown Lincoln, it provides convenient access for both business and leisure travelers. The airport offers a selection of domestic flights, with connections to major hubs, making it easy to reach destinations across the country. Known for its friendly atmosphere and efficient operations, Lincoln Airport ensures a smooth travel experience without the congestion of larger airports. With its modern facilities and focus on customer service, LNK is a valuable resource for the growing Lincoln community." },
                    new Airport { AirportId = 1003, State = "Nebraska", City = "Omaha", Name = "Eppley Airfield", Shorthand = "OMA", VideoURL = "https://www.youtube.com/embed/lHIJl2K4AW4", FileName = "OMA.png", Description = "Eppley Airfield (OMA) is the largest airport in Nebraska, located just three miles northeast of downtown Omaha. As a key transportation hub for the region, it offers a range of domestic flights with connections to major cities across the United States. Known for its efficient layout and welcoming atmosphere, the airport provides a stress-free travel experience for passengers. Eppley Airfield features modern amenities, including dining and shopping options, and is equipped with services to accommodate both business and leisure travelers. Its central location and commitment to customer satisfaction make it an essential gateway to Omaha and the surrounding Midwest." },
                    new Airport { AirportId = 1004, State = "New York", City = "New York City", Name = "John F. Kennedy International Airport", Shorthand = "JFK", VideoURL = "https://www.youtube.com/embed/VeYVasEaBC0", FileName = "JFK.png", Description = "John F. Kennedy International Airport (JFK) is one of the busiest and most iconic airports in the world, located in Queens, New York City. Serving as a major international gateway to the United States, it offers flights to destinations across six continents. JFK features six passenger terminals, each equipped with world-class amenities, including renowned dining and shopping options that reflect the city’s diverse culture. Known for its historical significance and modern advancements, the airport is a hub for major airlines and a center for global travel. With its extensive transportation links, including the AirTrain and subway, JFK provides seamless connectivity to New York City and beyond." },
                    new Airport { AirportId = 1005, State = "New Jersey", City = "Newark", Name = "Newark Liberty International Airport", Shorthand = "EWR", VideoURL = "https://www.youtube.com/embed/nGkNDVtRMDM", FileName = "EWR.png", Description = "Newark Liberty International Airport (EWR) is a major airport serving the New York metropolitan area, located in Newark, New Jersey, just 16 miles southwest of Manhattan. Known for being one of the busiest airports in the United States, it offers a wide range of domestic and international flights, connecting travelers to destinations around the globe. The airport features three terminals with modern amenities, including dining, shopping, and lounges to enhance the passenger experience. As a hub for United Airlines, EWR plays a significant role in global aviation while providing easy access to New York City via NJ Transit and the AirTrain. Its combination of convenience, efficiency, and history makes it a vital gateway to the Northeast." },
                    new Airport { AirportId = 1006, State = "Florida", City = "Miami", Name = "Miami International Airport", Shorthand = "MIA", VideoURL = "https://www.youtube.com/embed/gnxvQ7atPMk", FileName = "MIA.png", Description = "Miami International Airport (MIA) is a major international gateway located just 8 miles west of downtown Miami, Florida. Serving as a key hub for travel between the United States, Latin America, and the Caribbean, it is one of the busiest airports in the world for international passenger traffic. MIA features a wide array of amenities, including luxury shopping, dining, and art installations that highlight the city’s vibrant culture. The airport's modern terminals handle millions of passengers annually, offering efficient services for both business and leisure travelers. With its close proximity to popular destinations like South Beach and the Florida Keys, Miami International Airport serves as an essential hub for tourism and global commerce." },
                    new Airport { AirportId = 1007, State = "Virginia", City = "Dulles", Name = "Washington Dulles International Airport", Shorthand = "IAD", VideoURL = "https://www.youtube.com/embed/4w-xPi_Dne0", FileName = "IAD.png", Description = "Washington Dulles International Airport (IAD) is a major international airport located 26 miles west of downtown Washington, D.C., in Virginia. Serving as a key hub for international and domestic travel, it offers connections to over 125 destinations across the globe. Known for its striking design by architect Eero Saarinen, including the iconic terminal building, Dulles features modern facilities and amenities for a seamless travel experience. The airport is a primary hub for United Airlines and handles millions of passengers annually, with services including dining, shopping, and lounges. With its convenient transportation options, including the Silver Line Metro connection, IAD offers easy access to the capital and beyond." }
            );

            modelBuilder.Entity<Terminal>().HasData(
                    new Terminal { TerminalId = 1, TerminalName = "B12", AirportId = 1003 },
                    new Terminal { TerminalId = 2, TerminalName = "B12", AirportId = 1002 },
                    new Terminal { TerminalId = 3, TerminalName = "B13", AirportId = 1003 },
                    new Terminal { TerminalId = 4, TerminalName = "B15", AirportId = 1003 },
                    new Terminal { TerminalId = 5, TerminalName = "A12", AirportId = 1002 },
                    new Terminal { TerminalId = 6, TerminalName = "A16", AirportId = 1002 },
                    new Terminal { TerminalId = 7, TerminalName = "C13", AirportId = 1000 },
                    new Terminal { TerminalId = 8, TerminalName = "C16", AirportId = 1000 },
                    new Terminal { TerminalId = 9, TerminalName = "C21", AirportId = 1000 },
                    new Terminal { TerminalId = 10, TerminalName = "D14", AirportId = 1001 },
                    new Terminal { TerminalId = 11, TerminalName = "D16", AirportId = 1001 },
                    new Terminal { TerminalId = 12, TerminalName = "D22", AirportId = 1000 },
                    new Terminal { TerminalId = 13, TerminalName = "E10", AirportId = 1004 },
                    new Terminal { TerminalId = 14, TerminalName = "E11", AirportId = 1004 },
                    new Terminal { TerminalId = 15, TerminalName = "E15", AirportId = 1004 },
                    new Terminal { TerminalId = 16, TerminalName = "F24", AirportId = 1005 },
                    new Terminal { TerminalId = 17, TerminalName = "F14", AirportId = 1005 },
                    new Terminal { TerminalId = 18, TerminalName = "F09", AirportId = 1005 },
                    new Terminal { TerminalId = 19, TerminalName = "G23", AirportId = 1006 },
                    new Terminal { TerminalId = 20, TerminalName = "G17", AirportId = 1006 },
                    new Terminal { TerminalId = 21, TerminalName = "G19", AirportId = 1006 }
                );

            modelBuilder.Entity<Aircraft>().HasData(
                    new Aircraft { AircraftId = 1, Name = "Boeing 737", Type = "Commercial", Capacity = 190 },
                    new Aircraft { AircraftId = 2, Name = "Airbus A320", Type = "Commercial", Capacity = 180 },
                    new Aircraft { AircraftId = 3, Name = "Bombardier CRJ900", Type = "Regional", Capacity = 90 },
                    new Aircraft { AircraftId = 4, Name = "Embraer E175", Type = "Regional", Capacity = 76 },
                    new Aircraft { AircraftId = 5, Name = "Boeing 747", Type = "Cargo", Capacity = 600 },
                    new Aircraft { AircraftId = 6, Name = "Boeing 777", Type = "Commercial", Capacity = 396 },
                    new Aircraft { AircraftId = 7, Name = "Airbus A330", Type = "Commercial", Capacity = 277 },
                    new Aircraft { AircraftId = 8, Name = "Boeing 787", Type = "Commercial", Capacity = 242 },
                    new Aircraft { AircraftId = 9, Name = "Airbus A380", Type = "Commercial", Capacity = 555 },
                    new Aircraft { AircraftId = 10, Name = "Cessna 208", Type = "Regional", Capacity = 9 },
                    new Aircraft { AircraftId = 11, Name = "Pilatus PC-12", Type = "Regional", Capacity = 9 },
                    new Aircraft { AircraftId = 12, Name = "Boeing 767", Type = "Cargo", Capacity = 217 },
                    new Aircraft { AircraftId = 13, Name = "Lockheed C-130 Hercules", Type = "Cargo", Capacity = 64 },
                    new Aircraft { AircraftId = 14, Name = "Antonov An-225", Type = "Cargo", Capacity = 640 },
                    new Aircraft { AircraftId = 15, Name = "Airbus Beluga", Type = "Cargo", Capacity = 47 }
            );

            modelBuilder.Entity<Flight>().HasData(
    new Flight { FlightId = 1, FlightPrice = 150.75, TakeOff = DateTime.Parse(DateTime.Now.AddHours(1).ToShortTimeString()), TerminalId = 5, PassengerTotal = 180, PassengerCount = 0, DepartureAirportId = 1000, DepartureAirport = "LAX", ArrivalAirportId = 1001, ArrivalAirport = "SEA", AircraftId = 1 },
    new Flight { FlightId = 2, FlightPrice = 220.50, TakeOff = DateTime.Parse(DateTime.Now.AddHours(2).ToShortTimeString()), TerminalId = 4, PassengerTotal = 150, PassengerCount = 0, DepartureAirportId = 1001, DepartureAirport = "SEA", ArrivalAirportId = 1004, ArrivalAirport = "JFK", AircraftId = 2 },
    new Flight { FlightId = 3, FlightPrice = 180.30, TakeOff = DateTime.Parse(DateTime.Now.AddHours(3).ToShortTimeString()), TerminalId = 2, PassengerTotal = 90, PassengerCount = 0, DepartureAirportId = 1002, DepartureAirport = "LNK", ArrivalAirportId = 1003, ArrivalAirport = "OMA", AircraftId = 3 },
    new Flight { FlightId = 4, FlightPrice = 175.00, TakeOff = DateTime.Parse(DateTime.Now.AddHours(4).ToShortTimeString()), TerminalId = 11, PassengerTotal = 200, PassengerCount = 0, DepartureAirportId = 1000, DepartureAirport = "LAX", ArrivalAirportId = 1005, ArrivalAirport = "EWR", AircraftId = 4 },
    new Flight { FlightId = 5, FlightPrice = 450.00, TakeOff = DateTime.Parse(DateTime.Now.AddHours(5).ToShortTimeString()), TerminalId = 18, PassengerTotal = 555, PassengerCount = 0, DepartureAirportId = 1004, DepartureAirport = "JFK", ArrivalAirportId = 1001, ArrivalAirport = "SEA", AircraftId = 9 },
    new Flight { FlightId = 6, FlightPrice = 320.00, TakeOff = DateTime.Parse(DateTime.Now.AddHours(6).ToShortTimeString()), TerminalId = 19, PassengerTotal = 600, PassengerCount = 0, DepartureAirportId = 1006, DepartureAirport = "MIA", ArrivalAirportId = 1003, ArrivalAirport = "OMA", AircraftId = 5 },
    new Flight { FlightId = 7, FlightPrice = 180.50, TakeOff = DateTime.Parse(DateTime.Now.AddHours(7).ToShortTimeString()), TerminalId = 7, PassengerTotal = 242, PassengerCount = 0, DepartureAirportId = 1000, DepartureAirport = "LAX", ArrivalAirportId = 1004, ArrivalAirport = "JFK", AircraftId = 8 },
    new Flight { FlightId = 8, FlightPrice = 500.00, TakeOff = DateTime.Parse(DateTime.Now.AddHours(8).ToShortTimeString()), TerminalId = 16, PassengerTotal = 300, PassengerCount = 0, DepartureAirportId = 1005, DepartureAirport = "EWR", ArrivalAirportId = 1002, ArrivalAirport = "LNK", AircraftId = 7 },
    new Flight { FlightId = 9, FlightPrice = 140.00, TakeOff = DateTime.Parse(DateTime.Now.AddHours(9).ToShortTimeString()), TerminalId = 6, PassengerTotal = 200, PassengerCount = 0, DepartureAirportId = 1002, DepartureAirport = "LNK", ArrivalAirportId = 1001, ArrivalAirport = "SEA", AircraftId = 2 },
    new Flight { FlightId = 10, FlightPrice = 120.00, TakeOff = DateTime.Parse(DateTime.Now.AddHours(10).ToShortTimeString()), TerminalId = 12, PassengerTotal = 180, PassengerCount = 0, DepartureAirportId = 1000, DepartureAirport = "LAX", ArrivalAirportId = 1006, ArrivalAirport = "MIA", AircraftId = 3 },
    new Flight { FlightId = 11, FlightPrice = 270.50, TakeOff = DateTime.Parse(DateTime.Now.AddHours(11).ToShortTimeString()), TerminalId = 14, PassengerTotal = 76, PassengerCount = 0, DepartureAirportId = 1004, DepartureAirport = "JFK", ArrivalAirportId = 1007, ArrivalAirport = "IAD", AircraftId = 4 },
    new Flight { FlightId = 12, FlightPrice = 420.75, TakeOff = DateTime.Parse(DateTime.Now.AddHours(12).ToShortTimeString()), TerminalId = 9, PassengerTotal = 500, PassengerCount = 0, DepartureAirportId = 1000, DepartureAirport = "LAX", ArrivalAirportId = 1004, ArrivalAirport = "JFK", AircraftId = 10 },
    new Flight { FlightId = 13, FlightPrice = 600.00, TakeOff = DateTime.Parse(DateTime.Now.AddHours(13).ToShortTimeString()), TerminalId = 3, PassengerTotal = 300, PassengerCount = 0, DepartureAirportId = 1003, DepartureAirport = "OMA", ArrivalAirportId = 1001, ArrivalAirport = "SEA", AircraftId = 9 },
    new Flight { FlightId = 14, FlightPrice = 190.30, TakeOff = DateTime.Parse(DateTime.Now.AddHours(14).ToShortTimeString()), TerminalId = 15, PassengerTotal = 277, PassengerCount = 0, DepartureAirportId = 1004, DepartureAirport = "JFK", ArrivalAirportId = 1002, ArrivalAirport = "LNK", AircraftId = 6 },
    new Flight { FlightId = 15, FlightPrice = 210.00, TakeOff = DateTime.Parse(DateTime.Now.AddHours(15).ToShortTimeString()), TerminalId = 16, PassengerTotal = 555, PassengerCount = 0, DepartureAirportId = 1005, DepartureAirport = "EWR", ArrivalAirportId = 1000, ArrivalAirport = "LAX", AircraftId = 9 },
    new Flight { FlightId = 16, FlightPrice = 130.00, TakeOff = DateTime.Parse(DateTime.Now.AddHours(16).ToShortTimeString()), TerminalId = 9, PassengerTotal = 180, PassengerCount = 0, DepartureAirportId = 1000, DepartureAirport = "LAX", ArrivalAirportId = 1003, ArrivalAirport = "OMA", AircraftId = 11 },
    new Flight { FlightId = 17, FlightPrice = 210.50, TakeOff = DateTime.Parse(DateTime.Now.AddHours(17).ToShortTimeString()), TerminalId = 10, PassengerTotal = 90, PassengerCount = 0, DepartureAirportId = 1001, DepartureAirport = "SEA", ArrivalAirportId = 1006, ArrivalAirport = "MIA", AircraftId = 7 },
    new Flight { FlightId = 18, FlightPrice = 330.00, TakeOff = DateTime.Parse(DateTime.Now.AddHours(18).ToShortTimeString()), TerminalId = 20, PassengerTotal = 600, PassengerCount = 0, DepartureAirportId = 1006, DepartureAirport = "MIA", ArrivalAirportId = 1002, ArrivalAirport = "LNK", AircraftId = 13 },
    new Flight { FlightId = 19, FlightPrice = 280.25, TakeOff = DateTime.Parse(DateTime.Now.AddHours(19).ToShortTimeString()), TerminalId = 7, PassengerTotal = 242, PassengerCount = 0, DepartureAirportId = 1000, DepartureAirport = "LAX", ArrivalAirportId = 1004, ArrivalAirport = "JFK", AircraftId = 8 },
    new Flight { FlightId = 20, FlightPrice = 160.50, TakeOff = DateTime.Parse(DateTime.Now.AddHours(20).ToShortTimeString()), TerminalId = 13, PassengerTotal = 200, PassengerCount = 0, DepartureAirportId = 1004, DepartureAirport = "JFK", ArrivalAirportId = 1001, ArrivalAirport = "SEA", AircraftId = 15 }
);



        }
    }
}
