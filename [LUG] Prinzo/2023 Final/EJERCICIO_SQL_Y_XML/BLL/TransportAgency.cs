using System;
using System.Collections.Generic;
using DAL;
using BEL;

namespace BLL
{
    public class TransportAgency : ITransportAgency
    {
        private IDataAccess dataAccess;

        public TransportAgency()
        {
            dataAccess = new SqlDataAccess(); // Implementación concreta de acceso a datos
        }

        public void AddVehicle(Vehicle vehicle)
        {
            dataAccess.AddVehicle(vehicle);
        }

        public void RemoveVehicle(Vehicle vehicle)
        {
            dataAccess.RemoveVehicle(vehicle);
        }

        public void AddClient(Client client)
        {
            dataAccess.AddClient(client);
        }

        public void RemoveClient(Client client)
        {
            dataAccess.RemoveClient(client);
        }

        public void RentVehicle(Client client, Vehicle vehicle, int days)
        {
            client.RentedVehicle = vehicle;
            client.RentalDays = days;
            dataAccess.RentVehicle(client, vehicle, days);
        }

        public void ReturnVehicle(Client client, Vehicle vehicle)
        {
            client.RentedVehicle = null;
            client.RentalDays = 0;
            dataAccess.ReturnVehicle(client, vehicle);
        }

        public List<Vehicle> GetMostRentedVehicles()
        {
            return dataAccess.GetMostRentedVehicles();
        }

        public List<Vehicle> GetLeastRentedVehicles()
        {
            return dataAccess.GetLeastRentedVehicles();
        }

        public decimal GetTotalRevenueByVehicleType(string vehicleType)
        {
            return dataAccess.GetTotalRevenueByVehicleType(vehicleType);
        }
    }
}
