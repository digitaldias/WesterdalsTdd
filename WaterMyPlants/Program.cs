using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Westerdals.Domain.Contracts;
using StructureMap;

namespace WaterMyPlants
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get Readings
            var runtimeRegistry      = new RuntimeRegistry();
            var iocContainer         = new Container(runtimeRegistry);
            var plantReadingsManager = iocContainer.GetInstance<IPlantReadingsManager>() ;

            // Grab some values
            var plantReading = plantReadingsManager.GetPlantReading();

            // Transmit the readings
            IValuesTransmitter valuesTransmitter = iocContainer.GetInstance<IValuesTransmitter>();
            valuesTransmitter.Transmit(plantReading);
        }
    }
}
