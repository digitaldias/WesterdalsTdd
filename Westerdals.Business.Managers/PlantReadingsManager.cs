using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Westerdals.Domain.Contracts;
using Westerdals.Domain.Entities;

namespace Westerdals.Business.Managers
{
    public class PlantReadingsManager : IPlantReadingsManager
    {
        private readonly IExceptionHandler _exceptionHandler;
        private readonly IPlantReadingsVerifier _plantReadingsVerifier;
        private readonly ISensorReader _sensorReader;

        public PlantReadingsManager(ISensorReader sensorReader, IExceptionHandler exceptionHandler, IPlantReadingsVerifier plantReadingsVerifier)
        {
            _sensorReader = sensorReader;
            _exceptionHandler = exceptionHandler;
            _plantReadingsVerifier = plantReadingsVerifier;
        }


        public PlantReading GetPlantReading()
        {
            var reading = _exceptionHandler.GetFromUnsafeMethod(() =>  _sensorReader.GetSensorData());

            if (reading == null)
                return PlantReading.Default;

            if(_plantReadingsVerifier.IsValid(reading))
                return PlantReading.Default;

            return reading;
        }
    }
}
