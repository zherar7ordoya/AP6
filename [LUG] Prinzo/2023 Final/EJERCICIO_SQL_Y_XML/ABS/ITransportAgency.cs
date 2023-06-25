using System;
using System.Collections.Generic;

namespace ABS
{
    public interface ITransportAgency
    {
        void AddVehicle(Vehicle vehicle);
        void RemoveVehicle(Vehicle vehicle);
        void AddClient(Client client);
        void RemoveClient(Client client);
        void RentVehicle(Client client, Vehicle vehicle, int days);
        void ReturnVehicle(Client client, Vehicle vehicle);
        List<Vehicle> GetMostRentedVehicles();
        List<Vehicle> GetLeastRentedVehicles();
        decimal GetTotalRevenueByVehicleType(string vehicleType);
    }
}
