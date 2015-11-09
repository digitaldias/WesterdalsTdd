using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Westerdals.Business.Managers;
using Westerdals.Data.Azure;
using Westerdals.Data.Fakes;
using Westerdals.Data.Sensors;
using Westerdals.Domain.Contracts;

namespace WaterMyPlants
{
    public class RuntimeRegistry : Registry
    {
        public RuntimeRegistry()
        {
            For<ILogger>().Use<FakeLogger>();

            Scan(x =>
            {
                x.AssemblyContainingType<IPlantReadingsManager>(); // Tar med seg alt i Westerdals.Domain.dll
                x.AssemblyContainingType<PlantReadingsManager>();   // Tar med seg alt i Westerdals.Business.Managers.dll
                x.AssemblyContainingType<SensorReader>();           // Tar med seg alt i Westerdals.Data.Sensors.dll
                x.AssemblyContainingType<AzureTableConnector>();    // Tar med seg alt i Westerdals.Data.Azure.dll
                x.AssemblyContainingType<FakeLogger>();             // Tar med seg alt i Westerdals.Data.Fakes.dll

                x.WithDefaultConventions(); // Match Ixxx mot klasse xxx
            });

            For<IConnector>().Use<AzureTableConnector>();

        }
    }
}
