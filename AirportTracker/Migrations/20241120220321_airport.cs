using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirportTracker.Migrations
{
    public partial class airport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aircrafts",
                columns: table => new
                {
                    AircraftId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aircrafts", x => x.AircraftId);
                });

            migrationBuilder.CreateTable(
                name: "Airports",
                columns: table => new
                {
                    AirportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Shorthand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VideoURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airports", x => x.AirportId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    fName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    milage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    employed = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Terminals",
                columns: table => new
                {
                    TerminalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TerminalName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AirportId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terminals", x => x.TerminalId);
                    table.ForeignKey(
                        name: "FK_Terminals_Airports_AirportId",
                        column: x => x.AirportId,
                        principalTable: "Airports",
                        principalColumn: "AirportId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmpId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AirportId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmpId);
                    table.ForeignKey(
                        name: "FK_Employees_Airports_AirportId",
                        column: x => x.AirportId,
                        principalTable: "Airports",
                        principalColumn: "AirportId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    FlightId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightPrice = table.Column<double>(type: "float", nullable: false),
                    TakeOff = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PassengerTotal = table.Column<int>(type: "int", nullable: false),
                    PassengerCount = table.Column<int>(type: "int", nullable: true),
                    AirportId = table.Column<int>(type: "int", nullable: true),
                    DepartureAirportId = table.Column<int>(type: "int", nullable: false),
                    DepartureAirport = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArrivalAirportId = table.Column<int>(type: "int", nullable: false),
                    ArrivalAirport = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeEmpId = table.Column<int>(type: "int", nullable: true),
                    AircraftId = table.Column<int>(type: "int", nullable: false),
                    TerminalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.FlightId);
                    table.ForeignKey(
                        name: "FK_Flights_Aircrafts_AircraftId",
                        column: x => x.AircraftId,
                        principalTable: "Aircrafts",
                        principalColumn: "AircraftId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flights_Airports_AirportId",
                        column: x => x.AirportId,
                        principalTable: "Airports",
                        principalColumn: "AirportId");
                    table.ForeignKey(
                        name: "FK_Flights_Employees_EmployeeEmpId",
                        column: x => x.EmployeeEmpId,
                        principalTable: "Employees",
                        principalColumn: "EmpId");
                    table.ForeignKey(
                        name: "FK_Flights_Terminals_TerminalId",
                        column: x => x.TerminalId,
                        principalTable: "Terminals",
                        principalColumn: "TerminalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FlightId = table.Column<int>(type: "int", nullable: false),
                    NumberOfSeats = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_Bookings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "FlightId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Aircrafts",
                columns: new[] { "AircraftId", "Capacity", "Name", "Type" },
                values: new object[,]
                {
                    { 1, 190, "Boeing 737", "Commercial" },
                    { 2, 180, "Airbus A320", "Commercial" },
                    { 3, 90, "Bombardier CRJ900", "Regional" },
                    { 4, 76, "Embraer E175", "Regional" },
                    { 5, 600, "Boeing 747", "Cargo" },
                    { 6, 396, "Boeing 777", "Commercial" },
                    { 7, 277, "Airbus A330", "Commercial" },
                    { 8, 242, "Boeing 787", "Commercial" },
                    { 9, 555, "Airbus A380", "Commercial" },
                    { 10, 9, "Cessna 208", "Regional" },
                    { 11, 9, "Pilatus PC-12", "Regional" },
                    { 12, 217, "Boeing 767", "Cargo" },
                    { 13, 64, "Lockheed C-130 Hercules", "Cargo" },
                    { 14, 640, "Antonov An-225", "Cargo" },
                    { 15, 47, "Airbus Beluga", "Cargo" }
                });

            migrationBuilder.InsertData(
                table: "Airports",
                columns: new[] { "AirportId", "City", "Description", "FileName", "Name", "Shorthand", "State", "VideoURL" },
                values: new object[,]
                {
                    { 1000, "Los Angeles", "Los Angeles International Airport (LAX) is one of the busiest and most iconic airports in the world, serving as a major gateway to the United States and a hub for international travel. Located in Westchester, just 18 miles from downtown Los Angeles, it connects travelers to over 180 destinations worldwide. Known for its iconic Theme Building and futuristic design, LAX embodies the dynamic energy of Los Angeles. The airport is home to nine passenger terminals, including the state-of-the-art Tom Bradley International Terminal, which accommodates millions of passengers annually. With world-class dining, shopping, and efficient transit options, LAX offers a premier travel experience while reflecting the cultural diversity of Southern California.", null, "Los Angeles International Airport", "LAX", "California", "https://www.youtube.com/embed/yyVLqUCqWAw" },
                    { 1001, "Seattle", "Seattle-Tacoma International Airport (SEA), commonly known as Sea-Tac, is the primary airport serving the Seattle metropolitan area and the Pacific Northwest. Located about 14 miles south of downtown Seattle, it is a major hub for domestic and international travel, particularly to Asia and Alaska. Known for its stunning views of Mount Rainier and Puget Sound, the airport features modern amenities, including a wide range of dining and shopping options. Sea-Tac’s focus on sustainability is evident through initiatives like renewable energy use and eco-friendly terminal designs. With efficient public transit connections, such as the Link Light Rail, it offers convenient access for travelers while showcasing the region’s commitment to innovation and natural beauty.", null, "Seattle International Airport", "SEA", "Washington", "https://www.youtube.com/embed/9f9GJ-xSS3A" },
                    { 1002, "Lincoln", "Lincoln Airport (LNK) is a regional airport located in Lincoln, Nebraska, serving as a vital gateway to the city and surrounding areas. Situated about five miles northwest of downtown Lincoln, it provides convenient access for both business and leisure travelers. The airport offers a selection of domestic flights, with connections to major hubs, making it easy to reach destinations across the country. Known for its friendly atmosphere and efficient operations, Lincoln Airport ensures a smooth travel experience without the congestion of larger airports. With its modern facilities and focus on customer service, LNK is a valuable resource for the growing Lincoln community.", null, "Lincoln Airport", "LNK", "Nebraska", "https://www.youtube.com/embed/3w7EiX92W_E" },
                    { 1003, "Omaha", "Eppley Airfield (OMA) is the largest airport in Nebraska, located just three miles northeast of downtown Omaha. As a key transportation hub for the region, it offers a range of domestic flights with connections to major cities across the United States. Known for its efficient layout and welcoming atmosphere, the airport provides a stress-free travel experience for passengers. Eppley Airfield features modern amenities, including dining and shopping options, and is equipped with services to accommodate both business and leisure travelers. Its central location and commitment to customer satisfaction make it an essential gateway to Omaha and the surrounding Midwest.", null, "Eppley Airfield", "OMA", "Nebraska", "https://www.youtube.com/embed/lHIJl2K4AW4" },
                    { 1004, "New York City", "John F. Kennedy International Airport (JFK) is one of the busiest and most iconic airports in the world, located in Queens, New York City. Serving as a major international gateway to the United States, it offers flights to destinations across six continents. JFK features six passenger terminals, each equipped with world-class amenities, including renowned dining and shopping options that reflect the city’s diverse culture. Known for its historical significance and modern advancements, the airport is a hub for major airlines and a center for global travel. With its extensive transportation links, including the AirTrain and subway, JFK provides seamless connectivity to New York City and beyond.", null, "John F. Kennedy International Airport", "JFK", "New York", "https://www.youtube.com/embed/VeYVasEaBC0" },
                    { 1005, "Newark", "Newark Liberty International Airport (EWR) is a major airport serving the New York metropolitan area, located in Newark, New Jersey, just 16 miles southwest of Manhattan. Known for being one of the busiest airports in the United States, it offers a wide range of domestic and international flights, connecting travelers to destinations around the globe. The airport features three terminals with modern amenities, including dining, shopping, and lounges to enhance the passenger experience. As a hub for United Airlines, EWR plays a significant role in global aviation while providing easy access to New York City via NJ Transit and the AirTrain. Its combination of convenience, efficiency, and history makes it a vital gateway to the Northeast.", null, "Newark Liberty International Airport", "EWR", "New Jersey", "https://www.youtube.com/embed/nGkNDVtRMDM" },
                    { 1006, "Miami", "Miami International Airport (MIA) is a major international gateway located just 8 miles west of downtown Miami, Florida. Serving as a key hub for travel between the United States, Latin America, and the Caribbean, it is one of the busiest airports in the world for international passenger traffic. MIA features a wide array of amenities, including luxury shopping, dining, and art installations that highlight the city’s vibrant culture. The airport's modern terminals handle millions of passengers annually, offering efficient services for both business and leisure travelers. With its close proximity to popular destinations like South Beach and the Florida Keys, Miami International Airport serves as an essential hub for tourism and global commerce.", null, "Miami International Airport", "MIA", "Florida", "https://www.youtube.com/embed/gnxvQ7atPMk" },
                    { 1007, "Dulles", "Washington Dulles International Airport (IAD) is a major international airport located 26 miles west of downtown Washington, D.C., in Virginia. Serving as a key hub for international and domestic travel, it offers connections to over 125 destinations across the globe. Known for its striking design by architect Eero Saarinen, including the iconic terminal building, Dulles features modern facilities and amenities for a seamless travel experience. The airport is a primary hub for United Airlines and handles millions of passengers annually, with services including dining, shopping, and lounges. With its convenient transportation options, including the Silver Line Metro connection, IAD offers easy access to the capital and beyond.", null, "Washington Dulles International Airport", "IAD", "Virginia", "https://www.youtube.com/embed/4w-xPi_Dne0" }
                });

            migrationBuilder.InsertData(
                table: "Terminals",
                columns: new[] { "TerminalId", "AirportId", "TerminalName" },
                values: new object[,]
                {
                    { 1, 1003, "B12" },
                    { 2, 1002, "B12" },
                    { 3, 1003, "B13" },
                    { 4, 1003, "B15" },
                    { 5, 1002, "A12" },
                    { 6, 1002, "A16" },
                    { 7, 1000, "C13" },
                    { 8, 1000, "C16" },
                    { 9, 1000, "C21" },
                    { 10, 1001, "D14" },
                    { 11, 1001, "D16" },
                    { 12, 1000, "D22" },
                    { 13, 1004, "E10" },
                    { 14, 1004, "E11" },
                    { 15, 1004, "E15" },
                    { 16, 1005, "F24" },
                    { 17, 1005, "F14" },
                    { 18, 1005, "F09" },
                    { 19, 1006, "G23" },
                    { 20, 1006, "G17" },
                    { 21, 1006, "G19" }
                });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "FlightId", "AircraftId", "AirportId", "ArrivalAirport", "ArrivalAirportId", "DepartureAirport", "DepartureAirportId", "EmployeeEmpId", "FlightPrice", "PassengerCount", "PassengerTotal", "TakeOff", "TerminalId" },
                values: new object[,]
                {
                    { 1, 1, null, "SEA", 1001, "LAX", 1000, null, 150.75, 0, 180, new DateTime(2024, 11, 20, 17, 3, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 2, 2, null, "JFK", 1004, "SEA", 1001, null, 220.5, 0, 150, new DateTime(2024, 11, 20, 18, 3, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 3, 3, null, "OMA", 1003, "LNK", 1002, null, 180.30000000000001, 0, 90, new DateTime(2024, 11, 20, 19, 3, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 4, 4, null, "EWR", 1005, "LAX", 1000, null, 175.0, 0, 200, new DateTime(2024, 11, 20, 20, 3, 0, 0, DateTimeKind.Unspecified), 11 },
                    { 5, 9, null, "SEA", 1001, "JFK", 1004, null, 450.0, 0, 555, new DateTime(2024, 11, 20, 21, 3, 0, 0, DateTimeKind.Unspecified), 18 },
                    { 6, 5, null, "OMA", 1003, "MIA", 1006, null, 320.0, 0, 600, new DateTime(2024, 11, 20, 22, 3, 0, 0, DateTimeKind.Unspecified), 19 },
                    { 7, 8, null, "JFK", 1004, "LAX", 1000, null, 180.5, 0, 242, new DateTime(2024, 11, 20, 23, 3, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 8, 7, null, "LNK", 1002, "EWR", 1005, null, 500.0, 0, 300, new DateTime(2024, 11, 20, 0, 3, 0, 0, DateTimeKind.Unspecified), 16 },
                    { 9, 2, null, "SEA", 1001, "LNK", 1002, null, 140.0, 0, 200, new DateTime(2024, 11, 20, 1, 3, 0, 0, DateTimeKind.Unspecified), 6 },
                    { 10, 3, null, "MIA", 1006, "LAX", 1000, null, 120.0, 0, 180, new DateTime(2024, 11, 20, 2, 3, 0, 0, DateTimeKind.Unspecified), 12 },
                    { 11, 4, null, "IAD", 1007, "JFK", 1004, null, 270.5, 0, 76, new DateTime(2024, 11, 20, 3, 3, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 12, 10, null, "JFK", 1004, "LAX", 1000, null, 420.75, 0, 500, new DateTime(2024, 11, 20, 4, 3, 0, 0, DateTimeKind.Unspecified), 9 },
                    { 13, 9, null, "SEA", 1001, "OMA", 1003, null, 600.0, 0, 300, new DateTime(2024, 11, 20, 5, 3, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 14, 6, null, "LNK", 1002, "JFK", 1004, null, 190.30000000000001, 0, 277, new DateTime(2024, 11, 20, 6, 3, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 15, 9, null, "LAX", 1000, "EWR", 1005, null, 210.0, 0, 555, new DateTime(2024, 11, 20, 7, 3, 0, 0, DateTimeKind.Unspecified), 16 },
                    { 16, 11, null, "OMA", 1003, "LAX", 1000, null, 130.0, 0, 180, new DateTime(2024, 11, 20, 8, 3, 0, 0, DateTimeKind.Unspecified), 9 },
                    { 17, 7, null, "MIA", 1006, "SEA", 1001, null, 210.5, 0, 90, new DateTime(2024, 11, 20, 9, 3, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 18, 13, null, "LNK", 1002, "MIA", 1006, null, 330.0, 0, 600, new DateTime(2024, 11, 20, 10, 3, 0, 0, DateTimeKind.Unspecified), 20 },
                    { 19, 8, null, "JFK", 1004, "LAX", 1000, null, 280.25, 0, 242, new DateTime(2024, 11, 20, 11, 3, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 20, 15, null, "SEA", 1001, "JFK", 1004, null, 160.5, 0, 200, new DateTime(2024, 11, 20, 12, 3, 0, 0, DateTimeKind.Unspecified), 13 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_FlightId",
                table: "Bookings",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserId",
                table: "Bookings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_AirportId",
                table: "Employees",
                column: "AirportId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserId",
                table: "Employees",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_AircraftId",
                table: "Flights",
                column: "AircraftId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_AirportId",
                table: "Flights",
                column: "AirportId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_EmployeeEmpId",
                table: "Flights",
                column: "EmployeeEmpId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_TerminalId",
                table: "Flights",
                column: "TerminalId");

            migrationBuilder.CreateIndex(
                name: "IX_Terminals_AirportId",
                table: "Terminals",
                column: "AirportId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Aircrafts");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Terminals");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Airports");
        }
    }
}
