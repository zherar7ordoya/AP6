﻿using System;

namespace Step2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BLL_Employee BLL_EMPLOYEE = new BLL_Employee();
            BEL_Employee BEL_EMPLOYEE = BLL_EMPLOYEE.GetEmployeeDetails(1);

            Console.WriteLine();

            Console.WriteLine("Employee Details:");
            Console.WriteLine("ID: {0}, Name: {1}, Department: {2}, Salary: {3}",
                BEL_EMPLOYEE.ID,
                BEL_EMPLOYEE.Name,
                BEL_EMPLOYEE.Department,
                BEL_EMPLOYEE.Salary);
            Console.ReadKey();
        }
    }
}
