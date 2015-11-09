namespace Westerdals.Domain.Entities
{
    public class PlantReading
    {
        public double Temperature { get; set; }

        public double AirMoisture { get; set; }

        public double SoilMoisture{ get; set; }

        public static PlantReading Default {
            get
            {
                return new PlantReading
                {
                    AirMoisture = 0.0,
                    SoilMoisture = 0.0,
                    Temperature = -273
                };
            }
        }
    }
}
