using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Westerdals.Domain.Contracts;
using Westerdals.Domain.Entities;

namespace Westerdals.Business.Managers
{
    public class ValuesTransmitter : IValuesTransmitter
    {
        private readonly IConnector _connector;
        private readonly IExceptionHandler _exceptionHandler;

        public ValuesTransmitter(IConnector connector, IExceptionHandler exceptionHandler)
        {
            _connector = connector;
            _exceptionHandler = exceptionHandler;
        }

        public void Transmit(PlantReading plantReading)
        {
            _exceptionHandler
                .RunUnsafeMethod(() => _connector.AddToTable(plantReading));
        }
    }
}
