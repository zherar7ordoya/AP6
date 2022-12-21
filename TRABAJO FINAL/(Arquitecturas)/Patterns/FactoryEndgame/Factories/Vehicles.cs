﻿namespace FactoryEndgame.Factories;

public interface IVehicle
{
    string VehicleType { get; set; }

    string Start();
}

public class Car : IVehicle
{
    public string VehicleType { get; set; } = "Car";

    public string Start()
    {
        return "Car started";
    }
}


public class Truck : IVehicle
{
    public string VehicleType { get; set; } = "Truck";

    public string Start()
    {
        return "Truck started";
    }
}


public class Van : IVehicle
{
    public string VehicleType { get; set; } = "Van";

    public string Start()
    {
        return "Van started";
    }
}
