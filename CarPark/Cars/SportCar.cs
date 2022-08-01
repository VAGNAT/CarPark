using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark
{
    public class SportCar : Car
    {        
        public SportCar(double averageFuel, uint fuelTankVolume, uint fuelQuantityInTank, uint speed) : base(averageFuel, fuelTankVolume, fuelQuantityInTank, speed)
        {
            TypeCar = TypeCar.Sport;
        }

        public override int GetPowerReserveDependingOnTheLoad()
        {
            return GetPowerReserve();
        }
    }
}
