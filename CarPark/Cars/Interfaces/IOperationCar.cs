using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark
{
    internal interface IOperationCar
    {
        int GetPowerReserve();
        int GetPowerReserveDependingOnTheLoad();
        double GetTravelTime(uint fuelQuantity, double distance);
    }
}
