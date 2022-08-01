using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark
{
    public class Truck : Car
    {
        private const int MAXLOAD = 1800;
        private const int POWERRESERVEREDUCTIONPERCENTAGE = 4;
        private const int REDUCTIONAMOUNT = 200;
        public double LoadMass { get; init; }
        public Truck(double averageFuel, uint fuelTankVolume, uint fuelQuantityInTank, uint speed, double loadMass) : base(averageFuel, fuelTankVolume, fuelQuantityInTank, speed)
        {
            if (loadMass > MAXLOAD)
            {
                throw new ArgumentNullException(nameof(loadMass), "The load mass cannot be greater than max load");
            }
            if (loadMass<0)
            {
                throw new ArgumentNullException(nameof(loadMass), "The load mass cannot be less than zero");
            }
            TypeCar = TypeCar.Truck;
            LoadMass = loadMass;
            PowerReserveReductionPercentage = POWERRESERVEREDUCTIONPERCENTAGE;
        }

        public override int GetPowerReserveDependingOnTheLoad()
        {            
            return CalculatePowerReserveWithTheLoad(LoadMass / REDUCTIONAMOUNT);
        }
    }
}
