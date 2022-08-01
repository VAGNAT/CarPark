using CarPark;

Car sportCar = new SportCar(18, 75, 30, 200);
Car passengerCar = new PassengerCar(8, 65, 40, 90, 3);
Car truck = new Truck(25, 400, 240, 80, 1250);

Console.WriteLine($"Passenger: ");
Console.WriteLine($"\tPower reserve: {passengerCar.GetPowerReserve()}");
Console.WriteLine($"\tPower reserve depending on the load: {passengerCar.GetPowerReserveDependingOnTheLoad()}");
Console.WriteLine($"\tTravel time: {passengerCar.GetTravelTime(20,100)}");
Console.WriteLine(new String('-', 80));

Console.WriteLine($"Sport: ");
Console.WriteLine($"\tPower reserve: {sportCar.GetPowerReserve()}");
Console.WriteLine($"\tPower reserve depending on the load: {sportCar.GetPowerReserveDependingOnTheLoad()}");
Console.WriteLine($"\tTravel time: {sportCar.GetTravelTime(20, 100)}");
Console.WriteLine(new String('-', 80));

Console.WriteLine($"Truck: ");
Console.WriteLine($"\tPower reserve: {truck.GetPowerReserve()}");
Console.WriteLine($"\tPower reserve depending on the load: {truck.GetPowerReserveDependingOnTheLoad()}");
Console.WriteLine($"\tTravel time: {truck.GetTravelTime(20, 100)}");
Console.WriteLine(new String('-', 80));