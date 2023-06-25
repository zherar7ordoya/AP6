using System.Collections.Generic;

using BEL;

namespace DAL
{
    public class SqlDataAccess : IDataAccess
    {
        public void AddVehicle(Vehicle vehicle)
        {
            // Implementación para agregar un vehículo a la base de datos SQL Server
        }

        public void RemoveVehicle(Vehicle vehicle)
        {
            // Implementación para eliminar un vehículo de la base de datos SQL Server
        }

        public void AddClient(Client client)
        {
            // Implementación para agregar un cliente a la base de datos SQL Server
        }

        public void RemoveClient(Client client)
        {
            // Implementación para eliminar un cliente de la base de datos SQL Server
        }

        public void RentVehicle(Client client, Vehicle vehicle, int days)
        {
            // Implementación para registrar el alquiler de un vehículo por un cliente en la base de datos SQL Server
        }

        public void ReturnVehicle(Client client, Vehicle vehicle)
        {
            // Implementación para registrar la devolución de un vehículo por un cliente en la base de datos SQL Server
        }

        public List<Vehicle> GetMostRentedVehicles()
        {
            // Implementación para obtener los vehículos más alquilados de la base de datos SQL Server
            return new List<Vehicle>();
        }

        public List<Vehicle> GetLeastRentedVehicles()
        {
            // Implementación para obtener los vehículos menos alquilados de la base de datos SQL Server
            return new List<Vehicle>();
        }

        public decimal GetTotalRevenueByVehicleType(string vehicleType)
        {
            // Implementación para obtener el monto total recaudado por tipo de vehículo de la base de datos SQL Server
            return 0;
        }
    }
}
